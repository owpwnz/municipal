using MahApps.Metro.Controls;
using Municipal_v2._0.AddWIndowFolder;
using Municipal_v2._0.ViewModel;
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

namespace Municipal_v2._0.WIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : MetroWindow
    {

        private ServiceViewModel ViewModel;

        public ServiceWindow()
        {
           
            InitializeComponent();
            DataContext = ViewModel = new ServiceViewModel();
        }

        private void addServiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel.selectedService = new Model.Service();
            AddService addServ = new AddService(ViewModel);
            addServ.ShowDialog();
        }

        private void deleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteService();
        }

        private void changeServiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddService addServ = new AddService(ViewModel);
            addServ.ShowDialog();
        }
    }
}
