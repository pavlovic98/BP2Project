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
    public class LeagueViewModel : BindableBase
    {
        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
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

        private int number;

        public int Number
        {
            get { return number; }
            set 
            {
                if (value != number)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }


        private ObservableCollection<League> leagues;

        public ObservableCollection<League> Leagues
        {
            get { return leagues; }
            set 
            {
                if (value != leagues)
                {
                    leagues = value;
                    OnPropertyChanged("Leagues");
                }
            }
        }

        private League selectedLeague;

        public League SelectedLeague
        {
            get { return selectedLeague; }
            set
            {
                if (value != selectedLeague)
                {
                    Reset();
                    selectedLeague = value;
                    OnPropertyChanged("SelectedLeague");
                }
            }
        }



        public LeagueViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            ShowCommand = new MyICommand(OnShow);
            GetData();
        }

        private void GetData()
        {
            Leagues = new ObservableCollection<League>(DataRepository.Instance.GetLeagues());
        }
        private void Reset()
        {
            Name = "";
            Number = 0;
        }

        private bool Validate()
        {
            bool retVal = true;
            if(Name =="" || number == 0)
            {
                retVal = false;
            }
            return retVal;
        }
        private void OnAdd()
        {
            if (Validate())
            {
                if (!IsEdit)
                {
                    League l = new League()
                    {
                        Name = Name,
                        NumberOfClubs = Number
                    };
                    if (DataRepository.Instance.AddLeague(l))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = System.Windows.Visibility.Hidden;
                        Btn.Visibility = System.Windows.Visibility.Visible;
                    }
                }
                else
                {
                    IsEdit = false;
                    SelectedLeague.Name = Name;
                    SelectedLeague.NumberOfClubs = Number;
                    if (DataRepository.Instance.EditLeague(SelectedLeague))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = System.Windows.Visibility.Hidden;
                        Btn.Visibility = System.Windows.Visibility.Visible;
                    }
                }
            }
            else
            {

                MessageBox.Show("Wrong fields values", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnEdit()
        {
            IsEdit = true;
            Name = "";
            Number = 0;
            Name = SelectedLeague.Name;
            Number = SelectedLeague.NumberOfClubs;
            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden;

        }

        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    DataRepository.Instance.DeleteLeague(SelectedLeague.Id);
                    GetData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to delete", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void OnShow()
        {
            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden;
        }

    }
}
