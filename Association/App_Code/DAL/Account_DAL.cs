using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Association.EntityFramework;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace Association
{
   public class Account_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Account Account = new Tbl_Account();
        HandlingExceptions hand_Excep = new HandlingExceptions();


        public string Insert(
             int Account_ID
             , string Account_Name
             //, int Trans_Type_ID
             )
        {
            try
            {
                Account.Account_ID = Account_ID;
                Account.Account_Name = Account_Name;
               // Account.Trans_Type_ID = Trans_Type_ID;

                Assoc.Tbl_Account.Add(Account);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }



        public string Update(
             int Account_ID
             , string Account_Name
             //, int Trans_Type_ID
             )
        {
            try
            {
                Account = Assoc.Tbl_Account.Where(O => O.Account_ID == Account_ID).FirstOrDefault<Tbl_Account>();
                if (Account != null)
                {
                    Account.Account_Name = Account_Name;
                   // Account.Trans_Type_ID = Trans_Type_ID;

                    Assoc.Entry(Account).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }



        public string Delet(int Account_ID)
        {
            try
            {
                Account = Assoc.Tbl_Account.Where(O => O.Account_ID == Account_ID).FirstOrDefault<Tbl_Account>();

                Assoc.Entry(Account).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Account> SelectAll_Accounts()
        {
            return Assoc.Tbl_Account.OrderByDescending(x => x.Account_ID).ToList();
        }






    }
}
