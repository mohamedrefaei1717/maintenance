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
    
    public partial class Tbl_Course_Exam
    {
        public Tbl_Course_Exam()
        {
            this.RS_Traning_Process = new HashSet<RS_Traning_Process>();
        }
    
        public int Exam_ID { get; set; }
        public string Exam_Name { get; set; }
    
        public virtual ICollection<RS_Traning_Process> RS_Traning_Process { get; set; }
    }
}
