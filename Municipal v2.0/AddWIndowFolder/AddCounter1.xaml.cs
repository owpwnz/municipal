using MahApps.Metro.Controls;
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

namespace Municipal_v2._0.AddWIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddCounter1.xaml
    /// </summary>
    public partial class AddCounter1 : MetroWindow
    {
        private CounterViewModel ViewModel;

        public AddCounter1()
        {
            InitializeComponent();
            DataContext = ViewModel = new CounterViewModel();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.selectedCounter = new Model.Counter();
            mainFrame.Navigate(new PageFolder.AddCounterPage(ViewModel));
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.selectedCounter = new Model.Counter();
            mainFrame.Navigate(new PageFolder.AddCounterAutoPage(ViewModel));
        }
    }
}
