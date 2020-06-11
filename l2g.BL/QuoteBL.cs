using l2g.BL.Interfaces;
using l2g.DL;
using l2g.DL.Interfaces;
using l2g.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace l2g.BL
{
    public class QuoteBL: IQuoteBL
    {
        private IQuoteDL _quoteDL;
        private ICarDL _carDL;
        private IUserDL _userDL;
        private IMileageDL _mileageDL;
        private IPaybackTimeDL _paybackTimeDL;
        
        public QuoteBL(IQuoteDL quoteDL, ICarDL carDL, IUserDL userDL, IMileageDL mileageDL, IPaybackTimeDL paybackTimeDL)
        {
            _quoteDL = quoteDL;
            _carDL = carDL;
            _userDL = userDL;
            _mileageDL = mileageDL;
            _paybackTimeDL = paybackTimeDL;
        }
        public ErrorResponseVM ValidateGetQuote(GetQuote quote)
        {
            ErrorResponseVM errors = new ErrorResponseVM();
            if (!_carDL.CarExists(quote.CarId))
            {
                Error err = new Error() 
                {
                    ErrorMessage = "Car with given CarId doesn't Exists!",
                    Property = "CarId"
                };
                errors.Errors.Add(err);
            }
            if (!_mileageDL.CheckMileageExists(quote.MileageId))
            {
                Error err = new Error()
                {
                    ErrorMessage = "Mileage with given MileageId doesn't Exists!",
                    Property = "MileageId"
                };
                errors.Errors.Add(err);
            }
            if (!_paybackTimeDL.CheckMonthsExists(quote.MonthId))
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
            int userId = _userDL.GetUserId(username);
            return _quoteDL.AddQuote(quote, userId);
        }
    }
}
