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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rnt in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on rnt.CarId equals cr.Id
                             join cus in context.Customers on rnt.CustomerId equals cus.Id
                             join usr in context.Users on cus.UserId equals usr.Id
                             select new CarRentalDetailDto
                             {
                                 RentalId = rnt.RentalId,
                                 CarId = cr.Id,
                                 CustomerId = cus.Id,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate

                             };

                return result.ToList();
            }
        }
    }
}
