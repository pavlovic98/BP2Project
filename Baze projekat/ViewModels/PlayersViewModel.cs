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
    public class PlayersViewModel : BindableBase
    {
        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand ShowCommand { get; set; }

        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;

        private string firstName="";

        public string FirstName
        {
            get { return firstName; }
            set 
            {
                if (value != firstName)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string lastName="";

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != lastName)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private string age="";

        public string Age
        {
            get { return age; }
            set
            {
                if (value != age)
                {
                    age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set 
            {
                if (value != salary)
                {
                    salary = value;
                    OnPropertyChanged("Salary");
                }
            }
        }

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


        private ObservableCollection<Player> players;
        public ObservableCollection<Player> Players
        {
            get
            {
                return players;
            }
            set
            {
                if (players != value)
                {
                    players = value;
                    OnPropertyChanged("Players");
                }
            }
        }

        private Player selectedPlayer;

        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set 
            {
                if (value != selectedPlayer)
                {
                    FirstName = "";
                    LastName = "";
                    Age = "";
                    Salary = 0;
                    Club = null;
                    
                    selectedPlayer = value;
                    OnPropertyChanged("SelectedPlayer");
                }
            }
        }

        public ObservableCollection<string> Clubs { get; set; } = new ObservableCollection<string>();


        public PlayersViewModel()
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
            Players = new ObservableCollection<Player>(DataRepository.Instance.GetPlayers());
        }
        private void Reset()
        {
            FirstName = "";
            LastName = "";
            Age = "";
            Salary = 0;
            club = null;
            SelectedPlayer = null;
        }

        private bool Validate()
        {
            bool retVal = true;
            if(FirstName=="" || LastName=="" || Age=="" || Salary == 0 || Club == null)
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
                    Player player = new Player()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Salary = salary
                    };
                    if (club != null)
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        if (bc != null)
                        {
                            player.BasketballClub = bc;
                        }
                    }
                    if (DataRepository.Instance.AddPlayer(player))
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
                    SelectedPlayer.FirstName = FirstName;
                    SelectedPlayer.LastName = LastName;
                    SelectedPlayer.Age = Age;
                    SelectedPlayer.Salary = Salary;
                    if (club != null && club != "")
                    {
                        SelectedPlayer.BasketballClub = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                    }
                    if (DataRepository.Instance.EditPlayer(SelectedPlayer))
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
                    DataRepository.Instance.DeletePlayer(selectedPlayer.Id);
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
            FirstName = "";
            LastName = "";
            Age = "";
            Salary = 0;
            Club = "";
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
            var player = DataRepository.Instance.GetPlayer(selectedPlayer.Id);

            FirstName = player.FirstName;
            LastName = player.LastName;
            Age = player.Age;
            Salary = player.Salary;
            FirstName = player.FirstName;
            if (player.BasketballClub != null)
            {
                Club = player.BasketballClub.Id + " " + player.BasketballClub.Name;
            }
        }
    }
}
