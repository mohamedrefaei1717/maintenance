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
    
    public partial class Tbl_Gender_Type
    {
        public Tbl_Gender_Type()
        {
            this.Tbl_Member_Registration = new HashSet<Tbl_Member_Registration>();
            this.Tbl_Relation = new HashSet<Tbl_Relation>();
        }
    
        public int Gender_ID { get; set; }
        public string Gender_Type { get; set; }
    
        public virtual ICollection<Tbl_Member_Registration> Tbl_Member_Registration { get; set; }
        public virtual ICollection<Tbl_Relation> Tbl_Relation { get; set; }
    }
}
