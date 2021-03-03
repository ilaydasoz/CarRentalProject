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
    }
}

