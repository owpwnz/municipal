using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using Municipal_v2._0.WIndowFolder;
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
using System.Windows.Shapes;

namespace Municipal_v2._0.AddWIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddCounter.xaml
    /// </summary>
    public partial class AddCounter : MetroWindow
    {
        private ViewModel.CounterViewModel CounterViewModel;

        public AddCounter(ViewModel.CounterViewModel counterViewModel)
        {
            InitializeComponent();

            DataContext = counterViewModel.selectedCounter;
            CounterViewModel = counterViewModel;
            houseComboBox.ItemsSource = Connection.Database.Apartment.ToList();
        }
        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var houseID = ((houseComboBox.SelectedItem as Apartment).House.house_id);
            apartmentComboBox.ItemsSource = Connection.Database.Apartment.ToList().Where(x => x.house_id == houseID);
            counterComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_id == houseID && x.device_id == 1);
        }

        private void addCounterButton_Click(object sender, RoutedEventArgs e)
        {
            CounterViewModel.ChangeCounter();
            MessageBox.Show("Счетчик добавлен");
        }
    }
}
