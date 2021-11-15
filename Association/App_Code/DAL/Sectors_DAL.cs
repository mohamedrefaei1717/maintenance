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
    public class Sectors_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        Tbl_Sectors Sectors = new Tbl_Sectors();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public List<Tbl_Sectors> SelectAll_Sectorss()
        {
            return Assoc.Tbl_Sectors.ToList<Tbl_Sectors>();
        }
        public List<Tbl_Sectors> SelectAll_Sectors_ByPK_Sect_ID(int Sect_ID)
        {
            return Assoc.Tbl_Sectors.Where(x => x.Sect_ID == Sect_ID).ToList();
        }

        public string Insert(
             string Sect_Name
           
            )
        {
            try
            {
                Sectors.Sect_Name = Sect_Name;
                
                Assoc.Tbl_Sectors.Add(Sectors);
                Assoc.SaveChanges();
                return "تمت الإضافة بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }
        }
        public string Update(
            int Sect_ID
            , string Sect_Name
            )
        {
            try
            {
                Sectors = Assoc.Tbl_Sectors.Where(O => O.Sect_ID == Sect_ID).FirstOrDefault<Tbl_Sectors>();
                if (Sectors != null)
                {

                    Sectors.Sect_Name = Sect_Name;
                    Assoc.Entry(Sectors).State = EntityState.Modified;
                    Assoc.SaveChanges();
                }
                return "تم التعديل بنجاح";
            }
            catch (Exception ex)
            {
                return hand_Excep.HandlingExce(ex);
            }

        }

        public string Delet_Temp(int sect_ID)
        {
            try
            {
                Sectors = Assoc.Tbl_Sectors.Where(O => O.Sect_ID == sect_ID).FirstOrDefault<Tbl_Sectors>();

                Assoc.Entry(Sectors).State = EntityState.Deleted;
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