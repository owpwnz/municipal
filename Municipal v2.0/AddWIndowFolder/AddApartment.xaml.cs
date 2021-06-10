using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
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
    /// Логика взаимодействия для AddApartment.xaml
    /// </summary>
    public partial class AddApartment : MetroWindow
    {

        private ViewModel.ApartmentViewModel ApartmentViewModel;

        public AddApartment(ViewModel.ApartmentViewModel apartmentViewModel)
        {
            InitializeComponent();

            houseComboBox.ItemsSource = Connection.Database.House.ToList();
            DataContext = apartmentViewModel.selectedApartment;
            ApartmentViewModel = apartmentViewModel;
        }

        private void addApartment_Click(object sender, RoutedEventArgs e)
        {
            ApartmentViewModel.SaveApartment();
            MessageBox.Show("Квартира добавлена");
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AddressWindow addrWin = new AddressWindow();
            addrWin.Show();
            Close();
        }
    }
}
