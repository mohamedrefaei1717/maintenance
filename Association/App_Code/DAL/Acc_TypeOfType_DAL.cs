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
    public class Acc_TypeOfType_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Acc_TypeOfType Acc_Type_Type = new Tbl_Acc_TypeOfType();
        HandlingExceptions hand_Excep = new HandlingExceptions();


        public List<AccModel> SelectAll_AccTypeofType_By_Acc_ID_And_Trans_ID(int Account_ID, int Trans_Type_ID) 
        {
            return Assoc.RS_Acc_Trans_TypeOfType.Where(x => x.Account_ID == Account_ID && x.Trans_Type_ID == Trans_Type_ID).Select(column => new AccModel
            {
                Acc_TypeOfType_ID = column.Tbl_Acc_TypeOfType.Acc_TypeOfType_ID,
                Acc_TypeOfType_Name = column.Tbl_Acc_TypeOfType.Acc_TypeOfType_Name
            }).ToList();

        }




        public string Insert(
            int Acc_TypeOfType_ID
            , string Acc_TypeOfType_Name
            )
        {
            try
            {
                Acc_Type_Type.Acc_TypeOfType_ID = Acc_TypeOfType_ID;
                Acc_Type_Type.Acc_TypeOfType_Name = Acc_TypeOfType_Name;

                Assoc.Tbl_Acc_TypeOfType.Add(Acc_Type_Type);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }


        public string Update(
            int Acc_TypeOfType_ID
            , string Acc_TypeOfType_Name
            )
        {
            try
            {
                Acc_Type_Type = Assoc.Tbl_Acc_TypeOfType.Where(O => O.Acc_TypeOfType_ID == Acc_TypeOfType_ID).FirstOrDefault<Tbl_Acc_TypeOfType>();
                if (Acc_Type_Type != null)
                {
                    Acc_Type_Type.Acc_TypeOfType_Name = Acc_TypeOfType_Name;

                    Assoc.Entry(Acc_Type_Type).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet(int Acc_TypeOfType_ID)
        {
            try
            {
                Acc_Type_Type = Assoc.Tbl_Acc_TypeOfType.Where(O => O.Acc_TypeOfType_ID == Acc_TypeOfType_ID).FirstOrDefault<Tbl_Acc_TypeOfType>();

                Assoc.Entry(Acc_Type_Type).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Acc_TypeOfType> SelectAll_Acc_TypeOfType()
        {
            return Assoc.Tbl_Acc_TypeOfType.OrderByDescending(x => x.Acc_TypeOfType_ID).ToList();
        }





    }
}