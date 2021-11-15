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
    public class Training_Place_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Training_Place Traning_Place = new Tbl_Training_Place();
        HandlingExceptions hand_Excep = new HandlingExceptions();
        public List<Tbl_Training_Place> Select_All_Training_Places()
        {
            return Assoc.Tbl_Training_Place.ToList();
        }
        public string Insert(
            int Training_Place_ID
            , string Training_Place_Name
            )
        {
            try
            {
                Traning_Place.Training_Place_ID = Training_Place_ID;
                Traning_Place.Training_Place_Name = Training_Place_Name;

                Assoc.Tbl_Training_Place.Add(Traning_Place);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Training_Place_ID
            , string Training_Place_Name
            )
        {
            try
            {
                Traning_Place = Assoc.Tbl_Training_Place.Where(O => O.Training_Place_ID == Training_Place_ID).FirstOrDefault<Tbl_Training_Place>();
                if (Training_Place_ID  != null)
                {
                    Traning_Place.Training_Place_Name = Training_Place_Name;

                    Assoc.Entry(Traning_Place).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Training_Place_ID)
        {
            try
            {
                Traning_Place = Assoc.Tbl_Training_Place.Where(O => O.Training_Place_ID == Training_Place_ID).FirstOrDefault<Tbl_Training_Place>();

                Assoc.Entry(Traning_Place).State = System.Data.EntityState.Deleted;
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
