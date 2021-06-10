using Municipal.ViewModel;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Municipal_v2._0.ViewModel
{
 public  class OwnerViewModel
    {
        public Owner selectedOwner { get; set; }
        
        public ObservableCollection<Owner> Owners { get; set; }    

        public RelayCommand RemoveCommand { get; set; }

        public OwnerViewModel()
        {
            Owners = new ObservableCollection<Owner>(Connection.Database.Owner.ToArray());

        }

        public void SaveOwner()
        {
            if (selectedOwner.owner_id <1)
            {
                Owners.Add(selectedOwner);
                Connection.Database.Owner.Add(selectedOwner);
                Connection.Database.SaveChanges();              

            }
            else
            {
                Connection.Database.SaveChanges();
            }
        }

  


        public void RemoveOwner()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedOwner == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Owner.Remove(selectedOwner);
                    Owners.Remove(selectedOwner);
                    Connection.Database.SaveChanges();           
        }


      


    }
}
