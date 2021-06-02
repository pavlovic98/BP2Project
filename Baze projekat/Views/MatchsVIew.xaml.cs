using Baze_projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Baze_projekat.Views
{
    /// <summary>
    /// Interaction logic for MatchsVIew.xaml
    /// </summary>
    public partial class MatchsVIew : UserControl
    {
        public MatchsVIew()
        {
            InitializeComponent();
            DataContext = new MatchsVIewModel()
            {
                Box = addForm,
                Btn = addBtn
            };
        }
    }
}
