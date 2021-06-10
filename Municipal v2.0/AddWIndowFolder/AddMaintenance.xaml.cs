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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Municipal_v2._0.AddWIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddMaintenance.xaml
    /// </summary>
    public partial class AddMaintenance : MetroWindow
    {
        private ViewModel.MaintenanceAndRepairViewModel MaintenanceAndRepairViewModel;

        int houseID;
     

        public AddMaintenance(ViewModel.MaintenanceAndRepairViewModel maintenanceAndRepairViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = maintenanceAndRepairViewModel.selectedMaintenceAndRepair;
            MaintenanceAndRepairViewModel = maintenanceAndRepairViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
        }


        private void houseDataGrud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            houseID = ((houseComboBox.SelectedItem as House).house_id);
            flatComboBox.ItemsSource = Connection.Database.Personal_account.ToList().Where(x => x.Apartment.house_id == houseID);
            var servicePaymentID = Connection.Database.HouseService.ToList().Where(x => x.Service.type_service_id == 1);
            serviceComboBox.ItemsSource = servicePaymentID.Where(x => x.house_id == houseID);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var houseID1 = ((houseComboBox.SelectedItem as House).house_id);
            var apartmentPersonal = Connection.Database.Personal_account.ToList().Where(x => x.Apartment.house_id == houseID1);
            var vivod = apartmentPersonal.Count(x => Convert.ToBoolean(x.apartment_id));

            var a = Connection.Database.HouseService.ToList().Where(x => x.Service.type_service_id == 1);
            var b = a.Where(x => x.house_id == houseID);
            var c = b.Count(x => Convert.ToBoolean(x.Service.service_id));

            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            MaintenanceAndRepairViewModel.selectedMaintenceAndRepair.date = dt;
            for (int i = 0; i < vivod; i++)
            {
                for (int j = 0; j < c; j++)
                {

                    flatComboBox.SelectedIndex = i;
                    serviceComboBox.SelectedIndex = j;

                    if (benefitComboBox.SelectedItem != null)
                    {
                      if (benefitServiceComboBox.SelectedItem != null)
                        {
                            var selectedServiceBenefit = ((benefitServiceComboBox.SelectedItem as BenefitService).service_id);
                            var coefbenefit = ((benefitComboBox.SelectedItem as OwnerBenefit).Benefit.coefficient);
                           
                                MaintenanceAndRepairViewModel.CalculateMatinceAndRepair();
                                var benefitOnn = MaintenanceAndRepairViewModel.selectedMaintenceAndRepair.amount * Convert.ToDecimal(coefbenefit);
                                var benefitOff = MaintenanceAndRepairViewModel.selectedMaintenceAndRepair.amount;

                                amountTextBox.Text = Convert.ToString(benefitOnn);
                                amountPayTextBox.Text = Convert.ToString(benefitOff);
                                benefitTextBox.Text = Convert.ToString(benefitOff - benefitOnn);
                                MaintenanceAndRepairViewModel.SaveMaintenceAndRepair();
                                benefitTextBox.Text = null;
                        }
                        else
                        {
                            MaintenanceAndRepairViewModel.CalculateMatinceAndRepair();
                            MaintenanceAndRepairViewModel.SaveMaintenceAndRepair();

                        }
                    }
                    else
                    {
                       
                        MaintenanceAndRepairViewModel.CalculateMatinceAndRepair();
                        MaintenanceAndRepairViewModel.SaveMaintenceAndRepair();
                    }
                }
            }
            MessageBox.Show("Услуги рассчитаны");

        }

        private void serviceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaintenanceAndRepairViewModel.CalculateMatinceAndRepair();
            amountTextBox.Text = Convert.ToString(MaintenanceAndRepairViewModel.selectedMaintenceAndRepair.amount);

            if (benefitComboBox.SelectedItem == null)
            {

            }
            else
            {
                var selectedBenefit1 = ((benefitComboBox.SelectedItem as OwnerBenefit).benefit_id);
                benefitServiceComboBox.ItemsSource = Connection.Database.BenefitService.ToList().Where(x => x.benefit_id == selectedBenefit1 && x.service_id == (serviceComboBox.SelectedItem as HouseService).service_id);
                benefitServiceComboBox.SelectedIndex = 0;
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            IndicationWindow indWin = new IndicationWindow();
            indWin.Show();
            Close();
        }

        private void flatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var flatIDOwner = ((flatComboBox.SelectedItem as Personal_account).Owner.owner_id);
            benefitComboBox.ItemsSource = Connection.Database.OwnerBenefit.ToList().Where(x => x.Owner.owner_id == flatIDOwner);
            benefitComboBox.SelectedIndex = 0;
        }
    }
}
