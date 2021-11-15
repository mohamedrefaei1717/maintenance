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
    public class Central_Dept_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Central_Departments Cent_Dept = new Tbl_Central_Departments();
        HandlingExceptions hand_Excep = new HandlingExceptions();


        public List<Tbl_Central_Departments> SelectAll_Central_Depts(int Cent_Dept_ID)
        {
            return Assoc.Tbl_Central_Departments.ToList<Tbl_Central_Departments>();
        }
        public List<Tbl_Central_Departments> SelectAll_Cent_Depts_By_Sector_ID(int Sect_ID)
        {
            return Assoc.Tbl_Central_Departments.Where(x => x.Sect_ID == Sect_ID).ToList();
        }

        public string Insert(
            int Cent_Dept_ID
            , string Cent_Dept_Name
            , int Sect_ID
            )
        {
            try
            {
                Cent_Dept.Cent_Dept_ID = Cent_Dept_ID;
                Cent_Dept.Cent_Dept_Name = Cent_Dept_Name;
                Cent_Dept.Sect_ID = Sect_ID;



                Assoc.Tbl_Central_Departments.Add(Cent_Dept);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
               int Cent_Dept_ID
            , string Cent_Dept_Name
            , int Sect_ID
            )
        {
            try
            {
                Cent_Dept = Assoc.Tbl_Central_Departments.Where(O => O.Cent_Dept_ID == Cent_Dept_ID).FirstOrDefault<Tbl_Central_Departments>();
                if (Cent_Dept != null)
                {

                    Cent_Dept.Cent_Dept_Name = Cent_Dept_Name;
                    Cent_Dept.Sect_ID = Sect_ID;

                    Assoc.Entry(Cent_Dept).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet_Temp(int cent_Dept_ID)
        {
            try
            {
                Cent_Dept = Assoc.Tbl_Central_Departments.Where(O => O.Cent_Dept_ID == cent_Dept_ID).FirstOrDefault<Tbl_Central_Departments>();

                Assoc.Entry(Cent_Dept).State = EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Central_Departments> SelectAll_Cent_Dept()
        {
            return Assoc.Tbl_Central_Departments.OrderByDescending(x => x.Cent_Dept_ID).ToList();
        }


       
    }
}