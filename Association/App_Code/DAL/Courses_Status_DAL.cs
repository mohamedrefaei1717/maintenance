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
    public class Courses_Status_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Courses_Status Courses_Status = new Tbl_Courses_Status();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Courses_Status> Select_All_Courses_Status()
        {
            return Assoc.Tbl_Courses_Status.ToList();
        }

        public string Insert(
            int Course_Status_ID
            , string Course_Status_Name
            )
        {
            try
            {
                Courses_Status.Course_Status_ID = Course_Status_ID;
                Courses_Status.Course_Status_Name = Course_Status_Name;

                Assoc.Tbl_Courses_Status.Add(Courses_Status);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Course_Status_ID
            , string Course_Status_Name
            )
        {
            try
            {
                Courses_Status = Assoc.Tbl_Courses_Status.Where(O => O.Course_Status_ID == Course_Status_ID).FirstOrDefault<Tbl_Courses_Status>();
                if (Courses_Status != null)
                {
                    Courses_Status.Course_Status_Name = Course_Status_Name;

                    Assoc.Entry(Courses_Status).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Course_Status_ID)
        {
            try
            {
                Courses_Status = Assoc.Tbl_Courses_Status.Where(O => O.Course_Status_ID == Course_Status_ID).FirstOrDefault<Tbl_Courses_Status>();

                Assoc.Entry(Courses_Status).State = System.Data.EntityState.Deleted;
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
