using MahApps.Metro.Controls;
using Municipal_v2._0.AddWIndowFolder;
using Municipal_v2._0.Class;
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
    /// Логика взаимодействия для IndicationWindow.xaml
    /// </summary>
    public partial class IndicationWindow : MetroWindow
    {
        private PublicUtilitiesViewModel ViewModel;

        private MaintenanceAndRepairViewModel ViewModel2;

 
        public IndicationWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new PublicUtilitiesViewModel();

            (publicDataGrid.Columns[9] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
            (maintenanceDataGrid.Columns[6] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";

            ViewModel2 = new MaintenanceAndRepairViewModel();

            maintenanceDataGrid.DataContext = ViewModel2;
            maintenanceDataGrid.ItemsSource = Connection.Database.Maintenance_and_repair.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.DeleteMaintenanceAndRepair();
        }

        private void addMaintenceButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.selectedMaintenceAndRepair = new Model.Maintenance_and_repair();
            AddMaintenance addMain = new AddMaintenance(ViewModel2);
            addMain.Show();
            this.Close();
        }

        private void deleteMaintenceButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.DeleteMaintenanceAndRepair();
            maintenanceDataGrid.ItemsSource = Connection.Database.Maintenance_and_repair.ToList();
        }

        private void deletePublicButon_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeletePublicUtilities();
        }
        private void addPublicButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddPublic1 addPub = new AddPublic1();
            addPub.ShowDialog();
        }
    }
}
