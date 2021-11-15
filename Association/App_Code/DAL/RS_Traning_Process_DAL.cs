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
   public class RS_Traning_Process_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        RS_Traning_Process Traning_Process = new RS_Traning_Process();
       
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public RS_Traning_Process Select_Training_Process_By_ID(int Tr_Proc_ID)
        {
            return Assoc.RS_Traning_Process.Where(x => x.Tr_Proc_ID == Tr_Proc_ID).FirstOrDefault();
        }



        public bool Insert(
            //int Tr_Proc_ID
             string Memb_EmpID
            , int Course_ID
            , int Course_Typy_ID
            , DateTime Course_Start_Date
            , DateTime Course_End_Date
            , int Course_Funder_ID
            , int Training_Place_ID
            , int Course_Status_ID
            //, string Course_Certificate
            //, string Course_Rank
            , string Course_Cost
            , int Course_Exam
            , string Course_GPA
            , int Course_PhaseNo_ID
            , string Course_Image
            )
        {
            try
            {
                //Traning_Process.Tr_Proc_ID = Tr_Proc_ID;
                Traning_Process.Memb_EmpID = Memb_EmpID;
                Traning_Process.Course_ID = Course_ID;
                Traning_Process.Course_Typy_ID=Course_Typy_ID;
                Traning_Process.Course_Start_Date=Course_Start_Date;
                Traning_Process.Course_End_Date = Course_End_Date;
                Traning_Process.Course_Funder_ID = Course_Funder_ID;
                Traning_Process.Training_Place_ID = Training_Place_ID;
                Traning_Process.Course_Status_ID = Course_Status_ID;
                //Traning_Process.Course_Certificate = Course_Certificate;
                //Traning_Process.Course_Rank = Course_Rank;
                Traning_Process.Course_Cost = Course_Cost;
                Traning_Process.Course_Exam_ID = Course_Exam;
                Traning_Process.Course_GPA = Course_GPA;
                Traning_Process.Course_PhaseNo_ID = Course_PhaseNo_ID;
                Traning_Process.Course_Image = Course_Image;



                Assoc.RS_Traning_Process.Add(Traning_Process);
                Assoc.SaveChanges();
                //return "تمت الإضافة بنجاح";
                return true;
            }

            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }
        }

        public bool Update(
            int Tr_Proc_ID
            , string Memb_EmpID
            , int Course_ID
            , int Course_Typy_ID
            , DateTime Course_Start_Date
            , DateTime Course_End_Date
            , int Course_Funder_ID
            , int Training_Place_ID
            , int Course_Status_ID
            //, string Course_Certificate
           // , string Course_Rank
            , string Course_Cost
            , int Course_Exam
            , string Course_GPA
            , int Course_PhaseNo_ID
            , string Course_Image
            )
        {
            try
            {
                Traning_Process = Assoc.RS_Traning_Process.Where(O => O.Tr_Proc_ID == Tr_Proc_ID).FirstOrDefault<RS_Traning_Process>();
                if (Traning_Process != null)
                {
                    Traning_Process.Tr_Proc_ID = Tr_Proc_ID;
                    Traning_Process.Memb_EmpID = Memb_EmpID;
                    Traning_Process.Course_ID = Course_ID;
                    Traning_Process.Course_Typy_ID = Course_Typy_ID;
                    Traning_Process.Course_Start_Date = Course_Start_Date;
                    Traning_Process.Course_End_Date = Course_End_Date;
                    Traning_Process.Course_Funder_ID = Course_Funder_ID;
                    Traning_Process.Training_Place_ID = Training_Place_ID;
                    Traning_Process.Course_Status_ID = Course_Status_ID;
                    //Traning_Process.Course_Certificate = Course_Certificate;
                    //Traning_Process.Course_Rank = Course_Rank;
                    Traning_Process.Course_Cost = Course_Cost;
                    Traning_Process.Course_Exam_ID = Course_Exam;
                    Traning_Process.Course_GPA = Course_GPA;
                    Traning_Process.Course_PhaseNo_ID = Course_PhaseNo_ID;
                    Traning_Process.Course_Image = Course_Image;


                    Assoc.Entry(Traning_Process).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                //return "تم التعديل بنجاح";
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }

        }

        public string Delet(int Tr_Proc_ID)
        {
            try
            {
                Traning_Process = Assoc.RS_Traning_Process.Where(O => O.Tr_Proc_ID == Tr_Proc_ID).FirstOrDefault<RS_Traning_Process>();

                Assoc.Entry(Traning_Process).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }
        public List<SelectAllMembersWith_AllCourses_Result> getAllMembersWithCourses()
        {
            List<SelectAllMembersWith_AllCourses_Result> trainingCourses = Assoc.SelectAllMembersWith_AllCourses().ToList();
            return trainingCourses;
        }

    }
}
