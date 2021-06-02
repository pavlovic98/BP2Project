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
    public class PlayerCentarViewModel : BindableBase
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


        private string centar;

        public string Centar
        {
            get { return centar; }
            set
            {
                if (value != centar)
                {
                    centar = value;
                    OnPropertyChanged("Centar");
                }
            }
        }


        private PlayerCenter selectedPlayerCenter;

        public PlayerCenter SelectedPlayerCenter
        {
            get { return selectedPlayerCenter; }
            set
            {
                if (value != selectedPlayerCenter)
                {
                    Player = null;
                    Centar = null;
                    selectedPlayerCenter = value;
                    OnPropertyChanged("SelectedLicense");
                }
            }
        }

        private ObservableCollection<PlayerCenter> playerCenters;

        public ObservableCollection<PlayerCenter> PlayerCenters
        {
            get { return playerCenters; }
            set
            {
                if (value != playerCenters)
                {
                    playerCenters = value;
                    OnPropertyChanged("PlayerCenters");
                }
            }
        }

        public ObservableCollection<string> Players { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Centars { get; set; } = new ObservableCollection<string>();

        public PlayerCentarViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            ShowCommand = new MyICommand(OnShow);

            foreach (var item in DataRepository.Instance.GetPlayers())
            {
                Players.Add(item.Id + " " + item.FirstName+" "+item.LastName);
            }
            foreach (var item in DataRepository.Instance.GetFacilities())
            {
                if (item is MedicalCenter)
                {
                    Centars.Add(item.Id + " " + item.Name);
                }
            }
            GetData();
        }

        private void GetData()
        {
            PlayerCenters = new ObservableCollection<PlayerCenter>(DataRepository.Instance.GetPlayerCenters());
        }
        private bool Validate()
        {
            bool retVal = true;
            if(Player == null || Centar == null)
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
                    PlayerCenter pc = new PlayerCenter();
                    Player p = DataRepository.Instance.GetPlayer(Int32.Parse(Player.Split(' ')[0]));
                    MedicalCenter mc = (MedicalCenter)DataRepository.Instance.GetFacility(Int32.Parse(Centar.Split(' ')[0]));
                    pc.Player = p;
                    pc.MedicalCenter = mc;
                    if (DataRepository.Instance.AddPlayerCenter(pc))
                    {
                        GetData();
                        Player = null;
                        Centar = null;
                        Box.Visibility = System.Windows.Visibility.Hidden;
                        Btn.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Already exist", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    IsEdit = false;
                    Player p = DataRepository.Instance.GetPlayer(Int32.Parse(Player.Split(' ')[0]));
                    MedicalCenter mc = (MedicalCenter)DataRepository.Instance.GetFacility(Int32.Parse(Centar.Split(' ')[0]));
                    SelectedPlayerCenter.Player = p;
                    SelectedPlayerCenter.MedicalCenter = mc;

                    if (DataRepository.Instance.EditPlayerCenter(SelectedPlayerCenter))
                    {
                        GetData();
                        Player = null;
                        Centar = null;
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
            Player = null;
            Centar = null;

            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
            Player = SelectedPlayerCenter.Player.Id + " " + SelectedPlayerCenter.Player.FirstName + " " + SelectedPlayerCenter.Player.LastName;
            Centar = SelectedPlayerCenter.MedicalCenter.Id + " " + SelectedPlayerCenter.MedicalCenter.Name;

        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    DataRepository.Instance.DeletePlayerCenter(SelectedPlayerCenter.Id);
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
