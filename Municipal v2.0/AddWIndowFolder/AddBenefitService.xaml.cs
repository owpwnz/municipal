using MahApps.Metro.Controls;
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

namespace Municipal_v2._0.AddWIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddBenefitService.xaml
    /// </summary>
    public partial class AddBenefitService : MetroWindow
    {
        private ViewModel.BenefitServiceViewModel BenefitServiceViewModel;



        public AddBenefitService(ViewModel.BenefitServiceViewModel benefitServiceViewModel)
        {
            InitializeComponent();
            DataContext = benefitServiceViewModel.selectedBenefitService;
            BenefitServiceViewModel = benefitServiceViewModel;
            houseComboBox.ItemsSource = Connection.Database.Benefit.ToList();
            counterComboBox.ItemsSource = Connection.Database.Service.ToList();

        }

        private void addCounterButton_Click(object sender, RoutedEventArgs e)
        {
            BenefitServiceViewModel.SaveBenefitService();
            MessageBox.Show("Услуга добавлена");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
