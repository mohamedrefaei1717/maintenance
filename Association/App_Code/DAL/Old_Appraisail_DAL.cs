using System;
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
    public class Old_Appraisail_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Old_Appraisal Old_Appraisail = new Tbl_Old_Appraisal();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public bool Insert(
            
            int Memb_ID
            , int Appraisal_Degree
            , int Appraisal_Rate_ID
            , string Appraisal_Year
            , string Appraisal_Image
            )
        {
            try
            {
                Old_Appraisail.Memb_ID = Memb_ID;
                Old_Appraisail.Appraisal_Degree = Appraisal_Degree; ;
                Old_Appraisail.Appraisal_Rate_ID = Appraisal_Rate_ID;
                Old_Appraisail.Appraisal_Year = Appraisal_Year;
                Old_Appraisail.Appraisal_Image = Appraisal_Image;

                Assoc.Tbl_Old_Appraisal.Add(Old_Appraisail);
                Assoc.SaveChanges();
                //return "تمت الإضافة بنجاح";
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }
        }

        public string Update(
            int Appraisal_ID
            , int Memb_ID
            , int Appraisal_Degree
            , int Appraisal_Rate_ID
            , string Appraisal_Year
            , string Appraisal_Image
            )
        {
            try
            {
                Old_Appraisail = Assoc.Tbl_Old_Appraisal.Where(O => O.Appraisal_ID == Appraisal_ID).FirstOrDefault<Tbl_Old_Appraisal>();
                if (Old_Appraisail != null)
                {
                    Old_Appraisail.Memb_ID = Memb_ID;
                    Old_Appraisail.Appraisal_Degree = Appraisal_Degree; ;
                    Old_Appraisail.Appraisal_Rate_ID = Appraisal_Rate_ID;
                    Old_Appraisail.Appraisal_Year = Appraisal_Year;
                    Old_Appraisail.Appraisal_Image = Appraisal_Image;

                    Assoc.Entry(Old_Appraisail).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Appraisal_ID)
        {
            try
            {
                Old_Appraisail = Assoc.Tbl_Old_Appraisal.Where(O => O.Appraisal_ID == Appraisal_ID).FirstOrDefault<Tbl_Old_Appraisal>();

                Assoc.Entry(Old_Appraisail).State = System.Data.EntityState.Deleted;
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
