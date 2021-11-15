using Association.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Association
{
    public class HandlingExceptions
    {
        string Exc_Num;
        string Exc_Code;
        string Excep_Message;
        string User_Message;
        Assoc_Helper helper = new Assoc_Helper();
        AssociationEntities Assoc = new AssociationEntities();

        public HandlingExceptions() { }
        public string HandlingExce(Exception ex)
        {
            try
            {
                Excep_Message = ex.Message;
                if (ex.GetType() == typeof(DbUpdateException))
                {
                    //SqlException sqlex = (SqlException)ex.InnerException; 
                    SqlException sqlex = (SqlException)ex.InnerException.InnerException;
                    Exc_Num = sqlex.Number.ToString();
                    Exc_Code = sqlex.ErrorCode.ToString();
                    Excep_Message = sqlex.Message;

                    if (Exc_Num == "2627")
                    {
                        User_Message = "هذا السجل موجود مسبقاً";
                    }
                    else if (Exc_Num == "547")
                    {
                        User_Message = "هناك بيانات متعلقة بهذا السجل";
                    }
                    else
                    {
                        User_Message = "هناك بيانات خاطئة";
                        Insert_Exception(ex);
                    }
                }
                else if (ex.GetType() == typeof(ArgumentNullException))
                {
                    User_Message = "هذا السجل غير موجود";
                    Insert_Exception(ex);
                }
                //else if()
                //{

                //}
                else if (ex.GetType() == typeof(DbEntityValidationException))
                {
                    string ValMess = "";
                    DbEntityValidationException dbEx = (DbEntityValidationException)ex;

                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            ValMess = validationError.PropertyName + " - - " + validationError.ErrorMessage;
                            User_Message = ValMess;
                            Insert_Exception(ex);
                        }
                    }
                    //User_Message = ValMess;
                }
                else
                {
                    Insert_Exception(ex);
                    User_Message = "هناك بيانات خاطئة";
                }



                return User_Message;
            }


            catch (Exception excep)
            {
                Excep_Message = excep.Message;
                Insert_Exception(ex);
                return User_Message;
            }

        }





        public void Insert_Exception(Exception ex)
        {
            try
            {
                TBL_Exception TBLExcep = new TBL_Exception();
                TBLExcep.Excep_ErrorNumber = Exc_Num;
                TBLExcep.Excep_ErrorCode = Exc_Code;
                TBLExcep.Excep_Type = ex.GetType().ToString();
                TBLExcep.Excep_Message = Excep_Message;
                TBLExcep.Excep_DateTime = helper.format_date(DateTime.Now.ToString());

                // Insert it
                Assoc.TBL_Exception.Add(TBLExcep);
                Assoc.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string ValMess = "";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        ValMess = validationError.PropertyName + " - - " + validationError.ErrorMessage;
                        User_Message = ValMess;
                        Insert_Exception(ex);
                    }
                }
                //User_Message = ValMess;
                //Insert_Exception(ex);
            }
            catch (Exception excep)
            {
                Insert_Exception(excep);
            }

        }






    }
}