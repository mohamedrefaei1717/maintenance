using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Association.EntityFramework;
using System.Globalization;

namespace Association
{
    public partial class Subscribes_PL : System.Web.UI.Page
    {
        Assoc_Helper helper = new Assoc_Helper();
        HandlingExceptions HandExcep = new HandlingExceptions();
        Member_Registration_DAL Member = new Member_Registration_DAL();
        Subscribes_DAL Subscribes_DAL = new Subscribes_DAL();
        Member_Registration_DAL Member_Registration_DAL = new Member_Registration_DAL();
        AssociationEntities DB = new AssociationEntities();

        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 11; i--)
                {
                    ddl_Year.Items.Add(i.ToString());
                }
                ddl_Year.Items.Insert(0, new ListItem("أختر السنة", "0"));


                for (int i = 1; i < 13; i++)
                {
                    ddl_Month.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                }
                ddl_Month.Items.Insert(0, new ListItem("إختر الشهر", "0"));


            }

            //if (gvSubscribes.Rows.Count > 0)
            //{
            //    // adds scope attribute

            //    gvSubscribes.UseAccessibleHeader = true;



            //    //adds <thead> and <tbody> elements

            //    gvSubscribes.HeaderRow.TableSection =

            //        TableRowSection.TableHeader;

            //    gvSubscribes.HeaderRow.CssClass = "someclass";
            //}
        }

        protected void Upload_Event_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSub_Paied.Text.Trim() == "" || ddl_Month.SelectedIndex == 0 || ddl_Year.SelectedIndex == 0)
                {
                    lblError.Text = "هناك بيانات خاطئة";
                    return;
                }

                DataTable SubscribesInfo_dtExcel = new DataTable();


                //=======================================================================================
                //======================================================================================= 
                //Second Step Read Excel And Validate Nat & Inst
                //=======================================================================================
                //======================================================================================= 


                DataTable dtExcel = new DataTable();
                dtExcel = helper.Save_And_Read_Excel(FUFile, "Yes");
                if (dtExcel.Rows.Count > 0)
                {
                    //Reomove all empty rows from datatable
                    helper.RemoveAllNullRowsFromDataTable(dtExcel);

                    //Reomove Temp File From Server
                    if (File.Exists(helper.TempFilePath)) { File.Delete(helper.TempFilePath); }



                    int CurrentYear = Convert.ToInt32(ddl_Year.SelectedValue);
                    int CurrentMonthValue = Convert.ToInt32(ddl_Month.SelectedValue);
                    int Sub_Paied = Convert.ToInt32(txtSub_Paied.Text.Trim());


                    List<int> EmpIDS = new List<int>();
                    foreach (DataRow row in dtExcel.Rows)
                    {
                        int EmpID = Convert.ToInt32(row["EmpID"]);
                        EmpIDS.Add(EmpID);
                    }
             


                    List<Tbl_Member_Registration> RegMems = Member_Registration_DAL.Select_All_Member_Registration();
                    foreach (var Member in RegMems)
                    {
                        Tbl_Member_Registration result = RegMems.Where(i => EmpIDS.Contains(Member.Memb_EmpID)).FirstOrDefault();
                         
                        if (result!=null)
                        {
                            SetUpdate(Member.Memb_EmpID, CurrentYear, CurrentMonthValue, Sub_Paied, true);
                        }
                        else
                        {
                            SetUpdate(Member.Memb_EmpID, CurrentYear, CurrentMonthValue, Sub_Paied, false);
                        }
                    }

                    //List<SubMemRegModel> MemberList = new List<SubMemRegModel>();
                    //foreach (var EmpID in EmpIDS)
                    //{ 
                    //    SubMemRegModel Subscribes = Subscribes_DAL.SubscribesWithName().Where(x => x.Memb_EmpID == EmpID).FirstOrDefault();
                    //    if (Subscribes != null)
                    //    { 
                    //        SetUpdate(EmpID, CurrentYear, CurrentMonthValue, Sub_Paied); 
                    //    } 
                    //}

        #region  Select subsribers where updated only
                    List<SubMemRegModel> MemberList = new List<SubMemRegModel>();
                    foreach (var EmpID in EmpIDS)
                    {
                        SubMemRegModel Subscribes = Subscribes_DAL.SubscribesWithName().Where(x => x.Memb_EmpID == EmpID).FirstOrDefault();
                        if (Subscribes != null)
                        {
                            MemberList.Add(Subscribes);
                        } 
                    }
        #endregion

                    gvSubscribes.DataSource = MemberList;
                    gvSubscribes.DataBind();



                }
                else
                {
                    gvSubscribes.DataSource = null;
                    gvSubscribes.DataBind();
                }





            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(string), "uniqueKey1" + DateTime.Now, " ShowMess('" + ex.Message + "','Failed' );", true);
                helper.ResetFormControlValues(this);
            }
        }

        private void SetUpdate(int EmpID, int CurrentYear, int CurrentMonthValue, int Sub_Paied, bool flag)
        {
            if (CurrentMonthValue == 1)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Jan: flag);
            }
            else if (CurrentMonthValue == 2)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Feb: flag);

            }
            else if (CurrentMonthValue == 3)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Mar: flag);

            }
            else if (CurrentMonthValue == 4)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Apr: flag);

            }
            else if (CurrentMonthValue == 5)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, May: flag);

            }
            else if (CurrentMonthValue == 6)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Jun: flag);

            }
            else if (CurrentMonthValue == 7)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Jul: flag);

            }
            else if (CurrentMonthValue == 8)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Aug: flag);

            }
            else if (CurrentMonthValue == 9)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Sep: flag);

            }
            else if (CurrentMonthValue == 10)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Oct: flag);

            }
            else if (CurrentMonthValue == 11)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Nov: flag);

            }
            else if (CurrentMonthValue == 12)
            {
                Subscribes_DAL.UpdateByEmpId(EmpID, CurrentYear, Sub_Paied, Dec: flag);

            }
        }

        private string SetCurrMonth(int CurrentMonthInValue)
        {
            Array enumValueArray = Enum.GetValues(typeof(Assoc_Helper.MonthEnum));
            foreach (int enumValue in enumValueArray)
            {
                if (CurrentMonthInValue == enumValue)
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(enumValue);
                }
            }

            return "";
        }
        protected void gvSubscribes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 4; i < 16; i++)
                {
                    string lblValue = e.Row.Cells[i].Text.Replace("&nbsp;", "");
                    if (lblValue != "")
                    {
                        bool? val = Convert.ToBoolean(lblValue);
                        if (val == true)
                        {
                            e.Row.Cells[i].Text = "تم الدفع";
                            e.Row.Cells[i].ForeColor = System.Drawing.Color.Green;
                        }
                        else if (val == false)
                        {
                            e.Row.Cells[i].Text = "لم يتم الدفع";
                            e.Row.Cells[i].ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }


    }
}