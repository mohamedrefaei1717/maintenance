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
    public class Social_DAL
    {

        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Social Social = new Tbl_Social();
        HandlingExceptions hand_Excep = new HandlingExceptions();


        public Tbl_Social SelectAll_Social_ByPK(int Social_ID)
        {
            return Assoc.Tbl_Social.Where(O => O.Social_ID == Social_ID).FirstOrDefault<Tbl_Social>();
        }


        public string Insert(
            int Social_ID
            , string Social_Name
            )
        {
            try
            {
                Social.Social_ID = Social_ID;
                Social.Social_Name = Social_Name;




                Assoc.Tbl_Social.Add(Social);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
               int Social_ID
            , string Social_Name
            )
        {
            try
            {
                Social = Assoc.Tbl_Social.Where(O => O.Social_ID == Social_ID).FirstOrDefault<Tbl_Social>();
                if (Social != null)
                {
                    
                    Social.Social_Name = Social_Name;

                    Assoc.Entry(Social).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }


        public string Delet_Temp(int Social_ID)
        {
            try
            {
                Social = Assoc.Tbl_Social.Where(O => O.Social_ID == Social_ID).FirstOrDefault<Tbl_Social>();

                Assoc.Entry(Social).State = EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Social> SelectAll_Social()
        {
            return Assoc.Tbl_Social.OrderByDescending(x => x.Social_ID).ToList();
        }

    }
}