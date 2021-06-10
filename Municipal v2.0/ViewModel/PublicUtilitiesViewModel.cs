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
    public class PublicUtilitiesViewModel
    {
        public Public_utilities selectedPublicUtilities { get; set; }

        public ObservableCollection<Public_utilities> Public_utilitiess { get; set; }


        public PublicUtilitiesViewModel()
        {
            Public_utilitiess = new ObservableCollection<Public_utilities>(Connection.Database.Public_utilities.ToArray());
        }

        public void SavePublicUtilities()
        {   
               Public_utilitiess.Add(selectedPublicUtilities);
               Connection.Database.Public_utilities.Add(selectedPublicUtilities);
               Connection.Database.SaveChanges();    
        }
        public void DeletePublicUtilities()
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (selectedPublicUtilities == null || result == MessageBoxResult.No)
                return;
            Connection.Database.Public_utilities.Remove(selectedPublicUtilities);
            Public_utilitiess.Remove(selectedPublicUtilities);
            Connection.Database.SaveChanges();
        }


        public void CalculateAveragePublicUtilities()
        {
            selectedPublicUtilities.used = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToSingle(selectedPublicUtilities.HouseService.norm);
        }

        public void CalculateServicePublicUtilities()
        {
            if (selectedPublicUtilities.HouseService.payment_id == 23 || selectedPublicUtilities.HouseService.payment_id == 26) // Холодное водоснабжение кол.во людей + Горячее водоснабжение кол.во людей 
            {
                selectedPublicUtilities.amount = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate); // Кол.во проживающих  * Норматив * Тариф
                selectedPublicUtilities.amount_pay = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.used = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToSingle(selectedPublicUtilities.HouseService.norm);
            }
                   
            if (selectedPublicUtilities.HouseService.payment_id == 28) // Водоотведение ХВС,ГВС
            {                
                    var coldWaterUsed = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == 59 && x.date == selectedPublicUtilities.date && x.Personal_account.apartment_id == selectedPublicUtilities.Personal_account.apartment_id).Sum(k => k.used);
                    var hotWaterUsed = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == 60 && x.date == selectedPublicUtilities.date && x.Personal_account.apartment_id == selectedPublicUtilities.Personal_account.apartment_id).Sum(k => k.used);
                    var sumWaterUsed = coldWaterUsed + hotWaterUsed;
                    selectedPublicUtilities.used = sumWaterUsed;
                    selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                    selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
            }

            if (selectedPublicUtilities.HouseService.payment_id == 27)
            {
                var hotWaterUsed = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == 60 && x.date == selectedPublicUtilities.date && x.Personal_account.apartment_id == selectedPublicUtilities.Personal_account.apartment_id).Sum(k => k.used);
                selectedPublicUtilities.used = Convert.ToSingle(selectedPublicUtilities.HouseService.norm) * Convert.ToSingle(hotWaterUsed);
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(hotWaterUsed) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(hotWaterUsed) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
            }

            if (selectedPublicUtilities.HouseService.payment_id == 35)
            {
                selectedPublicUtilities.amount = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
            }

            if (selectedPublicUtilities.HouseService.payment_id == 30)
            {
                var housePokazanie = Connection.Database.House_public_utilities.ToList().Where(x=> x.date == selectedPublicUtilities.date && x.HouseService.service_id == selectedPublicUtilities.HouseService.service_id).Sum(k=> k.used);

                var used = housePokazanie * Convert.ToSingle(selectedPublicUtilities.Personal_account.Apartment.square) / Convert.ToSingle(selectedPublicUtilities.Personal_account.Apartment.House.square_residental);
                selectedPublicUtilities.used = used;

                selectedPublicUtilities.amount = Convert.ToDecimal(used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);

            }



        }

        public void CalculateCounterPublicUtilities()
        {
            if (selectedPublicUtilities.Counter.HouseService.payment_id == 22) // Холодное водоснабжение счетчик
            {
                if (selectedPublicUtilities.Counter.bit == true)
                {
                    var amountOnHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.high_coef);
                    var amountOffHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                    selectedPublicUtilities.amount = amountOnHighCoef;
                    selectedPublicUtilities.amount_pay = amountOffHighCoef;
                    selectedPublicUtilities.size_high_coef = selectedPublicUtilities.HouseService.high_coef;
                    selectedPublicUtilities.amount_high_coef = amountOnHighCoef - amountOffHighCoef;
                }
                else
                {
                    selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                    selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                }
            }

            if (selectedPublicUtilities.Counter.HouseService.payment_id == 25) // Горячее водоснабжение подача
            {
                if (selectedPublicUtilities.Counter.bit == true)
                {
                    var amountOnHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.high_coef);
                    var amountOffHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                    selectedPublicUtilities.amount = amountOnHighCoef;
                    selectedPublicUtilities.amount_high_coef = amountOnHighCoef - amountOffHighCoef;
                    selectedPublicUtilities.size_high_coef = selectedPublicUtilities.HouseService.high_coef;
                    selectedPublicUtilities.amount_pay = amountOffHighCoef;
                }
                else
                {
                    selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                    selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                }
            }
            
            if (selectedPublicUtilities.Counter.HouseService.payment_id == 31) // Электроэнергия дн.начисление
            {
                if (selectedPublicUtilities.Counter.bit == true)
                {
                    var amountOnHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.high_coef);
                    var amountOffHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                    selectedPublicUtilities.amount = amountOnHighCoef;
                    selectedPublicUtilities.amount_pay = amountOffHighCoef;
                    selectedPublicUtilities.amount_high_coef = amountOnHighCoef - amountOffHighCoef;
                    selectedPublicUtilities.size_high_coef = selectedPublicUtilities.HouseService.high_coef;
                }
                else
                {
                    selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                    selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                }
            }

            if (selectedPublicUtilities.Counter.HouseService.payment_id == 33) // Электроэнергия нч.начисление
            {
                if (selectedPublicUtilities.Counter.bit == true)
                {
                    var amountOnHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.high_coef);
                    var amountOffHighCoef = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                    selectedPublicUtilities.amount = amountOnHighCoef;
                    selectedPublicUtilities.amount_pay = amountOffHighCoef;
                    selectedPublicUtilities.amount_high_coef = amountOnHighCoef - amountOffHighCoef;
                    selectedPublicUtilities.size_high_coef = selectedPublicUtilities.HouseService.high_coef;
                    
                }
                else
                {
                    selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                    selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);

                }
            }
        }

        public void RecalculateCounterPublicUtilities()
        {
            if (selectedPublicUtilities.Counter.HouseService.payment_id == 22) // Холодное водоснабжение счетчик
            {
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                selectedPublicUtilities.recalculation = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);

            }

            if (selectedPublicUtilities.Counter.HouseService.payment_id == 25) // Горячее водоснабжение подача
            {
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                selectedPublicUtilities.recalculation = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
            }

            if (selectedPublicUtilities.Counter.HouseService.payment_id == 31) // Электроэнергия дн.начисление
            {
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                selectedPublicUtilities.recalculation = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
            }

            if (selectedPublicUtilities.Counter.HouseService.payment_id == 33) // Электроэнергия нч.начисление
            {
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate); // Обьем.ком услуг * Тариф
                selectedPublicUtilities.recalculation = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.Counter.HouseService.rate);
            }
        }

       
        public void RecalculateServicePublicUtilities()
        {
            if (selectedPublicUtilities.HouseService.payment_id == 23 || selectedPublicUtilities.HouseService.payment_id == 26) // Холодное водоснабжение кол.во людей + Горячее водоснабжение кол.во людей 
            {
                selectedPublicUtilities.amount = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate); // Кол.во проживающих  * Норматив * Тариф
                selectedPublicUtilities.recalculation = selectedPublicUtilities.amount = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.used = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToSingle(selectedPublicUtilities.HouseService.norm);
                selectedPublicUtilities.amount_pay = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);

            }

            if (selectedPublicUtilities.HouseService.payment_id == 28) // Водоотведение ХВС,ГВС
            {
                var coldWaterUsed = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == 59 && x.date == selectedPublicUtilities.date && x.Personal_account.apartment_id == selectedPublicUtilities.Personal_account.apartment_id).Sum(k => k.used);
                var hotWaterUsed = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == 60 && x.date == selectedPublicUtilities.date && x.Personal_account.apartment_id == selectedPublicUtilities.Personal_account.apartment_id).Sum(k => k.used);
                var sumWaterUsed = coldWaterUsed + hotWaterUsed;
                selectedPublicUtilities.used = sumWaterUsed;
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.recalculation = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);

            }

            if (selectedPublicUtilities.HouseService.payment_id == 27)
            {
                var hotWaterUsed = Connection.Database.Public_utilities.ToList().Where(x => x.HouseService.service_id == 60 && x.date == selectedPublicUtilities.date && x.Personal_account.apartment_id == selectedPublicUtilities.Personal_account.apartment_id).Sum(k => k.used);
                selectedPublicUtilities.used = Convert.ToSingle(selectedPublicUtilities.HouseService.norm) * Convert.ToSingle(hotWaterUsed);
                selectedPublicUtilities.amount = Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(hotWaterUsed) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.recalculation = Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(hotWaterUsed) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
            }

            if (selectedPublicUtilities.HouseService.payment_id == 35)
            {
                selectedPublicUtilities.amount = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.recalculation = selectedPublicUtilities.Personal_account.Apartment.number_of_residents__number_of_residents__number_of_residents__number_of_residents__number_of_residents_ * Convert.ToDecimal(selectedPublicUtilities.HouseService.norm) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(selectedPublicUtilities.used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
            }

            if (selectedPublicUtilities.HouseService.payment_id == 30)
            {
                var housePokazanie = Connection.Database.House_public_utilities.ToList().Where(x => x.date == selectedPublicUtilities.date && x.HouseService.service_id == selectedPublicUtilities.HouseService.service_id).Sum(k => k.used);

                var used = housePokazanie * Convert.ToSingle(selectedPublicUtilities.Personal_account.Apartment.square) / Convert.ToSingle(selectedPublicUtilities.Personal_account.Apartment.House.square_residental);
                selectedPublicUtilities.used = used;

                selectedPublicUtilities.amount = Convert.ToDecimal(used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.recalculation = Convert.ToDecimal(used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
                selectedPublicUtilities.amount_pay = Convert.ToDecimal(used) * Convert.ToDecimal(selectedPublicUtilities.HouseService.rate);
            }



        }


    }
}
