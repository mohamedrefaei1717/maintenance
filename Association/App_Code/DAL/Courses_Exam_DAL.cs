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
    class Courses_Exam_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Course_Exam Courses_Exam = new Tbl_Course_Exam();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Course_Exam> Select_All_Courses_Exam()
        {
            return Assoc.Tbl_Course_Exam.ToList();
        }

        public string Insert(
            int Course_Exam_ID
            , string Course_Exam_Name
            )
        {
            try
            {
                Courses_Exam.Exam_ID = Course_Exam_ID;
                Courses_Exam.Exam_Name = Course_Exam_Name;

                Assoc.Tbl_Course_Exam.Add(Courses_Exam);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Course_Exam_ID
            , string Course_Exam_Name
            )
        {
            try
            {
                Courses_Exam = Assoc.Tbl_Course_Exam.Where(O => O.Exam_ID == Course_Exam_ID).FirstOrDefault<Tbl_Course_Exam>();
                if (Courses_Exam != null)
                {
                    Courses_Exam.Exam_Name = Course_Exam_Name;

                    Assoc.Entry(Courses_Exam).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Course_Exam_ID)
        {
            try
            {
                Courses_Exam = Assoc.Tbl_Course_Exam.Where(O => O.Exam_ID == Course_Exam_ID).FirstOrDefault<Tbl_Course_Exam>();

                Assoc.Entry(Courses_Exam).State = System.Data.EntityState.Deleted;
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
