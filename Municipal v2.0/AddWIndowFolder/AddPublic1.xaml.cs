using ControlzEx.Standard;
using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using Municipal_v2._0.ViewModel;
using Municipal_v2._0.WIndowFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для AddPublic1.xaml
    /// </summary>
    public partial class AddPublic1 : MetroWindow
    {
        private PublicUtilitiesViewModel ViewModel;

        public AddPublic1()
        {
            InitializeComponent();
            DataContext = ViewModel = new PublicUtilitiesViewModel();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.selectedPublicUtilities = new Model.Public_utilities();
            mainFrame.Navigate(new PageFolder.AddPublicPage(ViewModel));
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.selectedPublicUtilities = new Model.Public_utilities();
            mainFrame.Navigate(new PageFolder.AddHousePublicPage(ViewModel));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            IndicationWindow indWin = new IndicationWindow();
            indWin.Show();
        }
    }
}
