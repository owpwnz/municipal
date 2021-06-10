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
    /// Логика взаимодействия для BenefitService.xaml
    /// </summary>
    public partial class BenefitService : MetroWindow
    {
        private ViewModel.BenefitViewModel BenefitViewModel;

        private BenefitServiceViewModel ViewModel;

        public BenefitService(ViewModel.BenefitViewModel benefitViewModel)
        {
            InitializeComponent();
            DataContext = benefitViewModel.selectedBenefit;
            BenefitViewModel = benefitViewModel;
            benefitServiceDataGrid.ItemsSource = Connection.Database.BenefitService.ToList().Where(x=> x.benefit_id == BenefitViewModel.selectedBenefit.benefit_id);
            benefitServiceDataGrid.DataContext = ViewModel = new BenefitServiceViewModel();
        }

        private void removeCounterButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveBenefitService();
        }

        private void changeCounteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel.selectedBenefitService = new Model.BenefitService();
            AddBenefitService addBenServ = new  AddBenefitService(ViewModel);
            addBenServ.ShowDialog();
            
        }
    }
}
