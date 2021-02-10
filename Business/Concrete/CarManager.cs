using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice> 0 && car.Description.Length >= 2)
            {
                _CarDal.Add(car);
                Console.WriteLine("Yeni araba eklendi.");
            }
            else
            {
                Console.WriteLine("Günlük fiyatı sıfırdan farklı giriniz.");
            }
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
            Console.WriteLine("Araba silindi.");
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _CarDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetByColorID(int colorId)
        {
            return _CarDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _CarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetByModelYear(string modelYear)
        {
            return _CarDal.GetAll(c => c.ModelYear.Contains(modelYear) == true);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _CarDal.GetCarDetails();
        }

        public void Update(Car car)
        {

            _CarDal.Update(car);
            Console.WriteLine("Araba güncellendi.");
        }
    }
}
