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
    public class HousePublicUtilitiesViewModel
    {
        public House_public_utilities selectedHousePublic { get; set; }
        public ObservableCollection<House_public_utilities> housePublicUtilitiess { get; set; }


        public HousePublicUtilitiesViewModel ()
        {
            housePublicUtilitiess = new ObservableCollection<House_public_utilities>(Connection.Database.House_public_utilities.ToArray());
        }

        public void saveHousePublic()
        {
            try
            {
                housePublicUtilitiess.Add(selectedHousePublic);
                Connection.Database.House_public_utilities.Add(selectedHousePublic);
                Connection.Database.SaveChanges();
            }
            catch
            {

            }
        }

        public void deleteHousePublic()
        {

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedHousePublic == null || result == MessageBoxResult.No)
                return;
            Connection.Database.House_public_utilities.Remove(selectedHousePublic);
            housePublicUtilitiess.Remove(selectedHousePublic);
            Connection.Database.SaveChanges();
        }

        public void calculateHousePublic()
        {
            //if (selectedHousePublic.House_counter.HouseService.payment_id == 6)
            ////{
            ////    selectedHousePublic.amount = selectedHousePublic.used * Convert.ToSingle(selectedHousePublic.House_counter.HouseService.rate);
            //}
        }

    }
}
