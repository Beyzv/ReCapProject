using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentCarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from cu in filter is null
                             ? context.Customers
                             : context.Customers.Where(filter)
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId=cu.CustomerId,
                                 UserId=u.UserId,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 Mail=u.Email,
                                 CompanyName=cu.CompanyName,
                                 
                             };
                return result.ToList();

            }
        }

    
    }
}
