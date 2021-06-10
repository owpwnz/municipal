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
    public class ServiceViewModel
    {
        public Service selectedService { get; set; }

        public ObservableCollection<Service> Services { get; set; }


        public ServiceViewModel()
        {
            Services = new ObservableCollection<Service>(Connection.Database.Service.ToArray());
        }

        public void SaveService ()
        {


            if (selectedService.service_id < 1)
            {
                Services.Add(selectedService);
                Connection.Database.Service.Add(selectedService);
                Connection.Database.SaveChanges();
            }
            else
            {
                Connection.Database.SaveChanges();
            }
        }

        public void DeleteService()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedService == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Service.Remove(selectedService);
            Services.Remove(selectedService);
            Connection.Database.SaveChanges();
        }

    }
}
