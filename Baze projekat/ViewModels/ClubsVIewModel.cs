using NetworkService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Repository;
using System.Windows;
using System.Windows.Controls;

namespace Baze_projekat.ViewModels
{
    public class ClubsViewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;
        private string name="";

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string supperior = "";

        public string Supperior
        {
            get { return supperior; }
            set
            {
                if (value != supperior)
                {
                    supperior  = value;
                    OnPropertyChanged("Supperior");
                }
            }
        }



        private ObservableCollection<BasketballClub> clubs;
        public ObservableCollection<BasketballClub> Clubs
        {
            get
            {
                return clubs;
            }
            set
            {
                if (clubs != value)
                {
                    clubs = value;
                    OnPropertyChanged("Clubs");
                }
            }
        }

        private BasketballClub selectedClub;

        public BasketballClub SelectedCLub
        {
            get { return selectedClub; }
            set {
                
                selectedClub = value;
                Name = "";
                Supperior = null;
            }
        }

        public ObservableCollection<string> Supperiors { get; set; } = new ObservableCollection<string>();

        public ClubsViewModel()
        {
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            AddCommand = new MyICommand(OnAdd);
            ShowCommand = new MyICommand(OnShow);
            clubs = new ObservableCollection<BasketballClub>();
            GetData();

        }
        private void OnShow()
        {
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
        }
        private void GetData()
        {

            Clubs = new ObservableCollection<BasketballClub>(DataRepository.Instance.GetClubs());
            Supperiors.Clear();
            foreach (var item in Clubs)
            {
                Supperiors.Add(item.Id+" "+item.Name);
            }
        }

        private void OnEdit()
        {
            IsEdit = true;
            Name = "";
            Supperior = null;
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
            var club = DataRepository.Instance.GetClub(selectedClub.Id);

            Name = club.Name;
            if(club.SupperiorClub != null)
            {
                Supperior = club.SupperiorClub.Id + " " + club.SupperiorClub.Name;
            }

        }

        private void OnDelete()
        {
            MessageBoxResult res =  MessageBox.Show("Do you want to delete item","Info",MessageBoxButton.YesNo,MessageBoxImage.Question); 
            if(res == MessageBoxResult.Yes)
            {
                try
                {
                    DataRepository.Instance.DeleteCLub(selectedClub.Id);
                    selectedClub = null;
                    GetData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to delete","Info",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                
            }
        }
        private bool Validate()
        {
            bool retVal = true;
            if(Name == "")
            {
                retVal = false;
            }
            if(Supperior != null && Supperior != "")
            {
                var c = DataRepository.Instance.GetClub(Int32.Parse(supperior.Split(' ')[0]));
                if (c == null)
                {
                    retVal = false;   
                }
            }
            return retVal;
        }
        private void OnAdd()
        {
            if (Validate())
            {
                if (!IsEdit)
                {
                    BasketballClub club = new BasketballClub()
                    {
                        Name = Name
                    };
                    if (supperior != "" && supperior != null)
                    {
                        var c = DataRepository.Instance.GetClub(Int32.Parse(supperior.Split(' ')[0]));
                        if (c != null)
                        {
                            club.SupperiorClub = c;
                        }
                    }
                    if (DataRepository.Instance.AddClub(club))
                    {
                        GetData();
                        Name = "";
                        Supperior = null;
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Name is taken", "INFO", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    IsEdit = false;
                    SelectedCLub.Name = Name;
                    if (supperior != null && Supperior != "")
                    {
                        SelectedCLub.SupperiorClub = DataRepository.Instance.GetClub(Int32.Parse(Supperior.Split(' ')[0]));
                    }
                    if (DataRepository.Instance.EditClub(SelectedCLub))
                    {

                        GetData();
                        Name = "";
                        Supperior = "";
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                        SelectedCLub = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong fields values","Info",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
