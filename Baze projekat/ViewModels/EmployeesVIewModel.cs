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
    public class EmployeesVIewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public GroupBox Box { get; set; }
        public Button Btn { get; set; }
        private bool IsEdit = false;

        private string firstName;

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

        private string lastName;

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

        private string facility;

        public string Facility
        {
            get { return facility; }
            set
            {
                if (value != facility)
                {
                    facility = value;
                    OnPropertyChanged("Facility");
                }
            }
        }

        private ObservableCollection<string> facilities = new ObservableCollection<string>();

        public ObservableCollection<string> Facilities
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

        public ObservableCollection<string> Clubs { get; set; } = new ObservableCollection<string>();
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

        


        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set 
            {
                if (value != employees)
                {
                    employees = value;
                    OnPropertyChanged("Employees");
                }
            }
        }

        private Employee employee;

        public Employee Employee
        {
            get { return employee; }
            set 
            {
                if (value != employee)
                {
                    Reset();
                    employee = value;
                    OnPropertyChanged("Employee");
                }
            }
        }

        public ObservableCollection<string> Types { get; set; } = new ObservableCollection<string>()
        {
            "Economist",
            "Seller",
            "Medical staff"
        };

        private string type;

        public string Type
        {
            get { return type; }
            set 
            {
                if (value != type)
                {
                    type = value;
                    if(type == "Economist")
                    {
                        Facilities.Clear();
                        foreach (var item in DataRepository.Instance.GetFacilities())
                        {
                            if(item is Arena)
                                Facilities.Add(item.Id+" "+item.Name);
                        }
                    }
                    else if(type == "Seller")
                    {
                        Facilities.Clear();
                        foreach (var item in DataRepository.Instance.GetFacilities())
                        {
                            if (item is Shop)
                                Facilities.Add(item.Id + " " + item.Name);
                        }
                    }
                    else if(type == "Medical staff")
                    {
                        Facilities.Clear();
                        foreach (var item in DataRepository.Instance.GetFacilities())
                        {
                            if (item is MedicalCenter)
                                Facilities.Add(item.Id + " " + item.Name);
                        }
                    }
                    OnPropertyChanged("Type");
                }
            }
        }


        public EmployeesVIewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            EditCommand = new MyICommand(OnEdit);
            DeleteCommand = new MyICommand(OnDelete);
            ShowCommand = new MyICommand(OnShow);

            foreach (var item in DataRepository.Instance.GetClubs())
            {
                Clubs.Add(item.Id + " " + item.Name);
            }
            
            GetData();
        }
        private void Reset()
        {
            FirstName = "";
            LastName = "";
            Type = null;
            Club = null;
            Facility = null;
            Salary = 0;
        }
        private void GetData()
        {
            Employees = new ObservableCollection<Employee>(DataRepository.Instance.GetEmployees());
        }

        private void OnAdd()
        {
            if (!IsEdit)
            {
                if (Type == "Economist")
                {
                    Economist e = new Economist()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Salary = Salary,
                        Type = Type
                    };
                    if (club != null && club != "")
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        e.BasketballClub = bc;
                    }
                    if(facility != null && facility != "")
                    {
                        Arena f = (Arena)DataRepository.Instance.GetFacility(Int32.Parse(facility.Split(' ')[0]));
                        e.Arena = f;
                    }
                    if (DataRepository.Instance.AddEmployee(e))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                }
                else if(type == "Seller")
                {
                    Seller e = new Seller()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Salary = Salary,
                        Type = Type
                    };
                    if (club != null && club != "")
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        e.BasketballClub = bc;
                    }
                    if (facility != null && facility != "")
                    {
                        Shop f = (Shop)DataRepository.Instance.GetFacility(Int32.Parse(facility.Split(' ')[0]));
                        e.Shop = f;
                    }
                    if (DataRepository.Instance.AddEmployee(e))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                }
                else if(type == "Medical staff")
                {
                    MedicalStaff e = new MedicalStaff()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Salary = Salary,
                        Type = Type
                    };
                    if (club != null && club != "")
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        e.BasketballClub = bc;
                    }
                    if (facility != null && facility != "")
                    {
                        MedicalCenter f = (MedicalCenter)DataRepository.Instance.GetFacility(Int32.Parse(facility.Split(' ')[0]));
                        e.MedicalCenter = f;
                    }
                    if (DataRepository.Instance.AddEmployee(e))
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
                if (Type == "Economist")
                {
                    var emp = (Economist)Employee;
                    emp.FirstName = FirstName;
                    emp.LastName = FirstName;
                    emp.Salary = Salary;
                    
                    if (club != null && club != "")
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        emp.BasketballClub = bc;
                    }
                    if (facility != null && facility != "")
                    {
                        Arena f = (Arena)DataRepository.Instance.GetFacility(Int32.Parse(facility.Split(' ')[0]));
                        emp.Arena = f;
                    }
                    if (DataRepository.Instance.EditEmployee(emp))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                }
                else if (type == "Seller")
                {
                    var emp = (Seller)Employee;
                    emp.FirstName = FirstName;
                    emp.LastName = FirstName;
                    emp.Salary = Salary;

                    if (club != null && club != "")
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        emp.BasketballClub = bc;
                    }
                    if (facility != null && facility != "")
                    {
                        Shop f = (Shop)DataRepository.Instance.GetFacility(Int32.Parse(facility.Split(' ')[0]));
                        emp.Shop = f;
                    }
                    if (DataRepository.Instance.EditEmployee(emp))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                }
                else if (type == "Medical staff")
                {
                    var emp = (MedicalStaff)Employee;
                    emp.FirstName = FirstName;
                    emp.LastName = FirstName;
                    emp.Salary = Salary;

                    if (club != null && club != "")
                    {
                        BasketballClub bc = DataRepository.Instance.GetClub(Int32.Parse(club.Split(' ')[0]));
                        emp.BasketballClub = bc;
                    }
                    if (facility != null && facility != "")
                    {
                        MedicalCenter f = (MedicalCenter)DataRepository.Instance.GetFacility(Int32.Parse(facility.Split(' ')[0]));
                        emp.MedicalCenter = f;
                    }
                    if (DataRepository.Instance.EditEmployee(emp))
                    {
                        GetData();
                        Reset();
                        Box.Visibility = Visibility.Hidden;
                        Btn.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private void OnEdit()
        {
            IsEdit = true;
            
            Box.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Hidden;

            FirstName = Employee.FirstName;
            LastName = Employee.LastName;
            Salary = Employee.Salary;
            Type = Employee.Type;
            Club = Employee.BasketballClub.Id + " " + Employee.BasketballClub.Name;
            if(type == "Economist")
            {
                Facility = ((Economist)Employee).Arena.Id + " " + ((Economist)Employee).Arena.Name;
            }
            else if(type == "Seller")
            {    
                Facility = ((Seller)Employee).Shop.Id + " " + ((Seller)Employee).Shop.Name;
            }
            else if(type == "Medical staff")
            {
                Facility = ((MedicalStaff)Employee).MedicalCenterId + " " + ((MedicalStaff)Employee).MedicalCenter.Name;
            }
        }
        private void OnDelete()
        {
            MessageBoxResult res = MessageBox.Show("Do you want to delete item", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                DataRepository.Instance.DeleteEmployee(Employee.Id);
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
