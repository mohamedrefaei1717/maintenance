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
    
    public partial class RS_Acc_Trans_TypeOfType
    {
        public RS_Acc_Trans_TypeOfType()
        {
            this.Rs_Acc_Transaction = new HashSet<Rs_Acc_Transaction>();
        }
    
        public int RS_Acc_Trans_TypeOfType_ID { get; set; }
        public int Acc_TypeOfType_ID { get; set; }
        public int Account_ID { get; set; }
        public int Trans_Type_ID { get; set; }
    
        public virtual Tbl_Acc_TypeOfType Tbl_Acc_TypeOfType { get; set; }
        public virtual Tbl_Account Tbl_Account { get; set; }
        public virtual Tbl_TransactionType Tbl_TransactionType { get; set; }
        public virtual ICollection<Rs_Acc_Transaction> Rs_Acc_Transaction { get; set; }
    }
}
