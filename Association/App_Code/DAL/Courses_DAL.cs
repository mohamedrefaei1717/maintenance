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
    public class Courses_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Courses Courses = new Tbl_Courses();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Courses> Select_All_Courses()
        {
            return Assoc.Tbl_Courses.ToList();
        }

        public List<Tbl_Courses> Select_All_Courses_By_Type(int Course_ID)
        {
            return Assoc.Tbl_Courses.Where(O => O.Course_TypeID == Course_ID).ToList<Tbl_Courses>();
        }

        public string Insert(
            int Course_ID
            , string Course_Name
            , int Course_Type_ID
            )
        {
            try
            {
                Courses.Course_ID = Course_ID;
                Courses.Coures_Name = Course_Name;
                Courses.Course_TypeID = Course_Type_ID;

                Assoc.Tbl_Courses.Add(Courses);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Course_ID
            , string Course_Name
            , int Course_Type_ID
            )
        {
            try
            {
                Courses = Assoc.Tbl_Courses.Where(O => O.Course_ID == Course_ID).FirstOrDefault<Tbl_Courses>();
                if (Courses != null)
                {
                    Courses.Coures_Name = Course_Name;
                    Courses.Course_TypeID = Course_Type_ID;

                    Assoc.Entry(Courses).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Course_ID)
        {
            try
            {
                Courses = Assoc.Tbl_Courses.Where(O => O.Course_ID == Course_ID).FirstOrDefault<Tbl_Courses>();

                Assoc.Entry(Courses).State = System.Data.EntityState.Deleted;
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