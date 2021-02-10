using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {CarId=1, BrandId=1, ColorId=2, DailyPrice= 220, ModelYear="2020", Description="Otomatik Dizel Siyah Renault Clio"},
                new Car {CarId=2, BrandId=4, ColorId=3, DailyPrice= 400, ModelYear="2020", Description="Otomatik Dizel Beyaz Mercedes C Serisi"},
                new Car {CarId=3, BrandId=4, ColorId=3, DailyPrice= 560, ModelYear="2020", Description="Otomatik Dizel Beyaz Mercedes E Serisi"},
                new Car {CarId=4, BrandId=5, ColorId=3, DailyPrice= 326, ModelYear="2020", Description="Otomatik Dizel Beyaz Peugeot 3008"},
                new Car {CarId=5, BrandId=3, ColorId=1, DailyPrice= 197, ModelYear="2020", Description="Otomatik Dizel Gri Fiat Egea"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetByColorID(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
