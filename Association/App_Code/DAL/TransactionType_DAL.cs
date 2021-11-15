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
    public class TransactionType_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_TransactionType TransType = new Tbl_TransactionType();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Trans_Type_ID
            , string Trans_Type_Name
            )
        {
            try
            {
                TransType.Trans_Type_ID = Trans_Type_ID;
                TransType.Trans_Type_Name = Trans_Type_Name;

                Assoc.Tbl_TransactionType.Add(TransType);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Trans_Type_ID
            , string Trans_Type_Name
            )
        {
            try
            {
                TransType = Assoc.Tbl_TransactionType.Where(O => O.Trans_Type_ID == Trans_Type_ID).FirstOrDefault<Tbl_TransactionType>();
                if (TransType != null)
                {
                    TransType.Trans_Type_Name = Trans_Type_Name;

                    Assoc.Entry(TransType).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet(int Trans_Type_ID)
        {
            try
            {
                TransType = Assoc.Tbl_TransactionType.Where(O => O.Trans_Type_ID == Trans_Type_ID).FirstOrDefault<Tbl_TransactionType>();

                Assoc.Entry(TransType).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_TransactionType> SelectAll_TransactionType()
        {
            return Assoc.Tbl_TransactionType.OrderByDescending(x => x.Trans_Type_ID).ToList();
        }










    }
}