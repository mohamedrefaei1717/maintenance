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
    
    public partial class Tbl_Public_Departments
    {
        public Tbl_Public_Departments()
        {
            this.Tbl_Departments = new HashSet<Tbl_Departments>();
        }
    
        public int Pub_Dept_ID { get; set; }
        public string Pub_Dept_Name { get; set; }
        public Nullable<int> Cent_Dept_ID { get; set; }
    
        public virtual Tbl_Central_Departments Tbl_Central_Departments { get; set; }
        public virtual ICollection<Tbl_Departments> Tbl_Departments { get; set; }
    }
}
