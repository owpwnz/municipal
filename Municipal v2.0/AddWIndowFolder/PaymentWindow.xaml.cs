using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : MetroWindow
    {
        private ViewModel.ReceiptViewModel ReceiptViewModel;

        public PaymentWindow(ViewModel.ReceiptViewModel receiptViewModel)
        {
            InitializeComponent();
            DataContext = receiptViewModel.selectedRecepit;
            ReceiptViewModel = receiptViewModel;    
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            ReceiptViewModel.selectedRecepit.date_pay = dt;
            ReceiptViewModel.changeReceipt();
            this.Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    
        private void fullPayment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
