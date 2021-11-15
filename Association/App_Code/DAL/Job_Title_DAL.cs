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
    public class Job_Title_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Jobs_Titles JobTitles = new Tbl_Jobs_Titles();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Job_Title_ID
            , string Job_Title_Name
            )
        {
            try
            {
                JobTitles.Job_Title_ID = Job_Title_ID;
                JobTitles.Job_Title_Name = Job_Title_Name;

                Assoc.Tbl_Jobs_Titles.Add(JobTitles);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Job_Title_ID
            , string Job_Title_Name
            )
        {
            try
            {
                JobTitles = Assoc.Tbl_Jobs_Titles.Where(O => O.Job_Title_ID == Job_Title_ID).FirstOrDefault<Tbl_Jobs_Titles>();
                if (JobTitles != null)
                {
                    JobTitles.Job_Title_Name = Job_Title_Name;

                    Assoc.Entry(JobTitles).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Job_Title_ID)
        {
            try
            {
                JobTitles = Assoc.Tbl_Jobs_Titles.Where(O => O.Job_Title_ID == Job_Title_ID).FirstOrDefault<Tbl_Jobs_Titles>();

                Assoc.Entry(JobTitles).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Jobs_Titles> SelectAll_Jobs_Titles()
        {
            return Assoc.Tbl_Jobs_Titles.OrderByDescending(x => x.Job_Title_ID).ToList();
        }
    }
}
