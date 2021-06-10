using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.WIndowFolder;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : MetroWindow
    {
        private ViewModel.ServiceViewModel ServiceViewModel;

        public AddService(ViewModel.ServiceViewModel serviceViewModel)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DataContext = serviceViewModel.selectedService;
            ServiceViewModel = serviceViewModel;
            typeServiceComboBox.ItemsSource = Connection.Database.Type_service.ToList();
        }

        private void addService_Click(object sender, RoutedEventArgs e)
        {
            ServiceViewModel.SaveService();
            ServiceWindow srvWin = new ServiceWindow();
            srvWin.Show();        
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow srvWin = new ServiceWindow();
            srvWin.Show();
            Close();
        }
    }
}
