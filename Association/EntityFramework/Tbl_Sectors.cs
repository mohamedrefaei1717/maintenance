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
    
    public partial class Tbl_Sectors
    {
        public Tbl_Sectors()
        {
            this.Tbl_Central_Departments = new HashSet<Tbl_Central_Departments>();
        }
    
        public int Sect_ID { get; set; }
        public string Sect_Name { get; set; }
    
        public virtual ICollection<Tbl_Central_Departments> Tbl_Central_Departments { get; set; }
    }
}