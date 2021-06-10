using MahApps.Metro.Controls;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
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
    /// Логика взаимодействия для AddPersonalAccount.xaml
    /// </summary>
    public partial class AddPersonalAccount : MetroWindow
    {
        private ViewModel.PersonalAccountViewModel PersonalAccountViewModel;

        public AddPersonalAccount(ViewModel.PersonalAccountViewModel personalAccountViewModel)
        {
            InitializeComponent();

            DataContext = personalAccountViewModel.selectedPersonalAccount;
            PersonalAccountViewModel = personalAccountViewModel;

            

            ownerComboBox.ItemsSource = Connection.Database.Owner.ToList();
            ownerIdComboBox.ItemsSource = Connection.Database.Owner.ToList();
            adresComboBox.ItemsSource = Connection.Database.House.ToList();
        }

   
    

        private void saveButoon_Click(object sender, RoutedEventArgs e)
        {
            PersonalAccountViewModel.savePersonalAccount();
            OwnerWindow ownWin = new OwnerWindow();
            ownWin.Show();
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownWin = new OwnerWindow();
            ownWin.Show();
            Close();
        }

        private void adresComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var d = ((adresComboBox.SelectedItem as House).house_id);


            flatComboBox.ItemsSource = Connection.Database.Apartment.ToList().Where(x => x.house_id == d);
        }
    }
}
