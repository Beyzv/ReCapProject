using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            bool sonuc = true;
            while (sonuc)
            {
                System.Console.WriteLine(" \n    Rent-a-car  \n" +
                                         "1-Fiyat Listesi  \n " +
                                         "2-Detaylarıyla tüm arabalarımız  \n" +
                                         "Gerçekleştirmek istediğiniz işlemi seçiniz."
                                         );
                int number = Convert.ToInt32(System.Console.ReadLine());
                System.Console.WriteLine("\n ************************************************************\n");
                switch(number)
                {
                    case 1:
                        decimal min = Convert.ToDecimal(System.Console.ReadLine());
                        decimal max = Convert.ToDecimal(System.Console.ReadLine());
                        foreach (var car in carManager.GetByDailyPrice(min,max))
                        {
                            System.Console.WriteLine($"{car.CarId} \t{colorManager.GetById(car.ColorId).ColorName}\t{brandManager.GetById(car.BrandId).BrandName} \t\t{car.ModelYear} \t {car.DailyPrice}");
                        }
                        break;
                    case 2:
                        System.Console.WriteLine("Arabalarımız :" );
                        foreach (var car in carManager.GetAll())
                        {
                            System.Console.WriteLine("\n Arabanın Günlük Fiyatı : " + car.DailyPrice + "/n Arabanın Modelinin Yılı :" + car.ModelYear + "\n Araba Hakkında : " + car.Description);
                        }

                        break;
                }
            }

         
            carManager.Add(new Entities.Concrete.Car { CarId = 6, BrandId = 2, ColorId = 4, Description = "Otomatik Dizel kırmızı fiat" , DailyPrice= 321 , ModelYear="2020" });

            foreach (var cars in carManager.GetCarDetails())
            {
                System.Console.WriteLine(cars.BrandName + ":" + cars.CarId);
            }
        }
    }
}
