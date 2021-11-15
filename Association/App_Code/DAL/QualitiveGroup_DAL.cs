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
    public class QualitiveGroup_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Qualitative_Group QualitativeGro = new Tbl_Qualitative_Group();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public string Insert(
            int Qualitative_ID
            , string Qualitative_Name
            )
        {
            try
            {
                QualitativeGro.Qualitative_ID = Qualitative_ID;
                QualitativeGro.Qualitative_Name = Qualitative_Name;

                Assoc.Tbl_Qualitative_Group.Add(QualitativeGro);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }

        public string Update(
            int Qualitative_ID
            , string Qualitative_Name
            )
        {
            try
            {
                QualitativeGro = Assoc.Tbl_Qualitative_Group.Where(O => O.Qualitative_ID == Qualitative_ID).FirstOrDefault<Tbl_Qualitative_Group>();
                if (QualitativeGro != null)
                {
                    QualitativeGro.Qualitative_Name = Qualitative_Name;

                    Assoc.Entry(QualitativeGro).State = System.Data.EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet(int Qualitative_ID)
        {
            try
            {
                QualitativeGro = Assoc.Tbl_Qualitative_Group.Where(O => O.Qualitative_ID == Qualitative_ID).FirstOrDefault<Tbl_Qualitative_Group>();

                Assoc.Entry(QualitativeGro).State = System.Data.EntityState.Deleted;
                Assoc.SaveChanges();

                return "تم الحذف بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public List<Tbl_Qualitative_Group> SelectAll_Qualitative_Group()
        {
            return Assoc.Tbl_Qualitative_Group.OrderByDescending(x => x.Qualitative_ID).ToList();
        }

    }
}
