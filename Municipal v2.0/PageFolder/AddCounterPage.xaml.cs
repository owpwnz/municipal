using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
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
    /// Логика взаимодействия для AddCounterPage.xaml
    /// </summary>
    public partial class AddCounterPage : Page
    {
        private ViewModel.CounterViewModel CounterViewModel;

        public AddCounterPage(ViewModel.CounterViewModel counterViewModel)
        {
            InitializeComponent();
            DataContext = counterViewModel.selectedCounter;
            CounterViewModel = counterViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var houseID = ((houseComboBox.SelectedItem as House).house_id);
            apartmentComboBox.ItemsSource = Connection.Database.Apartment.ToList().Where(x=> x.house_id == houseID);
            counterComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_id == houseID && x.device_id == 1);
        }

        private void addCounterButton_Click(object sender, RoutedEventArgs e)
        {
            CounterViewModel.SaveCounter();
            MessageBox.Show("Счетчик добавлен");
        }
    }
}
