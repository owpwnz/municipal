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
    /// Логика взаимодействия для HouseAboutInformation.xaml
    /// </summary>
    public partial class HouseAboutInformation : MetroWindow
    {

        private ViewModel.ApartmentViewModel ApartmentViewModel;
        private CounterViewModel ViewModel2;

        public HouseAboutInformation(ViewModel.ApartmentViewModel apartmentViewModel)
        {
            InitializeComponent();
            DataContext = apartmentViewModel.selectedApartment;

            ApartmentViewModel = apartmentViewModel;
            counterDataGrid.ItemsSource = Connection.Database.Counter.ToList().Where(x=> x.apartment_id == ApartmentViewModel.selectedApartment.apartment_id);
            counterDataGrid.DataContext = ViewModel2 = new CounterViewModel();
        }

        private void removeCounterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.DeleteCounter();
        }

        private void changeCounteButton_Click(object sender, RoutedEventArgs e)
        {
            AddCounter addCounter = new AddCounter(ViewModel2);
            addCounter.ShowDialog();
        }
    }
}
