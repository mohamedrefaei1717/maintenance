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
    public class Member_Registration_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Member_Registration Member_Registration = new Tbl_Member_Registration();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Member_Registration> Select_All_Member_Registration()
        {
            return Assoc.Tbl_Member_Registration.ToList();
        }
        public List<SelectAllMembersWithStatusAndReason_Result> SelectAllMembersWithStatusAndReason()
        {
            return Assoc.SelectAllMembersWithStatusAndReason().ToList();
        }

        public Tbl_Member_Registration Select_Member_Registration_By_ID(int Memb_ID)
        {
            return Assoc.Tbl_Member_Registration.Where(x => x.Memb_ID == Memb_ID).FirstOrDefault();
        }

        public Tbl_Member_Registration Select_Member_Registration_By_Emp_ID(string Emp_ID)
        {
            return Assoc.Tbl_Member_Registration.Where(x => x.Memb_EmpID == Emp_ID).FirstOrDefault();
        }


        public Tbl_Member_Registration Select_Member_Registration_By_National_ID(string National_ID)
        {
            return Assoc.Tbl_Member_Registration.Where(x => x.National_ID == National_ID).FirstOrDefault();
        }



        public bool Insert(
              int Memb_ID
            , DateTime Memb_SysDate
            , string Memb_EmpID
            , string Memb_Name
            , Nullable<DateTime> Memb_Date
            , DateTime Memb_Birthdate
            , int Memb_Social_ID
            , int Memb_Children_Number
            , int Memb_Gender_ID          
            , int? Memb_Military_Serv_ID
            , int Memb_Edu_Qualification_ID
            , int Memb_Work_Degree_ID
            , int Memb_FunctionalGr_ID
            , int Memb_QualitativeGr_ID
            , int Memb_Job_Title_ID
            , string Memb_Email
            , int Sect_ID
            , int Cent_Dept_ID
            , int Pub_Dept_ID
            , int Dept_ID
            //, string BirthHome
            , string Address
            //, string Job
            , string Mobil
            , string WorkPhone
            , string HomePhone
            , string National_ID
            //, string National_ID_Home
            , string Memb_Image
            , string Insurance_Number
            , Nullable<DateTime> Emp_Appointment_Date

            )
        {
            try
            {
                Member_Registration.Memb_ID = Memb_ID;
                Member_Registration.Memb_SysDate = Memb_SysDate;
                //if (Duplicate == "0")
                //{
                //    Member_Registration.Memb_EmpID = Memb_EmpID;
                //}
                //else
                //{
                //    Member_Registration.Memb_EmpID = Memb_EmpID + "-" + Duplicate;
                //}
                Member_Registration.Memb_EmpID = Memb_EmpID;
                Member_Registration.Memb_Name = Memb_Name;
                Member_Registration.Memb_Date = Memb_Date;
                Member_Registration.Memb_Birthdate = Memb_Birthdate;
                Member_Registration.Memb_Social_ID = Memb_Social_ID;
                Member_Registration.Memb_Children_Number = Memb_Children_Number;
                Member_Registration.Memb_Gender_ID = Memb_Gender_ID;
                
                Member_Registration.Military_Serv_ID = Memb_Military_Serv_ID;
                Member_Registration.Edu_Qualification_ID = Memb_Edu_Qualification_ID;
                Member_Registration.Work_Degree_ID = Memb_Work_Degree_ID;
                Member_Registration.Functional_ID = Memb_FunctionalGr_ID;
                Member_Registration.Qualitative_ID = Memb_QualitativeGr_ID;
                Member_Registration.Job_Title_ID = Memb_Job_Title_ID;
                Member_Registration.Email = Memb_Email;
                Member_Registration.Sect_ID = Sect_ID;
                Member_Registration.Cent_Dept_ID = Cent_Dept_ID;
                Member_Registration.Pub_Dept_ID = Pub_Dept_ID;
                Member_Registration.Dept_ID = Dept_ID;
                Member_Registration.Address = Address;
                Member_Registration.Memb_Image = Memb_Image;
                //Member_Registration.Job = Job;
                Member_Registration.Mobil = Mobil;
                Member_Registration.WorkPhone = WorkPhone;
                Member_Registration.HomePhone = HomePhone;
                Member_Registration.National_ID = National_ID;
                Member_Registration.Insurance_Number = Insurance_Number;
                Member_Registration.Emp_Appointment_Date = Emp_Appointment_Date;
                //Member_Registration.Insurance_Number = Insurance_Number;
                //  Member_Registration.NationalID_Home = National_ID_Home;
                // Member_Registration.BirthHome = BirthHome;

                Assoc.Tbl_Member_Registration.Add(Member_Registration);
                Assoc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }
        }

        public bool Update(
            int Memb_ID
            , DateTime Memb_SysDate
            , string Memb_EmpID
            , string Memb_Name
            , Nullable<DateTime> Memb_Date
            , DateTime Memb_Birthdate
            , int Memb_Social_ID
            , int Memb_Children_Number
            , int Memb_Gender_ID

            , int? Memb_Military_Serv_ID
            , int Memb_Edu_Qualification_ID
            , int Memb_Work_Degree_ID
            , int Memb_FunctionalGr_ID
            , int Memb_QualitativeGr_ID
            , int Memb_Job_Title_ID
            , string Memb_Email
            , int Sect_ID
            , int Cent_Dept_ID
            , int Pub_Dept_ID
            , int Dept_ID
            //, string BirthHome
            , string Address
            //, string Job
            , string Mobil
            , string WorkPhone
            , string HomePhone
            , string National_ID
            //, string National_ID_Home
            , string Memb_Image
            //, string Duplicate
            , string Insurance_Number
            , Nullable<DateTime> Emp_Appointment_Date
            )
        {
            try
            {
                Member_Registration = Assoc.Tbl_Member_Registration.Where(O => O.Memb_ID == Memb_ID).FirstOrDefault<Tbl_Member_Registration>();
                if (Member_Registration != null)
                {
                    Member_Registration.Memb_ID = Memb_ID;
                    Member_Registration.Memb_SysDate = Memb_SysDate;
                    //if (Duplicate == "0")
                    //{
                    //    Member_Registration.Memb_EmpID = Memb_EmpID;
                    //}
                    //else
                    //{
                    //    Member_Registration.Memb_EmpID = Memb_EmpID + "-" + Duplicate;
                    //}
                    Member_Registration.Memb_EmpID = Memb_EmpID;
                    Member_Registration.Memb_Name = Memb_Name;
                    Member_Registration.Memb_Date = Memb_Date;
                    Member_Registration.Memb_Birthdate = Memb_Birthdate;
                    Member_Registration.Memb_Social_ID = Memb_Social_ID;
                    Member_Registration.Memb_Children_Number = Memb_Children_Number;
                    Member_Registration.Memb_Gender_ID = Memb_Gender_ID;

                    Member_Registration.Military_Serv_ID = Memb_Military_Serv_ID;
                    Member_Registration.Edu_Qualification_ID = Memb_Edu_Qualification_ID;
                    Member_Registration.Work_Degree_ID = Memb_Work_Degree_ID;
                    Member_Registration.Functional_ID = Memb_FunctionalGr_ID;
                    Member_Registration.Qualitative_ID = Memb_QualitativeGr_ID;
                    Member_Registration.Job_Title_ID = Memb_Job_Title_ID;
                    Member_Registration.Email = Memb_Email;
                    Member_Registration.Sect_ID = Sect_ID;
                    Member_Registration.Cent_Dept_ID = Cent_Dept_ID;
                    Member_Registration.Pub_Dept_ID = Pub_Dept_ID;
                    Member_Registration.Dept_ID = Dept_ID;
                    Member_Registration.Address = Address;
                    Member_Registration.Memb_Image = Memb_Image;
                    //Member_Registration.Job = Job;
                    Member_Registration.Mobil = Mobil;
                    Member_Registration.WorkPhone = WorkPhone;
                    Member_Registration.HomePhone = HomePhone;
                    Member_Registration.National_ID = National_ID;
                    Member_Registration.Insurance_Number = Insurance_Number;
                    Member_Registration.Emp_Appointment_Date = Emp_Appointment_Date;



                    Assoc.Entry(Member_Registration).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }

        }

        public string Delete(int Memb_ID)
        {
            try
            {
                Member_Registration = Assoc.Tbl_Member_Registration.Where(O => O.Memb_ID == Memb_ID).FirstOrDefault<Tbl_Member_Registration>();

                Assoc.Entry(Member_Registration).State = EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }



        public string DeleteWithChilds(int Memb_ID)
        {
            try
            {
                Tbl_Member_Registration Member_Registration = Assoc.Tbl_Member_Registration.Where(O => O.Memb_ID == Memb_ID).FirstOrDefault<Tbl_Member_Registration>();
                List<RS_Memb_Transaction> RS_Memb_Transaction = Assoc.RS_Memb_Transaction.Where(d => (d.Memb_ID == Memb_ID)).ToList();
                List<Tbl_Subscribes> Tbl_Subscribes = Assoc.Tbl_Subscribes.Where(d => (d.Mem_ID == Memb_ID)).ToList();
                List<Rs_Acc_Transaction> Rs_Acc_Transaction = Assoc.Rs_Acc_Transaction.Where(d => (d.Rs_Acc_Transaction_Member_ID == Memb_ID)).ToList();

                if (Rs_Acc_Transaction.Count > 0)
                {
                    foreach (var item in Rs_Acc_Transaction)
                    {
                        Assoc.Entry(item).State = System.Data.EntityState.Deleted;
                    }
                    Assoc.SaveChanges();
                }


                if (RS_Memb_Transaction.Count > 0)
                {
                    foreach (var item in RS_Memb_Transaction)
                    {
                        Assoc.Entry(item).State = System.Data.EntityState.Deleted;
                    }
                    Assoc.SaveChanges();
                }


                if (Tbl_Subscribes.Count > 0)
                {
                    foreach (var item in Tbl_Subscribes)
                    {
                        Assoc.Entry(item).State = System.Data.EntityState.Deleted;
                    }
                    Assoc.SaveChanges();
                }


                if (Member_Registration != null)
                {
                    Assoc.Entry(Member_Registration).State = System.Data.EntityState.Deleted;
                    Assoc.SaveChanges();
                }




                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }




    }
}