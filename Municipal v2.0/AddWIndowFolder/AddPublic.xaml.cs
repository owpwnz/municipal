using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
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
    /// Логика взаимодействия для AddPublic.xaml
    /// </summary>
    public partial class AddPublic : MetroWindow
    {
        private ViewModel.PublicUtilitiesViewModel PublicUtilitiesViewModel;


        public AddPublic(ViewModel.PublicUtilitiesViewModel publicUtilitiesViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = publicUtilitiesViewModel.selectedPublicUtilities;
            PublicUtilitiesViewModel = publicUtilitiesViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();

        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var houseID = ((houseComboBox.SelectedItem as House).house_id);
            flatComboBox.ItemsSource = Connection.Database.Personal_account.ToList().Where(x => x.Apartment.house_id == houseID);
            countryComboBox.ItemsSource = null;
        }

        private void flatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (flatComboBox.SelectedItem == null)
            {

            }
            else
            {
                var flatID = ((flatComboBox.SelectedItem as Personal_account).apartment_id);
                var houseID = ((houseComboBox.SelectedItem as House).house_id);
                personalAccountComboBox.ItemsSource = Connection.Database.Personal_account.ToList();
                countryComboBox.ItemsSource = Connection.Database.Counter.ToList().Where(x => x.apartment_id == flatID);
                serviceComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x=> x.house_id == houseID && x.Service.type_service_id == 2 && x.device_id == null);               
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            PublicUtilitiesViewModel.selectedPublicUtilities.date = dt;
            PublicUtilitiesViewModel.SavePublicUtilities();

            if (serviceComboBox.SelectedItem == null)
            {
                double indication = Convert.ToDouble(indicationTextBox.Text);
                PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications = Convert.ToDouble(indicationTextBox.Text);
            }

            MessageBox.Show("Рассчитано");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            IndicationWindow indWin = new IndicationWindow();
            indWin.Show();
            this.Close();
        }


        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (serviceComboBox.SelectedItem == null)
            {
                double indication = Convert.ToDouble(indicationTextBox.Text);
                usedTextBox.Text = Convert.ToString(indication - PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications);
                PublicUtilitiesViewModel.CalculateCounterPublicUtilities();
                amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                
           
            }
            if (countryComboBox.SelectedItem == null)
            {
                if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 28 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 35) // Водоотведение ХВС ГВС.
                {
                    PublicUtilitiesViewModel.CalculateServicePublicUtilities();
                    usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                    amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                }
                if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 23 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 26 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 27) // Холодная вода / Горячая
                {
                    PublicUtilitiesViewModel.CalculateServicePublicUtilities();
                    usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                    amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                }       
            }
        }

        private void serviceComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            countryComboBox.SelectedItem = null;
        }

        private void countryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            serviceComboBox.SelectedItem = null;
            if (countryComboBox.SelectedItem == null)
            {

            }
            else
            {
                var selectedCountryComboBox = (countryComboBox.SelectedItem as Counter).service_id;
                houseServiceComboBox2.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_service_id == selectedCountryComboBox);
                houseServiceComboBox2.SelectedIndex = 0;
            }            
            
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            datePicker2.SelectedDate = datePicker.SelectedDate;
        }
    }
}
