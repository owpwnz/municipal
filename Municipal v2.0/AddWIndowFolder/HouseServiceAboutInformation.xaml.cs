using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.ViewModel;
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
    /// Логика взаимодействия для HouseServiceAboutInformation.xaml
    /// </summary>
    public partial class HouseServiceAboutInformation : MetroWindow
    {
  
        private ViewModel.AddressViewModel AddressViewModel;
        private HouseServiceViewModel ViewModel;
        public HouseServiceAboutInformation(ViewModel.AddressViewModel addressViewModel)
        {
            InitializeComponent();
            DataContext = addressViewModel.selectedHouse;
            AddressViewModel = addressViewModel;
            houseServiceDataGrid.ItemsSource = Connection.Database.HouseService.ToList().Where(x=> x.house_id == AddressViewModel.selectedHouse.house_id);
            houseServiceDataGrid.DataContext = ViewModel = new HouseServiceViewModel();
        }

        private void changeHouseServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeHouseService changHoseService = new ChangeHouseService(ViewModel);
            changHoseService.ShowDialog();
            
        }

        private void deleteHouseServiCeButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteHoseService();
            houseServiceDataGrid.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_id == AddressViewModel.selectedHouse.house_id);
        }
    }
}
