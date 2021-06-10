using MahApps.Metro.Controls;
using Municipal_v2._0.AddWIndowFolder;
using Municipal_v2._0.Print;
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
    /// Логика взаимодействия для ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : MetroWindow
    {
        private ReceiptViewModel ViewModel;

        public ReceiptWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new ReceiptViewModel();

            (receiptDataGrid.Columns[3] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
            (receiptDataGrid.Columns[8] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
            (receiptDataGrid.Columns[10] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";

        }

        private void addReceiptButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel.selectedRecepit = new Model.Receipt();
            AddReceipt addRec = new AddReceipt(ViewModel);
            addRec.Show();
          
        }

        private void deleteReceiptButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.deleteReceipt();
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {   
            PrintReceipt prinRec = new PrintReceipt();
            prinRec.ShowDialog();
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            PaymentWindow payWin = new PaymentWindow(ViewModel);
            payWin.Show();
            
        }
    }
}
