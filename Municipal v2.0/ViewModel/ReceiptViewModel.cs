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
    public class ReceiptViewModel
    {
        public Receipt selectedRecepit { get; set; }
        
        public ObservableCollection<Receipt> Receipts { get; set; }

        public ReceiptViewModel()
        {
            Receipts = new ObservableCollection<Receipt>(Connection.Database.Receipt.ToArray());
        }
        public void saveReceipt ()
        {
            Receipts.Add(selectedRecepit);
            Connection.Database.Receipt.Add(selectedRecepit);
            Connection.Database.SaveChanges();
        }
        public void changeReceipt ()
        {
            Connection.Database.SaveChanges();
        }
        public void deleteReceipt ()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedRecepit == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Receipt.Remove(selectedRecepit);
            Receipts.Remove(selectedRecepit);
            Connection.Database.SaveChanges();
        }
    }
}
