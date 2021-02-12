using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByColorID(int colorId);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByModelYear(string modelYear);
        IDataResult<List<Car>> GetByDailyPrice(decimal min ,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
