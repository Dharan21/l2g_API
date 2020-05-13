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

        public bool AddBankDeatils(UserBankDetailsVM userVM)
        {
            l2g_tbl_UserBankDetails user = MappingConfig.UserBankDetailsToDataEntity(userVM);
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
            l2g_tbl_UserBankDetails user = db.l2g_tbl_UserBankDetails.Where(x => x.UserId == userId).First();
            if(user != null)
            {
                return MappingConfig.UserBankDetailsToBusinessEntity(user);
            }
            return new UserBankDetailsVM();
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

        public bool AddUserEmployementDetails(UserEmploymentDetailsVM userVM) {
            l2g_tbl_UserEmployeementDetails user = MappingConfig.UserEmploymentDetailsToDataEntity(userVM);
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
            l2g_tbl_UserEmployeementDetails user = db.l2g_tbl_UserEmployeementDetails.Where(x => x.UserId == userId).First();
            if (user != null)
            {
                return MappingConfig.UserEmploymentDetailsToBusinessEntity(user);
            }
            return new UserEmploymentDetailsVM();
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
                userEntity = user;
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
