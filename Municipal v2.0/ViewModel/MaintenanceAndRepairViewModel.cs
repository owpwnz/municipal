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
   public class MaintenanceAndRepairViewModel
    {
        public Maintenance_and_repair selectedMaintenceAndRepair { get; set; }

        public HouseService selectedHouseService { get; set;}

        public ObservableCollection<Maintenance_and_repair> MaintenanceAndRepairs { get; set; }

        public MaintenanceAndRepairViewModel()
        {
            MaintenanceAndRepairs = new ObservableCollection<Maintenance_and_repair>(Connection.Database.Maintenance_and_repair.ToArray());
        }


        public void SaveMaintenceAndRepair()
        {
            MaintenanceAndRepairs.Add(selectedMaintenceAndRepair);
            Connection.Database.Maintenance_and_repair.Add(selectedMaintenceAndRepair);
            Connection.Database.SaveChanges();
        }

        public void DeleteMaintenanceAndRepair()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedMaintenceAndRepair == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Maintenance_and_repair.Remove(selectedMaintenceAndRepair);
            MaintenanceAndRepairs.Remove(selectedMaintenceAndRepair);
            Connection.Database.SaveChanges();

        }

        public void CalculateMatinceAndRepair()
        {
            if (selectedMaintenceAndRepair.HouseService.payment_id == 36) // Видеонаблюдение + орхана
            {
                selectedMaintenceAndRepair.amount = Convert.ToDecimal(selectedMaintenceAndRepair.HouseService.rate * selectedMaintenceAndRepair.Personal_account.Apartment.square);  // Тариф * Общая площадь
                selectedMaintenceAndRepair.amount_pay = Convert.ToDecimal(selectedMaintenceAndRepair.HouseService.rate * selectedMaintenceAndRepair.Personal_account.Apartment.square);
            }
            if (selectedMaintenceAndRepair.HouseService.payment_id == 37) // Домофон
            {
                selectedMaintenceAndRepair.amount = Convert.ToDecimal(selectedMaintenceAndRepair.HouseService.rate); //Тариф
                selectedMaintenceAndRepair.amount_pay = Convert.ToDecimal(selectedMaintenceAndRepair.HouseService.rate * selectedMaintenceAndRepair.Personal_account.Apartment.square);
            }
            if (selectedMaintenceAndRepair.HouseService.payment_id == 38) // Содержание и ремонт общего имущества
            {
               selectedMaintenceAndRepair.amount = Convert.ToDecimal(selectedMaintenceAndRepair.HouseService.rate * selectedMaintenceAndRepair.Personal_account.Apartment.square);  // Тариф * Общая площадь
               selectedMaintenceAndRepair.amount_pay = Convert.ToDecimal(selectedMaintenceAndRepair.HouseService.rate * selectedMaintenceAndRepair.Personal_account.Apartment.square);
            }  
        } 
    }
}
