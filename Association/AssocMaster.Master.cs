using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Association
{
    public partial class AssocMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usr_Name"] == null)
            //{
            //    Response.Redirect("~/Login_PL.aspx");
            //}
            //else
            //{
            //    lblUsrName.Text = Session["Usr_Name"].ToString();
            //}
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            //Session.RemoveAll();
            //Session["Usr_Name"] = null;

            //Response.Redirect("~/Login_PL.aspx", false);
        }



    }
}