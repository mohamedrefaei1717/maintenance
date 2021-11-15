using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Association.EntityFramework;

namespace Association
{
    public class SysUsers_Dal
    {
        AssociationEntities DB = new AssociationEntities();
        TBL_SysUsers SysUsers = new TBL_SysUsers();
        TBL_SysUsers SysUserInsert = new TBL_SysUsers();
        HandlingExceptions hand_Excep = new HandlingExceptions();
        Tbl_IPS IPs = new Tbl_IPS();




        public List<Get_Login_Info_Result> Get_Login_Info(string Usr_IP, string Usr_Name, string Usr_Pass)
        {
            return DB.Get_Login_Info(Usr_Name, Usr_Pass, Usr_IP).ToList();
        }


        public string DeleteUser(int UserID)
        {
            List<Tbl_IPS> UserIpList = DB.Tbl_IPS.Where(d => (d.IPS_Usr_ID == UserID)).ToList();


            //var FollowList = DB.Tbl_Follow.Where(d => (d.Ltr_No == Ltr_No) && (d.Ltr_Date == Ltr_Reg_Date));
            try
            {
                if (UserIpList != null)
                {
                    foreach (var UserIPs in UserIpList)
                    {
                        // DB.RS_FollowOrgExec.Remove(FollowList);
                        //DB.ItemBinding.Remove(ib);
                        Tbl_IPS UserIp = DB.Tbl_IPS.Where(d => (d.IPS_Usr_ID == UserIPs.IPS_Usr_ID)).FirstOrDefault<Tbl_IPS>();
                        DB.Entry(UserIp).State = System.Data.EntityState.Deleted;
                        DB.SaveChanges();
                    }

                    TBL_SysUsers SysUser = DB.TBL_SysUsers.Where(c => c.Usr_ID == UserID).SingleOrDefault();
                    DB.Entry(SysUser).State = System.Data.EntityState.Deleted;
                    DB.SaveChanges();
                    return "تم الحذف بنجاح";
                }
                else
                {
                    return "لم يتم الحذف";
                }
            }
            catch (Exception ex)
            {
                return "لم يتم الحذف";
            }
           
            
        }
        public string UpdateUserPass(int UID, string OldPass, string NewPass)
        {
            try
            {
                TBL_SysUsers User = DB.TBL_SysUsers.Where(p => (p.Usr_ID == UID)).FirstOrDefault();

                if (User != null)
                {
                    User.Usr_Pass = NewPass;
                    DB.Entry(User).State = System.Data.EntityState.Modified; //For 2012
                    DB.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }


        public string UpdateUserIP(int UserId, string OldIP, string NewIP)
        {
            Tbl_IPS UserIPS = DB.Tbl_IPS.Where(c => c.IPS_Usr_ID == UserId && c.IPS_Usr_IP == OldIP).FirstOrDefault();

            if (UserIPS != null)
            {
                UserIPS.IPS_Usr_IP = NewIP;
                DB.Entry(UserIPS).State = System.Data.EntityState.Modified; //For 2012
                DB.SaveChanges();
            }
            return "تم التعديل";
        }

        public string UpdateUserType(int UserId, int NewUserType)
        {
            TBL_SysUsers SysUser = DB.TBL_SysUsers.Where(c => c.Usr_ID == UserId).FirstOrDefault();

            if (SysUser != null)
            {
                SysUser.Usr_ModID = NewUserType;
                DB.Entry(SysUser).State = System.Data.EntityState.Modified; //For 2012
                DB.SaveChanges();
            }
            return "تم التعديل";
        }

        public string UpdateUserActive(int UserId,bool IsActive)
        {
            TBL_SysUsers UserActive = DB.TBL_SysUsers.Where(c => c.Usr_ID == UserId).SingleOrDefault();

            if (UserActive != null)
            {
                UserActive.Usr_IsActive = IsActive;
                DB.Entry(UserActive).State = System.Data.EntityState.Modified; //For 2012
                DB.SaveChanges();
            }
            return "تم التعديل";
        }

        public string InsertNewUser(string fName, string lName, string userName,string pass, string email,string Ip, int  userMode)
        {
            try
            {

                SysUserInsert.Usr_firstname = fName;
                SysUserInsert.Usr_familyname = lName;
                SysUserInsert.Usr_email = email;
                SysUserInsert.Usr_Name = userName;
                SysUserInsert.Usr_Pass = pass;
                SysUserInsert.Usr_ModID = userMode;
                SysUserInsert.Usr_IsActive = true;
                SysUserInsert.DateAdded = DateTime.Now.Date;
                
                DB.TBL_SysUsers.Add(SysUserInsert);
                DB.SaveChanges();

                TBL_SysUsers SysUser = DB.TBL_SysUsers.Where(c => c.Usr_Name.Contains(userName)).SingleOrDefault();
                int SysUserId = SysUser.Usr_ID;

                IPs.IPS_Usr_ID = SysUserId;
                IPs.IPS_Usr_IP = Ip;

                DB.Tbl_IPS.Add(IPs);
                DB.SaveChanges();

                return "تم التسجيل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public List<TBL_SysModules> SelectAll_UserType()
        {
            return DB.TBL_SysModules.OrderByDescending(x => x.Mod_ID).ToList();
        }

        public List<TBL_SysUsers> SelectAll_User()
        {
            return DB.TBL_SysUsers.OrderByDescending(x => x.Usr_ID).ToList();
        }


        public List<SelectAll_TBL_SysUsers_Tbl_IPS_Result> SelectAll_TBL_SysUsers_Tbl_IPS()
        {
            return DB.SelectAll_TBL_SysUsers_Tbl_IPS().ToList();
        }
    }
}