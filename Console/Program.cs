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

            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine("\n Arabanın Günlük Fiyatı : " + car.DailyPrice + "/n Arabanın Modelinin Yılı :" + car.ModelYear + "\n Araba Hakkında : " + car.Description);
            }

            carManager.Add(new Entities.Concrete.Car { CarId = 6, BrandId = 2, ColorId = 4, Description = "Otomatik Dizel kırmızı fiat" , DailyPrice= 321 , ModelYear=2020 });
        }
    }
}
