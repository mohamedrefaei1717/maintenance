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
    public class  Insurance_Subscripe_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Insurance_Subscripe InsuSubscripe = new Tbl_Insurance_Subscripe();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Insur_ID
            , int Mem_ID
            , DateTime Insur_Sub_Date
            )
        {
            try
            {
                InsuSubscripe.Insur_ID = Insur_ID;
                InsuSubscripe.Mem_ID = Mem_ID;
                InsuSubscripe.Insur_Sub_Date = Insur_Sub_Date;

                Assoc.Tbl_Insurance_Subscripe.Add(InsuSubscripe);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return (hand_Excep.HandlingExce(ex));
            }
        }

        public string Update(
            int Insur_ID
            , int Mem_ID
            , DateTime Insur_Sub_Date
            )
        {
            try
            {
                InsuSubscripe = Assoc.Tbl_Insurance_Subscripe.Where(d => (d.Insur_ID == Insur_ID) && (d.Insur_Sub_Date == d.Insur_Sub_Date)).FirstOrDefault<Tbl_Insurance_Subscripe>();
                if (InsuSubscripe != null)
                {
                    InsuSubscripe.Mem_ID = Mem_ID;

                    Assoc.Entry(InsuSubscripe).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return (hand_Excep.HandlingExce(ex));
            }
        }

        public string Delet(int Insur_ID, DateTime Insur_Sub_Date)
        {
            try
            {
                InsuSubscripe = Assoc.Tbl_Insurance_Subscripe.Where(d => (d.Insur_ID == Insur_ID) && (d.Insur_Sub_Date == d.Insur_Sub_Date)).FirstOrDefault<Tbl_Insurance_Subscripe>();

                Assoc.Entry(InsuSubscripe).State = System.Data.EntityState.Deleted;
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