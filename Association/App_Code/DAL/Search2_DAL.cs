using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Association.EntityFramework;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Data;




namespace Association.App_Code.DAL
{
    public class Search_DAL
    {
        AssociationEntities Assoc = new AssociationEntities();
        HandlingExceptions hand_Excep = new HandlingExceptions();

        public DataTable select_All_Check_Tbl()
        {
            DataTable dt = GenLstToDt.ToDataTable<SelectAllCheck_Result>(Assoc.SelectAllCheck().ToList());
            return dt;
        }

    }
}