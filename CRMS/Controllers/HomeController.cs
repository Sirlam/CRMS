using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMS.Utils;

namespace CRMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var crmsUtil = new CrmsUtil();
            ViewBag.GovtCodes = crmsUtil.GetGovernmentCodes();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.RepaymentSource = crmsUtil.GetRepaymentSource();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            //Get The Values Again After Post
            var crmsUtil = new CrmsUtil();
            ViewBag.GovtCodes = crmsUtil.GetGovernmentCodes();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.RepaymentSource = crmsUtil.GetRepaymentSource();

            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string govtCode = formCollection["GovtCode"];
            string legalStatus = formCollection["LegalStatus"];
            string creditType = formCollection["CreditType"];
            string businessLines = formCollection["BusinessLines"];
            string businessLinesSubsector = formCollection["BusinessLinesSubsector"];
            decimal creditLimit = Math.Round(Convert.ToDecimal(formCollection["CreditLimit"]), 2);
            decimal outstandingAmount = Math.Round(Convert.ToDecimal(formCollection["OutstandingAmount"]), 2);

            string feeType1 = formCollection["FeeType1"];
            decimal feeAmount1 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount1"]), 2);

            string feeType2 = formCollection["FeeType2"];
            decimal feeAmount2 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount2"]), 2);

            string feeType3 = formCollection["FeeType3"];
            decimal feeAmount3 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount3"]), 2);

            string feeType4 = formCollection["FeeType4"];
            decimal feeAmount4 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount4"]), 2);

            string feeType5 = formCollection["FeeType5"];
            decimal feeAmount5 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount5"]), 2);

            string feeType6 = formCollection["FeeType6"];
            decimal feeAmount6 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount6"]), 2);

            string feeType7 = formCollection["FeeType7"];
            decimal feeAmount7 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount7"]), 2);

            string feeType8 = formCollection["FeeType8"];
            decimal feeAmount8 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount8"]), 2);

            string feeType9 = formCollection["FeeType9"];
            decimal feeAmount9 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount9"]), 2);

            string feeType10 = formCollection["FeeType10"];
            decimal feeAmount10 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount10"]), 2);

            string feeType11 = formCollection["FeeType11"];
            decimal feeAmount11 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount11"]), 2);

            string feeType12 = formCollection["FeeType12"];
            decimal feeAmount12 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount12"]), 2);

            string feeType13 = formCollection["FeeType13"];
            decimal feeAmount13 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount13"]), 2);

            string feeType14 = formCollection["FeeType14"];
            decimal feeAmount14 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount14"]), 2);

            string feeType15 = formCollection["FeeType15"];
            decimal feeAmount15 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount15"]), 2);

            string feeType16 = formCollection["FeeType16"];
            decimal feeAmount16 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount16"]), 2);

            DateTime effectiveDate = DateTime.ParseExact(formCollection["EffectiveDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            int tenor = Convert.ToInt32(formCollection["Tenor"]);
            DateTime expiryDate = DateTime.ParseExact(formCollection["ExpiryDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            string repaymentAgreement = formCollection["RepaymentAgreement"];
            string specialisedLoan = formCollection["SpecialisedLoan"];
            int specialisedLoanPeriod = Convert.ToInt32(formCollection["SpecialisedLoanPeriod"]);
            decimal interestRate = Math.Round(Convert.ToDecimal(formCollection["InterestRate"]), 2);

            string collateralPresent1 = formCollection["CollateralPresent1"];
            string collateralSecure1 = formCollection["CollateralSecure1"];
            string securityType1 = formCollection["SecurityType1"];

            string collateralSecure2 = formCollection["CollateralSecure2"];
            string securityType2 = formCollection["SecurityType2"];

            string collateralSecure3 = formCollection["CollateralSecure3"];
            string securityType3 = formCollection["SecurityType3"];

            string collateralSecure4 = formCollection["CollateralSecure4"];
            string securityType4 = formCollection["SecurityType4"];

            string collateralSecure5 = formCollection["CollateralSecure5"];
            string securityType5 = formCollection["SecurityType5"];

            string collateralSecure6 = formCollection["CollateralSecure6"];
            string securityType6 = formCollection["SecurityType6"];

            string collateralSecure7 = formCollection["CollateralSecure7"];
            string securityType7 = formCollection["SecurityType7"];

            string collateralSecure8 = formCollection["CollateralSecure8"];
            string securityType8 = formCollection["SecurityType8"];

            string collateralSecure9 = formCollection["CollateralSecure9"];
            string securityType9 = formCollection["SecurityType9"];

            string collateralSecure10 = formCollection["CollateralSecure10"];
            string securityType10 = formCollection["SecurityType10"];

            string syndication = formCollection["Syndication"];
            string syndicationStatus = formCollection["SyndicationStatus"];
            string syndicationReferenceNumber = formCollection["SyndicationReferenceNumber"];
            string repaymentSource = formCollection["RepaymentSource"];
            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
            
            bool status = saveData.SaveCrms100(code, customerId, accountNumber, customerName, govtCode, legalStatus,
                creditType, businessLines,
                businessLinesSubsector, creditLimit, outstandingAmount, feeType1, feeAmount1, feeType2, feeAmount2,
                feeType3, feeAmount3,
                feeType4, feeAmount4, feeType5, feeAmount5, feeType6, feeAmount6, feeType7, feeAmount7, feeType8,
                feeAmount8, feeType9, feeAmount9,
                feeType10, feeAmount10, feeType11, feeAmount11, feeType12, feeAmount12, feeType13, feeAmount13,
                feeType14, feeAmount14, feeType15,
                feeAmount15, feeType16, feeAmount16, effectiveDate, tenor, expiryDate, repaymentAgreement,
                specialisedLoan, specialisedLoanPeriod, interestRate, collateralPresent1, collateralSecure1, securityType1,
                collateralSecure2, securityType2, collateralSecure3, securityType3, collateralSecure4, securityType4, collateralSecure5, securityType5,
                 collateralSecure6, securityType6, collateralSecure7, securityType7, collateralSecure8, securityType8, collateralSecure9, securityType9,
                 collateralSecure10, securityType10, repaymentSource, syndication, syndicationStatus,
                syndicationReferenceNumber, inputterId, inputterDateStamp, "");

            ViewBag.saveCrms100 = status;

            if (status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 100 inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            

            return View();
            //throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Second()
        {
            var crmsUtil = new CrmsUtil();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.PerformanceRepayment = crmsUtil.GetPerformanceRepaymentStatus();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.RepaymentSource = crmsUtil.GetRepaymentSource();
            return View();
        }

        [HttpPost]
        public ActionResult Second(FormCollection formCollection)
        {
            //Get The Values Again After Post
            var crmsUtil = new CrmsUtil();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.PerformanceRepayment = crmsUtil.GetPerformanceRepaymentStatus();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.RepaymentSource = crmsUtil.GetRepaymentSource();

            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string govtMdaTin = formCollection["GovernmentMdaTin"];
            string legalStatus = formCollection["LegalStatus"];
            string creditType = formCollection["CreditType"];
            string businessLines = formCollection["BusinessLines"];
            string businessLinesSubsector = formCollection["BusinessLinesSubsector"];
            decimal creditLimit = Math.Round(Convert.ToDecimal(formCollection["CreditLimit"]), 2);
            decimal outstandingAmount = Math.Round(Convert.ToDecimal(formCollection["OutstandingAmount"]), 2);

            string feeType1 = formCollection["FeeType1"];
            decimal feeAmount1 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount1"]), 2);

            string feeType2 = formCollection["FeeType2"];
            decimal feeAmount2 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount2"]), 2);

            string feeType3 = formCollection["FeeType3"];
            decimal feeAmount3 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount3"]), 2);

            string feeType4 = formCollection["FeeType4"];
            decimal feeAmount4 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount4"]), 2);

            string feeType5 = formCollection["FeeType5"];
            decimal feeAmount5 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount5"]), 2);

            string feeType6 = formCollection["FeeType6"];
            decimal feeAmount6 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount6"]), 2);

            string feeType7 = formCollection["FeeType7"];
            decimal feeAmount7 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount7"]), 2);

            string feeType8 = formCollection["FeeType8"];
            decimal feeAmount8 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount8"]), 2);

            string feeType9 = formCollection["FeeType9"];
            decimal feeAmount9 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount9"]), 2);

            string feeType10 = formCollection["FeeType10"];
            decimal feeAmount10 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount10"]), 2);

            string feeType11 = formCollection["FeeType11"];
            decimal feeAmount11 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount11"]), 2);

            string feeType12 = formCollection["FeeType12"];
            decimal feeAmount12 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount12"]), 2);

            string feeType13 = formCollection["FeeType13"];
            decimal feeAmount13 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount13"]), 2);

            string feeType14 = formCollection["FeeType14"];
            decimal feeAmount14 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount14"]), 2);

            string feeType15 = formCollection["FeeType15"];
            decimal feeAmount15 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount15"]), 2);

            string feeType16 = formCollection["FeeType16"];
            decimal feeAmount16 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount16"]), 2);

            DateTime effectiveDate = DateTime.ParseExact(formCollection["EffectiveDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            int tenor = Convert.ToInt32(formCollection["Tenor"]);
            DateTime expiryDate = DateTime.ParseExact(formCollection["ExpiryDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            string repaymentAgreement = formCollection["RepaymentAgreement"];
            string performanceRepayment = formCollection["PerformanceRepayment"];
            string specialisedLoan = formCollection["SpecialisedLoan"];
            int specialisedLoanPeriod = Convert.ToInt32(formCollection["SpecialisedLoanPeriod"]);
            decimal interestRate = Math.Round(Convert.ToDecimal(formCollection["InterestRate"]), 2);

            string collateralPresent1 = formCollection["CollateralPresent1"];
            string collateralSecure1 = formCollection["CollateralSecure1"];
            string securityType1 = formCollection["SecurityType1"];

            string collateralSecure2 = formCollection["CollateralSecure2"];
            string securityType2 = formCollection["SecurityType2"];

            string collateralSecure3 = formCollection["CollateralSecure3"];
            string securityType3 = formCollection["SecurityType3"];

            string collateralSecure4 = formCollection["CollateralSecure4"];
            string securityType4 = formCollection["SecurityType4"];

            string collateralSecure5 = formCollection["CollateralSecure5"];
            string securityType5 = formCollection["SecurityType5"];

            string collateralSecure6 = formCollection["CollateralSecure6"];
            string securityType6 = formCollection["SecurityType6"];

            string collateralSecure7 = formCollection["CollateralSecure7"];
            string securityType7 = formCollection["SecurityType7"];

            string collateralSecure8 = formCollection["CollateralSecure8"];
            string securityType8 = formCollection["SecurityType8"];

            string collateralSecure9 = formCollection["CollateralSecure9"];
            string securityType9 = formCollection["SecurityType9"];

            string collateralSecure10 = formCollection["CollateralSecure10"];
            string securityType10 = formCollection["SecurityType10"];

            string syndication = formCollection["Syndication"];
            string syndicationStatus = formCollection["SyndicationStatus"];
            string syndicationReferenceNumber = formCollection["SyndicationReferenceNumber"];
            string repaymentSource = formCollection["RepaymentSource"];
            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
            
                bool status = saveData.SaveCrms200(code, customerId, accountNumber, customerName, govtMdaTin, legalStatus,
                creditType, businessLines,
                businessLinesSubsector, creditLimit, outstandingAmount, feeType1, feeAmount1, feeType2, feeAmount2,
                feeType3, feeAmount3,
                feeType4, feeAmount4, feeType5, feeAmount5, feeType6, feeAmount6, feeType7, feeAmount7, feeType8,
                feeAmount8, feeType9, feeAmount9,
                feeType10, feeAmount10, feeType11, feeAmount11, feeType12, feeAmount12, feeType13, feeAmount13,
                feeType14, feeAmount14, feeType15,
                feeAmount15, feeType16, feeAmount16, effectiveDate, tenor, expiryDate, repaymentAgreement, performanceRepayment,
                specialisedLoan, specialisedLoanPeriod, interestRate, collateralPresent1, collateralSecure1, securityType1,
                collateralSecure2, securityType2, collateralSecure3, securityType3, collateralSecure4, securityType4, collateralSecure5, securityType5,
                collateralSecure6, securityType6, collateralSecure7, securityType7,collateralSecure8, securityType8, collateralSecure9, securityType9,
                collateralSecure10, securityType10, repaymentSource, syndication, syndicationStatus,
                syndicationReferenceNumber, inputterId, inputterDateStamp, "");

            ViewBag.saveCrms200 = status;

            if (status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 200 inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            

            return View();
        }

        [HttpGet]
        public ActionResult Third()
        {
            var crmsUtil = new CrmsUtil();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.LocationOfBeneficiary = crmsUtil.GetLocationOfBeneficiary();
            ViewBag.RelationshipType = crmsUtil.GetRelationshipType();
            ViewBag.CompanySize = crmsUtil.GetCompanySize();
            ViewBag.FundingSource = crmsUtil.GetFundingSource();
            return View();
        }

        [HttpPost]
        public ActionResult Third(FormCollection formCollection)
        {
            //Get the elements again
            var crmsUtil = new CrmsUtil();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.LocationOfBeneficiary = crmsUtil.GetLocationOfBeneficiary();
            ViewBag.RelationshipType = crmsUtil.GetRelationshipType();
            ViewBag.CompanySize = crmsUtil.GetCompanySize();
            ViewBag.FundingSource = crmsUtil.GetFundingSource();

            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string uniqueIdentificationType = formCollection["UniqueIdentificationType"];
            string identificationNo = formCollection["IdentificationNo"];
            string creditType = formCollection["CreditType"];
            string businessLines = formCollection["BusinessLines"];
            string businessLinesSubsector = formCollection["BusinessLinesSubsector"];
            decimal creditLimit = Math.Round(Convert.ToDecimal(formCollection["CreditLimit"]), 2);
            decimal outstandingAmount = Math.Round(Convert.ToDecimal(formCollection["OutstandingAmount"]), 2);
            string feeType1 = formCollection["FeeType1"];
            decimal feeAmount1 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount1"]), 2);
            string feeType2 = formCollection["FeeType2"];
            decimal feeAmount2 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount2"]), 2);
            string feeType3 = formCollection["FeeType3"];
            decimal feeAmount3 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount3"]), 2);
            string feeType4 = formCollection["FeeType4"];
            decimal feeAmount4 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount4"]), 2);
            string feeType5 = formCollection["FeeType5"];
            decimal feeAmount5 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount5"]), 2);
            string feeType6 = formCollection["FeeType6"];
            decimal feeAmount6 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount6"]), 2);
            string feeType7 = formCollection["FeeType7"];
            decimal feeAmount7 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount7"]), 2);
            string feeType8 = formCollection["FeeType8"];
            decimal feeAmount8 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount8"]), 2);
            string feeType9 = formCollection["FeeType9"];
            decimal feeAmount9 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount9"]), 2);
            string feeType10 = formCollection["FeeType10"];
            decimal feeAmount10 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount10"]), 2);
            string feeType11 = formCollection["FeeType11"];
            decimal feeAmount11 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount11"]), 2);
            string feeType12 = formCollection["FeeType12"];
            decimal feeAmount12 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount12"]), 2);
            string feeType13 = formCollection["FeeType13"];
            decimal feeAmount13 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount13"]), 2);
            string feeType14 = formCollection["FeeType14"];
            decimal feeAmount14 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount14"]), 2);
            string feeType15 = formCollection["FeeType15"];
            decimal feeAmount15 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount15"]), 2);
            string feeType16 = formCollection["FeeType16"];
            decimal feeAmount16 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount16"]), 2);
            DateTime effectiveDate = DateTime.ParseExact(formCollection["EffectiveDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            int tenor = Convert.ToInt32(formCollection["Tenor"]);
            DateTime expiryDate = DateTime.ParseExact(formCollection["ExpiryDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            decimal interestRate = Math.Round(Convert.ToDecimal(formCollection["InterestRate"]), 2);
            string benefciaryAccount = formCollection["BenefciaryAccount"];
            string locationOfBeneficiary = formCollection["LocationOfBeneficiary"];
            string relationshipType = formCollection["RelationshipType"];
            string companySize = formCollection["CompanySize"];
            string fundingSourceCategory = formCollection["FundingSourceCategory"];
            string ecciNumber = formCollection["ECCINumber"];
            string fundingSource = formCollection["FundingSource"];
            string legalStatus = formCollection["LegalStatus"];
            string cBusinessLines = formCollection["CBusinessLines"];
            string cBusinessLinesSubsector = formCollection["CBusinessLinesSubsector"];
            string repaymentAgreement = formCollection["RepaymentAgreement"];
            String specialisedLoan = formCollection["SpecialisedLoan"];
            int specialisedLoanPeriod = Convert.ToInt32(formCollection["SpecialisedLoanPeriod"]);

            string directorUniqueIdentificationType1 = formCollection["DirectorUniqueIdentificationType1"];
            string directorUniqueIdentificationNumber1 = formCollection["DirectorUniqueIdentificationNumber1"];
            string directorEmail1 = formCollection["DirectorEmail1"];

            string directorUniqueIdentificationType2 = formCollection["DirectorUniqueIdentificationType2"];
            string directorUniqueIdentificationNumber2 = formCollection["DirectorUniqueIdentificationNumber2"];
            string directorEmail2 = formCollection["DirectorEmail2"];

            string directorUniqueIdentificationType3 = formCollection["DirectorUniqueIdentificationType3"];
            string directorUniqueIdentificationNumber3 = formCollection["DirectorUniqueIdentificationNumber3"];
            string directorEmail3 = formCollection["DirectorEmail3"];

            string directorUniqueIdentificationType4 = formCollection["DirectorUniqueIdentificationType4"];
            string directorUniqueIdentificationNumber4 = formCollection["DirectorUniqueIdentificationNumber4"];
            string directorEmail4 = formCollection["DirectorEmail4"];

            string directorUniqueIdentificationType5 = formCollection["DirectorUniqueIdentificationType5"];
            string directorUniqueIdentificationNumber5 = formCollection["DirectorUniqueIdentificationNumber5"];
            string directorEmail5 = formCollection["DirectorEmail5"];

            string syndication = formCollection["Syndication"];
            string syndicationStatus = formCollection["SyndicationStatus"];
            string syndicationReferenceNumber = formCollection["SyndicationReferenceNumber"];

            string collateralPresent1 = formCollection["CollateralPresent1"];
            string collateralSecure1 = formCollection["CollateralSecure1"];
            string securityType1 = formCollection["SecurityType1"];
            string addressofSecurity1 = formCollection["AddressofSecurity1"];
            string ownerofSecurity1 = formCollection["OwnerofSecurity1"];
            string securityUniqueIdentificationType1 = formCollection["SecurityUniqueIdentificationType1"];
            string securityUniqueIdentificationNumber1 = formCollection["SecurityUniqueIdentificationNumber1"];

            string collateralSecure2 = formCollection["CollateralSecure2"];
            string securityType2 = formCollection["SecurityType2"];
            string addressofSecurity2 = formCollection["AddressofSecurity2"];
            string ownerofSecurity2 = formCollection["OwnerofSecurity2"];
            string securityUniqueIdentificationType2 = formCollection["SecurityUniqueIdentificationType2"];
            string securityUniqueIdentificationNumber2 = formCollection["SecurityUniqueIdentificationNumber2"];

            string collateralSecure3 = formCollection["CollateralSecure3"];
            string securityType3 = formCollection["SecurityType3"];
            string addressofSecurity3 = formCollection["AddressofSecurity3"];
            string ownerofSecurity3 = formCollection["OwnerofSecurity3"];
            string securityUniqueIdentificationType3 = formCollection["SecurityUniqueIdentificationType3"];
            string securityUniqueIdentificationNumber3 = formCollection["SecurityUniqueIdentificationNumber3"];

            string collateralSecure4 = formCollection["CollateralSecure4"];
            string securityType4 = formCollection["SecurityType4"];
            string addressofSecurity4 = formCollection["AddressofSecurity4"];
            string ownerofSecurity4 = formCollection["OwnerofSecurity4"];
            string securityUniqueIdentificationType4 = formCollection["SecurityUniqueIdentificationType4"];
            string securityUniqueIdentificationNumber4 = formCollection["SecurityUniqueIdentificationNumber4"];

            string collateralSecure5 = formCollection["CollateralSecure5"];
            string securityType5 = formCollection["SecurityType5"];
            string addressofSecurity5 = formCollection["AddressofSecurity5"];
            string ownerofSecurity5 = formCollection["OwnerofSecurity5"];
            string securityUniqueIdentificationType5 = formCollection["SecurityUniqueIdentificationType5"];
            string securityUniqueIdentificationNumber5 = formCollection["SecurityUniqueIdentificationNumber5"];

            string collateralSecure6 = formCollection["CollateralSecure6"];
            string securityType6 = formCollection["SecurityType6"];
            string addressofSecurity6 = formCollection["AddressofSecurity6"];
            string ownerofSecurity6 = formCollection["OwnerofSecurity6"];
            string securityUniqueIdentificationType6 = formCollection["SecurityUniqueIdentificationType6"];
            string securityUniqueIdentificationNumber6 = formCollection["SecurityUniqueIdentificationNumber6"];

            string collateralSecure7 = formCollection["CollateralSecure7"];
            string securityType7 = formCollection["SecurityType7"];
            string addressofSecurity7 = formCollection["AddressofSecurity7"];
            string ownerofSecurity7 = formCollection["OwnerofSecurity7"];
            string securityUniqueIdentificationType7 = formCollection["SecurityUniqueIdentificationType7"];
            string securityUniqueIdentificationNumber7 = formCollection["SecurityUniqueIdentificationNumber7"];

            string collateralSecure8 = formCollection["CollateralSecure8"];
            string securityType8 = formCollection["SecurityType8"];
            string addressofSecurity8 = formCollection["AddressofSecurity8"];
            string ownerofSecurity8 = formCollection["OwnerofSecurity8"];
            string securityUniqueIdentificationType8 = formCollection["SecurityUniqueIdentificationType8"];
            string securityUniqueIdentificationNumber8 = formCollection["SecurityUniqueIdentificationNumber8"];

            string collateralSecure9 = formCollection["CollateralSecure9"];
            string securityType9 = formCollection["SecurityType9"];
            string addressofSecurity9 = formCollection["AddressofSecurity9"];
            string ownerofSecurity9 = formCollection["OwnerofSecurity9"];
            string securityUniqueIdentificationType9 = formCollection["SecurityUniqueIdentificationType9"];
            string securityUniqueIdentificationNumber9 = formCollection["SecurityUniqueIdentificationNumber9"];

            string collateralSecure10 = formCollection["CollateralSecure10"];
            string securityType10 = formCollection["SecurityType10"];
            string addressofSecurity10 = formCollection["AddressofSecurity10"];
            string ownerofSecurity10 = formCollection["OwnerofSecurity10"];
            string securityUniqueIdentificationType10 = formCollection["SecurityUniqueIdentificationType10"];
            string securityUniqueIdentificationNumber10 = formCollection["SecurityUniqueIdentificationNumber10"];

            string guarantee1 = formCollection["Guarantee1"];
            string guaranteeType1 = formCollection["GuaranteeType1"];
            string guarantorUniqueIdentificationType1 = formCollection["GuarantorUniqueIdentificationType1"];
            string guarantorUniqueIdentificationNumber1 = formCollection["GuarantorUniqueIdentificationNumber1"];
            decimal amountGuaranteed1 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed1"]), 2);

            string guaranteeType2 = formCollection["GuaranteeType2"];
            string guarantorUniqueIdentificationType2 = formCollection["GuarantorUniqueIdentificationType2"];
            string guarantorUniqueIdentificationNumber2 = formCollection["GuarantorUniqueIdentificationNumber2"];
            decimal amountGuaranteed2 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed2"]), 2);

            string guaranteeType3 = formCollection["GuaranteeType3"];
            string guarantorUniqueIdentificationType3 = formCollection["GuarantorUniqueIdentificationType3"];
            string guarantorUniqueIdentificationNumber3 = formCollection["GuarantorUniqueIdentificationNumber3"];
            decimal amountGuaranteed3 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed3"]), 2);

            string guaranteeType4 = formCollection["GuaranteeType4"];
            string guarantorUniqueIdentificationType4 = formCollection["GuarantorUniqueIdentificationType4"];
            string guarantorUniqueIdentificationNumber4 = formCollection["GuarantorUniqueIdentificationNumber4"];
            decimal amountGuaranteed4 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed4"]), 2);

            string guaranteeType5 = formCollection["GuaranteeType5"];
            string guarantorUniqueIdentificationType5 = formCollection["GuarantorUniqueIdentificationType5"];
            string guarantorUniqueIdentificationNumber5 = formCollection["GuarantorUniqueIdentificationNumber5"];
            decimal amountGuaranteed5 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed5"]), 2);

            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
            
                bool status = saveData.SaveCrms300(code, customerId, accountNumber, customerName, uniqueIdentificationType, identificationNo, creditType, businessLines,
                businessLinesSubsector, creditLimit, outstandingAmount, feeType1, feeAmount1, feeType2, feeAmount2, feeType3, feeAmount3,
                feeType4, feeAmount4, feeType5, feeAmount5, feeType6, feeAmount6, feeType7, feeAmount7, feeType8, feeAmount8, feeType9, feeAmount9,
                feeType10, feeAmount10, feeType11, feeAmount11, feeType12, feeAmount12, feeType13, feeAmount13, feeType14, feeAmount14, feeType15,
                feeAmount15, feeType16, feeAmount16, effectiveDate, tenor, expiryDate, repaymentAgreement, interestRate, benefciaryAccount, locationOfBeneficiary, relationshipType,
                companySize, fundingSourceCategory, ecciNumber, fundingSource, legalStatus, cBusinessLines, cBusinessLinesSubsector,specialisedLoan, specialisedLoanPeriod,
                directorUniqueIdentificationType1, directorUniqueIdentificationNumber1, directorEmail1, directorUniqueIdentificationType2, directorUniqueIdentificationNumber2, directorEmail2,
                directorUniqueIdentificationType3, directorUniqueIdentificationNumber3, directorEmail3, directorUniqueIdentificationType4, directorUniqueIdentificationNumber4, directorEmail4,
                directorUniqueIdentificationType5, directorUniqueIdentificationNumber5, directorEmail5,syndication, syndicationStatus, syndicationReferenceNumber, 
                collateralPresent1, collateralSecure1, securityType1, addressofSecurity1, ownerofSecurity1, securityUniqueIdentificationType1, securityUniqueIdentificationNumber1,
                collateralSecure2, securityType2, addressofSecurity2, ownerofSecurity2, securityUniqueIdentificationType2, securityUniqueIdentificationNumber2,
                collateralSecure3, securityType3, addressofSecurity3, ownerofSecurity3, securityUniqueIdentificationType3, securityUniqueIdentificationNumber3,
                collateralSecure4, securityType4, addressofSecurity4, ownerofSecurity4, securityUniqueIdentificationType4, securityUniqueIdentificationNumber4,
                collateralSecure5, securityType5, addressofSecurity5, ownerofSecurity5, securityUniqueIdentificationType5, securityUniqueIdentificationNumber5,
                collateralSecure6, securityType6, addressofSecurity6, ownerofSecurity6, securityUniqueIdentificationType6, securityUniqueIdentificationNumber6,
                collateralSecure7, securityType7, addressofSecurity7, ownerofSecurity7, securityUniqueIdentificationType7, securityUniqueIdentificationNumber7,
                collateralSecure8, securityType8, addressofSecurity8, ownerofSecurity8, securityUniqueIdentificationType8, securityUniqueIdentificationNumber8,
                collateralSecure9, securityType9, addressofSecurity9, ownerofSecurity9, securityUniqueIdentificationType9, securityUniqueIdentificationNumber9,
                collateralSecure10, securityType10, addressofSecurity10, ownerofSecurity10, securityUniqueIdentificationType10, securityUniqueIdentificationNumber10,
                guarantee1, guaranteeType1, guarantorUniqueIdentificationType1, guarantorUniqueIdentificationNumber1, amountGuaranteed1,
                guaranteeType2, guarantorUniqueIdentificationType2, guarantorUniqueIdentificationNumber2, amountGuaranteed2,
                guaranteeType3, guarantorUniqueIdentificationType3, guarantorUniqueIdentificationNumber3, amountGuaranteed3,
                guaranteeType4, guarantorUniqueIdentificationType4, guarantorUniqueIdentificationNumber4, amountGuaranteed4,
                guaranteeType5, guarantorUniqueIdentificationType5, guarantorUniqueIdentificationNumber5, amountGuaranteed5, 
                inputterId, inputterDateStamp, "");

            ViewBag.saveCrms300 = status;

            if (status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 300 inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            
            
            return View();
        }

        [HttpGet]
        public ActionResult Fourth()
        {
            var crmsUtil = new CrmsUtil();

            return View();
        }
        
        [HttpPost]
        public ActionResult Fourth(FormCollection formCollection)
        {
            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string uniqueIdentificationType = formCollection["UniqueIdentificationType"];
            string uniqueIdentificationNo = formCollection["IdentificationNo"];
            string crmsRefNo = formCollection["CRMSRefNo"];
            DateTime effectiveDate = DateTime.ParseExact(formCollection["EffectiveDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            int tenor = Convert.ToInt32(formCollection["Tenor"]);
            DateTime expiryDate = DateTime.ParseExact(formCollection["ExpiryDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
            
                bool status = saveData.SaveCrms400A(code, customerId, accountNumber, customerName, uniqueIdentificationType, uniqueIdentificationNo,
                crmsRefNo, effectiveDate, tenor, expiryDate, inputterId, inputterDateStamp, "");

            ViewBag.saveCrms400A = status;

            if (status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 400A inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            
            return View();
        }

        [HttpGet]
        public ActionResult Fifth()
        {
            var crmsUtil = new CrmsUtil();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.RepaymentSource = crmsUtil.GetRepaymentSource();
            ViewBag.PerformanceRepayment = crmsUtil.GetPerformanceRepaymentStatus();
            ViewBag.FundingSource = crmsUtil.GetFundingSource();
            ViewBag.LocationOfBeneficiary = crmsUtil.GetLocationOfBeneficiary();
            ViewBag.RelationshipType = crmsUtil.GetRelationshipType();
            return View();
        }

        [HttpPost]
        public ActionResult Fifth(FormCollection formCollection)
        {
            //Get Data Again after post
            var crmsUtil = new CrmsUtil();
            ViewBag.CreditType = crmsUtil.GetCreditType();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.RepaymentAgreement = crmsUtil.GetRepaymentAgreementMode();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.RepaymentSource = crmsUtil.GetRepaymentSource();
            ViewBag.PerformanceRepayment = crmsUtil.GetPerformanceRepaymentStatus();
            ViewBag.FundingSource = crmsUtil.GetFundingSource();
            ViewBag.LocationOfBeneficiary = crmsUtil.GetLocationOfBeneficiary();
            ViewBag.RelationshipType = crmsUtil.GetRelationshipType();

            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string uniqueIdentificationType = formCollection["UniqueIdentificationType"];
            string identificationNo = formCollection["IdentificationNo"];
            string crmsRefNo = formCollection["CRMSRefNo"];
            string creditType = formCollection["CreditType"];
            decimal creditLimit = Math.Round(Convert.ToDecimal(formCollection["CreditLimit"]), 2);
            decimal outstandingAmount = Math.Round(Convert.ToDecimal(formCollection["OutstandingAmount"]), 2);
            string feeType1 = formCollection["FeeType1"];
            decimal feeAmount1 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount1"]), 2);
            string feeType2 = formCollection["FeeType2"];
            decimal feeAmount2 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount2"]), 2);
            string feeType3 = formCollection["FeeType3"];
            decimal feeAmount3 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount3"]), 2);
            string feeType4 = formCollection["FeeType4"];
            decimal feeAmount4 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount4"]), 2);
            string feeType5 = formCollection["FeeType5"];
            decimal feeAmount5 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount5"]), 2);
            string feeType6 = formCollection["FeeType6"];
            decimal feeAmount6 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount6"]), 2);
            string feeType7 = formCollection["FeeType7"];
            decimal feeAmount7 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount7"]), 2);
            string feeType8 = formCollection["FeeType8"];
            decimal feeAmount8 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount8"]), 2);
            string feeType9 = formCollection["FeeType9"];
            decimal feeAmount9 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount9"]), 2);
            string feeType10 = formCollection["FeeType10"];
            decimal feeAmount10 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount10"]), 2);
            string feeType11 = formCollection["FeeType11"];
            decimal feeAmount11 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount11"]), 2);
            string feeType12 = formCollection["FeeType12"];
            decimal feeAmount12 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount12"]), 2);
            string feeType13 = formCollection["FeeType13"];
            decimal feeAmount13 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount13"]), 2);
            string feeType14 = formCollection["FeeType14"];
            decimal feeAmount14 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount14"]), 2);
            string feeType15 = formCollection["FeeType15"];
            decimal feeAmount15 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount15"]), 2);
            string feeType16 = formCollection["FeeType16"];
            decimal feeAmount16 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount16"]), 2);
            DateTime effectiveDate = DateTime.ParseExact(formCollection["EffectiveDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            int tenor = Convert.ToInt32(formCollection["Tenor"]);
            DateTime expiryDate = DateTime.ParseExact(formCollection["ExpiryDate"], "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
            string repaymentAgreement = formCollection["RepaymentAgreement"];
            string performanceRepayment = formCollection["PerformanceRepayment"];
            string reasonForRestructuring = formCollection["ReasonforRestructuring"];
            decimal interestRate = Math.Round(Convert.ToDecimal(formCollection["InterestRate"]), 2);
            string benefciaryAccount = formCollection["BenefciaryAccount"];
            string locationOfBeneficiary = formCollection["LocationOfBeneficiary"];
            string relationshipType = formCollection["RelationshipType"];
            string fundingSourceCategory = formCollection["FundingSourceCategory"];
            string ecciNumber = formCollection["ECCINumber"];
            string fundingSource = formCollection["FundingSource"];
            String specialisedLoan = formCollection["SpecialisedLoan"];
            int specialisedLoanPeriod = Convert.ToInt32(formCollection["SpecialisedLoanPeriod"]);

            string directorUniqueIdentificationType1 = formCollection["DirectorUniqueIdentificationType1"];
            string directorUniqueIdentificationNumber1 = formCollection["DirectorUniqueIdentificationNumber1"];
            string directorEmail1 = formCollection["DirectorEmail1"];

            string directorUniqueIdentificationType2 = formCollection["DirectorUniqueIdentificationType2"];
            string directorUniqueIdentificationNumber2 = formCollection["DirectorUniqueIdentificationNumber2"];
            string directorEmail2 = formCollection["DirectorEmail2"];

            string directorUniqueIdentificationType3 = formCollection["DirectorUniqueIdentificationType3"];
            string directorUniqueIdentificationNumber3 = formCollection["DirectorUniqueIdentificationNumber3"];
            string directorEmail3 = formCollection["DirectorEmail3"];

            string directorUniqueIdentificationType4 = formCollection["DirectorUniqueIdentificationType4"];
            string directorUniqueIdentificationNumber4 = formCollection["DirectorUniqueIdentificationNumber4"];
            string directorEmail4 = formCollection["DirectorEmail4"];

            string directorUniqueIdentificationType5 = formCollection["DirectorUniqueIdentificationType5"];
            string directorUniqueIdentificationNumber5 = formCollection["DirectorUniqueIdentificationNumber5"];
            string directorEmail5 = formCollection["DirectorEmail5"];

            string collateralPresent1 = formCollection["CollateralPresent1"];
            string collateralSecure1 = formCollection["CollateralSecure1"];
            string securityType1 = formCollection["SecurityType1"];
            string addressofSecurity1 = formCollection["AddressofSecurity1"];
            string ownerofSecurity1 = formCollection["OwnerofSecurity1"];
            string securityUniqueIdentificationType1 = formCollection["SecurityUniqueIdentificationType1"];
            string securityUniqueIdentificationNumber1 = formCollection["SecurityUniqueIdentificationNumber1"];

            string collateralSecure2 = formCollection["CollateralSecure2"];
            string securityType2 = formCollection["SecurityType2"];
            string addressofSecurity2 = formCollection["AddressofSecurity2"];
            string ownerofSecurity2 = formCollection["OwnerofSecurity2"];
            string securityUniqueIdentificationType2 = formCollection["SecurityUniqueIdentificationType2"];
            string securityUniqueIdentificationNumber2 = formCollection["SecurityUniqueIdentificationNumber2"];

            string collateralSecure3 = formCollection["CollateralSecure3"];
            string securityType3 = formCollection["SecurityType3"];
            string addressofSecurity3 = formCollection["AddressofSecurity3"];
            string ownerofSecurity3 = formCollection["OwnerofSecurity3"];
            string securityUniqueIdentificationType3 = formCollection["SecurityUniqueIdentificationType3"];
            string securityUniqueIdentificationNumber3 = formCollection["SecurityUniqueIdentificationNumber3"];

            string collateralSecure4 = formCollection["CollateralSecure4"];
            string securityType4 = formCollection["SecurityType4"];
            string addressofSecurity4 = formCollection["AddressofSecurity4"];
            string ownerofSecurity4 = formCollection["OwnerofSecurity4"];
            string securityUniqueIdentificationType4 = formCollection["SecurityUniqueIdentificationType4"];
            string securityUniqueIdentificationNumber4 = formCollection["SecurityUniqueIdentificationNumber4"];

            string collateralSecure5 = formCollection["CollateralSecure5"];
            string securityType5 = formCollection["SecurityType5"];
            string addressofSecurity5 = formCollection["AddressofSecurity5"];
            string ownerofSecurity5 = formCollection["OwnerofSecurity5"];
            string securityUniqueIdentificationType5 = formCollection["SecurityUniqueIdentificationType5"];
            string securityUniqueIdentificationNumber5 = formCollection["SecurityUniqueIdentificationNumber5"];

            string collateralSecure6 = formCollection["CollateralSecure6"];
            string securityType6 = formCollection["SecurityType6"];
            string addressofSecurity6 = formCollection["AddressofSecurity6"];
            string ownerofSecurity6 = formCollection["OwnerofSecurity6"];
            string securityUniqueIdentificationType6 = formCollection["SecurityUniqueIdentificationType6"];
            string securityUniqueIdentificationNumber6 = formCollection["SecurityUniqueIdentificationNumber6"];

            string collateralSecure7 = formCollection["CollateralSecure7"];
            string securityType7 = formCollection["SecurityType7"];
            string addressofSecurity7 = formCollection["AddressofSecurity7"];
            string ownerofSecurity7 = formCollection["OwnerofSecurity7"];
            string securityUniqueIdentificationType7 = formCollection["SecurityUniqueIdentificationType7"];
            string securityUniqueIdentificationNumber7 = formCollection["SecurityUniqueIdentificationNumber7"];

            string collateralSecure8 = formCollection["CollateralSecure8"];
            string securityType8 = formCollection["SecurityType8"];
            string addressofSecurity8 = formCollection["AddressofSecurity8"];
            string ownerofSecurity8 = formCollection["OwnerofSecurity8"];
            string securityUniqueIdentificationType8 = formCollection["SecurityUniqueIdentificationType8"];
            string securityUniqueIdentificationNumber8 = formCollection["SecurityUniqueIdentificationNumber8"];

            string collateralSecure9 = formCollection["CollateralSecure9"];
            string securityType9 = formCollection["SecurityType9"];
            string addressofSecurity9 = formCollection["AddressofSecurity9"];
            string ownerofSecurity9 = formCollection["OwnerofSecurity9"];
            string securityUniqueIdentificationType9 = formCollection["SecurityUniqueIdentificationType9"];
            string securityUniqueIdentificationNumber9 = formCollection["SecurityUniqueIdentificationNumber9"];

            string collateralSecure10 = formCollection["CollateralSecure10"];
            string securityType10 = formCollection["SecurityType10"];
            string addressofSecurity10 = formCollection["AddressofSecurity10"];
            string ownerofSecurity10 = formCollection["OwnerofSecurity10"];
            string securityUniqueIdentificationType10 = formCollection["SecurityUniqueIdentificationType10"];
            string securityUniqueIdentificationNumber10 = formCollection["SecurityUniqueIdentificationNumber10"];

            string guarantee1 = formCollection["Guarantee1"];
            string guaranteeType1 = formCollection["GuaranteeType1"];
            string guarantorUniqueIdentificationType1 = formCollection["GuarantorUniqueIdentificationType1"];
            string guarantorUniqueIdentificationNumber1 = formCollection["GuarantorUniqueIdentificationNumber1"];
            decimal amountGuaranteed1 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed1"]), 2);

            string guaranteeType2 = formCollection["GuaranteeType2"];
            string guarantorUniqueIdentificationType2 = formCollection["GuarantorUniqueIdentificationType2"];
            string guarantorUniqueIdentificationNumber2 = formCollection["GuarantorUniqueIdentificationNumber2"];
            decimal amountGuaranteed2 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed2"]), 2);

            string guaranteeType3 = formCollection["GuaranteeType3"];
            string guarantorUniqueIdentificationType3 = formCollection["GuarantorUniqueIdentificationType3"];
            string guarantorUniqueIdentificationNumber3 = formCollection["GuarantorUniqueIdentificationNumber3"];
            decimal amountGuaranteed3 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed3"]), 2);

            string guaranteeType4 = formCollection["GuaranteeType4"];
            string guarantorUniqueIdentificationType4 = formCollection["GuarantorUniqueIdentificationType4"];
            string guarantorUniqueIdentificationNumber4 = formCollection["GuarantorUniqueIdentificationNumber4"];
            decimal amountGuaranteed4 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed4"]), 2);

            string guaranteeType5 = formCollection["GuaranteeType5"];
            string guarantorUniqueIdentificationType5 = formCollection["GuarantorUniqueIdentificationType5"];
            string guarantorUniqueIdentificationNumber5 = formCollection["GuarantorUniqueIdentificationNumber5"];
            decimal amountGuaranteed5 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed5"]), 2);

            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
            
                bool status = saveData.SaveCrms400B(code, customerId, accountNumber, customerName, uniqueIdentificationType, identificationNo, crmsRefNo,creditType, 
                creditLimit, outstandingAmount, feeType1, feeAmount1, feeType2, feeAmount2, feeType3, feeAmount3,
                feeType4, feeAmount4, feeType5, feeAmount5, feeType6, feeAmount6, feeType7, feeAmount7, feeType8, feeAmount8, feeType9, feeAmount9,
                feeType10, feeAmount10, feeType11, feeAmount11, feeType12, feeAmount12, feeType13, feeAmount13, feeType14, feeAmount14, feeType15,
                feeAmount15, feeType16, feeAmount16, effectiveDate, tenor, expiryDate, repaymentAgreement, performanceRepayment,reasonForRestructuring,
                interestRate, benefciaryAccount, locationOfBeneficiary, relationshipType, fundingSourceCategory, ecciNumber, fundingSource, specialisedLoan, specialisedLoanPeriod,
                directorUniqueIdentificationType1, directorUniqueIdentificationNumber1, directorEmail1, directorUniqueIdentificationType2, directorUniqueIdentificationNumber2, directorEmail2,
                directorUniqueIdentificationType3, directorUniqueIdentificationNumber3, directorEmail3, directorUniqueIdentificationType4, directorUniqueIdentificationNumber4, directorEmail4,
                directorUniqueIdentificationType5, directorUniqueIdentificationNumber5, directorEmail5, collateralPresent1, collateralSecure1, securityType1, addressofSecurity1, ownerofSecurity1, securityUniqueIdentificationType1, securityUniqueIdentificationNumber1,
                collateralSecure2, securityType2, addressofSecurity2, ownerofSecurity2, securityUniqueIdentificationType2, securityUniqueIdentificationNumber2,
                collateralSecure3, securityType3, addressofSecurity3, ownerofSecurity3, securityUniqueIdentificationType3, securityUniqueIdentificationNumber3,
                collateralSecure4, securityType4, addressofSecurity4, ownerofSecurity4, securityUniqueIdentificationType4, securityUniqueIdentificationNumber4,
                collateralSecure5, securityType5, addressofSecurity5, ownerofSecurity5, securityUniqueIdentificationType5, securityUniqueIdentificationNumber5,
                collateralSecure6, securityType6, addressofSecurity6, ownerofSecurity6, securityUniqueIdentificationType6, securityUniqueIdentificationNumber6,
                collateralSecure7, securityType7, addressofSecurity7, ownerofSecurity7, securityUniqueIdentificationType7, securityUniqueIdentificationNumber7,
                collateralSecure8, securityType8, addressofSecurity8, ownerofSecurity8, securityUniqueIdentificationType8, securityUniqueIdentificationNumber8,
                collateralSecure9, securityType9, addressofSecurity9, ownerofSecurity9, securityUniqueIdentificationType9, securityUniqueIdentificationNumber9,
                collateralSecure10, securityType10, addressofSecurity10, ownerofSecurity10, securityUniqueIdentificationType10, securityUniqueIdentificationNumber10,
                guarantee1, guaranteeType1, guarantorUniqueIdentificationType1, guarantorUniqueIdentificationNumber1, amountGuaranteed1,
                guaranteeType2, guarantorUniqueIdentificationType2, guarantorUniqueIdentificationNumber2, amountGuaranteed2,
                guaranteeType3, guarantorUniqueIdentificationType3, guarantorUniqueIdentificationNumber3, amountGuaranteed3,
                guaranteeType4, guarantorUniqueIdentificationType4, guarantorUniqueIdentificationNumber4, amountGuaranteed4,
                guaranteeType5, guarantorUniqueIdentificationType5, guarantorUniqueIdentificationNumber5, amountGuaranteed5,  inputterId, inputterDateStamp, "");

            ViewBag.saveCrms400B = status;

            if (status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 400B inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            
            return View();
        }

        //Unused
        public ActionResult Sixth()
        {
            var crmsUtil = new CrmsUtil();
            //do not touch

            return View();
        }
        
        [HttpGet]
        public ActionResult Seventh()
        {
            var crmsUtil = new CrmsUtil();
            ViewBag.BankCodes = crmsUtil.GetBankCodes();
           
            
            return View();
        }
        
        [HttpPost]
        public ActionResult Seventh(FormCollection formCollection)
        {
            //Get Data again
            var crmsUtil = new CrmsUtil();
            ViewBag.BankCodes = crmsUtil.GetBankCodes();

            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string syndicationRefNumber = formCollection["SyndicationRefNumber"];
            string syndicationName = formCollection["SyndicationName"];
            decimal syndicationTotalAmount = Convert.ToDecimal(formCollection["SyndicationTotalAmount"]);
            string participatingBankCode = formCollection["ParticipatingBankCode"];
            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
                bool status=saveData.SaveCrms600(code, customerId, accountNumber, customerName, syndicationRefNumber, syndicationName,
               syndicationTotalAmount, participatingBankCode, inputterId, inputterDateStamp, "");
            ViewBag.saveCrms600 = status;
            if(status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 600 inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            
            return View();
        }

        [HttpGet]
        public ActionResult Eight()
        {
            var crmsUtil = new CrmsUtil();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.LocationOfBeneficiary = crmsUtil.GetLocationOfBeneficiary();
            ViewBag.RelationshipType = crmsUtil.GetRelationshipType();
            ViewBag.CompanySize = crmsUtil.GetCompanySize();
            ViewBag.FundingSource = crmsUtil.GetFundingSource();
            return View();
        }

        [HttpPost]
        public ActionResult Eight(FormCollection formCollection)
        {
            //Get the elements again
            var crmsUtil = new CrmsUtil();
            ViewBag.LegalStatus = crmsUtil.GetLegalStatus();
            ViewBag.BusinessLines = crmsUtil.GetBusinessLines();
            ViewBag.BusinessLinesSubsector = crmsUtil.GetBusinessLinesSubSector();
            ViewBag.FeeType = crmsUtil.GetFeeType();
            ViewBag.SecurityType = crmsUtil.GetSecurityType();
            ViewBag.LocationOfBeneficiary = crmsUtil.GetLocationOfBeneficiary();
            ViewBag.RelationshipType = crmsUtil.GetRelationshipType();
            ViewBag.CompanySize = crmsUtil.GetCompanySize();
            ViewBag.FundingSource = crmsUtil.GetFundingSource();

            string code = formCollection["code"];
            string customerId = formCollection["CustomerID"];
            string accountNumber = formCollection["AccountNumber"];
            string customerName = formCollection["CustomerName"];
            string uniqueIdentificationType = formCollection["UniqueIdentificationType"];
            string identificationNo = formCollection["IdentificationNo"];
            string crmsRefNumber = formCollection["CRMSRefNo"];
            string businessLines = formCollection["BusinessLines"];
            string businessLinesSubsector = formCollection["BusinessLinesSubsector"];
            string feeType1 = formCollection["FeeType1"];
            decimal feeAmount1 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount1"]), 2);
            string feeType2 = formCollection["FeeType2"];
            decimal feeAmount2 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount2"]), 2);
            string feeType3 = formCollection["FeeType3"];
            decimal feeAmount3 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount3"]), 2);
            string feeType4 = formCollection["FeeType4"];
            decimal feeAmount4 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount4"]), 2);
            string feeType5 = formCollection["FeeType5"];
            decimal feeAmount5 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount5"]), 2);
            string feeType6 = formCollection["FeeType6"];
            decimal feeAmount6 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount6"]), 2);
            string feeType7 = formCollection["FeeType7"];
            decimal feeAmount7 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount7"]), 2);
            string feeType8 = formCollection["FeeType8"];
            decimal feeAmount8 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount8"]), 2);
            string feeType9 = formCollection["FeeType9"];
            decimal feeAmount9 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount9"]), 2);
            string feeType10 = formCollection["FeeType10"];
            decimal feeAmount10 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount10"]), 2);
            string feeType11 = formCollection["FeeType11"];
            decimal feeAmount11 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount11"]), 2);
            string feeType12 = formCollection["FeeType12"];
            decimal feeAmount12 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount12"]), 2);
            string feeType13 = formCollection["FeeType13"];
            decimal feeAmount13 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount13"]), 2);
            string feeType14 = formCollection["FeeType14"];
            decimal feeAmount14 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount14"]), 2);
            string feeType15 = formCollection["FeeType15"];
            decimal feeAmount15 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount15"]), 2);
            string feeType16 = formCollection["FeeType16"];
            decimal feeAmount16 = Math.Round(Convert.ToDecimal(formCollection["FeeAmount16"]), 2);
            int tenor = Convert.ToInt32(formCollection["Tenor"]);
            string benefciaryAccount = formCollection["BenefciaryAccount"];
            string locationOfBeneficiary = formCollection["LocationOfBeneficiary"];
            string relationshipType = formCollection["RelationshipType"];
            string companySize = formCollection["CompanySize"];
            string fundingSourceCategory = formCollection["FundingSourceCategory"];
            string ecciNumber = formCollection["ECCINumber"];
            string fundingSource = formCollection["FundingSource"];
            string legalStatus = formCollection["LegalStatus"];
            string cBusinessLines = formCollection["CBusinessLines"];
            string cBusinessLinesSubsector = formCollection["CBusinessLinesSubsector"];
            String specialisedLoan = formCollection["SpecialisedLoan"];
            int specialisedLoanPeriod = Convert.ToInt32(formCollection["SpecialisedLoanPeriod"]);

            string directorUniqueIdentificationType1 = formCollection["DirectorUniqueIdentificationType1"];
            string directorUniqueIdentificationNumber1 = formCollection["DirectorUniqueIdentificationNumber1"];
            string directorEmail1 = formCollection["DirectorEmail1"];

            string directorUniqueIdentificationType2 = formCollection["DirectorUniqueIdentificationType2"];
            string directorUniqueIdentificationNumber2 = formCollection["DirectorUniqueIdentificationNumber2"];
            string directorEmail2 = formCollection["DirectorEmail2"];

            string directorUniqueIdentificationType3 = formCollection["DirectorUniqueIdentificationType3"];
            string directorUniqueIdentificationNumber3 = formCollection["DirectorUniqueIdentificationNumber3"];
            string directorEmail3 = formCollection["DirectorEmail3"];

            string directorUniqueIdentificationType4 = formCollection["DirectorUniqueIdentificationType4"];
            string directorUniqueIdentificationNumber4 = formCollection["DirectorUniqueIdentificationNumber4"];
            string directorEmail4 = formCollection["DirectorEmail4"];

            string directorUniqueIdentificationType5 = formCollection["DirectorUniqueIdentificationType5"];
            string directorUniqueIdentificationNumber5 = formCollection["DirectorUniqueIdentificationNumber5"];
            string directorEmail5 = formCollection["DirectorEmail5"];

            string syndication = formCollection["Syndication"];
            string syndicationStatus = formCollection["SyndicationStatus"];
            string syndicationName = formCollection["SyndicationName"];
            decimal syndicationTotalAmount = Math.Round(Convert.ToDecimal(formCollection["SyndicationTotalAmount"]), 2); 
            string syndicationReferenceNumber = formCollection["SyndicationReferenceNumber"];

            string collateralPresent1 = formCollection["CollateralPresent1"];
            string collateralSecure1 = formCollection["CollateralSecure1"];
            string securityType1 = formCollection["SecurityType1"];
            string addressofSecurity1 = formCollection["AddressofSecurity1"];
            string ownerofSecurity1 = formCollection["OwnerofSecurity1"];
            string securityUniqueIdentificationType1 = formCollection["SecurityUniqueIdentificationType1"];
            string securityUniqueIdentificationNumber1 = formCollection["SecurityUniqueIdentificationNumber1"];

            string collateralSecure2 = formCollection["CollateralSecure2"];
            string securityType2 = formCollection["SecurityType2"];
            string addressofSecurity2 = formCollection["AddressofSecurity2"];
            string ownerofSecurity2 = formCollection["OwnerofSecurity2"];
            string securityUniqueIdentificationType2 = formCollection["SecurityUniqueIdentificationType2"];
            string securityUniqueIdentificationNumber2 = formCollection["SecurityUniqueIdentificationNumber2"];

            string collateralSecure3 = formCollection["CollateralSecure3"];
            string securityType3 = formCollection["SecurityType3"];
            string addressofSecurity3 = formCollection["AddressofSecurity3"];
            string ownerofSecurity3 = formCollection["OwnerofSecurity3"];
            string securityUniqueIdentificationType3 = formCollection["SecurityUniqueIdentificationType3"];
            string securityUniqueIdentificationNumber3 = formCollection["SecurityUniqueIdentificationNumber3"];

            string collateralSecure4 = formCollection["CollateralSecure4"];
            string securityType4 = formCollection["SecurityType4"];
            string addressofSecurity4 = formCollection["AddressofSecurity4"];
            string ownerofSecurity4 = formCollection["OwnerofSecurity4"];
            string securityUniqueIdentificationType4 = formCollection["SecurityUniqueIdentificationType4"];
            string securityUniqueIdentificationNumber4 = formCollection["SecurityUniqueIdentificationNumber4"];

            string collateralSecure5 = formCollection["CollateralSecure5"];
            string securityType5 = formCollection["SecurityType5"];
            string addressofSecurity5 = formCollection["AddressofSecurity5"];
            string ownerofSecurity5 = formCollection["OwnerofSecurity5"];
            string securityUniqueIdentificationType5 = formCollection["SecurityUniqueIdentificationType5"];
            string securityUniqueIdentificationNumber5 = formCollection["SecurityUniqueIdentificationNumber5"];

            string collateralSecure6 = formCollection["CollateralSecure6"];
            string securityType6 = formCollection["SecurityType6"];
            string addressofSecurity6 = formCollection["AddressofSecurity6"];
            string ownerofSecurity6 = formCollection["OwnerofSecurity6"];
            string securityUniqueIdentificationType6 = formCollection["SecurityUniqueIdentificationType6"];
            string securityUniqueIdentificationNumber6 = formCollection["SecurityUniqueIdentificationNumber6"];

            string collateralSecure7 = formCollection["CollateralSecure7"];
            string securityType7 = formCollection["SecurityType7"];
            string addressofSecurity7 = formCollection["AddressofSecurity7"];
            string ownerofSecurity7 = formCollection["OwnerofSecurity7"];
            string securityUniqueIdentificationType7 = formCollection["SecurityUniqueIdentificationType7"];
            string securityUniqueIdentificationNumber7 = formCollection["SecurityUniqueIdentificationNumber7"];

            string collateralSecure8 = formCollection["CollateralSecure8"];
            string securityType8 = formCollection["SecurityType8"];
            string addressofSecurity8 = formCollection["AddressofSecurity8"];
            string ownerofSecurity8 = formCollection["OwnerofSecurity8"];
            string securityUniqueIdentificationType8 = formCollection["SecurityUniqueIdentificationType8"];
            string securityUniqueIdentificationNumber8 = formCollection["SecurityUniqueIdentificationNumber8"];

            string collateralSecure9 = formCollection["CollateralSecure9"];
            string securityType9 = formCollection["SecurityType9"];
            string addressofSecurity9 = formCollection["AddressofSecurity9"];
            string ownerofSecurity9 = formCollection["OwnerofSecurity9"];
            string securityUniqueIdentificationType9 = formCollection["SecurityUniqueIdentificationType9"];
            string securityUniqueIdentificationNumber9 = formCollection["SecurityUniqueIdentificationNumber9"];

            string collateralSecure10 = formCollection["CollateralSecure10"];
            string securityType10 = formCollection["SecurityType10"];
            string addressofSecurity10 = formCollection["AddressofSecurity10"];
            string ownerofSecurity10 = formCollection["OwnerofSecurity10"];
            string securityUniqueIdentificationType10 = formCollection["SecurityUniqueIdentificationType10"];
            string securityUniqueIdentificationNumber10 = formCollection["SecurityUniqueIdentificationNumber10"];

            string guarantee1 = formCollection["Guarantee1"];
            string guaranteeType1 = formCollection["GuaranteeType1"];
            string guarantorUniqueIdentificationType1 = formCollection["GuarantorUniqueIdentificationType1"];
            string guarantorUniqueIdentificationNumber1 = formCollection["GuarantorUniqueIdentificationNumber1"];
            decimal amountGuaranteed1 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed1"]), 2);

            string guaranteeType2 = formCollection["GuaranteeType2"];
            string guarantorUniqueIdentificationType2 = formCollection["GuarantorUniqueIdentificationType2"];
            string guarantorUniqueIdentificationNumber2 = formCollection["GuarantorUniqueIdentificationNumber2"];
            decimal amountGuaranteed2 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed2"]), 2);

            string guaranteeType3 = formCollection["GuaranteeType3"];
            string guarantorUniqueIdentificationType3 = formCollection["GuarantorUniqueIdentificationType3"];
            string guarantorUniqueIdentificationNumber3 = formCollection["GuarantorUniqueIdentificationNumber3"];
            decimal amountGuaranteed3 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed3"]), 2);

            string guaranteeType4 = formCollection["GuaranteeType4"];
            string guarantorUniqueIdentificationType4 = formCollection["GuarantorUniqueIdentificationType4"];
            string guarantorUniqueIdentificationNumber4 = formCollection["GuarantorUniqueIdentificationNumber4"];
            decimal amountGuaranteed4 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed4"]), 2);

            string guaranteeType5 = formCollection["GuaranteeType5"];
            string guarantorUniqueIdentificationType5 = formCollection["GuarantorUniqueIdentificationType5"];
            string guarantorUniqueIdentificationNumber5 = formCollection["GuarantorUniqueIdentificationNumber5"];
            decimal amountGuaranteed5 = Math.Round(Convert.ToDecimal(formCollection["AmountGuaranteed5"]), 2);

            string inputterId = User.Identity.Name;
            DateTime inputterDateStamp = DateTime.Now;

            var saveData = new SaveData();
            
                bool status = saveData.SaveCrms700(code, customerId, accountNumber, customerName, uniqueIdentificationType, identificationNo, crmsRefNumber, businessLines,
                businessLinesSubsector, feeType1, feeAmount1, feeType2, feeAmount2, feeType3, feeAmount3,
                feeType4, feeAmount4, feeType5, feeAmount5, feeType6, feeAmount6, feeType7, feeAmount7, feeType8, feeAmount8, feeType9, feeAmount9,
                feeType10, feeAmount10, feeType11, feeAmount11, feeType12, feeAmount12, feeType13, feeAmount13, feeType14, feeAmount14, feeType15,
                feeAmount15, feeType16, feeAmount16, tenor, benefciaryAccount, locationOfBeneficiary, relationshipType,
                companySize, fundingSourceCategory, ecciNumber, fundingSource, legalStatus, cBusinessLines, cBusinessLinesSubsector, specialisedLoan, specialisedLoanPeriod,
                directorUniqueIdentificationType1, directorUniqueIdentificationNumber1, directorEmail1, directorUniqueIdentificationType2, directorUniqueIdentificationNumber2, directorEmail2,
                directorUniqueIdentificationType3, directorUniqueIdentificationNumber3, directorEmail3, directorUniqueIdentificationType4, directorUniqueIdentificationNumber4, directorEmail4,
                directorUniqueIdentificationType5, directorUniqueIdentificationNumber5, directorEmail5, syndication, syndicationStatus, syndicationName, syndicationTotalAmount, syndicationReferenceNumber,
                collateralPresent1, collateralSecure1, securityType1, addressofSecurity1, ownerofSecurity1, securityUniqueIdentificationType1, securityUniqueIdentificationNumber1,
                collateralSecure2, securityType2, addressofSecurity2, ownerofSecurity2, securityUniqueIdentificationType2, securityUniqueIdentificationNumber2,
                collateralSecure3, securityType3, addressofSecurity3, ownerofSecurity3, securityUniqueIdentificationType3, securityUniqueIdentificationNumber3,
                collateralSecure4, securityType4, addressofSecurity4, ownerofSecurity4, securityUniqueIdentificationType4, securityUniqueIdentificationNumber4,
                collateralSecure5, securityType5, addressofSecurity5, ownerofSecurity5, securityUniqueIdentificationType5, securityUniqueIdentificationNumber5,
                collateralSecure6, securityType6, addressofSecurity6, ownerofSecurity6, securityUniqueIdentificationType6, securityUniqueIdentificationNumber6,
                collateralSecure7, securityType7, addressofSecurity7, ownerofSecurity7, securityUniqueIdentificationType7, securityUniqueIdentificationNumber7,
                collateralSecure8, securityType8, addressofSecurity8, ownerofSecurity8, securityUniqueIdentificationType8, securityUniqueIdentificationNumber8,
                collateralSecure9, securityType9, addressofSecurity9, ownerofSecurity9, securityUniqueIdentificationType9, securityUniqueIdentificationNumber9,
                collateralSecure10, securityType10, addressofSecurity10, ownerofSecurity10, securityUniqueIdentificationType10, securityUniqueIdentificationNumber10,
                guarantee1, guaranteeType1, guarantorUniqueIdentificationType1, guarantorUniqueIdentificationNumber1, amountGuaranteed1,
                guaranteeType2, guarantorUniqueIdentificationType2, guarantorUniqueIdentificationNumber2, amountGuaranteed2,
                guaranteeType3, guarantorUniqueIdentificationType3, guarantorUniqueIdentificationNumber3, amountGuaranteed3,
                guaranteeType4, guarantorUniqueIdentificationType4, guarantorUniqueIdentificationNumber4, amountGuaranteed4,
                guaranteeType5, guarantorUniqueIdentificationType5, guarantorUniqueIdentificationNumber5, amountGuaranteed5,
                inputterId, inputterDateStamp, "");

            ViewBag.saveCrms700 = status;
            if (status)
                saveData.SendMail(new string[] { inputterId + "@ecobank.com", "aoyedere@ecobank.com", "chuokafor@ecobank.com" }, "CRMS 700 inputted by " + inputterId, "Record has been saved and is awaiting further action from CAD - Portfolio Unit");
            

            return View();
        }

        public ActionResult Admin()
        {
            var viewUtil = new ViewUtil();
            ViewBag.Crms100 = viewUtil.GetCrms100S();
            ViewBag.Crms200 = viewUtil.GetCrms200S();
            ViewBag.Crms300 = viewUtil.GetCrms300S();
            ViewBag.Crms400A = viewUtil.GetCrms400As();
            ViewBag.Crms400B = viewUtil.GetCrms400Bs();
            ViewBag.Crms600 = viewUtil.GetCrms600S();
            ViewBag.Crms700 = viewUtil.GetCrms700S();
            return View();
        }

        public ActionResult MyUploads()
        {
            var viewUtil = new ViewUtil();
            ViewBag.Crms100 = viewUtil.GetCrms100S();
            ViewBag.Crms200 = viewUtil.GetCrms200S();
            ViewBag.Crms300 = viewUtil.GetCrms300S();
            ViewBag.Crms400A = viewUtil.GetCrms400As();
            ViewBag.Crms400B = viewUtil.GetCrms400Bs();
            ViewBag.Crms600 = viewUtil.GetCrms600S();
            ViewBag.Crms700 = viewUtil.GetCrms700S();
            return View();
        }

        public JsonResult AccountDetails(string accountNumber)
        {
            CrmsUtil crmsUtil = new CrmsUtil();
            var accountData = crmsUtil.GetAccountDetails(accountNumber);

            return Json(accountData, JsonRequestBehavior.AllowGet);
        }
    }
}