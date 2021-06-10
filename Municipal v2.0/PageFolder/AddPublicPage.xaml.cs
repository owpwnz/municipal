using Municipal_v2._0.AddWIndowFolder;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Municipal_v2._0.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddPublicPage.xaml
    /// </summary> 
    public partial class AddPublicPage : Page
    {
        private ViewModel.PublicUtilitiesViewModel PublicUtilitiesViewModel;

        public AddPublicPage(ViewModel.PublicUtilitiesViewModel publicUtilitiesViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = publicUtilitiesViewModel.selectedPublicUtilities;
            PublicUtilitiesViewModel = publicUtilitiesViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
            houseServiceComboBox3.ItemsSource = Connection.Database.HouseService.ToList();
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
                var flatIDOwner = ((flatComboBox.SelectedItem as Personal_account).Owner.owner_id);
                var houseID = ((houseComboBox.SelectedItem as House).house_id);
               
                personalAccountComboBox.ItemsSource = Connection.Database.Personal_account.ToList();
                countryComboBox.ItemsSource = Connection.Database.Counter.ToList().Where(x => x.apartment_id == flatID);
                serviceComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_id == houseID && x.Service.type_service_id == 2 && x.device_id == null || x.house_id == houseID && x.Service.type_service_id == 2 && x.device_id == 2);

                benefitComboBox.ItemsSource = Connection.Database.OwnerBenefit.ToList().Where(x => x.Owner.owner_id == flatIDOwner);
                benefitComboBox.SelectedIndex = 0;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dt;
                dt = Convert.ToDateTime(datePicker.SelectedDate);
                PublicUtilitiesViewModel.selectedPublicUtilities.date = dt;

                if (serviceComboBox.SelectedItem == null)
                {
                    double indication = Convert.ToDouble(indicationTextBox.Text);
                    PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications = Convert.ToDouble(indicationTextBox.Text);
                }

                PublicUtilitiesViewModel.SavePublicUtilities();
                MessageBox.Show("Рассчитано");
            }
            catch
            {

            }
        }




        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (recalculationCheckBox.IsChecked == false)
            {
                try
                {
                    if (serviceComboBox.SelectedItem == null)
                    {
                        if (benefitComboBox.SelectedItem != null)
                        {
                            if (benefitServiceComboBox.SelectedItem == null)
                            {
                                double indication = Convert.ToDouble(indicationTextBox.Text);
                                usedTextBox.Text = Convert.ToString(indication - PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications);
                                PublicUtilitiesViewModel.CalculateCounterPublicUtilities();        
                                amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                                amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                            }
                            else
                            {
                                var selectedServiceBenefit = ((benefitServiceComboBox.SelectedItem as BenefitService).service_id);
                                var coefbenefit = ((benefitComboBox.SelectedItem as OwnerBenefit).Benefit.coefficient);

                                if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.Service.service_id == selectedServiceBenefit)
                                {
                                    if (PublicUtilitiesViewModel.selectedPublicUtilities.Counter.bit == true)
                                    {
                                        var benefitOff = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate);
                                        var benefitOnn = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(coefbenefit);
                                        var amountOnHighCoef = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.high_coef) * Convert.ToDecimal(coefbenefit);
                                        var amountOffHighCoef = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(coefbenefit);
                                        PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate);
                                        PublicUtilitiesViewModel.selectedPublicUtilities.amount = amountOnHighCoef;
                                        PublicUtilitiesViewModel.selectedPublicUtilities.benefit = benefitOff - benefitOnn;

                                        PublicUtilitiesViewModel.selectedPublicUtilities.amount_high_coef = amountOnHighCoef - amountOffHighCoef;
                                        PublicUtilitiesViewModel.selectedPublicUtilities.size_high_coef = PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.high_coef;
                                        amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                                        amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);

                                    }
                                    else
                                    {
                                        double indication = Convert.ToDouble(indicationTextBox.Text);
                                        usedTextBox.Text = Convert.ToString(indication - PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications);
                                        PublicUtilitiesViewModel.selectedPublicUtilities.amount = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(coefbenefit);
                                        PublicUtilitiesViewModel.selectedPublicUtilities.benefit = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate) - PublicUtilitiesViewModel.selectedPublicUtilities.amount;
                                        PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay = Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.used) * Convert.ToDecimal(PublicUtilitiesViewModel.selectedPublicUtilities.Counter.HouseService.rate);
                                        amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                                        amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                                    }
                                }
                            }
                        }
                        else
                        {
                            double indication = Convert.ToDouble(indicationTextBox.Text);
                            usedTextBox.Text = Convert.ToString(indication - PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications);
                            PublicUtilitiesViewModel.CalculateCounterPublicUtilities();
                            amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                            amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                        }


                    }
                    if (countryComboBox.SelectedItem == null)
                    {
                        if (benefitComboBox.SelectedItem != null)
                        {
                            if (benefitServiceComboBox.SelectedItem == null)
                            {
                                if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 28 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 35 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 23 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 26 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 27 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 30) // Водоотведение ХВС ГВС.
                                {
                                    PublicUtilitiesViewModel.CalculateServicePublicUtilities();
                                    usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                                    amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                                    amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                                }
                        }
                            else
                            {
                                if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 28 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 35 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 23 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 26 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 27 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 30) // Водоотведение ХВС ГВС.
                                {
                                    var coefbenefit = ((benefitComboBox.SelectedItem as OwnerBenefit).Benefit.coefficient);
                                    PublicUtilitiesViewModel.CalculateServicePublicUtilities();
                                    usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                                    var benefitOn = PublicUtilitiesViewModel.selectedPublicUtilities.amount * Convert.ToDecimal(coefbenefit);
                                    var benefitOff = PublicUtilitiesViewModel.selectedPublicUtilities.amount;
                                    var differentBenefit = benefitOff  - benefitOn;
                                    PublicUtilitiesViewModel.selectedPublicUtilities.benefit = differentBenefit;
                                    amountToPayTextBox.Text = Convert.ToString(benefitOff);
                                    amountTextBox.Text = Convert.ToString(benefitOn);
                                }
                            }
                        }
                        else
                        {
                            if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 28 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 35 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 23 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 26 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 27 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 30) // Водоотведение ХВС ГВС.
                            {
                                PublicUtilitiesViewModel.CalculateServicePublicUtilities();
                                usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                                amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                                amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                            }
                        }
                    }
                }
                catch
                {

                }
            }

            if (recalculationCheckBox.IsChecked == true)
            {
                try
                {
                    if (serviceComboBox.SelectedItem == null)
                    {

                        double indication = Convert.ToDouble(indicationTextBox.Text);
                        usedTextBox.Text = Convert.ToString(indication - PublicUtilitiesViewModel.selectedPublicUtilities.Counter.indications);
                        PublicUtilitiesViewModel.RecalculateCounterPublicUtilities();
                        amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                        amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                        recalculationTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.recalculation);       
                    }

                    if (countryComboBox.SelectedItem == null)
                    {
                        if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 28 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 35) // Водоотведение ХВС ГВС.
                        {
                            PublicUtilitiesViewModel.RecalculateServicePublicUtilities();
                            usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                            amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                            amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                            recalculationTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                        }
                        if (PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 23 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 26 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 27 || PublicUtilitiesViewModel.selectedPublicUtilities.HouseService.payment_id == 30) // Холодная вода / Горячая
                        {
                            PublicUtilitiesViewModel.RecalculateServicePublicUtilities();
                            usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
                            amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                            recalculationTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
                            amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
                        }
                    }
                }
                catch
                {

                }
            }

        }

        private void serviceComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            text1.Text = Convert.ToString(0.00);
            text2.Text = Convert.ToString(0.00);
            text3.Text = Convert.ToString(0.00);

            countryComboBox.SelectedItem = null;
            indicationTextBox.Text = null;
            lastMonthIndicationTextBox.Text = null;
            usedTextBox.Text = "0";
            recalculationTextBox.Text = null;
            amountTextBox.Text = "0";
            amountToPayTextBox.Text = "0";

            if (serviceComboBox.SelectedItem == null)
            {

            }
            else
            {
                if (benefitComboBox.SelectedItem == null)
                {

                }
                else
                {
                    var selectedBenefit1 = ((benefitComboBox.SelectedItem as OwnerBenefit).benefit_id);
                    benefitServiceComboBox.ItemsSource = Connection.Database.BenefitService.ToList().Where(x => x.benefit_id == selectedBenefit1 && x.service_id == (houseServiceComboBox3.SelectedItem as HouseService).service_id);
                    benefitServiceComboBox.SelectedIndex = 0;
                }
            }
        }

        private void countryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            text1.Text = Convert.ToString(0.00);
            text2.Text = Convert.ToString(0.00);
            text3.Text = Convert.ToString(0.00);


            serviceComboBox.SelectedItem = null;
            indicationTextBox.Text = null;
            usedTextBox.Text = "0";
            recalculationTextBox.Text = null;
            amountTextBox.Text = "0";
            amountToPayTextBox.Text = "0";

            if (countryComboBox.SelectedItem == null)
            {

            }
            else
            {
                var selectedCountryComboBox = (countryComboBox.SelectedItem as Counter).service_id;
                houseServiceComboBox2.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_service_id == selectedCountryComboBox);
                houseServiceComboBox2.SelectedIndex = 0;

                if (benefitComboBox.SelectedItem == null)
                {

                }
                else
                {
                    var selectedBenefit1 = ((benefitComboBox.SelectedItem as OwnerBenefit).benefit_id);
                    benefitServiceComboBox.ItemsSource = Connection.Database.BenefitService.ToList().Where(x => x.benefit_id == selectedBenefit1 && x.service_id == (houseServiceComboBox2.SelectedItem as HouseService).service_id);
                    benefitServiceComboBox.SelectedIndex = 0;
                }
            }



        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            datePicker2.SelectedDate = datePicker.SelectedDate;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            //IndicationWindow indWin = new IndicationWindow();
            AddPublic1 addPub1 = new AddPublic1();
            addPub1.Close();
            //indWin.Show()
        }

        private void averageButton_Click(object sender, RoutedEventArgs e)
        {
            PublicUtilitiesViewModel.CalculateAveragePublicUtilities();
            //amountToPayTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount_pay);
            //amountTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.amount);
            usedTextBox.Text = Convert.ToString(PublicUtilitiesViewModel.selectedPublicUtilities.used);
            indicationTextBox.Text = Convert.ToString(Convert.ToSingle(lastMonthIndicationTextBox.Text) + Convert.ToSingle(usedTextBox.Text));
        }

        private void averageCounterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flatComboBox.SelectedItem == null || countryComboBox.SelectedItem == null)
                {

                }
                else
                {
                    var selectedPersonalId = ((flatComboBox.SelectedItem as Personal_account).personal_id);
                    var selectedCounterId = ((countryComboBox.SelectedItem as Counter).counter_id);

                    var publicReceipt = Connection.Database.Public_utilities.ToList().Where(x => x.personal_id == selectedPersonalId && x.counter_id == selectedCounterId);
                    var oneMonth = publicReceipt.Skip(Math.Max(0, publicReceipt.Count() - 3));
                    var selectedAllMonth = oneMonth.Take(3).Average(x => x.used);

                    usedTextBox.Text = Convert.ToString(selectedAllMonth);
                    var indication = Convert.ToDecimal(lastMonthIndicationTextBox.Text) + Convert.ToDecimal(usedTextBox.Text);
                    indicationTextBox.Text = Convert.ToString(indication);
                }
            }
            catch
            {

            }
        }
    }
 }

