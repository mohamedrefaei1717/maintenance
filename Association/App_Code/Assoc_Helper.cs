using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Association
{
    public class Assoc_Helper
    {
        public enum MonthEnum
        {
            Undefined, // Required here even though it's not a valid month
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            June = 6,
            July = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12
        }

        public string sep(string s)
        {
            int l = s.IndexOf("-");
            if (l > 0)
            {
                return s.Substring(l+1);
            }
            return "0";

        }

        public string TempFilePath;

        public void ResetFormControlValues(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControlValues(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.CheckBoxList":
                            ((CheckBoxList)c).SelectedIndex = -1;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).SelectedIndex = -1;
                            break;
                        case "System.Web.UI.WebControls.DropDownList":

                            ((DropDownList)c).SelectedIndex = 0;

                            break;
                        case "System.Web.UI.WebControls.GridView":
                            ((GridView)c).DataSource = null;
                            ((GridView)c).DataBind();
                            break;
                        case "System.Web.UI.WebControls.Image":
                            ((Image)c).ImageUrl = null;
                            break;
                    }
                }
            }
        }

        public void Fill_DDL<T>(DropDownList DDL, IEnumerable<T> list, string DataTextField, string DataValueField)
        {
            DDL.DataSource = list;
            DDL.DataTextField = DataTextField;
            DDL.DataValueField = DataValueField;
            DDL.DataBind();
        }


        public void Fill_DDL<T>(DropDownList DDL, IEnumerable<T> list, string DataTextField, string DataValueField, string FirstItem = "")
        {
            DDL.DataSource = list;
            DDL.DataTextField = DataTextField;
            DDL.DataValueField = DataValueField;
            DDL.DataBind();
            if (FirstItem != "")
                DDL.Items.Insert(0, new ListItem(FirstItem, "0"));
        }


        public void DropDownListBind(DropDownList ddl, DataTable DataSource, string DataTextField, string DataValueField, string FirstItem = "")
        {
            ddl.DataSource = DataSource;
            ddl.DataTextField = DataTextField;
            ddl.DataValueField = DataValueField;
            ddl.DataBind();
            if (FirstItem != "")
                ddl.Items.Insert(0, new ListItem(FirstItem, "0"));

        }



        public void Fill_RadioButtonList<T>(RadioButtonList RB, IEnumerable<T> list, string DataTextField, string DataValueField, string SelectedValue = "")
        {
            RB.DataSource = list;
            RB.DataTextField = DataTextField;
            RB.DataValueField = DataValueField;
            RB.DataBind();
            if (SelectedValue != "")
                RB.SelectedValue = SelectedValue;
        }

        public void Fill_ListBox<T>(ListBox LB, IEnumerable<T> list, string DataTextField, string DataValueField, string SelectedValue = "")
        {
            LB.DataSource = list;
            LB.DataTextField = DataTextField;
            LB.DataValueField = DataValueField;
            LB.DataBind();
            if (SelectedValue != "")
                LB.SelectedValue = SelectedValue;
        }



        DateTimeFormatInfo FormatInfo = CultureInfo.CreateSpecificCulture("en-GB").DateTimeFormat;
        CultureInfo iv = CultureInfo.InvariantCulture;



        //format_date >>> Convert date as datepicker format(The date FormatException which the user write or choose)
        public DateTime format_date(Control date_control)
        {
            DateTime Dtime = new DateTime();
            if (date_control is TextBox)
            {
                TextBox txtdate = (TextBox)date_control;
                if (txtdate.Text.Trim() != "")
                {
                    Dtime = DateTime.Parse(txtdate.Text.Trim(), FormatInfo);
                }
            }
            else if (date_control is Label)
            {
                Label lbldate = (Label)date_control;
                if (lbldate.Text.Trim() != "")
                {
                    Dtime = DateTime.Parse(lbldate.Text.Trim(), FormatInfo);
                }
            }
            else if (date_control is DropDownList)
            {
                DropDownList ddldate = (DropDownList)date_control;
                if (ddldate.SelectedIndex != 0)
                {
                    Dtime = DateTime.Parse(ddldate.SelectedValue, FormatInfo);
                }
            }
            else if (date_control is HiddenField)
            {
                HiddenField hdf = (HiddenField)date_control;
                if (hdf.Value != "")
                {
                    Dtime = DateTime.Parse(hdf.Value, FormatInfo);
                }
            }
            return Dtime;
        }




        public DateTime format_date(string StringDate)
        {
            DateTime Dtime = new DateTime();

            if (StringDate != "")
            {
                Dtime = DateTime.Parse(StringDate, FormatInfo);
            }


            return Dtime;
        }



        public string ChangeFileName(string filename)
        {

            string newFileName;

            string[] Substring;

            char[] delimitdot = { '.' };

            char[] delimitspace = { ' ' };

            Substring = filename.Split(delimitdot, 2);

            string dateTimenew = System.DateTime.Now.ToString().Replace('/', ' ');

            string dateTime = dateTimenew.Replace(':', ' ');

            string[] substring1 = dateTime.Split(delimitspace);

            string appenddatetime = "";

            int i;

            for (i = 0; i < substring1.Length - 1; i++)
            {

                appenddatetime += substring1[i];

            }

            return newFileName = Substring[0] + appenddatetime + '.' + Substring[1];

        }


        public void ResetGV(GridView gv)
        {
            gv.DataSource = null;
            gv.DataBind();

        }



        public void RemoveAllNullRowsFromDataTable(DataTable dt)
        {
            try
            {
                int columnCount = dt.Columns.Count;

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    bool allNull = true;
                    for (int j = 0; j < columnCount; j++)
                    {
                        if (dt.Rows[i][j] != DBNull.Value)
                        {
                            allNull = false;
                        }
                    }
                    if (allNull)
                    {
                        dt.Rows[i].Delete();
                    }
                }
                dt.AcceptChanges();
            }


            catch (Exception ex)
            {
                //HandExcep.HandlingExce(ex, helper.GetPageName(Page), "RemoveAllNullRowsFromDataTable", Session["Usr_Name"].ToString());
            }
        }

        public DataTable Save_And_Read_Excel(FileUpload FileUpload, string isHDR)
        {
            try
            {
                if (FileUpload.HasFile)
                {
                    string conStr = "";


                    string FileName = Path.GetFileName(FileUpload.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload.PostedFile.FileName);
                    string RandomName = ChangeFileName(FileName);
                    string FilePath = HttpContext.Current.Server.MapPath("~/Excel/") + RandomName;
                    FileUpload.SaveAs(FilePath);
                    TempFilePath = FilePath;

                    switch (Extension)
                    {

                        case ".xls": //Excel 97-03

                            conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                     .ConnectionString;

                            break;

                        case ".xlsx": //Excel 07

                            conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                      .ConnectionString;

                            break;

                    }

                    conStr = String.Format(conStr, FilePath, isHDR);

                    OleDbConnection connExcel = new OleDbConnection(conStr);

                    OleDbCommand cmdExcel = new OleDbCommand();

                    OleDbDataAdapter oda = new OleDbDataAdapter();

                    DataTable dtExcel = new DataTable();

                    cmdExcel.Connection = connExcel;



                    //Get the name of First Sheet

                    connExcel.Open();

                    DataTable dtExcelSchema;

                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                    connExcel.Close();



                    //Read Data from First Sheet

                    connExcel.Open();

                    cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                    oda.SelectCommand = cmdExcel;

                    oda.Fill(dtExcel);

                    connExcel.Close();
                    return dtExcel;
                }
                else
                {
                    return new DataTable(); ;
                }

            }
            catch (Exception)
            {
                return new DataTable();
                //lblMsg.Text = HandExcep.HandlingExce(ex, helper.GetPageName(Page), helper.GetEventName(), Session["Usr_Name"].ToString());
            }
        }
        public Boolean CheckExcel(FileUpload FileUp)
        {
            if (FileUp.HasFile)
            {
                string filename = FileUp.PostedFile.FileName;
                string Extension = Path.GetExtension(filename);
                switch (Extension)
                {

                    case ".xls": //Excel 97-03

                        return true;



                    case ".xlsx": //Excel 07

                        return true;



                    default:
                        return false;


                }
            }
            else
            {
                return false;
            }


        }




    }
}