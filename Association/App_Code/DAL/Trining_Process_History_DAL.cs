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
        
    class Trining_Process_History_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Trining_Process_History Tr_Proc_History = new Tbl_Trining_Process_History();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Tr_Proc_History_ID
            , int Tr_Proc_ID
            , int Tr_Proc_History_Type_ID
            , int Memb_EmpID
            
            )
        {
            try
            {
                Tr_Proc_History.Tr_Proc_History_ID = Tr_Proc_History_ID;
                Tr_Proc_History.Tr_Proc_ID = Tr_Proc_ID;
                Tr_Proc_History.Tr_Proc_History_Type_ID = Tr_Proc_History_Type_ID;
                Tr_Proc_History.Memb_EmpID = Memb_EmpID;

                Assoc.Tbl_Trining_Process_History.Add(Tr_Proc_History);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Tr_Proc_History_ID
            , int Tr_Proc_ID
            , int Tr_Proc_History_Type_ID
            , int Memb_EmpID
            )
        {
            try
            {
                Tr_Proc_History = Assoc.Tbl_Trining_Process_History.Where(O => O.Tr_Proc_History_ID == Tr_Proc_History_ID).FirstOrDefault<Tbl_Trining_Process_History>();
                if (Tr_Proc_History != null)
                {
                    Tr_Proc_History.Tr_Proc_History_ID = Tr_Proc_History_ID;
                    Tr_Proc_History.Tr_Proc_ID = Tr_Proc_ID;
                    Tr_Proc_History.Tr_Proc_History_Type_ID = Tr_Proc_History_Type_ID;
                    Tr_Proc_History.Memb_EmpID = Memb_EmpID;

                    Assoc.Entry(Tr_Proc_History).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Tr_Proc_History_ID)
        {
            try
            {
                Tr_Proc_History = Assoc.Tbl_Trining_Process_History.Where(O => O.Tr_Proc_History_ID == Tr_Proc_History_ID).FirstOrDefault<Tbl_Trining_Process_History>();

                Assoc.Entry(Tr_Proc_History).State = System.Data.EntityState.Deleted;
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
