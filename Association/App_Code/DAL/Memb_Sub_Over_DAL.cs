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
    public class Memb_Sub_Over_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        //Memb_Sub_Over_DAL MembSubOver = new Memb_Sub_Over_DAL();
        Tbl_Memb_Sub_Over MembSubOver = new Tbl_Memb_Sub_Over();
        HandlingExceptions hand_Excep = new HandlingExceptions();


        public List<Tbl_Memb_Sub_Over> SelectAll_Memb_Sub_Over()
        {
            //return Assoc.Memb_Sub_Over.ToList<Memb_Sub_Over>();
            return Assoc.Tbl_Memb_Sub_Over.OrderByDescending(x => x.Date).ToList();
        }
        //public List<Memb_Sub_Over> SelectAll_Memb_Sub_Over_By_EmpId(int Memb_EmpId)
        //{
        //    return Assoc.Memb_Sub_Over.Where(x => x.Memb_EmpId == Memb_EmpId).ToList();
        //}

        public List<Tbl_Memb_Sub_Over> SelectAll_Memb_Sub_Over_By_Date(DateTime date_Exc_min, DateTime date_Exc_elaa)
        {
            return Assoc.Tbl_Memb_Sub_Over.OrderByDescending(x => x.Date).ToList().Where(x => x.Date >= date_Exc_min.Date && x.Date <= date_Exc_elaa.Date).ToList();
        }

        public string Insert(
            string Memb_EmpId
            , string Memb_Name
            , DateTime Date

            )
        {
            try
            {
                MembSubOver.Memb_EmpId = Memb_EmpId;
                MembSubOver.Memb_Name = Memb_Name;
                MembSubOver.Date = Date;



                Assoc.Tbl_Memb_Sub_Over.Add(MembSubOver);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        //public string Update(
        //       int Dept_ID
        //    , string Dept_Name
        //    , int Manag_ID
        //    )
        //{
        //    try
        //    {
        //        SubOrg = Assoc.Tbl_Departement.Where(O => O.Dept_ID == Dept_ID).FirstOrDefault<Tbl_Departement>();
        //        if (SubOrg != null)
        //        {

        //            SubOrg.Dept_Name = Dept_Name;
        //            SubOrg.Manag_ID = Manag_ID;

        //            Assoc.Entry(SubOrg).State = EntityState.Modified;
        //            Assoc.SaveChanges();
        //        }
        //        return "تم التعديل بنجاح";
        //    }
        //    catch (Exception ex)
        //    {
        //        return hand_Excep.HandlingExce(ex);
        //    }

        //}


        public string Delet_Memb_Sub_Over(string Memb_EmpId)
        {
            try
            {
                MembSubOver = Assoc.Tbl_Memb_Sub_Over.Where(O => O.Memb_EmpId == Memb_EmpId).FirstOrDefault<Tbl_Memb_Sub_Over>();

                Assoc.Entry(MembSubOver).State = EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Memb_Sub_Over> SelectAll_Memb_Over()
        {
            return Assoc.Tbl_Memb_Sub_Over.OrderByDescending(x => x.Memb_EmpId).ToList();
        }

    }
}