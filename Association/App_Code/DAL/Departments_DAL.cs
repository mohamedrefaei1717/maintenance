using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Association.EntityFramework;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Data;

namespace Association
{
    public class Departments_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Departments Depts = new Tbl_Departments();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Departments> SelectAll_Departments()
        {
            return Assoc.Tbl_Departments.OrderByDescending(x => x.Dept_ID).ToList();
        }

        public List<Tbl_Departments> SelectAll_Depts_By_Pub_Dept_ID(int Pub_Dept_ID)
        {
            return Assoc.Tbl_Departments.Where(O => O.Pub_Dept_ID == Pub_Dept_ID).ToList<Tbl_Departments>();
        }


        public string Insert(
            int Dept_ID 
            ,string Dept_Name
            , int Pub_Dept_ID
            
            


            )
        {
            try
            {
                Depts.Dept_ID = Dept_ID;
                Depts.Dept_Name = Dept_Name;
                Depts.Pub_Dept_ID = Pub_Dept_ID;




                Assoc.Tbl_Departments.Add(Depts);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
              int Dept_ID
            , string Dept_Name
            , int Pub_Dept_ID
            )
        {
            try
            {
                Depts = Assoc.Tbl_Departments.Where(O => O.Dept_ID == Dept_ID).FirstOrDefault<Tbl_Departments>();
                if (Depts != null)
                {

                    Depts.Dept_Name = Dept_Name;
                    Depts.Pub_Dept_ID = Pub_Dept_ID;

                    Assoc.Entry(Depts).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet_Temp(int Dept_ID)
        {
            try
            {
                Depts = Assoc.Tbl_Departments.Where(O => O.Dept_ID == Dept_ID).FirstOrDefault<Tbl_Departments>();

                Assoc.Entry(Depts).State = EntityState.Deleted;
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