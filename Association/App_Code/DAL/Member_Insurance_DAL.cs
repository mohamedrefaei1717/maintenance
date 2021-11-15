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
    public class  Member_Insurance_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Member_Insurance Member_Insurance = new Tbl_Member_Insurance();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
              int Inssur_ID
            , int Memb_ID
            , DateTime insur_Date
            , int insurance_Type_ID
            , int Insur_Value
           
            )
        {
            try
            {
                Member_Insurance.Inssur_ID = Inssur_ID;
                Member_Insurance.Memb_ID = Memb_ID;
                Member_Insurance.insur_Date = insur_Date;
                Member_Insurance.insurance_Type_ID = insurance_Type_ID;
                Member_Insurance.Insur_Value = Insur_Value;


                Assoc.Tbl_Member_Insurance.Add(Member_Insurance);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
              int Inssur_ID
            , int Memb_ID
            , DateTime insur_Date
            , int insurance_Type_ID
            , int Insur_Value
            )
        {
            try
            {
                Member_Insurance = Assoc.Tbl_Member_Insurance.Where(O => O.Inssur_ID == Inssur_ID).FirstOrDefault<Tbl_Member_Insurance>();
                if (Member_Insurance != null)
                {
                    Member_Insurance.Memb_ID = Memb_ID;
                    Member_Insurance.insur_Date = insur_Date;
                    Member_Insurance.insurance_Type_ID = insurance_Type_ID;
                    Member_Insurance.Insur_Value = Insur_Value; 

                    Assoc.Entry(Member_Insurance).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Inssur_ID)
        {
            try
            {
                Member_Insurance = Assoc.Tbl_Member_Insurance.Where(O => O.Inssur_ID == Inssur_ID).FirstOrDefault<Tbl_Member_Insurance>();

                Assoc.Entry(Member_Insurance).State = EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

    }
}