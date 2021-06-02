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
    class PlayersPositionsViewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;

        private string player;

        public string Player
        {
            get { return player; }
            set
            {
                if (value != player)
                {
                    player = value;
                    OnPropertyChanged("Player");
                }
            }
        }


        private string position;

        public string Position
        {
            get { return position; }
            set 
            {
                if (value != position)
                {
                    position = value;
                    OnPropertyChanged("Position");
                }
            }
        }


        private PlayerPosition selectedPlayerPosition;

        public PlayerPosition SelectedPlayerPosition
        {
            get { return selectedPlayerPosition; }
            set 
            {
                if (value != selectedPlayerPosition)
                {
                    Player = null;
                    Position = null;
                    selectedPlayerPosition = value;
                    OnPropertyChanged("SelectedPlayerPosition");
                }
            }
        }

        private ObservableCollection<PlayerPosition> playerPositions;

        public ObservableCollection<PlayerPosition> PlayerPositions
        {
            get { return playerPositions; }
            set 
            {
                if (value != playerPositions)
                {
                    playerPositions = value;
                    OnPropertyChanged("PlayerPositions");
                }
            }
        }

        public ObservableCollection<string> Players { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Positions { get; set; } = new ObservableCollection<string>();

        public PlayersPositionsViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            ShowCommand = new MyICommand(OnShow);

            foreach (var item in DataRepository.Instance.GetPlayers())
            {
                Players.Add(item.Id+" "+item.FirstName+" "+item.LastName);
            }
            foreach (var item in DataRepository.Instance.GetPositions())
            {
                Positions.Add(item.Id+" "+item.Name);
            }
            GetData();
        }

        private void GetData()
        {
            PlayerPositions = new ObservableCollection<PlayerPosition>(DataRepository.Instance.GetPlayerPositions());
        }

        private void OnAdd()
        {
            if(!IsEdit)
            {
                PlayerPosition pp = new PlayerPosition();
                Player player = DataRepository.Instance.GetPlayer(Int32.Parse(Player.Split(' ')[0]));
                Position position = DataRepository.Instance.GetPosition(Int32.Parse(Position.Split(' ')[0]));
                pp.Player = player;
                pp.Position = position;
                if(DataRepository.Instance.AddPlayerPosition(pp))
                {
                    GetData();
                    Player = null;
                    Position = null;
                    Box.Visibility = System.Windows.Visibility.Hidden;
                    Btn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Already exist","Info",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                IsEdit = false;
                Player player = DataRepository.Instance.GetPlayer(Int32.Parse(Player.Split(' ')[0]));
                Position position = DataRepository.Instance.GetPosition(Int32.Parse(Position.Split(' ')[0]));
                SelectedPlayerPosition.Player = player;
                SelectedPlayerPosition.Position = position;
                if(DataRepository.Instance.EditPlayerPosition(SelectedPlayerPosition))
                {
                    GetData();
                    Player = null;
                    Position = null;
                    Box.Visibility = System.Windows.Visibility.Hidden;
                    Btn.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
        private void OnEdit()
        {
            IsEdit = true;
            Player = null;
            Position = null;

            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
            Player = SelectedPlayerPosition.Player.Id + " " + SelectedPlayerPosition.Player.FirstName + " " + SelectedPlayerPosition.Player.LastName;
            Position = SelectedPlayerPosition.Position.Id + " " + SelectedPlayerPosition.Position.Name;
        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                DataRepository.Instance.DeletePlayerPosition(SelectedPlayerPosition.Id);
                GetData();
                SelectedPlayerPosition = null;                
            }
        }
        private void OnShow()
        {
            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
