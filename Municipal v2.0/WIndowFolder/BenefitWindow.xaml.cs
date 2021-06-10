using MahApps.Metro.Controls;
using Municipal_v2._0.AddWIndowFolder;
using Municipal_v2._0.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Municipal_v2._0.WIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для BenefitWindow.xaml
    /// </summary>
    public partial class BenefitWindow : MetroWindow
    {
        private BenefitViewModel ViewModel;

        public BenefitWindow()
        {
            InitializeComponent();

            DataContext = ViewModel = new BenefitViewModel();

           

        }

        private void addBenefitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel.selectedBenefit = new Model.Benefit();
            AddBenefit addBen = new AddBenefit(ViewModel);
            addBen.Show();
        }

        private void changeBenefitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AddBenefit addBen = new AddBenefit(ViewModel);
            addBen.Show();
        }

        private void deleteBenefitButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveBenefit();
        }

        private void benefitServiceButton_Click(object sender, RoutedEventArgs e)
        {
            BenefitServiceWIndow1 benSrv = new BenefitServiceWIndow1(ViewModel);
            benSrv.ShowDialog();
        }
    }
}
