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
    
    public partial class TBL_SysUsers
    {
        public TBL_SysUsers()
        {
            this.Tbl_IPS = new HashSet<Tbl_IPS>();
        }
    
        public int Usr_ID { get; set; }
        public string Usr_firstname { get; set; }
        public string Usr_familyname { get; set; }
        public string Usr_IP { get; set; }
        public string Usr_email { get; set; }
        public string Usr_mobnum { get; set; }
        public string Usr_address { get; set; }
        public string Usr_img { get; set; }
        public string Usr_Name { get; set; }
        public string Usr_Pass { get; set; }
        public int Usr_ModID { get; set; }
        public bool Usr_IsActive { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        public virtual ICollection<Tbl_IPS> Tbl_IPS { get; set; }
        public virtual TBL_SysModules TBL_SysModules { get; set; }
    }
}
