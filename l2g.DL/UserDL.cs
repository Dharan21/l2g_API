using l2g.DL.Mapping;
using l2g.Entities.BusinessEntities;
using l2g.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l2g.DL
{
    public class UserDL: IDisposable
    {
        Lead2OrderGenerateDbEntities db = new Lead2OrderGenerateDbEntities();

        public int GetUserId(string username)
        {
            int id = db.l2g_tbl_User.Where(x => x.Username == username).Select(x => x.UserId).First();
            return id;
        }

        public bool AddBankDeatils(GetUserBankDetails userVM)
        {
            l2g_tbl_UserBankDetails user = MappingConfig.GetUserBankDetailsToDataEntity(userVM);
            user.CreatedDate = DateTime.Now;
            try
            {
                db.l2g_tbl_UserBankDetails.Add(user);
                db.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public UserBankDetailsVM GetBankDetails(int userId)
        {
            try
            {
                l2g_tbl_UserBankDetails user = db.l2g_tbl_UserBankDetails.Where(x => x.UserId == userId).First();
                return MappingConfig.UserBankDetailsToBusinessEntity(user);
            }
            catch(Exception)
            {
                return new UserBankDetailsVM();
            }
            
        }

        public bool UpdateUserEmploymentDetails(GetUserEmploymentDetails userVM)
        {
            //l2g_tbl_UserEmployeementDetails user = MappingConfig.GetUserEmploymentDetailsToDataEntity(userVM);
            try
            {
                l2g_tbl_UserEmployeementDetails userEntity = db.l2g_tbl_UserEmployeementDetails.Where(x => x.UserId == userVM.UserId).First();
                userEntity.Company = userVM.Company;
                userEntity.ContractId = userVM.ContractId;
                userEntity.CreditScore = userVM.CreditScore;
                userEntity.EmployeeStatusId = userVM.EmployeeStatusId;
                userEntity.Salary = userVM.Salary;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CheckAccountNoExists(int userId, string accountNo)
        {
            return db.l2g_tbl_UserBankDetails.Any(x => x.UserId != userId && x.AccountNo == accountNo);
        }

        public bool CheckAccountNoExists(string accountNo)
        {
            return db.l2g_tbl_UserBankDetails.Any(x => x.AccountNo == accountNo);
        }

        public bool AddUserBankDetails(GetUserBankDetails userVM)
        {
            l2g_tbl_UserBankDetails user = MappingConfig.GetUserBankDetailsToDataEntity(userVM);
            user.CreatedDate = DateTime.Now;
            try
            {
                db.l2g_tbl_UserBankDetails.Add(user);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateUserBankDetails(GetUserBankDetails userVM)
        {
            try
            {
                l2g_tbl_UserBankDetails userEntity = db.l2g_tbl_UserBankDetails.Where(x => x.UserId == userVM.UserId).First();
                userEntity.AccountNo = userVM.AccountNo;
                userEntity.AccountHolderName = userVM.AccountHolderName;
                userEntity.AccountType = userVM.AccountType;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public UserBankDetailsVM GetUserBankDetails(int userId)
        {
            try
            {
                l2g_tbl_UserBankDetails user = db.l2g_tbl_UserBankDetails.Where(x => x.UserId == userId).First();
                return MappingConfig.UserBankDetailsToBusinessEntity(user);
            }
            catch (Exception)
            {
                return new UserBankDetailsVM();
            }

        }

        public int? GetContractId(string contractType)
        {
            return db.l2g_tbl_Contract.Where(x => x.ContractType == contractType)
                .Select(x => x.ContractId).FirstOrDefault();
        }

        public int GetEmployeeStatusId(string employeeStatusType)
        {
            return db.l2g_tbl_EmployeeStatus.Where(x => x.EmployeeStatusType == employeeStatusType)
                .Select(x=>x.EmployeeStatusId).First();
        }

        public bool AddUserEmployementDetails(GetUserEmploymentDetails userVM) {
            l2g_tbl_UserEmployeementDetails user = MappingConfig.GetUserEmploymentDetailsToDataEntity(userVM);
            user.CreatedDate = DateTime.Now;
            try
            {
                db.l2g_tbl_UserEmployeementDetails.Add(user);
                db.SaveChanges();
            }
            catch (Exception) {
                return false;
            }
            return true;
        }

        public UserEmploymentDetailsVM GetUserEmploymentDetails(int userId) 
        {
            try
            {
                l2g_tbl_UserEmployeementDetails user = db.l2g_tbl_UserEmployeementDetails.Where(x => x.UserId == userId).First();
                return MappingConfig.UserEmploymentDetailsToBusinessEntity(user);
            }
            catch(Exception)
            {
                return new UserEmploymentDetailsVM();
            }
            
        }

        public List<Contract> GetAllContracts()
        {
            List<l2g_tbl_Contract> contractEntities = db.l2g_tbl_Contract.ToList();
            List<Contract> contracts = new List<Contract>();
            foreach (l2g_tbl_Contract contract in contractEntities)
            {
                contracts.Add(MappingConfig.ContractToBusinessEntity(contract));
            }
            return contracts;
        }

        public List<EmploymentStatus> GetAllEmployeeStatues()
        {
            List<l2g_tbl_EmployeeStatus> statusEntities = db.l2g_tbl_EmployeeStatus.ToList();
            List<EmploymentStatus> statuses = new List<EmploymentStatus>();
            foreach(l2g_tbl_EmployeeStatus status in statusEntities)
            {
                statuses.Add(MappingConfig.EmployeeStatusToBusinessEntity(status));
            }
            return statuses;
        }

        public bool AddUserDetails(UserDetailsVM userVM) {
            l2g_tbl_UserDetails user = MappingConfig.UserDetailsToDataEntity(userVM);
            user.CreatedDate = DateTime.Now;
            try
            {
                db.l2g_tbl_UserDetails.Add(user);
                db.SaveChanges();
            }
            catch (Exception) 
            {
                return false;
            }
            return true;
        }

        public bool UpdateUserDetail(UserDetailsVM userVM)
        {
            l2g_tbl_UserDetails user = MappingConfig.UserDetailsToDataEntity(userVM);
            try
            {
                l2g_tbl_UserDetails userEntity = db.l2g_tbl_UserDetails.Where(x => x.UserId == user.UserId).First();
                userEntity.Firstname = user.Firstname;
                userEntity.Lastname = user.Lastname;
                userEntity.DOB = user.DOB;
                userEntity.Contact = user.Contact;
                userEntity.HouseNo = user.HouseNo;
                userEntity.Street = user.Street;
                userEntity.PIN = user.PIN;
                userEntity.Town = user.Town;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public UserDetailsVM GetUserDetails(int userId)
        {
            try
            {
                l2g_tbl_UserDetails user = db.l2g_tbl_UserDetails.Where(x => x.UserId == userId).First();
                return MappingConfig.UserDetailsToBusinessEntity(user);
            }
            catch (Exception)
            {
                return new UserDetailsVM();
            } 
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
