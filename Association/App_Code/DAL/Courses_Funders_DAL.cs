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
    public class Courses_Funders_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Courses_Funders Cours_Funders = new Tbl_Courses_Funders();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Courses_Funders> Select_All_Courses_Funders()
        {
            return Assoc.Tbl_Courses_Funders.ToList();
        }
        public string Insert(
            int Course_Funder_ID
            , string Course_Funder_Name
            )
        {
            try
            {
                Cours_Funders.Course_Funder_ID = Course_Funder_ID;
                Cours_Funders.Course_Funder_Name = Course_Funder_Name;

                Assoc.Tbl_Courses_Funders.Add(Cours_Funders);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Course_Funder_ID
            , string Course_Funder_Name
            )
        {
            try
            {
                Cours_Funders = Assoc.Tbl_Courses_Funders.Where(O => O.Course_Funder_ID == Course_Funder_ID).FirstOrDefault<Tbl_Courses_Funders>();
                if (Cours_Funders != null)
                {
                    Cours_Funders.Course_Funder_Name = Course_Funder_Name;

                    Assoc.Entry(Cours_Funders).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Course_Funder_ID)
        {
            try
            {
                Cours_Funders = Assoc.Tbl_Courses_Funders.Where(O => O.Course_Funder_ID == Course_Funder_ID).FirstOrDefault<Tbl_Courses_Funders>();

                Assoc.Entry(Cours_Funders).State = System.Data.EntityState.Deleted;
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
