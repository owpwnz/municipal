using Municipal.ViewModel;
using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Municipal_v2._0.ViewModel
{
   public class OwnerBenefitViewModel 
    {
       
        public OwnerBenefit selectedOwnerBenefit { get; set; }

        public ObservableCollection<OwnerBenefit> OwnerBenefits { get; set; }
        public RelayCommand RemoveCommand { get; set; }


        public OwnerBenefitViewModel()
        {        
            OwnerBenefits = new ObservableCollection<OwnerBenefit>(Connection.Database.OwnerBenefit.ToArray());
             

        RemoveCommand = new RelayCommand(
              (param) =>
                  {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedOwnerBenefit == null || result == MessageBoxResult.No) return;
            RemoveOwnerBenefit();
        },
                  (param) => selectedOwnerBenefit != null
                  );

        }

    

        public void RemoveOwnerBenefit()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedOwnerBenefit == null || result == MessageBoxResult.No)
                return;
                    Connection.Database.OwnerBenefit.Remove(selectedOwnerBenefit);
                    OwnerBenefits.Remove(selectedOwnerBenefit);
                    Connection.Database.SaveChanges();
        }

        public void SaveOwnerBenefit()
        {
            OwnerBenefits.Add(selectedOwnerBenefit);
            Connection.Database.OwnerBenefit.Add(selectedOwnerBenefit);
            Connection.Database.SaveChanges();
        }

    }
}
