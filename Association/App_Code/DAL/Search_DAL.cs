using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using Association.EntityFramework;

namespace Association
{
    public class Search_DAL
    {
        AssociationEntities AssoDB = new AssociationEntities();
        public DataTable SelectAllMembers_With_Status()
        {
            DataTable dt = GenLstToDt.ToDataTable<SelectAllMembers_With_Status_Result>(AssoDB.SelectAllMembers_With_Status().ToList());
            return dt;
        }

    }
}
