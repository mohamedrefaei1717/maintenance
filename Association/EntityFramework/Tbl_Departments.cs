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
    
    public partial class Tbl_Departments
    {
        public int Dept_ID { get; set; }
        public string Dept_Name { get; set; }
        public Nullable<int> Pub_Dept_ID { get; set; }
    
        public virtual Tbl_Public_Departments Tbl_Public_Departments { get; set; }
    }
}
