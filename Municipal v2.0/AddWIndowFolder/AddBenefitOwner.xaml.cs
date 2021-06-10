using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using Municipal_v2._0.ViewModel;
using Municipal_v2._0.WIndowFolder;
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
    /// Логика взаимодействия для AddBenefitOwner.xaml
    /// </summary>
    public partial class AddBenefitOwner : MetroWindow
    {
        private ViewModel.OwnerBenefitViewModel OwnerBenefitViewModel;

      
        public AddBenefitOwner(ViewModel.OwnerBenefitViewModel ownerBenefitViewModel)
        {
            InitializeComponent();

            DataContext = ownerBenefitViewModel.selectedOwnerBenefit;
            OwnerBenefitViewModel = ownerBenefitViewModel;

            ownerIdComboBox.ItemsSource = Connection.Database.Owner.ToList();
            ownerComboBox.ItemsSource = Connection.Database.Owner.ToList();
            benefitComboBox.ItemsSource = Connection.Database.Benefit.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            OwnerBenefitViewModel.SaveOwnerBenefit();
            MessageBox.Show("Льгота добавлена");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                OwnerWindow ownWin = new OwnerWindow();
                ownWin.Show();
                Close();
            
        }
    }
}
