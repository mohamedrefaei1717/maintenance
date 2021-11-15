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
    public class Rs_Acc_Transaction_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        HandlingExceptions hand_Excep = new HandlingExceptions();
        Rs_Acc_Transaction AccTrans = new Rs_Acc_Transaction();


        public string Insert(
            int Rs_Acc_Transaction_ID
            , DateTime RS_Acc_Transaction_Date
            , int RS_Acc_Trans_TypeOfType_ID
            , int Rs_Acc_Transaction_Value
            , string Rs_Acc_Transaction_Check_No
            , int? Rs_Acc_Transaction_Member_ID
            , string Rs_Acc_Transaction_Image
            , string Rs_Acc_Transaction_Notes
            
            )
        {
            try
            {
                AccTrans.Rs_Acc_Transaction_ID = Rs_Acc_Transaction_ID;
                AccTrans.RS_Acc_Transaction_Date = RS_Acc_Transaction_Date;
                AccTrans.RS_Acc_Trans_TypeOfType_ID = RS_Acc_Trans_TypeOfType_ID;
                AccTrans.Rs_Acc_Transaction_Value = Rs_Acc_Transaction_Value;
                AccTrans.Rs_Acc_Transaction_Check_No = Rs_Acc_Transaction_Check_No; 
                AccTrans.Rs_Acc_Transaction_Member_ID = Rs_Acc_Transaction_Member_ID; 
                AccTrans.Rs_Acc_Transaction_Image = Rs_Acc_Transaction_Image;
                AccTrans.Rs_Acc_Transaction_Notes = Rs_Acc_Transaction_Notes.ToString();
                

                Assoc.Rs_Acc_Transaction.Add(AccTrans);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                throw new Exception( hand_Excep.HandlingExce(ex));
            }
        }



        public string Update(
            int Rs_Acc_Transaction_ID
            , DateTime RS_Acc_Transaction_Date
            , int RS_Acc_Trans_TypeOfType_ID
            , int Rs_Acc_Transaction_Value
            , string Rs_Acc_Transaction_Check_No
            , int? Rs_Acc_Transaction_Member_ID
            , string Rs_Acc_transaction_Image
            , string Rs_Acc_Transaction_Notes
            )
        {
            try
            {
                AccTrans = Assoc.Rs_Acc_Transaction.Where(O => O.Rs_Acc_Transaction_ID == Rs_Acc_Transaction_ID).FirstOrDefault<Rs_Acc_Transaction>();
                if (AccTrans != null)
                {

                    AccTrans.RS_Acc_Trans_TypeOfType_ID = RS_Acc_Trans_TypeOfType_ID;
                    AccTrans.RS_Acc_Transaction_Date = RS_Acc_Transaction_Date;
                    AccTrans.Rs_Acc_Transaction_Value = Rs_Acc_Transaction_Value;
                    AccTrans.Rs_Acc_Transaction_Check_No = Rs_Acc_Transaction_Check_No;
                    AccTrans.Rs_Acc_Transaction_Member_ID = Rs_Acc_Transaction_Member_ID;
                    if (Rs_Acc_transaction_Image != "") AccTrans.Rs_Acc_Transaction_Image = Rs_Acc_transaction_Image;
                    AccTrans.Rs_Acc_Transaction_Notes = Rs_Acc_Transaction_Notes;

                    Assoc.Entry(AccTrans).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }




        public string Delet(int Rs_Acc_Transaction_ID)
        {
            try
            {
                AccTrans = Assoc.Rs_Acc_Transaction.Where(O => O.Rs_Acc_Transaction_ID == Rs_Acc_Transaction_ID).FirstOrDefault<Rs_Acc_Transaction>();

                Assoc.Entry(AccTrans).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }



        public List<SelectAll_Trans_For_MemberID_Result> SelectAll_Trans_For_MemberID(int MemberID)
        {
            return Assoc.SelectAll_Trans_For_MemberID(MemberID).ToList();
        }

        public Rs_Acc_Transaction Select_Transaction_By_ID(int Trans_ID)
        {
            return Assoc.Rs_Acc_Transaction.Where(x => x.Rs_Acc_Transaction_ID == Trans_ID).FirstOrDefault();
        }
   
    }
}