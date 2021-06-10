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
   public  class HouseCounterViewModel
    {
        public House_counter selectedHouseCounter { get; set; }
        public ObservableCollection<House_counter> house_Counters { get; set; }
    
        public HouseCounterViewModel()
        {
            house_Counters = new ObservableCollection<House_counter>(Connection.Database.House_counter.ToArray());
        }

        public void saveHouseCounter ()
        {
            house_Counters.Add(selectedHouseCounter);
            Connection.Database.House_counter.Add(selectedHouseCounter);
            Connection.Database.SaveChanges();
        }

        public void deleteHouseCounter()
        {

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedHouseCounter == null || result == MessageBoxResult.No)
                return;
            Connection.Database.House_counter.Remove(selectedHouseCounter);
            house_Counters.Remove(selectedHouseCounter);
            Connection.Database.SaveChanges();

        }

    }
}
