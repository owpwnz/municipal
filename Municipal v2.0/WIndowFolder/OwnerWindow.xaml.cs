using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
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
using Municipal_v2._0.WIndowFolder;
using Municipal_v2._0.AddWIndowFolder;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Municipal_v2._0.WIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для OwnerWindow.xaml
    /// </summary>
    public partial class OwnerWindow : MetroWindow
    {
        private OwnerViewModel ViewModel;

        private OwnerBenefitViewModel ViewModel1;

        private PersonalAccountViewModel ViewModel2;

       

        public OwnerWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new OwnerViewModel();

            genderComboBox.ItemsSource = Connection.Database.Gender.ToList();
            
            benefitDataGrid.DataContext = ViewModel1 = new OwnerBenefitViewModel();

            adresDataGrid.DataContext = ViewModel2 = new PersonalAccountViewModel();

            nameDocumentComboBox.SelectedIndex = 0;
            findComboBox.SelectedIndex = 0;   
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel.selectedOwner = new Model.Owner();
            AddOwner addOwn = new AddOwner(ViewModel);
            addOwn.ShowDialog();          
        }

        private void changeOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChangeOwner chngOwn = new ChangeOwner(ViewModel);
            chngOwn.ShowDialog();
        }

        private void ownerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.selectedOwner != null)
            {
                benefitDataGrid.ItemsSource = Connection.Database.OwnerBenefit.ToList().Where(x => x.owner_id == ViewModel.selectedOwner.owner_id);
                adresDataGrid.ItemsSource = Connection.Database.Personal_account.ToList().Where(x => x.owner_id == ViewModel.selectedOwner.owner_id);
            }
            if (ViewModel.selectedOwner == null)
            {
               
            }
        }

        private void addBenefitOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel1.selectedOwnerBenefit = new Model.OwnerBenefit();
            AddBenefitOwner addBenOwn = new AddBenefitOwner(ViewModel1);
            addBenOwn.ShowDialog();
        }

        private void deleteBenefitOwner_Click(object sender, RoutedEventArgs e)
        {
            ViewModel1.RemoveOwnerBenefit();
            benefitDataGrid.ItemsSource = Connection.Database.OwnerBenefit.ToList().Where(x => x.owner_id == ViewModel.selectedOwner.owner_id);
        }

        private void deleteOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveOwner();
            benefitDataGrid.ItemsSource = null;
        }

        private void addPersonalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ViewModel2.selectedPersonalAccount = new Model.Personal_account();
            AddPersonalAccount addPerAcc = new AddPersonalAccount(ViewModel2);
            addPerAcc.Show();
        }

        private void deletePersonalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel2.DeletePersonalAccount();
            adresDataGrid.ItemsSource = Connection.Database.Personal_account.ToList().Where(x => x.owner_id == ViewModel.selectedOwner.owner_id);
        }
    }
}
