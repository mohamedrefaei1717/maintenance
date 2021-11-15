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
    public class  Appraisal_Rate_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Appraisail_Rate Appraisail_Rate = new Tbl_Appraisail_Rate();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Appraisail_Rate> Select_All_Appraisail_Rate()
        {
            return Assoc.Tbl_Appraisail_Rate.ToList();
        }

        public string Insert(
            int Rate_ID
            , string Rate_Name
            )
        {
            try
            {
                Appraisail_Rate.Rate_ID = Rate_ID;
                Appraisail_Rate.Rate_Name = Rate_Name;

                Assoc.Tbl_Appraisail_Rate.Add(Appraisail_Rate);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Rate_ID
            , string Rate_Name
            )
        {
            try
            {
                Appraisail_Rate = Assoc.Tbl_Appraisail_Rate.Where(O => O.Rate_ID == Rate_ID).FirstOrDefault<Tbl_Appraisail_Rate>();
                if (Appraisail_Rate != null)
                {
                    Appraisail_Rate.Rate_Name = Rate_Name;

                    Assoc.Entry(Appraisail_Rate).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Rate_ID)
        {
            try
            {
                Appraisail_Rate = Assoc.Tbl_Appraisail_Rate.Where(O => O.Rate_ID == Rate_ID).FirstOrDefault<Tbl_Appraisail_Rate>();

                Assoc.Entry(Appraisail_Rate).State = System.Data.EntityState.Deleted;
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
