using Municipal_v2._0.AddWIndowFolder;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using Municipal_v2._0.WIndowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Municipal_v2._0.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddHousePublicPage.xaml
    /// </summary>
    public partial class AddHousePublicPage : Page
    {
        private ViewModel.PublicUtilitiesViewModel PublicUtilitiesViewModel;

        public AddHousePublicPage(ViewModel.PublicUtilitiesViewModel publicUtilitiesViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = publicUtilitiesViewModel.selectedPublicUtilities;
            PublicUtilitiesViewModel = publicUtilitiesViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedHouse = ((houseComboBox.SelectedItem as House).house_id);
            serviceComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x=> x.house_id == selectedHouse && x.Service.type_service_id == 3);
            flatComboBox.ItemsSource = Connection.Database.Personal_account.ToList().Where(x => x.Apartment.house_id == selectedHouse);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            PublicUtilitiesViewModel.selectedPublicUtilities.date = dt;
            PublicUtilitiesViewModel.SavePublicUtilities();
            MessageBox.Show("Расчитано");
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedDate = datePicker.SelectedDate;
                var selectedHouse = ((houseComboBox.SelectedItem as House).house_id);
                var selectedService = ((serviceComboBox.SelectedItem as HouseService).payment_id);
                var selectedService1 = ((serviceComboBox.SelectedItem as HouseService).house_service_id);

                if (selectedService == 40)
                {
                    var pokazanieHouse = Connection.Database.House_public_utilities.ToList().Where(x => x.HouseService.house_id == selectedHouse && x.house_service_id == selectedService1 && x.date == selectedDate).Sum(k => k.used);

                    var pokazanieFlat = Connection.Database.Individual_amount.ToList().Where(x => x.house_id == selectedHouse && x.HouseService.service_id == 62 && x.date == selectedDate).Sum(k => k.used);

                    var difference = Convert.ToString(pokazanieHouse - pokazanieFlat);

                    var used = Convert.ToDouble(difference) * (PublicUtilitiesViewModel.selectedPublicUtilities.Personal_account.Apartment.square / (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_residental + PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_nonresidental));

                    usedTextBox.Text = Convert.ToString(used);

                    var amount = used * PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.rate;
                    amountTextBox.Text = Convert.ToString(amount);
                    PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(amount);
                }

                if (selectedService == 41)
                {
                    var pokazanieHouse = Connection.Database.House_public_utilities.ToList().Where(x => x.HouseService.house_id == selectedHouse && x.house_service_id == selectedService1 && x.date == selectedDate).Sum(k => k.used);

                    var pokazanieFlat = Connection.Database.Individual_amount.ToList().Where(x => x.house_id == selectedHouse && x.HouseService.service_id == 60 && x.date == selectedDate).Sum(k => k.used);

                    var difference = Convert.ToString(pokazanieHouse - pokazanieFlat);

                    var used = Convert.ToDouble(difference) * (PublicUtilitiesViewModel.selectedPublicUtilities.Personal_account.Apartment.square / (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_residental + PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_nonresidental));

                    usedTextBox.Text = Convert.ToString(used);

                    var amount = used * PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.rate;
                    amountTextBox.Text = Convert.ToString(amount);
                    PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(amount);
                }


                if (selectedService == 42)
                {
                    var pokazanieHouse = Connection.Database.House_public_utilities.ToList().Where(x => x.HouseService.house_id == selectedHouse && x.house_service_id == selectedService1 && x.date == selectedDate).Sum(k => k.used);

                    var pokazanieFlat = Connection.Database.Individual_amount.ToList().Where(x => x.house_id == selectedHouse && x.HouseService.service_id == 61 && x.date == selectedDate).Sum(k => k.used);

                    var difference = Convert.ToString(pokazanieHouse - pokazanieFlat);

                    var used = Convert.ToDouble(difference) * (PublicUtilitiesViewModel.selectedPublicUtilities.Personal_account.Apartment.square / (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_residental + PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_nonresidental));

                    usedTextBox.Text = Convert.ToString(used);

                    var amount = used * PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.rate;
                    amountTextBox.Text = Convert.ToString(amount);
                    PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(amount);
                }

                if (selectedService == 43)
                {
                    var pokazanieHouse = Connection.Database.House_public_utilities.ToList().Where(x => x.HouseService.house_id == selectedHouse && x.house_service_id == selectedService1 && x.date == selectedDate).Sum(k => k.used);

                    var pokazanieFlat = Connection.Database.Individual_amount.ToList().Where(x => x.house_id == selectedHouse && x.HouseService.service_id == 59 && x.date == selectedDate).Sum(k => k.used);

                    var difference = Convert.ToString(pokazanieHouse - pokazanieFlat);

                    var used = Convert.ToDouble(difference) * (PublicUtilitiesViewModel.selectedPublicUtilities.Personal_account.Apartment.square / (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_residental + PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_nonresidental));

                    usedTextBox.Text = Convert.ToString(used);

                    var amount = used * PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.rate;
                    amountTextBox.Text = Convert.ToString(amount);
                    PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(amount);
                }

                if (selectedService == 44)
                {
                    var pokazanieHouse = Connection.Database.House_public_utilities.ToList().Where(x => x.HouseService.house_id == selectedHouse && x.house_service_id == selectedService1 && x.date == selectedDate).Sum(k => k.used);

                    var pokazanieFlat = Connection.Database.Individual_amount.ToList().Where(x => x.house_id == selectedHouse && x.HouseService.service_id == 64 && x.date == selectedDate).Sum(k => k.used);

                    var difference = Convert.ToString(pokazanieHouse - pokazanieFlat);

                    var used = Convert.ToDouble(difference) * (PublicUtilitiesViewModel.selectedPublicUtilities.Personal_account.Apartment.square / (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_residental + PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_nonresidental));

                    usedTextBox.Text = Convert.ToString(used);

                    var amount = used * PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.rate;
                    amountTextBox.Text = Convert.ToString(amount);
                    PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(amount);
                }

                if (selectedService == 45)
                {
                    var pokazanieHouse = Connection.Database.House_public_utilities.ToList().Where(x => x.HouseService.house_id == selectedHouse && x.house_service_id == selectedService1 && x.date == selectedDate).Sum(k => k.used);

                    var pokazanieFlat = Connection.Database.Individual_amount.ToList().Where(x => x.house_id == selectedHouse && x.HouseService.service_id == 65 && x.date == selectedDate).Sum(k => k.used);

                    var difference = Convert.ToString(pokazanieHouse - pokazanieFlat);

                    var used = Convert.ToDouble(difference) * (PublicUtilitiesViewModel.selectedPublicUtilities.Personal_account.Apartment.square / (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_residental + PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.House.square_nonresidental));

                    usedTextBox.Text = Convert.ToString(used);

                    var amount = used * PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.rate;
                    amountTextBox.Text = Convert.ToString(amount);
                    PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(amount);
                }
            }
            catch
            {

            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            IndicationWindow indWin = new IndicationWindow();
            AddPublic1 addPub1 = new AddPublic1();
            addPub1.Close();
            indWin.Show();
        }

        
    
    }
}
