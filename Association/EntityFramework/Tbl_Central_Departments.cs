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
    
    public partial class Tbl_Central_Departments
    {
        public Tbl_Central_Departments()
        {
            this.Tbl_Public_Departments = new HashSet<Tbl_Public_Departments>();
        }
    
        public int Cent_Dept_ID { get; set; }
        public string Cent_Dept_Name { get; set; }
        public Nullable<int> Sect_ID { get; set; }
    
        public virtual Tbl_Sectors Tbl_Sectors { get; set; }
        public virtual ICollection<Tbl_Public_Departments> Tbl_Public_Departments { get; set; }
    }
}