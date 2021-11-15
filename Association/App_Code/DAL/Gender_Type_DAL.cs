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
    public class Gender_Type_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Gender_Type GenType = new Tbl_Gender_Type();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Gender_ID
            , string Gender_Type
            )
        {
            try
            {
                GenType.Gender_ID = Gender_ID;
                GenType.Gender_Type = Gender_Type;

                Assoc.Tbl_Gender_Type.Add(GenType);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Gender_ID
            , string Gender_Type
            )
        {
            try
            {
                GenType = Assoc.Tbl_Gender_Type.Where(O => O.Gender_ID == Gender_ID).FirstOrDefault<Tbl_Gender_Type>();
                if (GenType !=null)
                {
                 GenType.Gender_Type = Gender_Type;
                 
                    Assoc.Entry(GenType).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Gender_ID)
        {
            try
            {
                GenType = Assoc.Tbl_Gender_Type.Where(O => O.Gender_ID == Gender_ID).FirstOrDefault<Tbl_Gender_Type>();

                Assoc.Entry(GenType).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Gender_Type> SelectAll_Gender()
        {
            return Assoc.Tbl_Gender_Type.OrderByDescending(x => x.Gender_ID).ToList();
        }
    }
}