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
    public class Reason_Type_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Reason_Type Reason_Type = new Tbl_Reason_Type();
        HandlingExceptions hand_Excep = new HandlingExceptions();
        public List<Tbl_Reason_Type> SelectAll_Reason_Type()
        {
            return Assoc.Tbl_Reason_Type.ToList<Tbl_Reason_Type>();
        }

        public List<Tbl_Reason_Type> SelectAll_Reason_TypeWithoutNewMembReason()
        {
            return Assoc.Tbl_Reason_Type.Where(x=>x.Reason_ID>1).ToList<Tbl_Reason_Type>();
        }


        public Tbl_Reason_Type SelectAll_Reason_Type_ByPK(int Reason_ID)
        {
            return Assoc.Tbl_Reason_Type.Where(O => O.Reason_ID == Reason_ID).FirstOrDefault<Tbl_Reason_Type>();
        }

     
       

        public string Insert(
            int Reason_ID
            , string Reason_Name
            )
        {
            try
            {
                Reason_Type.Reason_ID = Reason_ID;
                Reason_Type.Reason_Name = Reason_Name;




                Assoc.Tbl_Reason_Type.Add(Reason_Type);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
              int Reason_ID
            , string Reason_Name
            )
        {
            try
            {
                Reason_Type = Assoc.Tbl_Reason_Type.Where(O => O.Reason_ID == Reason_ID).FirstOrDefault<Tbl_Reason_Type>();
                if (Reason_Type != null)
                {
                   
                    Reason_Type.Reason_Name = Reason_Name;

                    Assoc.Entry(Reason_Type).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet_Temp(int Reason_ID)
        {
            try
            {
                Reason_Type = Assoc.Tbl_Reason_Type.Where(O => O.Reason_ID == Reason_ID).FirstOrDefault<Tbl_Reason_Type>();

                Assoc.Entry(Reason_Type).State = EntityState.Deleted;
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