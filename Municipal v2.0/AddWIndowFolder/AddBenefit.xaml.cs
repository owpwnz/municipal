using MahApps.Metro.Controls;
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
    /// Логика взаимодействия для AddBenefit.xaml
    /// </summary>
    public partial class AddBenefit : MetroWindow
    {
        private ViewModel.BenefitViewModel BenefitViewModel;

        public AddBenefit(ViewModel.BenefitViewModel benefitViewModel)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            DataContext = benefitViewModel.selectedBenefit;
            BenefitViewModel = benefitViewModel;
        }

        private void addBenefit_Click(object sender, RoutedEventArgs e)
        {
            BenefitViewModel.SaveBenefit();
            BenefitWindow benWin = new BenefitWindow();
            benWin.Show();
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            BenefitWindow benWin = new BenefitWindow();
            benWin.Show();
            Close();
        }
    }
}
