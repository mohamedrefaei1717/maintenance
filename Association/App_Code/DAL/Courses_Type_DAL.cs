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
    public class Courses_Type_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Courses_Type Courses_Type = new Tbl_Courses_Type();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Courses_Type> Select_All_Courses_Type()
        {
            return Assoc.Tbl_Courses_Type.ToList();
        }


        public string Insert(
            int Course_Type_ID
            , string Course_Type_Name
            )
        {
            try
            {
                Courses_Type.Course_Type_ID= Course_Type_ID;
                Courses_Type.Course_Type_Name = Course_Type_Name;
                
                Assoc.Tbl_Courses_Type.Add(Courses_Type);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Course_Type_ID
            , string Course_Type_Name
            )
        {
            try
            {
                Courses_Type = Assoc.Tbl_Courses_Type.Where(O => O.Course_Type_ID == Course_Type_ID).FirstOrDefault<Tbl_Courses_Type>();
                if (Courses_Type != null)
                {
                    Courses_Type.Course_Type_Name = Course_Type_Name;
                    
                    Assoc.Entry(Courses_Type).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Course_Type_ID)
        {
            try
            {
                Courses_Type = Assoc.Tbl_Courses_Type.Where(O => O.Course_Type_ID == Course_Type_ID).FirstOrDefault<Tbl_Courses_Type>();

                Assoc.Entry(Courses_Type).State = System.Data.EntityState.Deleted;
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
