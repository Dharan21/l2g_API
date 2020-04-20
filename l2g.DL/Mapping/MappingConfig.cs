using l2g.Entities.BusinessEntities;
using l2g.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL.Mapping
{
    public class MappingConfig
    {
        public static BrandVM BrandToBusinessEntity(l2g_tbl_Brand brand)
        {
            var brandVM = new BrandVM()
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName
            };
            return brandVM;
        }

        public static FuelVM FuelToBusinessEntity(l2g_tbl_Fuel fuel)
        {
            var fuelVM = new FuelVM()
            {
                FuelId = fuel.FuelId,
                FuelType = fuel.FuelType
            };
            return fuelVM;
        }

        public static GearboxVM GearboxToBusinessEntity(l2g_tbl_Gearbox gearbox)
        {
            var gearboxVM = new GearboxVM()
            {
                GearboxId = gearbox.GearboxId,
                GearboxType = gearbox.GearboxType
            };
            return gearboxVM;
        }

        public static CarVM CarToBusinessEntity(l2g_tbl_Car car)
        {
            var carVM = new CarVM()
            {
                CarId = car.CarId,
                Carname = car.CarName,
                Model = car.Model,
                Color = car.Color,
                Price = (float)car.Price,
                CO2Emission = (float)car.CO2Emission
            };

            using (var db = new Lead2OrderGenerateDbEntities())
            {
                carVM.Brand = MappingConfig.BrandToBusinessEntity(db.l2g_tbl_Brand.Find(car.BrandId));
                carVM.Fuel = MappingConfig.FuelToBusinessEntity(db.l2g_tbl_Fuel.Find(car.FuelId));
                carVM.Gearbox = MappingConfig.GearboxToBusinessEntity(db.l2g_tbl_Gearbox.Find(car.GearboxId));
            }
            return carVM;
        }

        public static QuoteVM QuoteToBusinessEntity(l2g_tbl_Quote quote) {
            var quoteVM = new QuoteVM() {
                QuoteId = quote.QuoteId,
                UserId = quote.UserId,
                CarId = quote.CarId,
                Price = quote.Price,
                MileageId = quote.MileageId,
                MonthId = quote.MonthId
            };

            using (var db = new Lead2OrderGenerateDbEntities())
            {
                var user = db.l2g_tbl_UserDetails.Find(quote.UserId);
                quoteVM.Firstname = user.Firstname;
                quoteVM.Lastname = user.Lastname;

                var car = db.l2g_tbl_Car.Find(quote.CarId);
                quoteVM.Carname = car.CarName;
                quoteVM.Model = car.Model;

                quoteVM.Kilometer = db.l2g_tbl_Mileage.Find(quote.MileageId).Kilometer;
                quoteVM.Months = db.l2g_tbl_PaybackTime.Find(quote.MonthId).Months;
            }

            return quoteVM; 
        }

        public static l2g_tbl_Quote QuoteToDataEntity(QuoteVM quoteVM) {
            var quote = new l2g_tbl_Quote() {
                QuoteId = quoteVM.QuoteId,
                UserId = quoteVM.UserId,
                CarId = quoteVM.CarId,
                MileageId = quoteVM.MileageId,
                MonthId = quoteVM.MonthId,
                Price = quoteVM.Price
            };
            return quote;
        }

        public static l2g_tbl_UserBankDetails UserBankDetailsToDataEntity(UserBankDetailsVM userVM)
        {
            var user = new l2g_tbl_UserBankDetails() {
                UserId = userVM.UserId,
                AccountNo = userVM.AccountNo,
                AccountHolderName = userVM.AccountHolderName,
                AccountType = userVM.AccountType,
            };
            return user;
        }

        //userbankdetails to business entity left

        public static UserDetailsVM UserDetailsToBusinessEntity(l2g_tbl_UserDetails user)
        {
            var userVM = new UserDetailsVM() {
                UserId = user.UserId,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                DOB = user.DOB,
                Contact = user.Contact,
                HouseNo = user.HouseNo,
                Street = user.Street,
                PIN = user.PIN,
                Town = user.Town
            };
            return userVM;
        }

        public static l2g_tbl_UserDetails UserDetailsToDataEntity(UserDetailsVM userVM)
        {
            var user = new l2g_tbl_UserDetails() {
                UserId = userVM.UserId,
                Firstname = userVM.Firstname,
                Lastname = userVM.Lastname,
                DOB = userVM.DOB,
                Contact = userVM.Contact,
                HouseNo = userVM.HouseNo,
                Street = userVM.Street,
                PIN = userVM.PIN,
                Town = userVM.Town
            };
            return user;
        }

        public static l2g_tbl_UserEmployeementDetails UserBankDetailsToDataEntity(UserEmploymentDetailsVM userVM)
        {
            var user = new l2g_tbl_UserEmployeementDetails()
            {
                UserId = userVM.UserId,
                Company = userVM.Company,
                Salary = userVM.Salary,
                CreditScore = userVM.CreditScore,
                EmployeeStatusId = userVM.EmployeeStatusId,
                ContractId = userVM.ContractId
            };
            return user;
        }

        public static UserBankDetailsVM UserBankDetailsToBusinessEntity(l2g_tbl_UserBankDetails user)
        {
            var userVM = new UserBankDetailsVM()
            {
                UserId = user.UserId,
                AccountNo = user.AccountNo,
                AccountHolderName = user.AccountHolderName,
                AccountType = user.AccountType
            };
            return userVM;
        }
        public static UserVM UserToBusinessEntity(l2g_tbl_User user)
        {
            var userVM = new UserVM()
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };
            return userVM;
        }
        public static l2g_tbl_User UserToDataEntity(UserVM userVM)
        {
            var user = new l2g_tbl_User()
            {
                UserId = userVM.UserId,
                Username = userVM.Username,
                Email = userVM.Email,
                Password = userVM.Password
            };
            return user;
        }

        public static MileageVM MileageToBusinessEntity(l2g_tbl_Mileage mileage)
        {
            var mileageVM = new MileageVM()
            {
                MileageId = mileage.MileageId,
                Kilometer = mileage.Kilometer
            };
            return mileageVM;
        }

        public static PaybackTimeVM paybackTimeToBusinessEntity(l2g_tbl_PaybackTime paybackTime)
        {
            var paybackTimeVM = new PaybackTimeVM()
            {
                MonthId = paybackTime.MonthId,
                Months = paybackTime.Months
            };
            return paybackTimeVM;
        }
    }
}
