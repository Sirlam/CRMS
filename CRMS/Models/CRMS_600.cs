//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRMS_600
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Customer_ID { get; set; }
        public string Customer_Account_Number { get; set; }
        public string Customer_Name { get; set; }
        public string Syndication_Reference_Number { get; set; }
        public string Syndication_Name { get; set; }
        public decimal Syndication_Total_Amount { get; set; }
        public string Participating_Bank_COde { get; set; }
        public string Inputter_ID { get; set; }
        public Nullable<System.DateTime> Inputter_Date_Stamp { get; set; }
        public string Modifier_ID { get; set; }
        public Nullable<System.DateTime> Modifier_Date_Stamp { get; set; }
        public string CRMS_Ref_Number { get; set; }
        public string Loan_Ref_Number { get; set; }
    }
}
