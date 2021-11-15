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
    public class Public_Dept_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Public_Departments Pub_Dept = new Tbl_Public_Departments();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Public_Departments> SelectAll_Pub_Dept()
        {
            return Assoc.Tbl_Public_Departments.OrderByDescending(x => x.Pub_Dept_ID).ToList();
        }

        public List<Tbl_Public_Departments> SelectAll_Pub_Dept_By_Cent_Dept_ID(int Cent_Dept_ID)
        {
            return Assoc.Tbl_Public_Departments.Where(O => O.Cent_Dept_ID == Cent_Dept_ID).ToList<Tbl_Public_Departments>();
        }


        public string Insert(
              int Pub_Dept_ID
            , string Pub_Dept_Name
            , int Cent_Dept_ID
            )
        {
            try
            { 
                Pub_Dept.Pub_Dept_ID = Pub_Dept_ID;
                Pub_Dept.Pub_Dept_Name = Pub_Dept_Name;
                Pub_Dept.Cent_Dept_ID = Cent_Dept_ID;
                 
                Assoc.Tbl_Public_Departments.Add(Pub_Dept);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
               int Pub_Dept_ID
            , string Pub_Dept_Name
            , int Cent_Dept_ID
            )
        {
            try
            {
                Pub_Dept = Assoc.Tbl_Public_Departments.Where(O => O.Pub_Dept_ID == Pub_Dept_ID).FirstOrDefault<Tbl_Public_Departments>();
                if (Pub_Dept != null)
                {

                    Pub_Dept.Pub_Dept_Name = Pub_Dept_Name;
                    Pub_Dept.Cent_Dept_ID = Cent_Dept_ID;

                    Assoc.Entry(Pub_Dept).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet_Temp(int Pub_Dep_ID)
        {
            try
            {
                Pub_Dept = Assoc.Tbl_Public_Departments.Where(O => O.Pub_Dept_ID == Pub_Dep_ID).FirstOrDefault<Tbl_Public_Departments>();

                Assoc.Entry(Pub_Dept).State = EntityState.Deleted;
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