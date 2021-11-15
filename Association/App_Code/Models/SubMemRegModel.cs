using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association 
{
    public class SubMemRegModel
    {
        public int Sub_Year { get; set; }
        public int Mem_ID { get; set; }
        public Nullable<bool> Jan { get; set; }
        public Nullable<bool> Feb { get; set; }
        public Nullable<bool> Mar { get; set; }
        public Nullable<bool> Apr { get; set; }
        public Nullable<bool> May { get; set; }
        public Nullable<bool> June { get; set; }
        public Nullable<bool> July { get; set; }
        public Nullable<bool> August { get; set; }
        public Nullable<bool> Sep { get; set; }
        public Nullable<bool> Oct { get; set; }
        public Nullable<bool> Nov { get; set; }
        public Nullable<bool> Dec { get; set; }
        public Nullable<int> Sub_Paied { get; set; }


        public string Memb_Name { get; set; }

        public string Memb_EmpID { get; set; }   
    }
}