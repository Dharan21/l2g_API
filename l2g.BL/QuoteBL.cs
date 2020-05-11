using l2g.DL;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.BL
{
    public class QuoteBL
    {
        private readonly CarDL carDL;
        private readonly MileageDL mileageDL;
        private readonly PaybackTimeDL paybackTimeDL;
        private readonly QuoteDL quoteDL;
        private readonly UserDL userDL;
        public QuoteBL()
        {
            carDL = new CarDL();
            mileageDL = new MileageDL();
            paybackTimeDL = new PaybackTimeDL();
            quoteDL = new QuoteDL();
            userDL = new UserDL();
        }
        public ErrorResponseVM ValidateGetQuote(GetQuote quote)
        {
            ErrorResponseVM errors = new ErrorResponseVM();
            if (!carDL.CarExists(quote.CarId))
            {
                Error err = new Error() 
                {
                    ErrorMessage = "Car with given CarId doesn't Exists!",
                    Property = "CarId"
                };
                errors.Errors.Add(err);
            }
            if (!mileageDL.CheckMileageExists(quote.MileageId))
            {
                Error err = new Error()
                {
                    ErrorMessage = "Mileage with given MileageId doesn't Exists!",
                    Property = "MileageId"
                };
                errors.Errors.Add(err);
            }
            if (!paybackTimeDL.CheckMonthsExists(quote.MonthId))
            {
                Error err = new Error()
                {
                    ErrorMessage = "PaybackTime with given PaybackTimeId doesn't Exists!",
                    Property = "PaybackTime"
                };
                errors.Errors.Add(err);
            }
            return errors;
        }

        public bool AddQuote(GetQuote quote, string username)
        {
            int userId = userDL.GetUserId(username);
            return quoteDL.AddQuote(quote, userId);
        }
    }
}
