using MahApps.Metro.Controls;
using Municipal_v2._0.AddWIndowFolder;
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

namespace Municipal_v2._0.WIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddressWindow.xaml
    /// </summary>
    public partial class AddressWindow : MetroWindow
    {

        private AddressViewModel ViewModel;

        private ApartmentViewModel ViewModel1;

        private CounterViewModel ViewModel2;

        private HouseServiceViewModel ViewModel3;

        private HouseCounterViewModel ViewModel4;

        public AddressWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new AddressViewModel();
            apartmentDataGrid.DataContext = ViewModel1 = new ApartmentViewModel();
            ViewModel2 = new CounterViewModel();
            ViewModel3 = new HouseServiceViewModel();
            ViewModel4 = new HouseCounterViewModel();


        }

        private void addHouseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel.selectedHouse = new Model.House();
            AddHouse addHouse = new AddHouse(ViewModel);
            addHouse.Show();
        }

        private void deleteHouseButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteHouse();

        }

        private void abouDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            HouseAboutInformation houseAbbInf = new HouseAboutInformation(ViewModel1);
            houseAbbInf.ShowDialog();
        }


        private void houseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.selectedHouse != null)
            {
                apartmentDataGrid.ItemsSource = Connection.Database.Apartment.ToList().Where(x => x.house_id == ViewModel.selectedHouse.house_id);
            }
            if (ViewModel.selectedHouse == null)
            {

            }
        }

        private void addApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel1.selectedApartment = new Model.Apartment();
            AddApartment addApart = new AddApartment(ViewModel1);
            addApart.ShowDialog();
        }

        private void addCounterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddCounter1 addCount = new AddCounter1();
            addCount.ShowDialog();
        }

        private void deleteApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel1.DeleteApartment();
            apartmentDataGrid.ItemsSource = Connection.Database.Apartment.ToList().Where(x => x.house_id == ViewModel.selectedHouse.house_id);
        }

        private void changeApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChangeApartment chnApart = new ChangeApartment(ViewModel1);
            chnApart.ShowDialog();
        }

        private void addHouseServiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel3.selectedHouseService = new Model.HouseService();
            AddHouseService addHouseServ = new AddHouseService(ViewModel3);
            addHouseServ.ShowDialog();
        }

        private void aboutHouseServiceButton_Click(object sender, RoutedEventArgs e)
        {
            HouseServiceAboutInformation houseServ = new HouseServiceAboutInformation(ViewModel);
            houseServ.ShowDialog();
        }

        private void addHouseCounter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel4.selectedHouseCounter = new Model.House_counter();
            AddHouseCounter addHouseCount = new AddHouseCounter(ViewModel4);
            addHouseCount.ShowDialog(); 
        }

        private void aboutHouseCounterButton_Click(object sender, RoutedEventArgs e)
        {
            HouseCounterAboutInformation houseCounter = new HouseCounterAboutInformation(ViewModel);
            houseCounter.ShowDialog();
        }
    }
}
