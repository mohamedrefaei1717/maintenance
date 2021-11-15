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
    public class Memb_Transaction_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        RS_Memb_Transaction RS_Memb_Transaction = new RS_Memb_Transaction();
        HandlingExceptions hand_Excep = new HandlingExceptions();
        //RS_Memb_Transaction MembTrans = new RS_Memb_Transaction();



        public string Insert(
            int Memb_ID
            , Nullable<DateTime> TransDate //Distion_Date
            , int Distion_No
            , int MembStatus_ID
            , int Reason_ID
            , Nullable<DateTime> Status_Date_From
            , Nullable<DateTime> Status_Date_To
            , string Status_Note
            )
        {
            try
            {
                RS_Memb_Transaction.Memb_ID = Memb_ID;
                RS_Memb_Transaction.TransDate = TransDate;
                RS_Memb_Transaction.Distion_No = Distion_No;
                RS_Memb_Transaction.MembStatus_ID = MembStatus_ID;
                RS_Memb_Transaction.Reason_ID = Reason_ID;
                RS_Memb_Transaction.Status_Date_From = Status_Date_From;
                RS_Memb_Transaction.Status_Date_To = Status_Date_To;
                RS_Memb_Transaction.Status_Note = Status_Note;


                Assoc.RS_Memb_Transaction.Add(RS_Memb_Transaction);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }


        public string update(
            int Transaction_ID
            , DateTime TransDate    //Distion_Date
            , int Distion_No
            , int MembStatus_ID
            , int Reason_ID
            , DateTime Status_Date_From
            , DateTime Status_Date_To
            , string Status_Note




            )
        {
            try
            {

                RS_Memb_Transaction = Assoc.RS_Memb_Transaction.Where(O => O.Transaction_ID == Transaction_ID).FirstOrDefault(); ;
              
                if (RS_Memb_Transaction != null)
                {
                    RS_Memb_Transaction.TransDate = TransDate;
                    RS_Memb_Transaction.Distion_No = Distion_No;
                    RS_Memb_Transaction.MembStatus_ID = MembStatus_ID;
                    RS_Memb_Transaction.Reason_ID = Reason_ID;
                    RS_Memb_Transaction.Status_Date_From = Status_Date_From;
                    RS_Memb_Transaction.Status_Date_To = Status_Date_To;
                    RS_Memb_Transaction.Status_Note = Status_Note;
                    
                    Assoc.Entry(RS_Memb_Transaction).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }



        }


        public string Delet(int Transaction_ID)
        {
            try
            {
                RS_Memb_Transaction = Assoc.RS_Memb_Transaction.Where(O => O.Transaction_ID == Transaction_ID).FirstOrDefault<RS_Memb_Transaction>();

                Assoc.Entry(RS_Memb_Transaction).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public RS_Memb_Transaction Select_Last_Trans_For_Memb(int Memb_ID)
        {
            return Assoc.RS_Memb_Transaction.Where(x => x.Memb_ID == Memb_ID).OrderByDescending(m => m.Transaction_ID).FirstOrDefault();
        }


        public RS_Memb_Transaction Select_Last_Trans_For_Memb_With_TransID(int Transaction_ID)
        {
            return Assoc.RS_Memb_Transaction.Where(x => x.Transaction_ID == Transaction_ID).OrderByDescending(m => m.TransDate).FirstOrDefault();
        }


    }
}