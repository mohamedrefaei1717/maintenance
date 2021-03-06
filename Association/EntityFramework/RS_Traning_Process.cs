//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Association.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class RS_Traning_Process
    {
        public RS_Traning_Process()
        {
            this.Tbl_Trining_Process_History = new HashSet<Tbl_Trining_Process_History>();
        }
    
        public int Tr_Proc_ID { get; set; }
        public string Memb_EmpID { get; set; }
        public Nullable<int> Course_ID { get; set; }
        public Nullable<int> Course_Typy_ID { get; set; }
        public System.DateTime Course_Start_Date { get; set; }
        public System.DateTime Course_End_Date { get; set; }
        public Nullable<int> Course_Funder_ID { get; set; }
        public Nullable<int> Training_Place_ID { get; set; }
        public Nullable<int> Course_Status_ID { get; set; }
        public string Course_Certificate { get; set; }
        public string Course_Rank { get; set; }
        public string Course_Cost { get; set; }
        public Nullable<int> Course_Exam_ID { get; set; }
        public string Course_GPA { get; set; }
        public Nullable<int> Course_PhaseNo_ID { get; set; }
        public string Course_Image { get; set; }
    
        public virtual Tbl_Course_Exam Tbl_Course_Exam { get; set; }
        public virtual Tbl_Course_Phase Tbl_Course_Phase { get; set; }
        public virtual Tbl_Courses Tbl_Courses { get; set; }
        public virtual Tbl_Courses_Status Tbl_Courses_Status { get; set; }
        public virtual Tbl_Courses_Funders Tbl_Courses_Funders { get; set; }
        public virtual Tbl_Courses_Type Tbl_Courses_Type { get; set; }
        public virtual Tbl_Training_Place Tbl_Training_Place { get; set; }
        public virtual ICollection<Tbl_Trining_Process_History> Tbl_Trining_Process_History { get; set; }
    }
}
