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
    public class LicenseViewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;

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


        private string league;

        public string League
        {
            get { return league; }
            set
            {
                if (value != league)
                {
                    league = value;
                    OnPropertyChanged("League");
                }
            }
        }


        private License selectedLicense;

        public License SelectedLicense
        {
            get { return selectedLicense; }
            set
            {
                if (value != selectedLicense)
                {
                    Club = null;
                    League = null;
                    selectedLicense = value;
                    OnPropertyChanged("SelectedLicense");
                }
            }
        }

        private ObservableCollection<License> licenses;

        public ObservableCollection<License> Licenses
        {
            get { return licenses; }
            set
            {
                if (value != licenses)
                {
                    licenses = value;
                    OnPropertyChanged("Licenses");
                }
            }
        }

        public ObservableCollection<string> Clubs { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Leagues { get; set; } = new ObservableCollection<string>();

        public LicenseViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            ShowCommand = new MyICommand(OnShow);

            foreach (var item in DataRepository.Instance.GetClubs())
            {
                Clubs.Add(item.Id + " " + item.Name);
            }
            foreach (var item in DataRepository.Instance.GetLeagues())
            {
                Leagues.Add(item.Id + " " + item.Name);
            }
            GetData();
        }

        private void GetData()
        {
            Licenses = new ObservableCollection<License>(DataRepository.Instance.GetLicenses());
        }

        private void OnAdd()
        {
            if (!IsEdit)
            {
                License l = new License();
                League league = DataRepository.Instance.GetLeague(Int32.Parse(League.Split(' ')[0]));
                BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(Club.Split(' ')[0]));
                l.BasketballClub = bc;
                l.League = league;
                l.NameOfTeam = bc.Name;
                l.NameOfLeague = league.Name;
                if (DataRepository.Instance.AddLicense(l))
                {
                    GetData();
                    Club = null;
                    League = null;
                    Box.Visibility = System.Windows.Visibility.Hidden;
                    Btn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Already exist","Info",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                IsEdit = false;
                League league = DataRepository.Instance.GetLeague(Int32.Parse(League.Split(' ')[0]));
                BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(Club.Split(' ')[0]));

                SelectedLicense.BasketballClub = bc;
                SelectedLicense.League = league;
                SelectedLicense.NameOfTeam = bc.Name;
                SelectedLicense.NameOfLeague = league.Name;
                
                if (DataRepository.Instance.EditLicense(SelectedLicense))
                {
                    GetData();
                    Club = null;
                    League = null;
                    Box.Visibility = System.Windows.Visibility.Hidden;
                    Btn.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
        private void OnEdit()
        {
            IsEdit = true;
            Club = null;
            League = null;

            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
            Club = SelectedLicense.BasketballClub.Id + " " + SelectedLicense.BasketballClub.Name;
            League = SelectedLicense.League.Id + " " + SelectedLicense.League.Name;
        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                DataRepository.Instance.DeleteLicense(SelectedLicense.Id);
                GetData();
                SelectedLicense = null;
            }
        }
        private void OnShow()
        {
            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
