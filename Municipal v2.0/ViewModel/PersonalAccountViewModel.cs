using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Municipal_v2._0.ViewModel
{
   public class PersonalAccountViewModel
    {
        public Personal_account selectedPersonalAccount { get; set; }

        public ObservableCollection<Personal_account> Personal_Accounts { get; set; }

        public Owner selectedOwner { get; set; }

        public PersonalAccountViewModel()
        {
            Personal_Accounts = new ObservableCollection<Personal_account>(Connection.Database.Personal_account.ToArray());
        }

        public void savePersonalAccount()
        {

            Personal_Accounts.Add(selectedPersonalAccount);
            Connection.Database.Personal_account.Add(selectedPersonalAccount);
            Connection.Database.SaveChanges();
        }

        public void DeletePersonalAccount()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedPersonalAccount == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Personal_account.Remove(selectedPersonalAccount);
            Personal_Accounts.Remove(selectedPersonalAccount);
            Connection.Database.SaveChanges();
        }


    }
}
