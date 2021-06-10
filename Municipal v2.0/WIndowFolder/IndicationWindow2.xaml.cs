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
    /// Логика взаимодействия для IndicationWindow2.xaml
    /// </summary>
    public partial class IndicationWindow2 : MetroWindow
    {
        private IndividualAmountViewModel ViewModel;
        private HousePublicUtilitiesViewModel ViewModel2;
        public IndicationWindow2()
        {
            InitializeComponent();
            DataContext = ViewModel = new IndividualAmountViewModel();
            ViewModel2 = new HousePublicUtilitiesViewModel();
            generalDataGrid.DataContext = ViewModel2;
            generalDataGrid.ItemsSource = Connection.Database.House_public_utilities.ToList();

            (individualDataGrid.Columns[3] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
            (generalDataGrid.Columns[3] as DataGridTextColumn).Binding.StringFormat = "dd.MM.yyyy";
        }

 
        private void addHousePublic_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel2.selectedHousePublic = new Model.House_public_utilities();
            AddHousePublic addHousePub = new AddHousePublic(ViewModel2);
            addHousePub.Show();
        }
        private void deleteHousePublic_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.deleteHousePublic();
            generalDataGrid.DataContext = ViewModel2;
            generalDataGrid.ItemsSource = Connection.Database.House_public_utilities.ToList();
        }

        private void addPublicButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.selectedIndividualAmount = new Model.Individual_amount();
            AddIndividualUsed addIndivUse = new AddIndividualUsed(ViewModel);
            addIndivUse.Show();
            this.Close();
        }

        private void deletePublicButon_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteIndividual();
            individualDataGrid.DataContext = ViewModel;
            individualDataGrid.ItemsSource = Connection.Database.Individual_amount.ToList();
        }
    }
}
