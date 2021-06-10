using MahApps.Metro.Controls;
using Municipal_v2._0.Model;
using Municipal_v2._0.ViewModel;
using Municipal_v2._0.WIndowFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Municipal_v2._0.AddWIndowFolder
{
    /// <summary>
    /// Логика взаимодействия для AddHouse.xaml
    /// </summary>
    public partial class AddHouse : MetroWindow
    {
        private ViewModel.AddressViewModel AddressViewModel;

        public AddHouse(ViewModel.AddressViewModel addressViewModel)
        {
            InitializeComponent();

            DataContext = addressViewModel.selectedHouse;
            AddressViewModel = addressViewModel;

        }

        dynamic d;
        string cityID;
        string streetID;

        private void regionTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
            "https://kladr-api.ru/api.php?query=" + regionTextBox.Text + "&contentType=region&withParent=1&limit=7");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            d = JsonConvert.DeserializeObject(sReadData);
            for (int i = 1; i < 5; i++)
            {
                try
                {
                    regionListBox.Items.Add(d.result[i].name + " " + d.result[i].typeShort + ".");
                }
                catch (Exception error)
                {

                }
            }
        }



        private void regionTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            regionListBox.Items.Clear();

            regionListBox.Visibility = Visibility.Visible;

            if (regionListBox.Visibility == Visibility.Visible)
            {
                cityTextBox.Visibility = Visibility.Hidden;
                streetTextBox.Visibility = Visibility.Hidden;
                houseTextBox.Visibility = Visibility.Hidden;
            }
        }

        private void regionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regionTextBox.Text == "")
            {
                regionListBox.Visibility = Visibility.Hidden;
            }

            if (regionListBox.Visibility == Visibility.Hidden)
            {
                cityTextBox.Visibility = Visibility.Visible;
                streetTextBox.Visibility = Visibility.Visible;
                houseTextBox.Visibility = Visibility.Visible;
            }
        }

        private void cityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
               "https://kladr-api.ru/api.php?query=" + cityTextBox.Text + "&contentType=city&withParent=1&limit=10");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(sReadData);

            for (int i = 1; i < 5; i++)
            {
                try
                {
                    cityListBox.Items.Add(d.result[i].name);


                }
                catch (Exception error)
                {

                }

            }
        }

        private void cityTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            cityListBox.Items.Clear();
            cityListBox.Visibility = Visibility.Visible;

            if (cityListBox.Visibility == Visibility.Visible)
            {
                streetTextBox.Visibility = Visibility.Hidden;
                houseTextBox.Visibility = Visibility.Hidden;
            }
        }


        private void cityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {                
            if (cityTextBox.Text == "")                                          
            { 
                cityListBox.Visibility = Visibility.Hidden;               
            }          

            if (cityListBox.Visibility == Visibility.Hidden)
            {
                streetTextBox.Visibility = Visibility.Visible;
                houseTextBox.Visibility = Visibility.Visible;
            }                             
        }


        private void cityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
              "https://kladr-api.ru/api.php?query=" + cityTextBox.Text + "&contentType=city&withParent=1&limit=10");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(sReadData);


            try
            {
                cityID = d.result[1].id;
            }
            catch (Exception error)
            {

            }

        }

        private void streetTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                   "https://kladr-api.ru/api.php?cityId=" + cityID + "&query=" + streetTextBox.Text + "&contentType=street");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                string sReadData = sr.ReadToEnd();
                response.Close();

                dynamic d = JsonConvert.DeserializeObject(sReadData);

                for (int i = 1; i < 5; i++)
                {
                    try
                    {
                        streetListBox.Items.Add(d.result[i].zip + " " + d.result[i].name);
                        
                    }
                    catch (Exception error)
                    {

                    }
                }
            }
            catch (Exception error)
            {

            }
        }

        private void streetTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            streetListBox.Items.Clear();

            streetListBox.Visibility = Visibility.Visible;
            if (streetListBox.Visibility == Visibility.Visible)
            {
                houseTextBox.Visibility = Visibility.Hidden;
            }

        }

        private void streetTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (streetTextBox.Text == "")
            {
                streetListBox.Visibility = Visibility.Hidden;
            }

            if (streetListBox.Visibility == Visibility.Hidden)
            {
                houseTextBox.Visibility = Visibility.Visible;
            }

        }


        private void streetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
              "https://kladr-api.ru/api.php?cityId=" + cityID + "&query=" + streetTextBox.Text + "&contentType=street&withParent=1&limit=10");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);

            string sReadData = sr.ReadToEnd();
            response.Close();

            dynamic d = JsonConvert.DeserializeObject(sReadData);


            try
            {
                streetID = d.result[1].id;
            }
            catch (Exception error)
            {

            }

            streetListBox.Visibility = Visibility.Hidden;
            houseTextBox.Visibility = Visibility.Visible;
        }


        private void houseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (houseTextBox.Text == "")
            {
                houseListBox.Visibility = Visibility.Hidden;
                addHouse.Visibility = Visibility.Visible;
                backHouse.Visibility = Visibility.Visible;
            }
        }

        private void houseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                     "https://kladr-api.ru/api.php?cityId=" + cityID + "&streetId=" + streetID + "&query=" + houseTextBox.Text + "&contentType=building&withParent=1&limit=10");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                string sReadData = sr.ReadToEnd();
                response.Close();

                dynamic d = JsonConvert.DeserializeObject(sReadData);

                for (int i = 1; i < 5; i++)
                {
                    try
                    {
                        houseListBox.Items.Add(d.result[i].name);
                    }
                    catch (Exception error)
                    {

                    }
                }
            }
            catch (Exception error)
            {

            }

        }
   
        private void houseTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            houseListBox.Items.Clear();
            houseListBox.Visibility = Visibility.Visible;
            if(houseListBox.Visibility == Visibility.Visible)
            {
                addHouse.Visibility = Visibility.Hidden;
                backHouse.Visibility = Visibility.Hidden;
            }
        }


    private void addHouse_Click(object sender, RoutedEventArgs e)
        {
            AddressViewModel.SaveHouse();
            MessageBox.Show("Дом добавлен");
        }

        private void backHouse_Click(object sender, RoutedEventArgs e)
        {
            AddressWindow addrWin = new AddressWindow();
            addrWin.Show();
            Close();
        }

        private void houseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            houseListBox.Visibility = Visibility.Hidden;
            if (houseListBox.Visibility == Visibility.Hidden)
            {
                addHouse.Visibility = Visibility.Visible;
                backHouse.Visibility = Visibility.Visible;
            }
        }
    }
}
