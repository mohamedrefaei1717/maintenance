using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Association
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Assoc_Helper Assoc_Helper = new Assoc_Helper();
            Tbl_Member_Registration_DAL Tbl_Memb_Reg_DAL = new Tbl_Member_Registration_DAL();

            GridView1.DataSource = Tbl_Memb_Reg_DAL.Select_All_Member_Registration();
            GridView1.DataBind();

        }
    }
}