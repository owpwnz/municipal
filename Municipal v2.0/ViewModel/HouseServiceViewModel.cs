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
    public class HouseServiceViewModel
    {

        public HouseService selectedHouseService { get; set; }
        public ObservableCollection<HouseService> houseServices { get; set; }


        public HouseServiceViewModel()
        {
            houseServices = new ObservableCollection<HouseService>(Connection.Database.HouseService.ToArray());
        }

        public void SaveHouseService()
        {

                houseServices.Add(selectedHouseService);
                Connection.Database.HouseService.Add(selectedHouseService);
                Connection.Database.SaveChanges();  
        }

        public void ChangeHouseService()
        {

                Connection.Database.SaveChanges();
            
        }

    public void DeleteHoseService()
        {

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedHouseService == null || result == MessageBoxResult.No)
                return;
            Connection.Database.HouseService.Remove(selectedHouseService);
            houseServices.Remove(selectedHouseService);
            Connection.Database.SaveChanges();

        }
    }
}
