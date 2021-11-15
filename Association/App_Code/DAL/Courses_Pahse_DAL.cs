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
    class Courses_Pahse_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Course_Phase Courses_Phase = new Tbl_Course_Phase();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Course_Phase> Select_All_Courses_Phases()
        {
            return Assoc.Tbl_Course_Phase.ToList();
        }
        public string Insert(
            int Course_Phase_ID
            , string Course_Phase_Name
            )
        {
            try
            {
                Courses_Phase.Phase_ID = Course_Phase_ID;
                Courses_Phase.Phase_Name = Course_Phase_Name;

                Assoc.Tbl_Course_Phase.Add(Courses_Phase);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Course_Phase_ID
            , string Course_Phase_Name
            )
        {
            try
            {
                Courses_Phase = Assoc.Tbl_Course_Phase.Where(O => O.Phase_ID == Course_Phase_ID).FirstOrDefault<Tbl_Course_Phase>();
                if (Courses_Phase != null)
                {
                    Courses_Phase.Phase_Name = Course_Phase_Name;

                    Assoc.Entry(Courses_Phase).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Course_Phase_ID)
        {
            try
            {
                Courses_Phase = Assoc.Tbl_Course_Phase.Where(O => O.Phase_ID == Course_Phase_ID).FirstOrDefault<Tbl_Course_Phase>();

                Assoc.Entry(Courses_Phase).State = System.Data.EntityState.Deleted;
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
