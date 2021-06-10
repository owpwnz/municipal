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
    /// Логика взаимодействия для AddIndividualUsed.xaml
    /// </summary>
    public partial class AddIndividualUsed : MetroWindow
    {
        private ViewModel.IndividualAmountViewModel IndividualAmountViewModel;

        public AddIndividualUsed(ViewModel.IndividualAmountViewModel individualAmountViewModel)
        {
            InitializeComponent();
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataContext = individualAmountViewModel.selectedIndividualAmount;
            IndividualAmountViewModel = individualAmountViewModel;
            houseComboBox.ItemsSource = Connection.Database.House.ToList();
        }

        private void houseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            var selectedHouse = ((houseComboBox.SelectedItem as House).house_id);
            serviceComboBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.House.house_id == selectedHouse && x.Service.type_service_id == 2);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            IndividualAmountViewModel.selectedIndividualAmount.date = dt;
            IndividualAmountViewModel.SaveIndividual();
            MessageBox.Show("Рассчитано");
        }

 
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            IndicationWindow2 indWin = new IndicationWindow2();
            indWin.Show();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(datePicker.SelectedDate);
            var selectedHouse = ((houseComboBox.SelectedItem as House).house_id);
            var selectedService = ((serviceComboBox.SelectedItem as HouseService).service_id);
            var summ = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == selectedService && x.date == dt && x.HouseService.house_id == selectedHouse).Sum(k=> k.used);
            usedTextBox.Text = Convert.ToString(summ);
        }
    }
}
