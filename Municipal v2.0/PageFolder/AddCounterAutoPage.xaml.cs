using Municipal_v2._0.Class;
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

namespace Municipal_v2._0.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddCounterAutoPage.xaml
    /// </summary>
    public partial class AddCounterAutoPage : Page
    {
        private ViewModel.CounterViewModel CounterViewModel;

        public AddCounterAutoPage(ViewModel.CounterViewModel counterViewModel)
        {
            InitializeComponent();
            DataContext = counterViewModel.selectedCounter;
            CounterViewModel = counterViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
        }
    }
}
