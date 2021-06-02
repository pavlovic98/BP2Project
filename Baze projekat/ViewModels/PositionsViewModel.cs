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
    public class PositionsViewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;
        private string name;

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

        private ObservableCollection<Position> positions;
        public ObservableCollection<Position> Positions
        {
            get
            {
                return positions;
            }
            set
            {
                if (positions != value)
                {
                    positions = value;
                    OnPropertyChanged("Positions");
                }
            }
        }

        private Position selectedPosition;

        public Position SelectedPosition
        {
            get { return selectedPosition; }
            set
            {

                selectedPosition = value;
                Name = "";
            }
        }


        public PositionsViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            ShowCommand = new MyICommand(OnShow);
            GetData();
        }

        private void GetData()
        {
            Positions = new ObservableCollection<Position>(DataRepository.Instance.GetPositions());
        }
        private void OnAdd()
        {
            if(!IsEdit)
            {
                Position p = new Position()
                {
                    Name = Name
                };

                if(DataRepository.Instance.AddPosition(p))
                {
                    GetData();
                    Name = "";
                    Box.Visibility = System.Windows.Visibility.Hidden;
                    Btn.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Positions already exist!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                IsEdit = false;
                SelectedPosition.Name = Name;
                if(DataRepository.Instance.EditPosition(SelectedPosition))
                {
                    GetData();
                    Name = "";
                    Box.Visibility = System.Windows.Visibility.Hidden;
                    Btn.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
        private void OnEdit()
        {
            IsEdit = true;
            Name = "";
            Name = SelectedPosition.Name;
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;
        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                DataRepository.Instance.DeletePosition(selectedPosition.Id);
                GetData();
            }
        }
        private void OnShow()
        {
            Box.Visibility = System.Windows.Visibility.Visible;
            Btn.Visibility = System.Windows.Visibility.Hidden; 
        }
    }
}
