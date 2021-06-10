using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using Municipal_v2._0.ViewModel;
using Municipal_v2._0.WIndowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для AddHouseCounter.xaml
    /// </summary>
    public partial class AddHouseCounter : MetroWindow
    {
        private ViewModel.HouseCounterViewModel HouseCounterViewModel;

        public AddHouseCounter(ViewModel.HouseCounterViewModel houseCounterViewModel)
        {
            InitializeComponent();
            DataContext = houseCounterViewModel.selectedHouseCounter;
            HouseCounterViewModel = houseCounterViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();

        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var houseID = ((houseComboBox.SelectedItem as House).house_id);
            counterComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.device_id == 2 && x.house_id == houseID);
        }

        private void addCounterButton_Click(object sender, RoutedEventArgs e)
        {
            HouseCounterViewModel.saveHouseCounter();
            MessageBox.Show("Счетчик добавлен");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddressWindow addWin = new AddressWindow();
            addWin.ShowDialog();
        }
    }
}
