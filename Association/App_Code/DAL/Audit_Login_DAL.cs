using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Association.EntityFramework;

namespace Association
{
    public class Audit_Login_DAL
    {
        AssociationEntities DB = new AssociationEntities();
        Tbl_Audit_Login AuditLogin = new Tbl_Audit_Login();
        HandlingExceptions hand_Excep = new HandlingExceptions();



        public List<Tbl_Audit_Login> Get_Audit_Login()
        {
            return DB.Tbl_Audit_Login.OrderByDescending(x => x.Audit_ID).ToList();
        }

        public String Audit_Insert(
                  string Audit_IP
                , DateTime Audit_DateTime
                , string Audit_UserName
                , string Audit_Password
                , bool   Audit_Status
            )
        {
            try
            {

                AuditLogin = new Tbl_Audit_Login();
                AuditLogin.Audit_IP = Audit_IP;
                AuditLogin.Audit_DateTime = Audit_DateTime;
                AuditLogin.Audit_UserName = Audit_UserName;
                AuditLogin.Audit_Password = Audit_Password;
                AuditLogin.Audit_Status = Audit_Status;
                DB.Tbl_Audit_Login.Add(AuditLogin);
                DB.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception(hand_Excep.HandlingExce(ex)); 
                return (hand_Excep.HandlingExce(ex));

            }
        }


        


    }
}