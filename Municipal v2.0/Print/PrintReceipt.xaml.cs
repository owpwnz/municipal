using Municipal_v2._0.Class;
using Municipal_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using Municipal_v2._0.ConverterImage;
using QRCoder;
using MahApps.Metro.Controls;

namespace Municipal_v2._0.Print
{
    /// <summary>
    /// Логика взаимодействия для PrintReceipt.xaml
    /// </summary>
    public partial class PrintReceipt : MetroWindow
    {
        

        public PrintReceipt()
        {
            InitializeComponent();
            personalComboBox.ItemsSource = Connection.Database.Personal_account.ToList();
            ukComboBox.ItemsSource = Connection.Database.info_UK.ToList();
            ukComboBox.SelectedIndex = 0;

        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(printGrid, "Печать");
            }


        }

        private void personalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var personalID = ((personalComboBox.SelectedItem as Personal_account).personal_id);
            var personalID1 = ((personalComboBox.SelectedItem as Personal_account).Apartment.House.house_id);

            serviceListBox.ItemsSource = Connection.Database.HouseService.ToList().Where(x => x.house_id == personalID1 && x.Service.type_service_id == 2 || x.house_id == personalID1 && x.Service.type_service_id == 1);
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            monthTextBlock3.Text = datePicker.DisplayDate.ToString("MMM");
            string before = monthTextBlock3.Text;
            String after = before.Substring(0, 1).ToUpper() + before.Substring(1);
            monthTextBlock3.Text = after;
            yearTextBlock3.Text = Convert.ToString(datePicker.DisplayDate.Year);


            string before1 = monthTextBlock3.Text;
            String after1 = before.Substring(0, 1).ToUpper() + before.Substring(1);
            monthTextBlock1.Text = after;
            yearTextBlock1.Text = Convert.ToString(datePicker.DisplayDate.Year);

            string before2 = monthTextBlock3.Text;
            String after2 = before.Substring(0, 1).ToUpper() + before.Substring(1);
            monthTextBlock2.Text = after;
            yearTextBlock2.Text = Convert.ToString(datePicker.DisplayDate.Year);


            datePayBeforeTextBlock.Text = datePicker.DisplayDate.ToString("dd-MMM-yy"); 

            var selectedDate = datePicker.SelectedDate;
            var personalID = ((personalComboBox.SelectedItem as Personal_account).personal_id);
            var personalID1 = ((personalComboBox.SelectedItem as Personal_account).Apartment.House.house_id);
            var personalID2 = ((personalComboBox.SelectedItem as Personal_account).apartment_id);


            nameServiceGrid.ItemsSource = Connection.Database.Public_utilities.ToList().Where(x => x.personal_id == personalID && x.HouseService.Service.type_service_id == 2 && x.date == selectedDate);
            nameServiceGrid1.ItemsSource = Connection.Database.Maintenance_and_repair.ToList().Where(x => x.personal_id == personalID && x.HouseService.Service.type_service_id == 1 && x.date == selectedDate);
            nameServiceGrid2.ItemsSource = Connection.Database.Public_utilities.ToList().Where(x => x.personal_id == personalID && x.HouseService.Service.type_service_id == 3 && x.date == selectedDate);


            amountListBox.ItemsSource = Connection.Database.Receipt.ToList().Where(x => x.personal_id == personalID && x.date == selectedDate);


            amountComboBox.ItemsSource = Connection.Database.Receipt.ToList().Where(x => x.personal_id == personalID && x.date == selectedDate);
            amountComboBox.SelectedIndex = 0;



            var qrText = "Name=" + ukNameTextBlock.Text + "PersonalAcc=" + rsTextBlock.Text + "Bankname=" + nameBankTextBlock.Text + "BIC=" + bikTextBlock.Text + "CorrespAcc=" + ksTextBlock.Text + "Sum=" + amountTextBlock.Text
            + "PayeeINN=" + innTextBlock.Text + "lastName=" + lastNameTextBlock.Text + "firstName=" + firstNameTextBlock1.Text + "middleName=" + middleNameTextBlock.Text + "payerAdress" + adress1.Text + adress2.Text + adress3.Text + adress4.Text + adress5.Text
            + "persAcc=" + personalTextBlock.Text + "payTerm" + datePayBeforeTextBlock.Text + "payPeriod" + monthTextBlock3.Text + yearTextBlock3.Text + "SumPay=" + amountTextBlock.Text;

            QRCodeGenerator qr = new QRCodeGenerator();
            var data = qr.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);

            QRCode code = new QRCode(data);
            qrCodeImage.Source = ConverterImageQR.ToBitmapImage(code.GetGraphic(5));


        }
    }
}
