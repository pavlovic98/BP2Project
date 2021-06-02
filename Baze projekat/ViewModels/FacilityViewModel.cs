using DataBase;
using NetworkService;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Baze_projekat.ViewModels
{
    public class FacilityViewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public ComboBox Combo { get; set; }
        public Button Btn { get; set; }
        public Label lbl { get; set; }
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

        private string address="";

        public string Address
        {
            get { return address; }
            set 
            {
                if (value != address)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public ObservableCollection<string> Types { get; set; } = new ObservableCollection<string>()
        {
            "Shop",
            "Arena",
            "Medical center"
        };
        private string club;

        public string Club
        {
            get { return club; }
            set
            {
                if (value != club)
                {
                    club = value;
                    OnPropertyChanged("Club");
                }
            }
        }
        public ObservableCollection<string> Clubs { get; set; } = new ObservableCollection<string>();

        private string type;

        public string Type
        {
            get { return type; }
            set 
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        private ObservableCollection<Facility> facilities;

        public ObservableCollection<Facility> Facilities
        {
            get { return facilities; }
            set 
            {
                if (value != facilities)
                {
                    facilities = value;
                    OnPropertyChanged("Facilities");
                }
            }
        }

        private Facility selectedFacility;

        public Facility SelectedFacility
        {
            get { return selectedFacility; }
            set
            {
                if (value != selectedFacility)
                {
                    Reset();
                    selectedFacility = value;
                    OnPropertyChanged("SelectedFacility");
                }
            }
        }



        public FacilityViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            EditCommand = new MyICommand(OnEdit);
            ShowCommand = new MyICommand(OnShow);


            foreach (var item in DataRepository.Instance.GetClubs())
            {
                Clubs.Add(item.Id+" "+item.Name);
            }
            GetData();
        }
        private void GetData()
        {
            Facilities = new ObservableCollection<Facility>(DataRepository.Instance.GetFacilities());
        }
        private void Reset()
        {
            Name = "";
            Address = "";
            Type = null;
            Club = null;
        }        

        private bool Validate()
        {
            bool retVal = true;
            if(Name =="" || Address == "" || Type == null || Club == null)
            {
                retVal = false;
            }
            return retVal;
        }
        private void OnShow()
        {

            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden;
        }
        private void OnAdd()
        {
            if (Validate())
            {
                if (!IsEdit)
                {

                    if (Type == "Shop")
                    {
                        Shop s = new Shop()
                        {
                            Name = Name,
                            Address = Address,
                            Type = Type
                        };
                        if (club != null && club != "")
                        {
                            BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                            s.BasketballClub = bc;
                        }
                        if (DataRepository.Instance.AddFacility(s))
                        {
                            GetData();
                            Reset();
                            Box.Visibility = Visibility.Hidden;
                            Btn.Visibility = Visibility.Visible;
                        }
                    }
                    else if (type == "Arena")
                    {
                        Arena a = new Arena()
                        {
                            Name = Name,
                            Address = Address,
                            Type = Type,

                        };
                        if (club != null && club != "")
                        {
                            BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                            a.BasketballClub = bc;
                        }
                        if (DataRepository.Instance.AddFacility(a))
                        {
                            GetData();
                            Reset();
                            Box.Visibility = Visibility.Hidden;
                            Btn.Visibility = Visibility.Visible;
                        }


                    }
                    else if (Type == "Medical center")
                    {
                        MedicalCenter mc = new MedicalCenter()
                        {
                            Name = Name,
                            Address = Address,
                            Type = Type
                        };
                        if (club != null && club != "")
                        {
                            BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                            mc.BasketballClub = bc;
                        }
                        if (DataRepository.Instance.AddFacility(mc))
                        {
                            GetData();
                            Reset();
                            Box.Visibility = Visibility.Hidden;
                            Btn.Visibility = Visibility.Visible;
                        }
                    }

                }
                else
                {
                    IsEdit = false;
                    Combo.Visibility = Visibility.Visible;
                    lbl.Visibility = Visibility.Visible;
                    SelectedFacility.Name = Name;
                    SelectedFacility.Address = Address;
                    if (Club != null && Club != "")
                    {
                        var bc = DataRepository.Instance.GetClub(Int32.Parse(Club.Split(' ')[0]));
                        if (bc != null)
                        {
                            SelectedFacility.BasketballClub = bc;
                        }
                    }
                    if (DataRepository.Instance.EditFacility(SelectedFacility))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }

                }
            }
            else
            {

                MessageBox.Show("Wrong fields values", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    DataRepository.Instance.DeleteFacility(SelectedFacility.Id);
                    GetData();
                    Reset();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to delete", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void OnEdit()
        {
            Combo.Visibility = Visibility.Hidden;
            lbl.Visibility = Visibility.Hidden;
            IsEdit = true;
            Reset();
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
            var facility = DataRepository.Instance.GetFacility(SelectedFacility.Id);

            Name = facility.Name;
            Address = facility.Address;
            Type = facility.Type;
            Club = facility.BasketballClub.Id+" "+facility.BasketballClub.Name;
            
        }

    }
}
