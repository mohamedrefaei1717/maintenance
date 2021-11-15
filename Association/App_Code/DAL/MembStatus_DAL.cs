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
    public class  MembStatus_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_MembStatus MembStatus = new Tbl_MembStatus();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_MembStatus> SelectAll_MembStatus()
        {
            return Assoc.Tbl_MembStatus.ToList<Tbl_MembStatus>();
        }
        public Tbl_MembStatus SelectAll_MembStatus_ByPK(int MembStatus_ID)
        {
            return Assoc.Tbl_MembStatus.Where(O => O.MembStatus_ID == MembStatus_ID).FirstOrDefault<Tbl_MembStatus>();
        }


        public string Insert(
            int MembStatus_ID
            , string MembStatus_Name
            )
        {
            try
            {
                MembStatus.MembStatus_ID = MembStatus_ID;
                MembStatus.MembStatus_Name = MembStatus_Name;




                Assoc.Tbl_MembStatus.Add(MembStatus);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
              int MembStatus_ID
            , string MembStatus_Name
            )
        {
            try
            {
                MembStatus = Assoc.Tbl_MembStatus.Where(O => O.MembStatus_ID == MembStatus_ID).FirstOrDefault<Tbl_MembStatus>();
                if (MembStatus != null)
                {
                    
                    MembStatus.MembStatus_Name = MembStatus_Name;

                    Assoc.Entry(MembStatus).State =EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet_Temp(int MembStatus_ID)
        {
            try
            {
                MembStatus = Assoc.Tbl_MembStatus.Where(O => O.MembStatus_ID == MembStatus_ID).FirstOrDefault<Tbl_MembStatus>();

                Assoc.Entry(MembStatus).State = EntityState.Deleted;
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