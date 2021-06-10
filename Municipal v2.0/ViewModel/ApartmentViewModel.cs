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
   public class ApartmentViewModel
    {
        public Apartment selectedApartment { get; set; }
        public ObservableCollection<Apartment> Apartments { get; set; }

        public ApartmentViewModel()
        {
            Apartments = new ObservableCollection<Apartment>(Connection.Database.Apartment.ToArray());
        }

        public void SaveApartment()
        {    
               Apartments.Add(selectedApartment);
               Connection.Database.Apartment.Add(selectedApartment);
               Connection.Database.SaveChanges();  
        }

        public void ChangeApartment()
        {
            Connection.Database.SaveChanges();
        }

        public void DeleteApartment()
        {

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedApartment == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Apartment.Remove(selectedApartment);
                    Apartments.Remove(selectedApartment);
                    Connection.Database.SaveChanges();
             
        }

    }
}
