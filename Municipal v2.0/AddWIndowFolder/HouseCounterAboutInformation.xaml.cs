using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
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
    /// Логика взаимодействия для HouseCounterAboutInformation.xaml
    /// </summary>
    public partial class HouseCounterAboutInformation : MetroWindow
    {
        private ViewModel.AddressViewModel AddressViewModel;
        private HouseCounterViewModel ViewModel;


        public HouseCounterAboutInformation(ViewModel.AddressViewModel addressViewModel)
        {
            InitializeComponent();
            DataContext = addressViewModel.selectedHouse;
            AddressViewModel = addressViewModel;
            houseCounterDataGrid.ItemsSource = Connection.Database.House_counter.ToList().Where(x=> x.house_id == AddressViewModel.selectedHouse.house_id);
            houseCounterDataGrid.DataContext = ViewModel = new HouseCounterViewModel();
           
        }

        private void deleteHouseServiCeButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.deleteHouseCounter();
            houseCounterDataGrid.ItemsSource = Connection.Database.House_counter.ToList().Where(x => x.house_id == AddressViewModel.selectedHouse.house_id);
           
        }
    }
}
