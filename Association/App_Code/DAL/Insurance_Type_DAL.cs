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
    public class Tbl_Insurance_Type_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Insurance_Type InsuType = new Tbl_Insurance_Type ();
        HandlingExceptions hand_Excep = new HandlingExceptions();


        public string Insert(
             int Insurance_ID
             ,string Insurance_Type_Name
             )
        {
            try
            {
                InsuType.Insurance_ID = Insurance_ID;
                InsuType.Insurance_Type_Name = Insurance_Type_Name;
                
                Assoc.Tbl_Insurance_Type.Add(InsuType);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Insurance_ID
             , string Insurance_Type_Name
            )
        {
            try
            {
                InsuType = Assoc.Tbl_Insurance_Type.Where(O => O.Insurance_ID == Insurance_ID).FirstOrDefault<Tbl_Insurance_Type>();
                if (InsuType != null)
                {
                    InsuType.Insurance_ID = Insurance_ID;
                    InsuType.Insurance_Type_Name = Insurance_Type_Name;

                    Assoc.Entry(InsuType).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet_Temp(int Insurance_ID)
        {
            try
            {
                InsuType = Assoc.Tbl_Insurance_Type.Where(O => O.Insurance_ID == Insurance_ID).FirstOrDefault<Tbl_Insurance_Type>();

                Assoc.Entry(InsuType).State = System.Data.EntityState.Deleted;
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