using DataBase;
using NetworkService;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Baze_projekat.ViewModels
{
    public class ClubLeagueViewModel : BindableBase
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


        private ClubLeague selectedClubLeague;

        public ClubLeague SelectedClubLeague
        {
            get { return selectedClubLeague; }
            set
            {
                if (value != selectedClubLeague)
                {
                    Club = null;
                    League = null;
                    selectedClubLeague = value;
                    OnPropertyChanged("SelectedClubLeague");
                }
            }
        }

        private ObservableCollection<ClubLeague> clubLeagues;

        public ObservableCollection<ClubLeague> ClubLeagues
        {
            get { return clubLeagues; }
            set
            {
                if (value != clubLeagues)
                {
                    clubLeagues = value;
                    OnPropertyChanged("ClubLeagues");
                }
            }
        }

        public ObservableCollection<string> Clubs { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Leagues { get; set; } = new ObservableCollection<string>();

        public ClubLeagueViewModel()
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
            ClubLeagues = new ObservableCollection<ClubLeague>(DataRepository.Instance.GetClubLeagues());
        }

        private void OnAdd()
        {
            if (!IsEdit)
            {
                ClubLeague l = new ClubLeague();
                League league = DataRepository.Instance.GetLeague(Int32.Parse(League.Split(' ')[0]));
                BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(Club.Split(' ')[0]));
                l.BasketballClub = bc;
                l.League = league;
               
                if (DataRepository.Instance.AddClubLeague(l))
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

                SelectedClubLeague.BasketballClub = bc;
                SelectedClubLeague.League = league;
                

                if (DataRepository.Instance.EditClubLeague(SelectedClubLeague))
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
            Club = SelectedClubLeague.BasketballClub.Id + " " + SelectedClubLeague.BasketballClub.Name;
            League = SelectedClubLeague.League.Id + " " + SelectedClubLeague.League.Name;
        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                DataRepository.Instance.DeleteClubLeague(SelectedClubLeague.Id);
                GetData();
                SelectedClubLeague = null;
            }
        }
        private void OnShow()
        {
            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
