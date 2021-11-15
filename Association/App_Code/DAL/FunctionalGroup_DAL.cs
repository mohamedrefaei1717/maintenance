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
    public class FunctionalGroup_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Funational_Group FunctionalGr = new Tbl_Funational_Group();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Functional_ID
            , string Functional_Name
            )
        {
            try
            {
                FunctionalGr.Functional_ID = Functional_ID;
                FunctionalGr.Functional_Name = Functional_Name;

                Assoc.Tbl_Funational_Group.Add(FunctionalGr);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Functional_ID
            , string Functional_Name
            )
        {
            try
            {
                FunctionalGr = Assoc.Tbl_Funational_Group.Where(O => O.Functional_ID == Functional_ID).FirstOrDefault<Tbl_Funational_Group>();
                if (FunctionalGr != null)
                {
                    FunctionalGr.Functional_Name = Functional_Name;

                    Assoc.Entry(FunctionalGr).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int functional_ID)
        {
            try
            {
                FunctionalGr = Assoc.Tbl_Funational_Group.Where(O => O.Functional_ID == functional_ID).FirstOrDefault<Tbl_Funational_Group>();

                Assoc.Entry(FunctionalGr).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Funational_Group> SelectAll_Functional_Group()
        {
            return Assoc.Tbl_Funational_Group.OrderByDescending(x => x.Functional_ID).ToList();
        }


    }
}
