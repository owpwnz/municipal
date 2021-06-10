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
  public  class AddressViewModel
    {
        public House selectedHouse { get; set; }
        public ObservableCollection<House> Houses { get; set; }


        public AddressViewModel()
        {
            Houses = new ObservableCollection<House>(Connection.Database.House.ToArray());
        }


        public void SaveHouse()
        {       
                Houses.Add(selectedHouse);
                Connection.Database.House.Add(selectedHouse);
                Connection.Database.SaveChanges();
        }

        public void DeleteHouse()
        {

            
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedHouse == null || result == MessageBoxResult.No)
                return;
            Connection.Database.House.Remove(selectedHouse);
                    Houses.Remove(selectedHouse);
                    Connection.Database.SaveChanges();
             
        }
    }
}
