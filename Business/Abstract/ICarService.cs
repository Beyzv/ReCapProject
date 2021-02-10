using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetByColorID(int colorId);
        List<Car> GetByBrandId(int brandId);
        List<Car> GetByModelYear(string modelYear);
        List<Car> GetByDailyPrice(decimal min ,decimal max);
        List<CarDetailDto> GetCarDetails();
    }
}
