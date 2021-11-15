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
    public class Illegal_Earn_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Illegal_Earning Illegal_Earn = new Tbl_Illegal_Earning();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public bool Insert(
            //int Illegal_ID
            int Memb_ID
            , DateTime Illegal_Date
            , string Illegal_Note
            ,string Illegal_Image
            )
        {
            try
            {
                //Illegal_Earn.Illegal_ID = Illegal_ID;
                Illegal_Earn.Memb_ID = Memb_ID;
                Illegal_Earn.Illegal_Date = Illegal_Date;
                Illegal_Earn.Illegal_Note = Illegal_Note;
                Illegal_Earn.Illegal_Image = Illegal_Image;

                Assoc.Tbl_Illegal_Earning.Add(Illegal_Earn);
                Assoc.SaveChanges();
                //return "تمت الإضافة بنجاح";
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(hand_Excep.HandlingExce(ex));
            }
        }

        public string Update(
            int Illegal_ID
            , int Memb_ID
            , DateTime Illegal_Date
            , string Illegal_Note
            , string Illegal_Image
            )
        {
            try
            {
                Illegal_Earn = Assoc.Tbl_Illegal_Earning.Where(O => O.Illegal_ID == Illegal_ID).FirstOrDefault<Tbl_Illegal_Earning>();
                if (Illegal_Earn != null)
                {
                    //Illegal_Earn.Illegal_ID = Illegal_ID;
                    Illegal_Earn.Memb_ID = Memb_ID;
                    Illegal_Earn.Illegal_Date = Illegal_Date;
                    Illegal_Earn.Illegal_Note = Illegal_Note;
                    Illegal_Earn.Illegal_Image = Illegal_Image;

                    Assoc.Entry(Illegal_Earn).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Illegal_ID)
        {
            try
            {
                Illegal_Earn = Assoc.Tbl_Illegal_Earning.Where(O => O.Illegal_ID == Illegal_ID).FirstOrDefault<Tbl_Illegal_Earning>();

                Assoc.Entry(Illegal_Earn).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<SelectAll_Illegal_Earning_For_MemberID_Result> SelectAll_Illegal_Earning_For_MemberID(int MemberID)
        {
            return Assoc.SelectAll_Illegal_Earning_For_MemberID(MemberID).ToList();
        }


        //public Illegal_Earn_DAL Select_Last_Illeagel_For_Memb_With_MembID(int Memb_ID)
        //{
        //    return Assoc.SelectAll_Illegal_Earning_For_MemberID.Where(x => x.Transaction_ID == Transaction_ID).OrderByDescending(m => m.TransDate).FirstOrDefault();
        //}



    }

}
