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
    
    public partial class Tbl_Social
    {
        public Tbl_Social()
        {
            this.Tbl_Member_Registration = new HashSet<Tbl_Member_Registration>();
        }
    
        public int Social_ID { get; set; }
        public string Social_Name { get; set; }
    
        public virtual ICollection<Tbl_Member_Registration> Tbl_Member_Registration { get; set; }
    }
}
