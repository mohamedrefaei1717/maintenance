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
    
    public partial class Tbl_kinshipType
    {
        public Tbl_kinshipType()
        {
            this.Tbl_Relation = new HashSet<Tbl_Relation>();
        }
    
        public int kinship_ID { get; set; }
        public string kinship_Type { get; set; }
    
        public virtual ICollection<Tbl_Relation> Tbl_Relation { get; set; }
    }
}
