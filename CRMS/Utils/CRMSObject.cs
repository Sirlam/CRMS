using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMS.Utils
{
    public class CrmsData
    {
        public String GovernmentCode { get; set; }
        public String GovernmentState { get; set; }
        public String LegalCode { get; set; }
        public String LegalStatus { get; set; }
        public String CreditTypeCode { get; set; }
        public String CreditType { get; set; }
        public String BusinessLinesCode { get; set; }
        public String BusinessLines { get; set; }
        public String BusinessLinesSubsectorCode { get; set; }
        public String BusinessLinesSubsector { get; set; }
        public String AssociatedBusinessLine { get; set; }
        public String FeeTypeCode { get; set; }
        public String FeeType { get; set; }
        public String RepaymentAgreementCode { get; set; }
        public String RepaymentAgreementMode { get; set; }
        public String SecurityCode { get; set; }
        public String SecurityType { get; set; }
        public String RepaymentSourceCode { get; set; }
        public String RepaymentSource { get; set; }
        public String CityCode { get; set; }
        public String CityName { get; set; }
        public String State { get; set; }
        public String RelationshipCode { get; set; }
        public String RelationshipType { get; set; }
        public String CompanySizeCode { get; set; }
        public String CompanySize { get; set; }
        public String FundingSourceCode { get; set; }
        public String FundingSource { get; set; }
        public String PerformanceRepaymentCode { get; set; }
        public String PerformanceRepaymentStatus { get; set; }
        public String BankCode { get; set; }
        public String BankName { get; set; }
    }

    public class AccountDetails
    {
        public String AccountNumber { get; set; }
        public String AccountName { get; set; }
    }
}