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
  public  class IndividualAmountViewModel
    {
        public Individual_amount selectedIndividualAmount { get; set; }

        public ObservableCollection<Individual_amount> Individual_Amounts { get; set; }

        public IndividualAmountViewModel()
        {
            Individual_Amounts = new ObservableCollection<Individual_amount>(Connection.Database.Individual_amount.ToArray());
        }

  

        public void SaveIndividual()
        {
            Individual_Amounts.Add(selectedIndividualAmount);
            Connection.Database.Individual_amount.Add(selectedIndividualAmount);
            Connection.Database.SaveChanges();
        }

        public void DeleteIndividual()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedIndividualAmount == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Individual_amount.Remove(selectedIndividualAmount);
            Individual_Amounts.Remove(selectedIndividualAmount);
            Connection.Database.SaveChanges();
        }

        public void CalculateIndividual()
        {

        }

    }
}

