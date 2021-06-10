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
    /// Логика взаимодействия для ChangeHouseService.xaml
    /// </summary>
    public partial class ChangeHouseService : MetroWindow
    {
        private ViewModel.HouseServiceViewModel HouseServiceViewModel;

        public ChangeHouseService(ViewModel.HouseServiceViewModel houseServiceViewModel)
        {
            InitializeComponent();
            DataContext = houseServiceViewModel.selectedHouseService;
            HouseServiceViewModel = houseServiceViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
            serviceComboBox.ItemsSource = Connection.Database.Service.ToList();
            deviceComboBox.ItemsSource = Connection.Database.Device.ToList();

        }

        private void addHouseService_Click(object sender, RoutedEventArgs e)
        {
            HouseServiceViewModel.ChangeHouseService();
            Close();

        }

        private void backHouseService_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void serviceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedService = ((serviceComboBox.SelectedItem as Service).service_id);
            typePaymentComboBox.ItemsSource = Connection.Database.Type_payment.ToList().Where(x => x.service_id == selectedService);
            deviceComboBox.SelectedItem = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            deviceComboBox.SelectedItem = null;
        }

    }
}
