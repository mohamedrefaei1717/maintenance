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
    
    public partial class Tbl_Reason_Type
    {
        public Tbl_Reason_Type()
        {
            this.RS_Memb_Transaction = new HashSet<RS_Memb_Transaction>();
        }
    
        public int Reason_ID { get; set; }
        public string Reason_Name { get; set; }
        public Nullable<int> MembStatus_ID { get; set; }
    
        public virtual ICollection<RS_Memb_Transaction> RS_Memb_Transaction { get; set; }
    }
}
