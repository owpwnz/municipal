using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using Municipal_v2._0.ViewModel;
using Municipal_v2._0.WIndowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AddHousePublic.xaml
    /// </summary>
    public partial class AddHousePublic : MetroWindow
    {
        private ViewModel.HousePublicUtilitiesViewModel HousePublicUtilitiesViewModel;

        public AddHousePublic(ViewModel.HousePublicUtilitiesViewModel housePublicUtilitiesViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = housePublicUtilitiesViewModel.selectedHousePublic;
            HousePublicUtilitiesViewModel = housePublicUtilitiesViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            HousePublicUtilitiesViewModel.selectedHousePublic.date = dt;
            
            if (serviceComboBox.SelectedItem == null)
            {
                HousePublicUtilitiesViewModel.selectedHousePublic.House_counter.indication = Convert.ToDouble(indicationNow.Text);

            }
            HousePublicUtilitiesViewModel.saveHousePublic();       
            MessageBox.Show("Рассчитано");

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            IndicationWindow2 indWin = new IndicationWindow2();
            indWin.Show();
            this.Close();
        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var houseID = ((houseComboBox.SelectedItem as House).house_id);
            serviceComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_id == houseID && x.Service.type_service_id == 3 && x.device_id != 2);
            counterServiceComboBox.ItemsSource = Connection.Database.House_counter.ToList().Where(x=> x.house_id == houseID);

        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceComboBox.SelectedItem == null)
            {
                double indication = Convert.ToDouble(indicationNow.Text);
                usedTextBox.Text = Convert.ToString(indication - HousePublicUtilitiesViewModel.selectedHousePublic.House_counter.indication);
            }
            
                      
        }

        private void counterServiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            serviceComboBox.SelectedItem = null;
            if (counterServiceComboBox.SelectedItem == null)
            {

            }
            else
            {
                var selectedCountryComboBox = (counterServiceComboBox.SelectedItem as House_counter).service_id;
                serviceComboBox2.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_service_id == selectedCountryComboBox);
                serviceComboBox2.SelectedIndex = 0;
            }
        }

        private void serviceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            counterServiceComboBox.SelectedItem = null;
        }
    }
}
