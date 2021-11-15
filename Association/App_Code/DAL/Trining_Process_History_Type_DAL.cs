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
    class Trining_Process_History_Type_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Trining_Process_History_Type Tr_Proc_History_Type = new Tbl_Trining_Process_History_Type();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Tr_Proc_History_Type_ID
            , string Tr_Proc_History_Type_Name
            )
        {
            try
            {
                Tr_Proc_History_Type.Tr_Proc_History_Type_ID = Tr_Proc_History_Type_ID;
                Tr_Proc_History_Type.Tr_Proc_History_Type_Name = Tr_Proc_History_Type_Name;

                Assoc.Tbl_Trining_Process_History_Type.Add(Tr_Proc_History_Type);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Tr_Proc_History_Type_ID
            , string Tr_Proc_History_Type_Name
            )
        {
            try
            {
                Tr_Proc_History_Type = Assoc.Tbl_Trining_Process_History_Type.Where(O => O.Tr_Proc_History_Type_ID == Tr_Proc_History_Type_ID).FirstOrDefault<Tbl_Trining_Process_History_Type>();
                if (Tr_Proc_History_Type != null)
                {
                    Tr_Proc_History_Type.Tr_Proc_History_Type_Name = Tr_Proc_History_Type_Name;

                    Assoc.Entry(Tr_Proc_History_Type).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Tr_Proc_History_Type_ID)
        {
            try
            {
                Tr_Proc_History_Type = Assoc.Tbl_Trining_Process_History_Type.Where(O => O.Tr_Proc_History_Type_ID == Tr_Proc_History_Type_ID).FirstOrDefault<Tbl_Trining_Process_History_Type>();

                Assoc.Entry(Tr_Proc_History_Type).State = System.Data.EntityState.Deleted;
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
