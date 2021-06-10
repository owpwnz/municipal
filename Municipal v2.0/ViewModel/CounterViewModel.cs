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
   public  class CounterViewModel
    {

        public Counter selectedCounter { get; set; }
        public ObservableCollection<Counter> Counters { get; set; }


        public  CounterViewModel()
        {
            Counters = new ObservableCollection<Counter>(Connection.Database.Counter.ToArray());
        }

        public void SaveCounter()
        {
            Counters.Add(selectedCounter);
            Connection.Database.Counter.Add(selectedCounter);
            Connection.Database.SaveChanges();
        }

        public void ChangeCounter()
        {
            Connection.Database.SaveChanges();
        }


        public void DeleteCounter()
        {

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedCounter == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Counter.Remove(selectedCounter);
            Counters.Remove(selectedCounter);
            Connection.Database.SaveChanges();

        }
    }
}
