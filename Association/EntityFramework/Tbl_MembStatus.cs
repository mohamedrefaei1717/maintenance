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
    
    public partial class Tbl_MembStatus
    {
        public Tbl_MembStatus()
        {
            this.RS_Memb_Transaction = new HashSet<RS_Memb_Transaction>();
        }
    
        public int MembStatus_ID { get; set; }
        public string MembStatus_Name { get; set; }
    
        public virtual ICollection<RS_Memb_Transaction> RS_Memb_Transaction { get; set; }
    }
}
