using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            CarTest();
            BrandTest();
            ColorTest();

            RentalAdd();
            UserAdd();
            CustomerAdd();


        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
      
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    System.Console.WriteLine("Car Name: " + car.CarName +
                    "\nCar Description: " + car.Description +
                    "\nCar Brand Name: " + car.BrandName +
                    "\nCar Color Name: " + car.ColorName +
                    "\nCar Model Year: " + car.ModelYear +
                    "\nCar Daily Price: " + car.DailyPrice );

                    System.Console.WriteLine("________________\n");

                }

                
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    System.Console.WriteLine("Brand Id: " + brand.BrandId + " Brand Name: " + brand.BrandName);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           
            var result = colorManager.GetAll();

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    System.Console.WriteLine("Color Id: " + color.ColorId + " Color Name: " + color.ColorName);
                }
            }
            else
            {
                System.Console.WriteLine(result.Message);
            }
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add (new Rental
            {
                RentalId = 1,
                CarId = 9,
                CustomerId = 1,
                RentDate = "03.08.2010",
                ReturnDate = "03.09.2010"
            });

            System.Console.WriteLine(result.Message);
        }
        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User
            { 
                Id = 1,
                FirstName = "İlayda Söz",
                LastName = "Yılmaz",
                Email = "isy@gmail.com",
                Password = "123456"   
            });

            System.Console.WriteLine(result.Message);
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer
            { 
                Id = 1,
                UserId = 1,
                CompanyName = "A Company"

            });

            System.Console.WriteLine(result.Message);
        }


    }
    }


