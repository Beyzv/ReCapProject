using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
         
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
           

        }
        static void RentCarTest(DateTime rentDate, DateTime returnDate, int carId,int customerId,int Id)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.RentDate = rentDate;
            rental.ReturnDate = returnDate;
            rental.CarId = carId;
            rental.CustomerId = customerId;
            rental.Id = Id;
            rentalManager.CarRentable(carId);

        }
        static void UserAddTest(string firstName, string lastName ,string Email,int userId ,string password)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User();
            user.UserId = userId;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = Email;
            user.Password = password;
            userManager.Add(user);
        }
        static void CustomerAddTest( string CompanyName , int UserId ,int customerId)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer =new Customer();
            customer.UserId = UserId;
            customer.CustomerId = customerId;
            customer.CompanyName = "Light Company";
            customerManager.Add(customer);
        }  
        static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                 System.Console.WriteLine("Marka :"+car.BrandName+"\n"+
                                          "Renk :"+car.ColorName+"\n"+
                                          "Günlük fiyat :"+car.DailyPrice+"\n"+
                                          "Detaylar :"+car.Description+"\n"+
                                          "Model yılı :"+car.ModelYear+"\n");
            }
        }
    }
}
