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

namespace Municipal_v2._0.ViewModel
{
    public class BenefitServiceViewModel
    {
        public BenefitService selectedBenefitService { get; set; }

        public ObservableCollection<BenefitService> BenefitServices { get; set; }
        public RelayCommand RemoveCommand { get; set; }


        public BenefitServiceViewModel()
        {
            BenefitServices = new ObservableCollection<BenefitService>(Connection.Database.BenefitService.ToArray());


            RemoveCommand = new RelayCommand(
                  (param) =>
                  {
                      MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                      if (selectedBenefitService == null || result == MessageBoxResult.No) return;
                      RemoveBenefitService();
                  },
                      (param) => selectedBenefitService != null
                      );

        }



        public void RemoveBenefitService()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedBenefitService == null || result == MessageBoxResult.No)
                return;
            Connection.Database.BenefitService.Remove(selectedBenefitService);
            BenefitServices.Remove(selectedBenefitService);
            Connection.Database.SaveChanges();
        }

        public void SaveBenefitService()
        {
            BenefitServices.Add(selectedBenefitService);
            Connection.Database.BenefitService.Add(selectedBenefitService);
            Connection.Database.SaveChanges();
        }
    }
}
