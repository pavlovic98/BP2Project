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
    public class MatchsVIewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;

        private ObservableCollection<Match> matches;

        public ObservableCollection<Match> Matches
        {
            get { return matches; }
            set
            {
                if (value != matches)
                {
                    matches = value;
                    OnPropertyChanged("Matches");
                }
            }
        }

        private Match match;

        public Match Match
        {
            get { return match; }
            set
            {
                if (match != value)
                {
                    Reset();
                    match = value;
                    OnPropertyChanged("Match");
                }
            }
        }

        private string arena;

        public string Arena
        {
            get { return arena; }
            set
            {
                if (value != arena)
                {
                    arena = value;
                    OnPropertyChanged("Arena");
                }
            }
        }

        public ObservableCollection<string> Arenas { get; set; } = new ObservableCollection<string>();
        private string host="";

        public string Host
        {
            get { return host; }
            set
            {
                if (value != host)
                {
                    host = value;
                    OnPropertyChanged("Host");
                }
            }
        }
        private string guest = "";

        public string Guest
        {
            get { return guest; }
            set
            {
                if (value != guest)
                {
                    guest = value;
                    OnPropertyChanged("Guest");
                }
            }
        }

        private string date="";

        public string Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private string result="";

        public string Result
        {
            get { return result; }
            set
            {
                if (value != result)
                {
                    result = value;
                    OnPropertyChanged("Result");
                }
            }
        }

        public ObservableCollection<string> GuestTeams { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> HostTeams { get; set; } = new ObservableCollection<string>();


        public MatchsVIewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            EditCommand = new MyICommand(OnEdit);
            ShowCommand = new MyICommand(OnShow);
            foreach (var item in DataRepository.Instance.GetClubs())
            {
                GuestTeams.Add(item.Name);
                HostTeams.Add(item.Name);
            }
            foreach (var item in DataRepository.Instance.GetFacilities())
            {
                if(item is Arena)
                {
                    Arenas.Add(item.Id+" "+item.Name);
                }
            }
            GetData();
            
        }
        private void GetData()
        {
            Matches = new ObservableCollection<Match>(DataRepository.Instance.GetMatches());
        }
        private void Reset()
        {
            
            Date = "";
            Result = "";
            Guest = null;
            Host = null;
            Arena = null;
        }


        private bool Validate()
        {
            bool retVal = true;
            if(Date == "" || Result == "" || Guest == null || Host == null || Arena == null)
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
                    Match match = new Match()
                    {
                        Result = Result,
                        Date = Date,
                        Host = Host,
                        Guest = Guest
                    };
                    var arena = DataRepository.Instance.GetFacility(Int32.Parse(Arena.Split(' ')[0]));
                    if (arena != null)
                    {
                        match.Arena = arena as Arena;
                    }
                    if (DataRepository.Instance.AddMatch(match))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    IsEdit = false;

                    Match.Date = Date;
                    Match.Host = Host;
                    Match.Guest = Guest;
                    Match.Result = Result;

                    if (Arena != null && Arena != "")
                    {
                        var arena = DataRepository.Instance.GetFacility(Int32.Parse(Arena.Split(' ')[0]));
                        if (arena != null)
                        {
                            match.Arena = arena as Arena;
                        }
                    }
                    if (DataRepository.Instance.EditMatch(Match))
                    {
                        Reset();
                        GetData();
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
                    DataRepository.Instance.DeleteMatch(Match.Id);
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
            IsEdit = true;
            Reset();
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;


            Host = Match.Host;
            Guest = Match.Guest;
            Result = Match.Result;
            Date = Match.Date;
            Arena = Match.Arena.Id + " " + Match.Arena.Name;
        }
    }
}
