using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                 new Brand{BrandId=1 , BrandName ="Renault"},
                 new Brand{BrandId=2 , BrandName ="Fiat"},
                 new Brand{BrandId=3 , BrandName ="Ford"},
                 new Brand{BrandId=4 , BrandName ="Mercedes"},
                 new Brand{BrandId=5 , BrandName ="Peugeot"}
            };
        }
        public void Add(Brand entity)
        {
            _brands.Add(entity);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b=>b.BrandId==brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brands;
        }

        public void Update(Brand entity)
        {
            Brand brandToUpgrade = _brands.SingleOrDefault(b => b.BrandId == entity.BrandId);
            brandToUpgrade.BrandId = entity.BrandId;
            brandToUpgrade.BrandName = entity.BrandName;
        }
    }
}
