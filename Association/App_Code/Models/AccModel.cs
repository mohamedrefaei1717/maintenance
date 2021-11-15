using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Association 
{
    public class AccModel
    { 
        public int Acc_TypeOfType_ID { get; set; }
        public string Acc_TypeOfType_Name { get; set; }


        public int Account_ID { get; set; }
        public string Account_Name { get; set; }

 

        public int Trans_Type_ID { get; set; }
        public string Trans_Type_Name { get; set; }

 

    }
}