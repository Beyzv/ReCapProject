using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _BrandDal.Add(brand);
                Console.WriteLine("Marka başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Marka ismi iki karakterden fazla olmalıdır.");
            }
        }

        public void Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            Console.WriteLine("Marka silindi.");
        }

        public List<Brand> GetAll()
        {
            return _BrandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _BrandDal.Get(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _BrandDal.Update(brand);
                Console.WriteLine("Marka başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Marka ismi iki karakterden fazla olmalıdır.");
            }
        }
    }
}
