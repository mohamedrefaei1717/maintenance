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
    public class CheckType_DAL
    {
    //    AssociationEntities Assoc = new AssociationEntities();
    //    Tbl_CheckType ChekType = new Tbl_CheckType();
    //    HandlingExceptions hand_Excep = new HandlingExceptions();

    //    public string Insert(
    //        int Check_TypeID
    //        , string Check_TypeName
    //        )
    //    {
    //        try
    //        {
    //            ChekType.Check_TypeID = Check_TypeID;
    //            ChekType.Check_TypeName = Check_TypeName;

    //            Assoc.Tbl_CheckType.Add(ChekType);
    //            Assoc.SaveChanges();
    //            return "تمت الإضافة بنجاح";
    //        }
    //        catch (Exception ex)
    //        {
    //            return (hand_Excep.HandlingExce(ex));
    //        }
    //    }

    //    public string Update(
    //        int Check_TypeID
    //        , string Check_TypeName
    //        )
    //    {
    //        try
    //        {
    //            ChekType = Assoc.Tbl_CheckType .Where(O => O.Check_TypeID  == Check_TypeID).FirstOrDefault<Tbl_CheckType>();
    //            if (ChekType != null)
    //            {
    //                ChekType.Check_TypeName = Check_TypeName;

    //                Assoc.Entry(ChekType).State = System.Data.EntityState.Modified;
    //                Assoc.SaveChanges();
    //            }
    //            return "تم التعديل بنجاح";
    //        }
    //        catch (Exception ex)
    //        {
    //            return hand_Excep.HandlingExce(ex);
    //        }
    //    }

    //    public string Delet(int Check_TypeID)
    //    {
    //        try
    //        {
    //            ChekType = Assoc.Tbl_CheckType.Where(O => O.Check_TypeID == Check_TypeID).FirstOrDefault<Tbl_CheckType>();

    //            Assoc.Entry(ChekType).State = System.Data.EntityState.Deleted;
    //            Assoc.SaveChanges();

    //            return "تم الحذف بنجاح";
    //        }
    //        catch (Exception ex)
    //        {
    //            return hand_Excep.HandlingExce(ex);
    //        }
    //    }

    }
}