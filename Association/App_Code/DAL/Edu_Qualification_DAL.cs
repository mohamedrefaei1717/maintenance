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
    public class Edu_Qualification_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Education_Qualification Edu_Qulaif = new Tbl_Education_Qualification();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Edu_Qualification_ID
            , string Edu_Qualification_Name
            )
        {
            try
            {
                Edu_Qulaif.Edu_Qualification_ID = Edu_Qualification_ID;
                Edu_Qulaif.Edu_Qualification_Name = Edu_Qualification_Name;

                Assoc.Tbl_Education_Qualification.Add(Edu_Qulaif);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Edu_Qualification_ID
            , string Edu_Qualification_Name
            )
        {
            try
            {
                Edu_Qulaif = Assoc.Tbl_Education_Qualification.Where(O => O.Edu_Qualification_ID == Edu_Qualification_ID).FirstOrDefault<Tbl_Education_Qualification>();
                if (Edu_Qulaif != null)
                {
                    Edu_Qulaif.Edu_Qualification_Name = Edu_Qualification_Name;

                    Assoc.Entry(Edu_Qulaif).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Edu_Qualification_ID)
        {
            try
            {
                Edu_Qulaif = Assoc.Tbl_Education_Qualification.Where(O => O.Edu_Qualification_ID == Edu_Qualification_ID).FirstOrDefault<Tbl_Education_Qualification>();

                Assoc.Entry(Edu_Qulaif).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Education_Qualification> SelectAll_Edu_Qualificationa()
        {
            return Assoc.Tbl_Education_Qualification.OrderByDescending(x => x.Edu_Qualification_ID).ToList();
        }
    }
}
