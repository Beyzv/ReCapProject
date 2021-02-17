using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.DailyPrice> 0 && car.Description.Length >= 2)
            {
                _CarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            
        }

        public IResult Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByColorID(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetByModelYear(string modelYear)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.ModelYear.Contains(modelYear) == true));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >= 2)
            {
                _CarDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            
        }
    }
}
