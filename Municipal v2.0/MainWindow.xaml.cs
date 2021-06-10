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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Municipal_v2._0
{
    using Municipal_v2._0.Class;
    using Municipal_v2._0.Model;
    using WIndowFolder;
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {   
            InitializeComponent();
            Connection.Database = new Model.municipalDBEntities();           
        }

        private void ownerBtn_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownWin = new OwnerWindow();
            ownWin.ShowDialog();
        }

        private void addressBtn_Click(object sender, RoutedEventArgs e)
        {
            AddressWindow addWin = new AddressWindow();
            addWin.ShowDialog();
        }

        private void serviceButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow servWin = new ServiceWindow();
            servWin.ShowDialog();
        }

        private void benefitButton_Click(object sender, RoutedEventArgs e)
        {
            BenefitWindow benWin = new BenefitWindow();
            benWin.ShowDialog();
        }

        private void indicationButton_Click(object sender, RoutedEventArgs e)
        {
            IndicationWindow indWin = new IndicationWindow();
            indWin.ShowDialog();
        }

        private void receiptBtn_Click(object sender, RoutedEventArgs e)
        {
            ReceiptWindow recWin = new ReceiptWindow();
            recWin.ShowDialog();
        }

        private void Indication2_Click(object sender, RoutedEventArgs e)
        {
            IndicationWindow2 indWin2 = new IndicationWindow2();
            indWin2.ShowDialog();
        }
    }
}
