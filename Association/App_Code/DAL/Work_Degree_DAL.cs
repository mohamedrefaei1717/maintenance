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
    public class Work_Degree_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Work_Degree WorkDegree = new Tbl_Work_Degree();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Work_Degree_ID
            , string Work_Degree_Name
            )
        {
            try
            {
                WorkDegree.Work_Degree_ID = Work_Degree_ID;
                WorkDegree.Work_Degree_Name = Work_Degree_Name;

                Assoc.Tbl_Work_Degree.Add(WorkDegree);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Work_Degree_ID
            , string Work_Degree_Name
            )
        {
            try
            {
                WorkDegree = Assoc.Tbl_Work_Degree.Where(O => O.Work_Degree_ID == Work_Degree_ID).FirstOrDefault<Tbl_Work_Degree>();
                if (WorkDegree != null)
                {
                    WorkDegree.Work_Degree_Name = Work_Degree_Name;

                    Assoc.Entry(WorkDegree).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Work_Degree_ID)
        {
            try
            {
                WorkDegree = Assoc.Tbl_Work_Degree.Where(O => O.Work_Degree_ID == Work_Degree_ID).FirstOrDefault<Tbl_Work_Degree>();

                Assoc.Entry(WorkDegree).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Work_Degree> SelectAll_WorkDegree()
        {
            return Assoc.Tbl_Work_Degree.OrderByDescending(x => x.Work_Degree_ID).ToList();
        }
    }
}
