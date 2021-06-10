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
    public class BenefitViewModel
    {
        public Benefit selectedBenefit { get; set; }

        public ObservableCollection<Benefit> Benefits { get; set; }

        public BenefitViewModel()
        {
            Benefits = new ObservableCollection<Benefit>(Connection.Database.Benefit.ToArray());
        }



        public void SaveBenefit()
        {
            if (selectedBenefit.benefit_id < 1)
            {
                Benefits.Add(selectedBenefit);
                Connection.Database.Benefit.Add(selectedBenefit);
                Connection.Database.SaveChanges();

            }
            else
            {
                Connection.Database.SaveChanges();
            }
        }




        public void RemoveBenefit()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedBenefit == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Benefit.Remove(selectedBenefit);
            Benefits.Remove(selectedBenefit);
            Connection.Database.SaveChanges();
        }


    }
}
