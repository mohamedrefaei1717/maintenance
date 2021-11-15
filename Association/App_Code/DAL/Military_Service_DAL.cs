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
    public class Military_Service_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Military_Service MilitarySer = new Tbl_Military_Service();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Military_Serv_ID
            , string Military_Serv_Name
            )
        {
            try
            {
                MilitarySer.Military_Serv_ID = Military_Serv_ID;
                MilitarySer.Military_Serv_ID = Military_Serv_ID;

                Assoc.Tbl_Military_Service.Add(MilitarySer);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Military_Serv_ID
            , string Military_Serv_Name
            )
        {
            try
            {
                MilitarySer = Assoc.Tbl_Military_Service.Where(O => O.Military_Serv_ID == Military_Serv_ID).FirstOrDefault<Tbl_Military_Service>();
                if (MilitarySer != null)
                {
                    MilitarySer.Military_Serv_Name = Military_Serv_Name;

                    Assoc.Entry(MilitarySer).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Military_Serv_ID)
        {
            try
            {
                MilitarySer = Assoc.Tbl_Military_Service.Where(O => O.Military_Serv_ID == Military_Serv_ID).FirstOrDefault<Tbl_Military_Service>();

                Assoc.Entry(MilitarySer).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Military_Service> SelectAll_Military_Service()
        {
            return Assoc.Tbl_Military_Service.OrderByDescending(x => x.Military_Serv_ID).ToList();
        }
    }
}
