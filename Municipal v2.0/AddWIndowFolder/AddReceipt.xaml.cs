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
    /// Логика взаимодействия для AddReceipt.xaml
    /// </summary>
    public partial class AddReceipt : MetroWindow
    {

        private ViewModel.ReceiptViewModel ReceiptViewModel;

        public AddReceipt(ViewModel.ReceiptViewModel receiptViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = receiptViewModel.selectedRecepit;
            ReceiptViewModel = receiptViewModel;
            personalComboBox.ItemsSource = Connection.Database.Personal_account.ToList();
            flatComboBox.ItemsSource = Connection.Database.Personal_account.ToList();
            houseComboBox.ItemsSource = Connection.Database.Personal_account.ToList();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //var d2 = datepickerTextBox.SelectedDate;
            //var diff = d2.Value.AddMonths(-1);

            penaltiesTextBox.Text = Convert.ToString(0.0000);
            debtTextBox.Text = Convert.ToString(0.0000);
            overPaymentTextBox.Text = Convert.ToString(0.0000);

            if (receiptComboBox.SelectedItem != null)
            {
                DateTime? datePayBefore = ((receiptComboBox.SelectedItem as Receipt).date_pay_before);
                DateTime? datePay = ((receiptComboBox.SelectedItem as Receipt).date_pay);

                var amountToPay = ((receiptComboBox.SelectedItem as Receipt).amount_to_pay);
                var amountPaid = ((receiptComboBox.SelectedItem as Receipt).amount_paid);

                lastPaymentDateTextBox.Text = Convert.ToString(datePay);

                if (datePay == null)
                {
                    var selectedDate = datePicker.SelectedDate;
                    var selectedPersonalID = ((personalComboBox.SelectedItem as Personal_account).personal_id);
                    var resultMaintenance = Connection.Database.Maintenance_and_repair.ToList().Where(x => x.personal_id == selectedPersonalID && x.date == selectedDate).Sum(k => k.amount);
                    var selectedApartmentID = ((flatComboBox.SelectedItem as Personal_account).personal_id);
                    var resultPublic = Connection.Database.Public_utilities.ToList().Where(x => x.personal_id == selectedApartmentID && x.date == selectedDate).Sum(k => k.amount);

                    debtTextBox.Text = Convert.ToString(amountToPay);
                    
                    //if (amountPaid > amountToPay)
                    //{
                    //    overPaymentTextBox.Text = Convert.ToString(amountPaid - amountToPay);
                    //}

                    var amount = resultMaintenance + resultPublic;
                    var result = Convert.ToDecimal(resultMaintenance) + Convert.ToDecimal(resultPublic) + Convert.ToDecimal(debtTextBox.Text);

                    ReceiptViewModel.selectedRecepit.overpayment = Convert.ToDecimal(overPaymentTextBox.Text);
                    ReceiptViewModel.selectedRecepit.debt = Convert.ToDecimal(debtTextBox.Text);
                    ReceiptViewModel.selectedRecepit.amount = Convert.ToDecimal(amount);
                    ReceiptViewModel.selectedRecepit.amount_to_pay = Convert.ToDecimal(result);


                    amountTextBox.Text = Convert.ToString(amount);
                    amountToPayTextBox.Text = Convert.ToString(result);
 
                }
                if (datePay != null)
                {
                    var selectedReceipt = ((receiptComboBox.SelectedItem as Receipt).penalties);
                    var selectedReceiptPay = ((receiptComboBox.SelectedItem as Receipt).amount_to_pay);
                    int differenceDate = (int)(datePay - datePayBefore).Value.TotalDays;
                    decimal penaltiesFin;
                    
                    if (differenceDate > 30)
                    {
                        int day = differenceDate;
                        var penalties = selectedReceiptPay * day * 1 / 300;
                        var penalties1 = (penalties / 100) * 6;
                        penaltiesFin = Math.Round(penalties1, 4);
                        penaltiesTextBox.Text = Convert.ToString(penaltiesFin);
                    }
                    if (differenceDate > 60)
                    {
                        int day = differenceDate;
                        var penalties = selectedReceiptPay * day * 1 / 130;
                        var penalties1 = (penalties / 100) * 6;
                        penaltiesFin = Math.Round(penalties1, 4);
                        penaltiesTextBox.Text = Convert.ToString(penaltiesFin);
                    }

                    var selectedDate = datePicker.SelectedDate;
                    var selectedPersonalID = ((personalComboBox.SelectedItem as Personal_account).personal_id);
                    var resultMaintenance = Connection.Database.Maintenance_and_repair.ToList().Where(x => x.personal_id == selectedPersonalID && x.date == selectedDate).Sum(k => k.amount);
                    var selectedApartmentID = ((flatComboBox.SelectedItem as Personal_account).personal_id);
                    var resultPublic = Connection.Database.Public_utilities.ToList().Where(x => x.personal_id == selectedApartmentID && x.date == selectedDate).Sum(k => k.amount);

                    if (amountPaid < amountToPay)
                    {
                        debtTextBox.Text = Convert.ToString(amountToPay - amountPaid);
                    }

                    if (amountPaid > amountToPay)
                    {
                        overPaymentTextBox.Text = Convert.ToString(amountPaid - amountToPay);
                    }

                    var amount = resultMaintenance + resultPublic;

                    var result = Convert.ToDecimal(resultMaintenance) + Convert.ToDecimal(resultPublic) + Convert.ToDecimal(debtTextBox.Text) + Convert.ToDecimal(penaltiesTextBox.Text) - Convert.ToDecimal(overPaymentTextBox.Text);



                    ReceiptViewModel.selectedRecepit.overpayment = Convert.ToDecimal(overPaymentTextBox.Text);
                    ReceiptViewModel.selectedRecepit.debt = Convert.ToDecimal(debtTextBox.Text);
                    ReceiptViewModel.selectedRecepit.amount = Convert.ToDecimal(amount);
                    ReceiptViewModel.selectedRecepit.amount_to_pay = Convert.ToDecimal(result);
                    ReceiptViewModel.selectedRecepit.penalties = Convert.ToDecimal(penaltiesTextBox.Text);

                    amountTextBox.Text = Convert.ToString(amount);
                    amountToPayTextBox.Text = Convert.ToString(result);
                }
            }

            if (receiptComboBox.SelectedItem == null)
            {
                var selectedDate = datePicker.SelectedDate;
                var selectedPersonalID = ((personalComboBox.SelectedItem as Personal_account).personal_id);
                var resultMaintenance = Connection.Database.Maintenance_and_repair.ToList().Where(x => x.personal_id == selectedPersonalID && x.date == selectedDate).Sum(k => k.amount);
                var selectedApartmentID = ((flatComboBox.SelectedItem as Personal_account).personal_id);
                var resultPublic = Connection.Database.Public_utilities.ToList().Where(x => x.personal_id == selectedApartmentID && x.date == selectedDate).Sum(k => k.amount);

                var amount = resultMaintenance + resultPublic;

                var result = resultMaintenance + resultPublic;


                ReceiptViewModel.selectedRecepit.debt = Convert.ToDecimal(debtTextBox.Text);
                ReceiptViewModel.selectedRecepit.amount = Convert.ToDecimal(amount);
                ReceiptViewModel.selectedRecepit.amount_to_pay = Convert.ToDecimal(result);
                ReceiptViewModel.selectedRecepit.penalties = Convert.ToDecimal(debtTextBox.Text);
                ReceiptViewModel.selectedRecepit.overpayment = Convert.ToDecimal(overPaymentTextBox.Text);

                amountTextBox.Text = Convert.ToString(amount);
                amountToPayTextBox.Text = Convert.ToString(result);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            DateTime dt2;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            dt2 = Convert.ToDateTime(datePicker1.SelectedDate);
            ReceiptViewModel.selectedRecepit.date_pay_before = dt2;
            ReceiptViewModel.selectedRecepit.date = dt;
            ReceiptViewModel.saveReceipt();
            MessageBox.Show("Рассчитано");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            ReceiptWindow rcpWin = new ReceiptWindow();
            rcpWin.Show();
            this.Close();
        }

        private void personalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPersonal = ((personalComboBox.SelectedItem as Personal_account).personal_id);
            receiptComboBox.ItemsSource = Connection.Database.Receipt.ToList().Where(x => x.personal_id == selectedPersonal);

            var countReceipt = Connection.Database.Receipt.ToList().Where(x => x.personal_id == selectedPersonal).Count();
            receiptComboBox.SelectedIndex = countReceipt - 1;
       
        }

  
    }
}
