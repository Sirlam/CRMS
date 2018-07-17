using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMS.Utils
{
    public class ViewUtil
    {
        private readonly string _databaseCs;
        private readonly string _myId = HttpContext.Current.User.Identity.Name.ToLower();

        public ViewUtil()
        {
            _databaseCs = ConfigurationManager.ConnectionStrings["DatabaseCS"].ConnectionString;
        }

        public List<Crms100> GetCrms100S()
        {
            List<Crms100> crms100S = new List<Crms100>();
            string sqlSelect = "select * from crms_100 where Inputter_ID = '"+_myId+"' ";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms100 = new Crms100()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            GovernmentCode = (rdr["Government_Code"].ToString()),
                            LegalStatus = (rdr["Legal_Status"].ToString()),
                            CreditType = (rdr["Credit_Type"].ToString()),
                            CreditPurposeByBusinessLines = (rdr["Credit_Purpose_By_Business_Lines"].ToString()),
                            CreditPurposeByBusinessLinesSubsector =
                                (rdr["Credit_Purpose_By_Business_Lines_Subsector"].ToString()),
                            CreditLimit = Convert.ToDecimal((rdr["Credit_Limit"].ToString())),
                            OutstandingAmount = Convert.ToDecimal((rdr["Outstanding_Amount"].ToString())),
                            FeeType1 = (rdr["Fee_Type1"].ToString()),
                            FeeAmount1 = Convert.ToDecimal((rdr["Fee_Amount1"].ToString())),
                            FeeType2 = (rdr["Fee_Type2"].ToString()),
                            FeeAmount2 = Convert.ToDecimal((rdr["Fee_Amount2"].ToString())),
                            FeeType3 = (rdr["Fee_Type3"].ToString()),
                            FeeAmount3 = Convert.ToDecimal((rdr["Fee_Amount3"].ToString())),
                            FeeType4 = (rdr["Fee_Type4"].ToString()),
                            FeeAmount4 = Convert.ToDecimal((rdr["Fee_Amount4"].ToString())),
                            FeeType5 = (rdr["Fee_Type5"].ToString()),
                            FeeAmount5 = Convert.ToDecimal((rdr["Fee_Amount5"].ToString())),
                            FeeType6 = (rdr["Fee_Type6"].ToString()),
                            FeeAmount6 = Convert.ToDecimal((rdr["Fee_Amount6"].ToString())),
                            FeeType7 = (rdr["Fee_Type7"].ToString()),
                            FeeAmount7 = Convert.ToDecimal((rdr["Fee_Amount7"].ToString())),
                            FeeType8 = (rdr["Fee_Type8"].ToString()),
                            FeeAmount8 = Convert.ToDecimal((rdr["Fee_Amount8"].ToString())),
                            FeeType9 = (rdr["Fee_Type9"].ToString()),
                            FeeAmount9 = Convert.ToDecimal((rdr["Fee_Amount9"].ToString())),
                            FeeType10 = (rdr["Fee_Type10"].ToString()),
                            FeeAmount10 = Convert.ToDecimal((rdr["Fee_Amount10"].ToString())),
                            FeeType11 = (rdr["Fee_Type11"].ToString()),
                            FeeAmount11 = Convert.ToDecimal((rdr["Fee_Amount11"].ToString())),
                            FeeType12 = (rdr["Fee_Type12"].ToString()),
                            FeeAmount12 = Convert.ToDecimal((rdr["Fee_Amount12"].ToString())),
                            FeeType13 = (rdr["Fee_Type13"].ToString()),
                            FeeAmount13 = Convert.ToDecimal((rdr["Fee_Amount13"].ToString())),
                            FeeType14 = (rdr["Fee_Type14"].ToString()),
                            FeeAmount14 = Convert.ToDecimal((rdr["Fee_Amount14"].ToString())),
                            FeeType15 = (rdr["Fee_Type15"].ToString()),
                            FeeAmount15 = Convert.ToDecimal((rdr["Fee_Amount15"].ToString())),
                            FeeType16 = (rdr["Fee_Type16"].ToString()),
                            FeeAmount16 = Convert.ToDecimal((rdr["Fee_Amount16"].ToString())),
                            EffectiveDate = DateTime.Parse((rdr["Effective_Date"].ToString())),
                            Tenor = Convert.ToInt32((rdr["Tenor"].ToString())),
                            ExpiryDate = DateTime.Parse((rdr["Expiry_Date"].ToString())),
                            RepaymentAgreementMode = (rdr["Repayment_Agreement_Mode"].ToString()),
                            SpecialisedLoan = (rdr["Specialised_Loan"].ToString()),
                            SpecialisedLoanPeriod = Convert.ToInt32((rdr["Specialised_Loan_Period"].ToString())),
                            InterestRate = Convert.ToDecimal((rdr["Interest_Rate"].ToString())),
                            CollateralPresent1 = (rdr["Collateral_Present1"].ToString()),
                            CollateralSecure1 = (rdr["Collateral_Secure1"].ToString()),
                            SecurityType1 = (rdr["Security_Type1"].ToString()),
                            CollateralSecure2 = (rdr["Collateral_Secure2"].ToString()),
                            SecurityType2 = (rdr["Security_Type2"].ToString()),
                            CollateralSecure3 = (rdr["Collateral_Secure3"].ToString()),
                            SecurityType3 = (rdr["Security_Type3"].ToString()),
                            CollateralSecure4 = (rdr["Collateral_Secure4"].ToString()),
                            SecurityType4 = (rdr["Security_Type4"].ToString()),
                            CollateralSecure5 = (rdr["Collateral_Secure5"].ToString()),
                            SecurityType5 = (rdr["Security_Type5"].ToString()),
                            CollateralSecure6 = (rdr["Collateral_Secure6"].ToString()),
                            SecurityType6 = (rdr["Security_Type6"].ToString()),
                            CollateralSecure7 = (rdr["Collateral_Secure7"].ToString()),
                            SecurityType7 = (rdr["Security_Type7"].ToString()),
                            CollateralSecure8 = (rdr["Collateral_Secure8"].ToString()),
                            SecurityType8 = (rdr["Security_Type8"].ToString()),
                            CollateralSecure9 = (rdr["Collateral_Secure9"].ToString()),
                            SecurityType9 = (rdr["Security_Type9"].ToString()),
                            CollateralSecure10 = (rdr["Collateral_Secure10"].ToString()),
                            SecurityType10 = (rdr["Security_Type10"].ToString()),
                            RepaymentSource = (rdr["Repayment_Source"].ToString()),
                            Syndication = (rdr["Syndication"].ToString()),
                            SyndicationStatus = (rdr["Syndication_Status"].ToString()),
                            SyndicationReferenceNumber = (rdr["Syndication_Reference_Number"].ToString()),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms100S.Add(crms100);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms100S;
        }

        public List<Crms200> GetCrms200S()
        {
            List<Crms200> crms200S = new List<Crms200>();
            string sqlSelect = "select * from crms_200 where Inputter_ID = '" + _myId + "'";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms200 = new Crms200()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            GovernmentMdaTin = (rdr["Government_Mda_Tin"].ToString()),
                            LegalStatus = (rdr["Legal_Status"].ToString()),
                            CreditType = (rdr["Credit_Type"].ToString()),
                            CreditPurposeByBusinessLines = (rdr["Credit_Purpose_By_Business_Lines"].ToString()),
                            CreditPurposeByBusinessLinesSubsector =
                                (rdr["Credit_Purpose_By_Business_Lines_Subsector"].ToString()),
                            CreditLimit = Convert.ToDecimal((rdr["Credit_Limit"].ToString())),
                            OutstandingAmount = Convert.ToDecimal((rdr["Outstanding_Amount"].ToString())),
                            FeeType1 = (rdr["Fee_Type1"].ToString()),
                            FeeAmount1 = Convert.ToDecimal((rdr["Fee_Amount1"].ToString())),
                            FeeType2 = (rdr["Fee_Type2"].ToString()),
                            FeeAmount2 = Convert.ToDecimal((rdr["Fee_Amount2"].ToString())),
                            FeeType3 = (rdr["Fee_Type3"].ToString()),
                            FeeAmount3 = Convert.ToDecimal((rdr["Fee_Amount3"].ToString())),
                            FeeType4 = (rdr["Fee_Type4"].ToString()),
                            FeeAmount4 = Convert.ToDecimal((rdr["Fee_Amount4"].ToString())),
                            FeeType5 = (rdr["Fee_Type5"].ToString()),
                            FeeAmount5 = Convert.ToDecimal((rdr["Fee_Amount5"].ToString())),
                            FeeType6 = (rdr["Fee_Type6"].ToString()),
                            FeeAmount6 = Convert.ToDecimal((rdr["Fee_Amount6"].ToString())),
                            FeeType7 = (rdr["Fee_Type7"].ToString()),
                            FeeAmount7 = Convert.ToDecimal((rdr["Fee_Amount7"].ToString())),
                            FeeType8 = (rdr["Fee_Type8"].ToString()),
                            FeeAmount8 = Convert.ToDecimal((rdr["Fee_Amount8"].ToString())),
                            FeeType9 = (rdr["Fee_Type9"].ToString()),
                            FeeAmount9 = Convert.ToDecimal((rdr["Fee_Amount9"].ToString())),
                            FeeType10 = (rdr["Fee_Type10"].ToString()),
                            FeeAmount10 = Convert.ToDecimal((rdr["Fee_Amount10"].ToString())),
                            FeeType11 = (rdr["Fee_Type11"].ToString()),
                            FeeAmount11 = Convert.ToDecimal((rdr["Fee_Amount11"].ToString())),
                            FeeType12 = (rdr["Fee_Type12"].ToString()),
                            FeeAmount12 = Convert.ToDecimal((rdr["Fee_Amount12"].ToString())),
                            FeeType13 = (rdr["Fee_Type13"].ToString()),
                            FeeAmount13 = Convert.ToDecimal((rdr["Fee_Amount13"].ToString())),
                            FeeType14 = (rdr["Fee_Type14"].ToString()),
                            FeeAmount14 = Convert.ToDecimal((rdr["Fee_Amount14"].ToString())),
                            FeeType15 = (rdr["Fee_Type15"].ToString()),
                            FeeAmount15 = Convert.ToDecimal((rdr["Fee_Amount15"].ToString())),
                            FeeType16 = (rdr["Fee_Type16"].ToString()),
                            FeeAmount16 = Convert.ToDecimal((rdr["Fee_Amount16"].ToString())),
                            EffectiveDate = DateTime.Parse((rdr["Effective_Date"].ToString())),
                            Tenor = Convert.ToInt32((rdr["Tenor"].ToString())),
                            ExpiryDate = DateTime.Parse((rdr["Expiry_Date"].ToString())),
                            RepaymentAgreementMode = (rdr["Repayment_Agreement_Mode"].ToString()),
                            PerformanceRepaymentStatus = (rdr["Performance_Repayment_Status"].ToString()),
                            SpecialisedLoan = (rdr["Specialised_Loan"].ToString()),
                            SpecialisedLoanPeriod = Convert.ToInt32((rdr["Specialised_Loan_Period"].ToString())),
                            InterestRate = Convert.ToDecimal((rdr["Interest_Rate"].ToString())),
                            CollateralPresent1 = (rdr["Collateral_Present1"].ToString()),
                            CollateralSecure1 = (rdr["Collateral_Secure1"].ToString()),
                            SecurityType1 = (rdr["Security_Type1"].ToString()),
                            CollateralSecure2 = (rdr["Collateral_Secure2"].ToString()),
                            SecurityType2 = (rdr["Security_Type2"].ToString()),
                            CollateralSecure3 = (rdr["Collateral_Secure3"].ToString()),
                            SecurityType3 = (rdr["Security_Type3"].ToString()),
                            CollateralSecure4 = (rdr["Collateral_Secure4"].ToString()),
                            SecurityType4 = (rdr["Security_Type4"].ToString()),
                            CollateralSecure5 = (rdr["Collateral_Secure5"].ToString()),
                            SecurityType5 = (rdr["Security_Type5"].ToString()),
                            CollateralSecure6 = (rdr["Collateral_Secure6"].ToString()),
                            SecurityType6 = (rdr["Security_Type6"].ToString()),
                            CollateralSecure7 = (rdr["Collateral_Secure7"].ToString()),
                            SecurityType7 = (rdr["Security_Type7"].ToString()),
                            CollateralSecure8 = (rdr["Collateral_Secure8"].ToString()),
                            SecurityType8 = (rdr["Security_Type8"].ToString()),
                            CollateralSecure9 = (rdr["Collateral_Secure9"].ToString()),
                            SecurityType9 = (rdr["Security_Type9"].ToString()),
                            CollateralSecure10 = (rdr["Collateral_Secure10"].ToString()),
                            SecurityType10 = (rdr["Security_Type10"].ToString()),
                            RepaymentSource = (rdr["Repayment_Source"].ToString()),
                            Syndication = (rdr["Syndication"].ToString()),
                            SyndicationStatus = (rdr["Syndication_Status"].ToString()),
                            SyndicationReferenceNumber = (rdr["Syndication_Reference_Number"].ToString()),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms200S.Add(crms200);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms200S;
        }

        public List<Crms300> GetCrms300S()
        {
            List<Crms300> crms300S = new List<Crms300>();
            string sqlSelect = "select * from crms_300 where Inputter_ID = '" + _myId + "'";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms300 = new Crms300()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            UniqueIdentificationType = (rdr["Unique_Identifcation_Type"].ToString()),
                            UniqueIdentificationNumber = (rdr["Unique_Identifcation_Number"].ToString()),
                            CreditType = (rdr["Credit_Type"].ToString()),
                            CreditPurposeByBusinessLines = (rdr["Credit_Purpose_By_Business_Lines"].ToString()),
                            CreditPurposeByBusinessLinesSubsector =
                                (rdr["Credit_Purpose_By_Business_Lines_Subsector"].ToString()),
                            CreditLimit = Convert.ToDecimal((rdr["Credit_Limit"].ToString())),
                            OutstandingAmount = Convert.ToDecimal((rdr["Outstanding_Amount"].ToString())),
                            FeeType1 = (rdr["Fee_Type1"].ToString()),
                            FeeAmount1 = Convert.ToDecimal((rdr["Fee_Amount1"].ToString())),
                            FeeType2 = (rdr["Fee_Type2"].ToString()),
                            FeeAmount2 = Convert.ToDecimal((rdr["Fee_Amount2"].ToString())),
                            FeeType3 = (rdr["Fee_Type3"].ToString()),
                            FeeAmount3 = Convert.ToDecimal((rdr["Fee_Amount3"].ToString())),
                            FeeType4 = (rdr["Fee_Type4"].ToString()),
                            FeeAmount4 = Convert.ToDecimal((rdr["Fee_Amount4"].ToString())),
                            FeeType5 = (rdr["Fee_Type5"].ToString()),
                            FeeAmount5 = Convert.ToDecimal((rdr["Fee_Amount5"].ToString())),
                            FeeType6 = (rdr["Fee_Type6"].ToString()),
                            FeeAmount6 = Convert.ToDecimal((rdr["Fee_Amount6"].ToString())),
                            FeeType7 = (rdr["Fee_Type7"].ToString()),
                            FeeAmount7 = Convert.ToDecimal((rdr["Fee_Amount7"].ToString())),
                            FeeType8 = (rdr["Fee_Type8"].ToString()),
                            FeeAmount8 = Convert.ToDecimal((rdr["Fee_Amount8"].ToString())),
                            FeeType9 = (rdr["Fee_Type9"].ToString()),
                            FeeAmount9 = Convert.ToDecimal((rdr["Fee_Amount9"].ToString())),
                            FeeType10 = (rdr["Fee_Type10"].ToString()),
                            FeeAmount10 = Convert.ToDecimal((rdr["Fee_Amount10"].ToString())),
                            FeeType11 = (rdr["Fee_Type11"].ToString()),
                            FeeAmount11 = Convert.ToDecimal((rdr["Fee_Amount11"].ToString())),
                            FeeType12 = (rdr["Fee_Type12"].ToString()),
                            FeeAmount12 = Convert.ToDecimal((rdr["Fee_Amount12"].ToString())),
                            FeeType13 = (rdr["Fee_Type13"].ToString()),
                            FeeAmount13 = Convert.ToDecimal((rdr["Fee_Amount13"].ToString())),
                            FeeType14 = (rdr["Fee_Type14"].ToString()),
                            FeeAmount14 = Convert.ToDecimal((rdr["Fee_Amount14"].ToString())),
                            FeeType15 = (rdr["Fee_Type15"].ToString()),
                            FeeAmount15 = Convert.ToDecimal((rdr["Fee_Amount15"].ToString())),
                            FeeType16 = (rdr["Fee_Type16"].ToString()),
                            FeeAmount16 = Convert.ToDecimal((rdr["Fee_Amount16"].ToString())),
                            EffectiveDate = DateTime.Parse((rdr["Effective_Date"].ToString())),
                            Tenor = Convert.ToInt32((rdr["Tenor"].ToString())),
                            ExpiryDate = DateTime.Parse((rdr["Expiry_Date"].ToString())),
                            RepaymentAgreementMode = (rdr["Repayment_Agreement_Mode"].ToString()),
                            InterestRate = Convert.ToDecimal((rdr["Interest_Rate"].ToString())),
                            BeneficiaryAccountNumber = (rdr["Beneficiary_Account_Number"].ToString()),
                            LocationOfBeneficiary = (rdr["Location_of_Beneficiary"].ToString()),
                            RelationshipType = (rdr["Relationship_Type"].ToString()),
                            FundingSourceCategory = (rdr["Funding_Source_Category"].ToString()),
                            EcciNumber = (rdr["Ecci_Number"].ToString()),
                            FundingSource = (rdr["Funding_Source"].ToString()),
                            LegalStatus = (rdr["Legal_Status"].ToString()),
                            ClassificationByBusinessLines = (rdr["Classification_By_Business_Lines"].ToString()),
                            ClassificationByBusinessLinesSubsector = (rdr["Classification_By_Business_Lines_Subsector"].ToString()),
                            SpecialisedLoan = (rdr["Specialised_Loan"].ToString()),
                            SpecialisedLoanPeriod = Convert.ToInt32((rdr["Specialised_Loan_Period"].ToString())),
                            DirectorIdType1 = (rdr["Director_Id_Type1"].ToString()),
                            DirectorIdNumber1 = (rdr["Director_Id_Number1"].ToString()),
                            DirectorIdEmail1 = (rdr["Director_Id_Email1"].ToString()),
                            DirectorIdType2 = (rdr["Director_Id_Type2"].ToString()),
                            DirectorIdNumber2 = (rdr["Director_Id_Number2"].ToString()),
                            DirectorIdEmail2 = (rdr["Director_Id_Email2"].ToString()),
                            DirectorIdType3 = (rdr["Director_Id_Type3"].ToString()),
                            DirectorIdNumber3 = (rdr["Director_Id_Number3"].ToString()),
                            DirectorIdEmail3 = (rdr["Director_Id_Email3"].ToString()),
                            DirectorIdType4 = (rdr["Director_Id_Type4"].ToString()),
                            DirectorIdNumber4 = (rdr["Director_Id_Number4"].ToString()),
                            DirectorIdEmail4 = (rdr["Director_Id_Email4"].ToString()),
                            DirectorIdType5 = (rdr["Director_Id_Type5"].ToString()),
                            DirectorIdNumber5 = (rdr["Director_Id_Number5"].ToString()),
                            DirectorIdEmail5 = (rdr["Director_Id_Email5"].ToString()),
                            Syndication = (rdr["Syndication"].ToString()),
                            SyndicationStatus = (rdr["Syndication_Status"].ToString()),
                            SyndicationReferenceNumber = (rdr["Syndication_Reference_Number"].ToString()),
                            CollateralPresent1 = (rdr["Collateral_Present1"].ToString()),
                            CollateralSecure1 = (rdr["Collateral_Secure1"].ToString()),
                            SecurityType1 = (rdr["Security_Type1"].ToString()),
                            AddressOfSecurity1 = (rdr["Address_Of_Security1"].ToString()),
                            OwnerOfSecurity1 = (rdr["Owner_Of_Security1"].ToString()),
                            SecurityIdType1 = (rdr["Security_Id_Type1"].ToString()),
                            SecurityIdNumber1 = (rdr["Security_Id_Number1"].ToString()),
                            CollateralSecure2 = (rdr["Collateral_Secure2"].ToString()),
                            SecurityType2 = (rdr["Security_Type2"].ToString()),
                            AddressOfSecurity2 = (rdr["Address_Of_Security2"].ToString()),
                            OwnerOfSecurity2 = (rdr["Owner_Of_Security2"].ToString()),
                            SecurityIdType2 = (rdr["Security_Id_Type2"].ToString()),
                            SecurityIdNumber2 = (rdr["Security_Id_Number2"].ToString()),
                            CollateralSecure3 = (rdr["Collateral_Secure3"].ToString()),
                            SecurityType3 = (rdr["Security_Type3"].ToString()),
                            AddressOfSecurity3 = (rdr["Address_Of_Security3"].ToString()),
                            OwnerOfSecurity3 = (rdr["Owner_Of_Security3"].ToString()),
                            SecurityIdType3 = (rdr["Security_Id_Type3"].ToString()),
                            SecurityIdNumber3 = (rdr["Security_Id_Number3"].ToString()),
                            CollateralSecure4 = (rdr["Collateral_Secure4"].ToString()),
                            SecurityType4 = (rdr["Security_Type4"].ToString()),
                            AddressOfSecurity4 = (rdr["Address_Of_Security4"].ToString()),
                            OwnerOfSecurity4 = (rdr["Owner_Of_Security4"].ToString()),
                            SecurityIdType4 = (rdr["Security_Id_Type4"].ToString()),
                            SecurityIdNumber4 = (rdr["Security_Id_Number4"].ToString()),
                            CollateralSecure5 = (rdr["Collateral_Secure5"].ToString()),
                            SecurityType5 = (rdr["Security_Type5"].ToString()),
                            AddressOfSecurity5 = (rdr["Address_Of_Security5"].ToString()),
                            OwnerOfSecurity5 = (rdr["Owner_Of_Security5"].ToString()),
                            SecurityIdType5 = (rdr["Security_Id_Type5"].ToString()),
                            SecurityIdNumber5 = (rdr["Security_Id_Number5"].ToString()),
                            CollateralSecure6 = (rdr["Collateral_Secure6"].ToString()),
                            SecurityType6 = (rdr["Security_Type6"].ToString()),
                            AddressOfSecurity6 = (rdr["Address_Of_Security6"].ToString()),
                            OwnerOfSecurity6 = (rdr["Owner_Of_Security6"].ToString()),
                            SecurityIdType6 = (rdr["Security_Id_Type6"].ToString()),
                            SecurityIdNumber6 = (rdr["Security_Id_Number6"].ToString()),
                            CollateralSecure7 = (rdr["Collateral_Secure7"].ToString()),
                            SecurityType7 = (rdr["Security_Type7"].ToString()),
                            AddressOfSecurity7 = (rdr["Address_Of_Security7"].ToString()),
                            OwnerOfSecurity7 = (rdr["Owner_Of_Security7"].ToString()),
                            SecurityIdType7 = (rdr["Security_Id_Type7"].ToString()),
                            SecurityIdNumber7 = (rdr["Security_Id_Number7"].ToString()),
                            CollateralSecure8 = (rdr["Collateral_Secure8"].ToString()),
                            SecurityType8 = (rdr["Security_Type8"].ToString()),
                            AddressOfSecurity8 = (rdr["Address_Of_Security8"].ToString()),
                            OwnerOfSecurity8 = (rdr["Owner_Of_Security8"].ToString()),
                            SecurityIdType8 = (rdr["Security_Id_Type8"].ToString()),
                            SecurityIdNumber8 = (rdr["Security_Id_Number8"].ToString()),
                            CollateralSecure9 = (rdr["Collateral_Secure9"].ToString()),
                            SecurityType9 = (rdr["Security_Type9"].ToString()),
                            AddressOfSecurity9 = (rdr["Address_Of_Security9"].ToString()),
                            OwnerOfSecurity9 = (rdr["Owner_Of_Security9"].ToString()),
                            SecurityIdType9 = (rdr["Security_Id_Type9"].ToString()),
                            SecurityIdNumber9 = (rdr["Security_Id_Number9"].ToString()),
                            CollateralSecure10 = (rdr["Collateral_Secure10"].ToString()),
                            SecurityType10 = (rdr["Security_Type10"].ToString()),
                            AddressOfSecurity10 = (rdr["Address_Of_Security10"].ToString()),
                            OwnerOfSecurity10 = (rdr["Owner_Of_Security10"].ToString()),
                            SecurityIdType10 = (rdr["Security_Id_Type10"].ToString()),
                            SecurityIdNumber10 = (rdr["Security_Id_Number10"].ToString()),
                            Guarantee1 = (rdr["Guarantee1"].ToString()),
                            GuaranteeType1 = (rdr["Guarantee_Type1"].ToString()),
                            GuaranteeIdType1 = (rdr["Guarantor_Id_Type1"].ToString()),
                            GuaranteeIdNumber1 = (rdr["Guarantor_Id_Number1"].ToString()),
                            AmountGuranteed1 = Convert.ToDecimal((rdr["Amount_Guaranteed1"].ToString())),
                            GuaranteeType2 = (rdr["Guarantee_Type2"].ToString()),
                            GuaranteeIdType2 = (rdr["Guarantor_Id_Type2"].ToString()),
                            GuaranteeIdNumber2 = (rdr["Guarantor_Id_Number2"].ToString()),
                            AmountGuranteed2 = Convert.ToDecimal((rdr["Amount_Guaranteed2"].ToString())),
                            GuaranteeType3 = (rdr["Guarantee_Type3"].ToString()),
                            GuaranteeIdType3 = (rdr["Guarantor_Id_Type3"].ToString()),
                            GuaranteeIdNumber3 = (rdr["Guarantor_Id_Number3"].ToString()),
                            AmountGuranteed3 = Convert.ToDecimal((rdr["Amount_Guaranteed3"].ToString())),
                            GuaranteeType4 = (rdr["Guarantee_Type4"].ToString()),
                            GuaranteeIdType4 = (rdr["Guarantor_Id_Type4"].ToString()),
                            GuaranteeIdNumber4 = (rdr["Guarantor_Id_Number4"].ToString()),
                            AmountGuranteed4 = Convert.ToDecimal((rdr["Amount_Guaranteed4"].ToString())),
                            GuaranteeType5 = (rdr["Guarantee_Type5"].ToString()),
                            GuaranteeIdType5 = (rdr["Guarantor_Id_Type5"].ToString()),
                            GuaranteeIdNumber5 = (rdr["Guarantor_Id_Number5"].ToString()),
                            AmountGuranteed5 = Convert.ToDecimal((rdr["Amount_Guaranteed5"].ToString())),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms300S.Add(crms300);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms300S;
        }

        public List<Crms400A> GetCrms400As()
        {
            List<Crms400A> crms400As = new List<Crms400A>();
            string sqlSelect = "select * from crms_400A where Inputter_ID = '" + _myId + "'";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms400A = new Crms400A()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            UniqueIdentificationType = (rdr["Unique_Identifcation_Type"].ToString()),
                            UniqueIdentificationNumber = (rdr["Unique_Identifcation_Number"].ToString()),
                            CrmsReferenceNumber = (rdr["Crms_Reference_Number"].ToString()),
                            EffectiveDate = DateTime.Parse((rdr["Effective_Date"].ToString())),
                            Tenor = Convert.ToInt32((rdr["Tenor"].ToString())),
                            ExpiryDate = DateTime.Parse((rdr["Expiry_Date"].ToString())),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms400As.Add(crms400A);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms400As;
        }

        public List<Crms400B> GetCrms400Bs()
        {
            List<Crms400B> crms400Bs = new List<Crms400B>();
            string sqlSelect = "select * from crms_400B where Inputter_ID = '" + _myId + "'";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms400B = new Crms400B()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            UniqueIdentificationType = (rdr["Unique_Identifcation_Type"].ToString()),
                            UniqueIdentificationNumber = (rdr["Unique_Identifcation_Number"].ToString()),
                            CrmsReferenceNumber = (rdr["CRMS_Reference_Number"].ToString()),
                            CreditType = (rdr["Credit_Type"].ToString()),
                            CreditLimit = Convert.ToDecimal((rdr["Credit_Limit"].ToString())),
                            OutstandingAmount = Convert.ToDecimal((rdr["Outstanding_Amount"].ToString())),
                            FeeType1 = (rdr["Fee_Type1"].ToString()),
                            FeeAmount1 = Convert.ToDecimal((rdr["Fee_Amount1"].ToString())),
                            FeeType2 = (rdr["Fee_Type2"].ToString()),
                            FeeAmount2 = Convert.ToDecimal((rdr["Fee_Amount2"].ToString())),
                            FeeType3 = (rdr["Fee_Type3"].ToString()),
                            FeeAmount3 = Convert.ToDecimal((rdr["Fee_Amount3"].ToString())),
                            FeeType4 = (rdr["Fee_Type4"].ToString()),
                            FeeAmount4 = Convert.ToDecimal((rdr["Fee_Amount4"].ToString())),
                            FeeType5 = (rdr["Fee_Type5"].ToString()),
                            FeeAmount5 = Convert.ToDecimal((rdr["Fee_Amount5"].ToString())),
                            FeeType6 = (rdr["Fee_Type6"].ToString()),
                            FeeAmount6 = Convert.ToDecimal((rdr["Fee_Amount6"].ToString())),
                            FeeType7 = (rdr["Fee_Type7"].ToString()),
                            FeeAmount7 = Convert.ToDecimal((rdr["Fee_Amount7"].ToString())),
                            FeeType8 = (rdr["Fee_Type8"].ToString()),
                            FeeAmount8 = Convert.ToDecimal((rdr["Fee_Amount8"].ToString())),
                            FeeType9 = (rdr["Fee_Type9"].ToString()),
                            FeeAmount9 = Convert.ToDecimal((rdr["Fee_Amount9"].ToString())),
                            FeeType10 = (rdr["Fee_Type10"].ToString()),
                            FeeAmount10 = Convert.ToDecimal((rdr["Fee_Amount10"].ToString())),
                            FeeType11 = (rdr["Fee_Type11"].ToString()),
                            FeeAmount11 = Convert.ToDecimal((rdr["Fee_Amount11"].ToString())),
                            FeeType12 = (rdr["Fee_Type12"].ToString()),
                            FeeAmount12 = Convert.ToDecimal((rdr["Fee_Amount12"].ToString())),
                            FeeType13 = (rdr["Fee_Type13"].ToString()),
                            FeeAmount13 = Convert.ToDecimal((rdr["Fee_Amount13"].ToString())),
                            FeeType14 = (rdr["Fee_Type14"].ToString()),
                            FeeAmount14 = Convert.ToDecimal((rdr["Fee_Amount14"].ToString())),
                            FeeType15 = (rdr["Fee_Type15"].ToString()),
                            FeeAmount15 = Convert.ToDecimal((rdr["Fee_Amount15"].ToString())),
                            FeeType16 = (rdr["Fee_Type16"].ToString()),
                            FeeAmount16 = Convert.ToDecimal((rdr["Fee_Amount16"].ToString())),
                            EffectiveDate = DateTime.Parse((rdr["Effective_Date"].ToString())),
                            Tenor = Convert.ToInt32((rdr["Tenor"].ToString())),
                            ExpiryDate = DateTime.Parse((rdr["Expiry_Date"].ToString())),
                            RepaymentAgreementMode = (rdr["Repayment_Agreement_Mode"].ToString()),
                            PerformanceRepaymentStatus = (rdr["Performance_Repayment_Status"].ToString()),
                            ReasonForRestructuring = (rdr["Reason_For_Restructuring"].ToString()),
                            InterestRate = Convert.ToDecimal((rdr["Interest_Rate"].ToString())),
                            BeneficiaryAccountNumber = (rdr["Beneficiary_Account_Number"].ToString()),
                            LocationOfBeneficiary = (rdr["Location_of_Beneficiary"].ToString()),
                            RelationshipType = (rdr["Relationship_Type"].ToString()),
                            FundingSourceCategory = (rdr["Funding_Source_Category"].ToString()),
                            EcciNumber = (rdr["Ecci_Number"].ToString()),
                            FundingSource = (rdr["Funding_Source"].ToString()),
                            SpecialisedLoan = (rdr["Specialised_Loan"].ToString()),
                            SpecialisedLoanPeriod = Convert.ToInt32((rdr["Specialised_Loan_Period"].ToString())),
                            DirectorIdType1 = (rdr["Director_Id_Type1"].ToString()),
                            DirectorIdNumber1 = (rdr["Director_Id_Number1"].ToString()),
                            DirectorIdEmail1 = (rdr["Director_Id_Email1"].ToString()),
                            DirectorIdType2 = (rdr["Director_Id_Type2"].ToString()),
                            DirectorIdNumber2 = (rdr["Director_Id_Number2"].ToString()),
                            DirectorIdEmail2 = (rdr["Director_Id_Email2"].ToString()),
                            DirectorIdType3 = (rdr["Director_Id_Type3"].ToString()),
                            DirectorIdNumber3 = (rdr["Director_Id_Number3"].ToString()),
                            DirectorIdEmail3 = (rdr["Director_Id_Email3"].ToString()),
                            DirectorIdType4 = (rdr["Director_Id_Type4"].ToString()),
                            DirectorIdNumber4 = (rdr["Director_Id_Number4"].ToString()),
                            DirectorIdEmail4 = (rdr["Director_Id_Email4"].ToString()),
                            DirectorIdType5 = (rdr["Director_Id_Type5"].ToString()),
                            DirectorIdNumber5 = (rdr["Director_Id_Number5"].ToString()),
                            DirectorIdEmail5 = (rdr["Director_Id_Email5"].ToString()),
                            CollateralPresent1 = (rdr["Collateral_Present1"].ToString()),
                            CollateralSecure1 = (rdr["Collateral_Secure1"].ToString()),
                            SecurityType1 = (rdr["Security_Type1"].ToString()),
                            AddressOfSecurity1 = (rdr["Address_Of_Security1"].ToString()),
                            OwnerOfSecurity1 = (rdr["Owner_Of_Security1"].ToString()),
                            SecurityIdType1 = (rdr["Security_Id_Type1"].ToString()),
                            SecurityIdNumber1 = (rdr["Security_Id_Number1"].ToString()),
                            CollateralSecure2 = (rdr["Collateral_Secure2"].ToString()),
                            SecurityType2 = (rdr["Security_Type2"].ToString()),
                            AddressOfSecurity2 = (rdr["Address_Of_Security2"].ToString()),
                            OwnerOfSecurity2 = (rdr["Owner_Of_Security2"].ToString()),
                            SecurityIdType2 = (rdr["Security_Id_Type2"].ToString()),
                            SecurityIdNumber2 = (rdr["Security_Id_Number2"].ToString()),
                            CollateralSecure3 = (rdr["Collateral_Secure3"].ToString()),
                            SecurityType3 = (rdr["Security_Type3"].ToString()),
                            AddressOfSecurity3 = (rdr["Address_Of_Security3"].ToString()),
                            OwnerOfSecurity3 = (rdr["Owner_Of_Security3"].ToString()),
                            SecurityIdType3 = (rdr["Security_Id_Type3"].ToString()),
                            SecurityIdNumber3 = (rdr["Security_Id_Number3"].ToString()),
                            CollateralSecure4 = (rdr["Collateral_Secure4"].ToString()),
                            SecurityType4 = (rdr["Security_Type4"].ToString()),
                            AddressOfSecurity4 = (rdr["Address_Of_Security4"].ToString()),
                            OwnerOfSecurity4 = (rdr["Owner_Of_Security4"].ToString()),
                            SecurityIdType4 = (rdr["Security_Id_Type4"].ToString()),
                            SecurityIdNumber4 = (rdr["Security_Id_Number4"].ToString()),
                            CollateralSecure5 = (rdr["Collateral_Secure5"].ToString()),
                            SecurityType5 = (rdr["Security_Type5"].ToString()),
                            AddressOfSecurity5 = (rdr["Address_Of_Security5"].ToString()),
                            OwnerOfSecurity5 = (rdr["Owner_Of_Security5"].ToString()),
                            SecurityIdType5 = (rdr["Security_Id_Type5"].ToString()),
                            SecurityIdNumber5 = (rdr["Security_Id_Number5"].ToString()),
                            CollateralSecure6 = (rdr["Collateral_Secure6"].ToString()),
                            SecurityType6 = (rdr["Security_Type6"].ToString()),
                            AddressOfSecurity6 = (rdr["Address_Of_Security6"].ToString()),
                            OwnerOfSecurity6 = (rdr["Owner_Of_Security6"].ToString()),
                            SecurityIdType6 = (rdr["Security_Id_Type6"].ToString()),
                            SecurityIdNumber6 = (rdr["Security_Id_Number6"].ToString()),
                            CollateralSecure7 = (rdr["Collateral_Secure7"].ToString()),
                            SecurityType7 = (rdr["Security_Type7"].ToString()),
                            AddressOfSecurity7 = (rdr["Address_Of_Security7"].ToString()),
                            OwnerOfSecurity7 = (rdr["Owner_Of_Security7"].ToString()),
                            SecurityIdType7 = (rdr["Security_Id_Type7"].ToString()),
                            SecurityIdNumber7 = (rdr["Security_Id_Number7"].ToString()),
                            CollateralSecure8 = (rdr["Collateral_Secure8"].ToString()),
                            SecurityType8 = (rdr["Security_Type8"].ToString()),
                            AddressOfSecurity8 = (rdr["Address_Of_Security8"].ToString()),
                            OwnerOfSecurity8 = (rdr["Owner_Of_Security8"].ToString()),
                            SecurityIdType8 = (rdr["Security_Id_Type8"].ToString()),
                            SecurityIdNumber8 = (rdr["Security_Id_Number8"].ToString()),
                            CollateralSecure9 = (rdr["Collateral_Secure9"].ToString()),
                            SecurityType9 = (rdr["Security_Type9"].ToString()),
                            AddressOfSecurity9 = (rdr["Address_Of_Security9"].ToString()),
                            OwnerOfSecurity9 = (rdr["Owner_Of_Security9"].ToString()),
                            SecurityIdType9 = (rdr["Security_Id_Type9"].ToString()),
                            SecurityIdNumber9 = (rdr["Security_Id_Number9"].ToString()),
                            CollateralSecure10 = (rdr["Collateral_Secure10"].ToString()),
                            SecurityType10 = (rdr["Security_Type10"].ToString()),
                            AddressOfSecurity10 = (rdr["Address_Of_Security10"].ToString()),
                            OwnerOfSecurity10 = (rdr["Owner_Of_Security10"].ToString()),
                            SecurityIdType10 = (rdr["Security_Id_Type10"].ToString()),
                            SecurityIdNumber10 = (rdr["Security_Id_Number10"].ToString()),
                            Guarantee1 = (rdr["Guarantee1"].ToString()),
                            GuaranteeType1 = (rdr["Guarantee_Type1"].ToString()),
                            GuaranteeIdType1 = (rdr["Guarantor_Id_Type1"].ToString()),
                            GuaranteeIdNumber1 = (rdr["Guarantor_Id_Number1"].ToString()),
                            AmountGuranteed1 = Convert.ToDecimal((rdr["Amount_Guaranteed1"].ToString())),
                            GuaranteeType2 = (rdr["Guarantee_Type2"].ToString()),
                            GuaranteeIdType2 = (rdr["Guarantor_Id_Type2"].ToString()),
                            GuaranteeIdNumber2 = (rdr["Guarantor_Id_Number2"].ToString()),
                            AmountGuranteed2 = Convert.ToDecimal((rdr["Amount_Guaranteed2"].ToString())),
                            GuaranteeType3 = (rdr["Guarantee_Type3"].ToString()),
                            GuaranteeIdType3 = (rdr["Guarantor_Id_Type3"].ToString()),
                            GuaranteeIdNumber3 = (rdr["Guarantor_Id_Number3"].ToString()),
                            AmountGuranteed3 = Convert.ToDecimal((rdr["Amount_Guaranteed3"].ToString())),
                            GuaranteeType4 = (rdr["Guarantee_Type4"].ToString()),
                            GuaranteeIdType4 = (rdr["Guarantor_Id_Type4"].ToString()),
                            GuaranteeIdNumber4 = (rdr["Guarantor_Id_Number4"].ToString()),
                            AmountGuranteed4 = Convert.ToDecimal((rdr["Amount_Guaranteed4"].ToString())),
                            GuaranteeType5 = (rdr["Guarantee_Type5"].ToString()),
                            GuaranteeIdType5 = (rdr["Guarantor_Id_Type5"].ToString()),
                            GuaranteeIdNumber5 = (rdr["Guarantor_Id_Number5"].ToString()),
                            AmountGuranteed5 = Convert.ToDecimal((rdr["Amount_Guaranteed5"].ToString())),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms400Bs.Add(crms400B);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms400Bs;
        }

        public List<Crms600> GetCrms600S()
        {
            List<Crms600> crms600S = new List<Crms600>();
            string sqlSelect = "select * from crms_600 where Inputter_ID = '" + _myId + "'";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms600 = new Crms600()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            SyndicationReferenceNumber = (rdr["Syndication_Reference_Number"].ToString()),
                            SyndicationName = (rdr["Syndication_Name"].ToString()),
                            SyndicationTotalAmount = Convert.ToDecimal((rdr["Syndication_Total_Amount"].ToString())),
                            ParticipatingBankCode = (rdr["Participating_Bank_COde"].ToString()),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms600S.Add(crms600);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms600S;
        }

        public List<Crms700> GetCrms700S()
        {
            List<Crms700> crms700S = new List<Crms700>();
            string sqlSelect = "select * from crms_700 where Inputter_ID = '" + _myId + "'";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crms700 = new Crms700()
                        {
                            Id = (rdr["ID"].ToString()),
                            Code = (rdr["Code"].ToString()),
                            CustomerId = (rdr["Customer_ID"].ToString()),
                            CustomerAccountNumber = (rdr["Customer_Account_Number"].ToString()),
                            CustomerName = (rdr["Customer_Name"].ToString()),
                            UniqueIdentificationType = (rdr["Unique_Identifcation_Type"].ToString()),
                            UniqueIdentificationNumber = (rdr["Unique_Identifcation_Number"].ToString()),
                            CrmsReferenceNumber = (rdr["CRMS_Reference_Number"].ToString()),
                            CreditPurposeByBusinessLines = (rdr["Credit_Purpose_By_Business_Lines"].ToString()),
                            CreditPurposeByBusinessLinesSubsector =
                                (rdr["Credit_Purpose_By_Business_Lines_Subsector"].ToString()),
                            FeeType1 = (rdr["Fee_Type1"].ToString()),
                            FeeAmount1 = Convert.ToDecimal((rdr["Fee_Amount1"].ToString())),
                            FeeType2 = (rdr["Fee_Type2"].ToString()),
                            FeeAmount2 = Convert.ToDecimal((rdr["Fee_Amount2"].ToString())),
                            FeeType3 = (rdr["Fee_Type3"].ToString()),
                            FeeAmount3 = Convert.ToDecimal((rdr["Fee_Amount3"].ToString())),
                            FeeType4 = (rdr["Fee_Type4"].ToString()),
                            FeeAmount4 = Convert.ToDecimal((rdr["Fee_Amount4"].ToString())),
                            FeeType5 = (rdr["Fee_Type5"].ToString()),
                            FeeAmount5 = Convert.ToDecimal((rdr["Fee_Amount5"].ToString())),
                            FeeType6 = (rdr["Fee_Type6"].ToString()),
                            FeeAmount6 = Convert.ToDecimal((rdr["Fee_Amount6"].ToString())),
                            FeeType7 = (rdr["Fee_Type7"].ToString()),
                            FeeAmount7 = Convert.ToDecimal((rdr["Fee_Amount7"].ToString())),
                            FeeType8 = (rdr["Fee_Type8"].ToString()),
                            FeeAmount8 = Convert.ToDecimal((rdr["Fee_Amount8"].ToString())),
                            FeeType9 = (rdr["Fee_Type9"].ToString()),
                            FeeAmount9 = Convert.ToDecimal((rdr["Fee_Amount9"].ToString())),
                            FeeType10 = (rdr["Fee_Type10"].ToString()),
                            FeeAmount10 = Convert.ToDecimal((rdr["Fee_Amount10"].ToString())),
                            FeeType11 = (rdr["Fee_Type11"].ToString()),
                            FeeAmount11 = Convert.ToDecimal((rdr["Fee_Amount11"].ToString())),
                            FeeType12 = (rdr["Fee_Type12"].ToString()),
                            FeeAmount12 = Convert.ToDecimal((rdr["Fee_Amount12"].ToString())),
                            FeeType13 = (rdr["Fee_Type13"].ToString()),
                            FeeAmount13 = Convert.ToDecimal((rdr["Fee_Amount13"].ToString())),
                            FeeType14 = (rdr["Fee_Type14"].ToString()),
                            FeeAmount14 = Convert.ToDecimal((rdr["Fee_Amount14"].ToString())),
                            FeeType15 = (rdr["Fee_Type15"].ToString()),
                            FeeAmount15 = Convert.ToDecimal((rdr["Fee_Amount15"].ToString())),
                            FeeType16 = (rdr["Fee_Type16"].ToString()),
                            FeeAmount16 = Convert.ToDecimal((rdr["Fee_Amount16"].ToString())),
                            Tenor = Convert.ToInt32((rdr["Tenor"].ToString())),
                            BeneficiaryAccountNumber = (rdr["Beneficiary_Account_Number"].ToString()),
                            LocationOfBeneficiary = (rdr["Location_of_Beneficiary"].ToString()),
                            RelationshipType = (rdr["Relationship_Type"].ToString()),
                            FundingSourceCategory = (rdr["Funding_Source_Category"].ToString()),
                            EcciNumber = (rdr["Ecci_Number"].ToString()),
                            FundingSource = (rdr["Funding_Source"].ToString()),
                            LegalStatus = (rdr["Legal_Status"].ToString()),
                            ClassificationByBusinessLines = (rdr["Classification_By_Business_Lines"].ToString()),
                            ClassificationByBusinessLinesSubsector = (rdr["Classification_By_Business_Lines_Subsector"].ToString()),
                            SpecialisedLoan = (rdr["Specialised_Loan"].ToString()),
                            SpecialisedLoanPeriod = Convert.ToInt32((rdr["Specialised_Loan_Period"].ToString())),
                            DirectorIdType1 = (rdr["Director_Id_Type1"].ToString()),
                            DirectorIdNumber1 = (rdr["Director_Id_Number1"].ToString()),
                            DirectorIdEmail1 = (rdr["Director_Id_Email1"].ToString()),
                            DirectorIdType2 = (rdr["Director_Id_Type2"].ToString()),
                            DirectorIdNumber2 = (rdr["Director_Id_Number2"].ToString()),
                            DirectorIdEmail2 = (rdr["Director_Id_Email2"].ToString()),
                            DirectorIdType3 = (rdr["Director_Id_Type3"].ToString()),
                            DirectorIdNumber3 = (rdr["Director_Id_Number3"].ToString()),
                            DirectorIdEmail3 = (rdr["Director_Id_Email3"].ToString()),
                            DirectorIdType4 = (rdr["Director_Id_Type4"].ToString()),
                            DirectorIdNumber4 = (rdr["Director_Id_Number4"].ToString()),
                            DirectorIdEmail4 = (rdr["Director_Id_Email4"].ToString()),
                            DirectorIdType5 = (rdr["Director_Id_Type5"].ToString()),
                            DirectorIdNumber5 = (rdr["Director_Id_Number5"].ToString()),
                            DirectorIdEmail5 = (rdr["Director_Id_Email5"].ToString()),
                            Syndication = (rdr["Syndication"].ToString()),
                            SyndicationStatus = (rdr["Syndication_Status"].ToString()),
                            SyndicationName = (rdr["Syndication_Name"].ToString()),
                            SyndicationTotalAmount = Convert.ToDecimal((rdr["Syndication_Total_Amount"].ToString())),
                            SyndicationReferenceNumber = (rdr["Syndication_Reference_Number"].ToString()),
                            CollateralPresent1 = (rdr["Collateral_Present1"].ToString()),
                            CollateralSecure1 = (rdr["Collateral_Secure1"].ToString()),
                            SecurityType1 = (rdr["Security_Type1"].ToString()),
                            AddressOfSecurity1 = (rdr["Address_Of_Security1"].ToString()),
                            OwnerOfSecurity1 = (rdr["Owner_Of_Security1"].ToString()),
                            SecurityIdType1 = (rdr["Security_Id_Type1"].ToString()),
                            SecurityIdNumber1 = (rdr["Security_Id_Number1"].ToString()),
                            CollateralSecure2 = (rdr["Collateral_Secure2"].ToString()),
                            SecurityType2 = (rdr["Security_Type2"].ToString()),
                            AddressOfSecurity2 = (rdr["Address_Of_Security2"].ToString()),
                            OwnerOfSecurity2 = (rdr["Owner_Of_Security2"].ToString()),
                            SecurityIdType2 = (rdr["Security_Id_Type2"].ToString()),
                            SecurityIdNumber2 = (rdr["Security_Id_Number2"].ToString()),
                            CollateralSecure3 = (rdr["Collateral_Secure3"].ToString()),
                            SecurityType3 = (rdr["Security_Type3"].ToString()),
                            AddressOfSecurity3 = (rdr["Address_Of_Security3"].ToString()),
                            OwnerOfSecurity3 = (rdr["Owner_Of_Security3"].ToString()),
                            SecurityIdType3 = (rdr["Security_Id_Type3"].ToString()),
                            SecurityIdNumber3 = (rdr["Security_Id_Number3"].ToString()),
                            CollateralSecure4 = (rdr["Collateral_Secure4"].ToString()),
                            SecurityType4 = (rdr["Security_Type4"].ToString()),
                            AddressOfSecurity4 = (rdr["Address_Of_Security4"].ToString()),
                            OwnerOfSecurity4 = (rdr["Owner_Of_Security4"].ToString()),
                            SecurityIdType4 = (rdr["Security_Id_Type4"].ToString()),
                            SecurityIdNumber4 = (rdr["Security_Id_Number4"].ToString()),
                            CollateralSecure5 = (rdr["Collateral_Secure5"].ToString()),
                            SecurityType5 = (rdr["Security_Type5"].ToString()),
                            AddressOfSecurity5 = (rdr["Address_Of_Security5"].ToString()),
                            OwnerOfSecurity5 = (rdr["Owner_Of_Security5"].ToString()),
                            SecurityIdType5 = (rdr["Security_Id_Type5"].ToString()),
                            SecurityIdNumber5 = (rdr["Security_Id_Number5"].ToString()),
                            CollateralSecure6 = (rdr["Collateral_Secure6"].ToString()),
                            SecurityType6 = (rdr["Security_Type6"].ToString()),
                            AddressOfSecurity6 = (rdr["Address_Of_Security6"].ToString()),
                            OwnerOfSecurity6 = (rdr["Owner_Of_Security6"].ToString()),
                            SecurityIdType6 = (rdr["Security_Id_Type6"].ToString()),
                            SecurityIdNumber6 = (rdr["Security_Id_Number6"].ToString()),
                            CollateralSecure7 = (rdr["Collateral_Secure7"].ToString()),
                            SecurityType7 = (rdr["Security_Type7"].ToString()),
                            AddressOfSecurity7 = (rdr["Address_Of_Security7"].ToString()),
                            OwnerOfSecurity7 = (rdr["Owner_Of_Security7"].ToString()),
                            SecurityIdType7 = (rdr["Security_Id_Type7"].ToString()),
                            SecurityIdNumber7 = (rdr["Security_Id_Number7"].ToString()),
                            CollateralSecure8 = (rdr["Collateral_Secure8"].ToString()),
                            SecurityType8 = (rdr["Security_Type8"].ToString()),
                            AddressOfSecurity8 = (rdr["Address_Of_Security8"].ToString()),
                            OwnerOfSecurity8 = (rdr["Owner_Of_Security8"].ToString()),
                            SecurityIdType8 = (rdr["Security_Id_Type8"].ToString()),
                            SecurityIdNumber8 = (rdr["Security_Id_Number8"].ToString()),
                            CollateralSecure9 = (rdr["Collateral_Secure9"].ToString()),
                            SecurityType9 = (rdr["Security_Type9"].ToString()),
                            AddressOfSecurity9 = (rdr["Address_Of_Security9"].ToString()),
                            OwnerOfSecurity9 = (rdr["Owner_Of_Security9"].ToString()),
                            SecurityIdType9 = (rdr["Security_Id_Type9"].ToString()),
                            SecurityIdNumber9 = (rdr["Security_Id_Number9"].ToString()),
                            CollateralSecure10 = (rdr["Collateral_Secure10"].ToString()),
                            SecurityType10 = (rdr["Security_Type10"].ToString()),
                            AddressOfSecurity10 = (rdr["Address_Of_Security10"].ToString()),
                            OwnerOfSecurity10 = (rdr["Owner_Of_Security10"].ToString()),
                            SecurityIdType10 = (rdr["Security_Id_Type10"].ToString()),
                            SecurityIdNumber10 = (rdr["Security_Id_Number10"].ToString()),
                            Guarantee1 = (rdr["Guarantee1"].ToString()),
                            GuaranteeType1 = (rdr["Guarantee_Type1"].ToString()),
                            GuaranteeIdType1 = (rdr["Guarantor_Id_Type1"].ToString()),
                            GuaranteeIdNumber1 = (rdr["Guarantor_Id_Number1"].ToString()),
                            AmountGuranteed1 = Convert.ToDecimal((rdr["Amount_Guaranteed1"].ToString())),
                            GuaranteeType2 = (rdr["Guarantee_Type2"].ToString()),
                            GuaranteeIdType2 = (rdr["Guarantor_Id_Type2"].ToString()),
                            GuaranteeIdNumber2 = (rdr["Guarantor_Id_Number2"].ToString()),
                            AmountGuranteed2 = Convert.ToDecimal((rdr["Amount_Guaranteed2"].ToString())),
                            GuaranteeType3 = (rdr["Guarantee_Type3"].ToString()),
                            GuaranteeIdType3 = (rdr["Guarantor_Id_Type3"].ToString()),
                            GuaranteeIdNumber3 = (rdr["Guarantor_Id_Number3"].ToString()),
                            AmountGuranteed3 = Convert.ToDecimal((rdr["Amount_Guaranteed3"].ToString())),
                            GuaranteeType4 = (rdr["Guarantee_Type4"].ToString()),
                            GuaranteeIdType4 = (rdr["Guarantor_Id_Type4"].ToString()),
                            GuaranteeIdNumber4 = (rdr["Guarantor_Id_Number4"].ToString()),
                            AmountGuranteed4 = Convert.ToDecimal((rdr["Amount_Guaranteed4"].ToString())),
                            GuaranteeType5 = (rdr["Guarantee_Type5"].ToString()),
                            GuaranteeIdType5 = (rdr["Guarantor_Id_Type5"].ToString()),
                            GuaranteeIdNumber5 = (rdr["Guarantor_Id_Number5"].ToString()),
                            AmountGuranteed5 = Convert.ToDecimal((rdr["Amount_Guaranteed5"].ToString())),
                            InputterId = (rdr["Inputter_ID"].ToString()),
                            InputterDateStamp = DateTime.Parse((rdr["Inputter_Date_Stamp"].ToString())),
                            ModifierId = (rdr["Modifier_ID"].ToString()),
                            ModifierDateStamp = ((rdr["Modifier_Date_Stamp"].ToString())),
                            CrmsRefNumber = (rdr["CRMS_Ref_Number"].ToString()),
                            LoanRefNumber = (rdr["Loan_Ref_Number"].ToString()),
                        };

                        crms700S.Add(crms700);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {

                    con.Close();
                }
            }

            return crms700S;
        }

    }
}