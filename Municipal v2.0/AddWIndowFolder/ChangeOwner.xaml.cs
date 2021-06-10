using MahApps.Metro.Controls;
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
    using Class;
    using Municipal_v2._0.Model;
    using Municipal_v2._0.WIndowFolder;

    /// <summary>
    /// Логика взаимодействия для ChangeOwner.xaml
    /// </summary>
    public partial class ChangeOwner : MetroWindow
    {

        private ViewModel.OwnerViewModel OwnerViewModel;

        public ChangeOwner(ViewModel.OwnerViewModel ownerViewModel)
        {
            InitializeComponent();
            DataContext = ownerViewModel.selectedOwner;
            OwnerViewModel = ownerViewModel;
            genderComboBox.ItemsSource = Connection.Database.Gender.ToList();
      

            nameDocumentComboBox.SelectedIndex = 0;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ownWin = new OwnerWindow();
            ownWin.Show();
            Close();

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            OwnerWindow ownWin = new OwnerWindow();
            ownWin.Show();
            OwnerViewModel.SaveOwner();
            Close();


        }

       
    }
}
