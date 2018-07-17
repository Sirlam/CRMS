using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace CRMS.Utils
{
    public class SaveData
    {
        private readonly string _databaseCS;

        public SaveData()
        {
            _databaseCS = ConfigurationManager.ConnectionStrings["DatabaseCS"].ConnectionString;
        }

        public void SendMail(string[] addresses, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();

                //Setting From , To and CC
                mail.Subject = subject;
                mail.From = new MailAddress("boservice@ecobank.com", "BoService");
                foreach (var address in addresses)
                {
                    mail.To.Add(new MailAddress(address));
                }
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.CC.Add(new MailAddress("aoyedere@ecobank.com"));
                //mail.CC.Add(new MailAddress("cokafor@ecobank.com"));
                var smtp = new SmtpClient();

                smtp.Host = "10.12.14.29";
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                var networkCred = new NetworkCredential("boservice", "2Hard4U123$", "ecobankgroup");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCred;
                smtp.Port = 25;

                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                (s, cert, chain, sslPolicyErrors) => true;
                smtp.Send(mail);
            }
            catch (SmtpException ste)
            {

                Console.WriteLine(ste.ToString());
            }

        }
        public Boolean SaveCrms100(String code, String customerId, String accountNumber, String customerName, String governmentCode, String legalCode,
            String creditType, String businessLinesCode, String businessLinesSubsectorCode, decimal creditLimit, decimal outstandingAmount,
            String feeTypeCode1, decimal feeAmount1, String feeTypeCode2, decimal feeAmount2, String feeTypeCode3, decimal feeAmount3, String feeTypeCode4, decimal feeAmount4,
            String feeTypeCode5, decimal feeAmount5, String feeTypeCode6, decimal feeAmount6, String feeTypeCode7, decimal feeAmount7, String feeTypeCode8, decimal feeAmount8,
            String feeTypeCode9, decimal feeAmount9, String feeTypeCode10, decimal feeAmount10, String feeTypeCode11, decimal feeAmount11, String feeTypeCode12, decimal feeAmount12,
            String feeTypeCode13, decimal feeAmount13, String feeTypeCode14, decimal feeAmount14, String feeTypeCode15, decimal feeAmount15, String feeTypeCode16, decimal feeAmount16,
            DateTime effectiveDate, int tenor, DateTime expiryDate, String repaymentAgreementCode, String specialisedLoan, int specialisedLoanPeriod,
            decimal interestRate, String collateralPresent1, string collateralSecure1, String securityCode1, string collateralSecure2, String securityCode2,
            string collateralSecure3, String securityCode3, string collateralSecure4, String securityCode4, string collateralSecure5, String securityCode5, string collateralSecure6, String securityCode6,
            string collateralSecure7, String securityCode7, string collateralSecure8, String securityCode8, string collateralSecure9, String securityCode9, string collateralSecure10, String securityCode10,
            String repaymentSource, String syndication, String syndicationStatus, String syndicationReferenceNumber,
            String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_100 (Code, Customer_ID, Customer_Account_Number, Customer_Name, government_code, legal_status, " +
                        "credit_type, Credit_Purpose_By_Business_Lines, Credit_Purpose_By_Business_Lines_Subsector, credit_limit, outstanding_amount, " +
                        "fee_type1, fee_amount1, fee_type2, fee_amount2, fee_type3, fee_amount3, fee_type4, fee_amount4, fee_type5, fee_amount5, " +
                        "fee_type6, fee_amount6, fee_type7, fee_amount7, fee_type8, fee_amount8, fee_type9, fee_amount9, fee_type10, fee_amount10, " +
                        "fee_type11, fee_amount11, fee_type12, fee_amount12, fee_type13, fee_amount13, fee_type14, fee_amount14, fee_type15, fee_amount15, " +
                        "fee_type16, fee_amount16, effective_date, tenor, expiry_date, repayment_agreement_mode, specialised_loan, Specialised_Loan_Period, " +
                        "interest_rate, collateral_present1, collateral_secure1, security_type1, " +
                        "collateral_secure2, security_type2, collateral_secure3, security_type3, " +
                        "collateral_secure4, security_type4, collateral_secure5, security_type5, " +
                        "collateral_secure6, security_type6, collateral_secure7, security_type7, " +
                        "collateral_secure8, security_type8, collateral_secure9, security_type9, " +
                        "collateral_secure10, security_type10, repayment_source, syndication, syndication_status, " +
                        "syndication_reference_number, inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @government_code, @legal_status, " +
                        "@credit_type, @credit_purpose_by_businesslines, @credit_purpose_by_businesslines_subsector, @credit_limit, @outstanding_amount, " +
                        "@fee_type1, @fee_amount1, @fee_type2, @fee_amount2, @fee_type3, @fee_amount3, @fee_type4, @fee_amount4, @fee_type5, @fee_amount5, " +
                        "@fee_type6, @fee_amount6, @fee_type7, @fee_amount7, @fee_type8, @fee_amount8, @fee_type9, @fee_amount9, @fee_type10, @fee_amount10," +
                        "@fee_type11, @fee_amount11, @fee_type12, @fee_amount12, @fee_type13, @fee_amount13, @fee_type14, @fee_amount14, @fee_type15, @fee_amount15," +
                        "@fee_type16, @fee_amount16, @effective_date, @tenor, @expiry_date, @repayment_agreement_mode, @specialised_loan, @specialised_loan_period, " +
                        "@interest_rate, @collateral_present1, @collateral_secure1, @security_type1, " +
                        "@collateral_secure2, @security_type2, @collateral_secure3, @security_type3, " +
                        "@collateral_secure4, @security_type4, @collateral_secure5, @security_type5, " +
                        "@collateral_secure6, @security_type6, @collateral_secure7, @security_type7, " +
                        "@collateral_secure8, @security_type8, @collateral_secure9, @security_type9, " +
                        "@collateral_secure10, @security_type10, @repayment_source, @syndication, @syndication_status, " +
                        "@syndication_reference_number, @inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@government_code", SqlDbType.NVarChar).Value = governmentCode;
                    cmd.Parameters.AddWithValue("@legal_status", SqlDbType.NVarChar).Value = legalCode;
                    cmd.Parameters.AddWithValue("@credit_type", SqlDbType.NVarChar).Value = creditType;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines", SqlDbType.NVarChar).Value =
                        businessLinesCode;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines_subsector", SqlDbType.NVarChar).Value =
                        businessLinesSubsectorCode;
                    cmd.Parameters.AddWithValue("@credit_limit", SqlDbType.Decimal).Value = creditLimit;
                    cmd.Parameters.AddWithValue("@outstanding_amount", SqlDbType.Decimal).Value = outstandingAmount;
                    cmd.Parameters.AddWithValue("@fee_type1", SqlDbType.NVarChar).Value = feeTypeCode1;
                    cmd.Parameters.AddWithValue("@fee_amount1", SqlDbType.Decimal).Value = feeAmount1;
                    cmd.Parameters.AddWithValue("@fee_type2", SqlDbType.NVarChar).Value = feeTypeCode2;
                    cmd.Parameters.AddWithValue("@fee_amount2", SqlDbType.Decimal).Value = feeAmount2;
                    cmd.Parameters.AddWithValue("@fee_type3", SqlDbType.NVarChar).Value = feeTypeCode3;
                    cmd.Parameters.AddWithValue("@fee_amount3", SqlDbType.Decimal).Value = feeAmount3;
                    cmd.Parameters.AddWithValue("@fee_type4", SqlDbType.NVarChar).Value = feeTypeCode4;
                    cmd.Parameters.AddWithValue("@fee_amount4", SqlDbType.Decimal).Value = feeAmount4;
                    cmd.Parameters.AddWithValue("@fee_type5", SqlDbType.NVarChar).Value = feeTypeCode5;
                    cmd.Parameters.AddWithValue("@fee_amount5", SqlDbType.Decimal).Value = feeAmount5;
                    cmd.Parameters.AddWithValue("@fee_type6", SqlDbType.NVarChar).Value = feeTypeCode6;
                    cmd.Parameters.AddWithValue("@fee_amount6", SqlDbType.Decimal).Value = feeAmount6;
                    cmd.Parameters.AddWithValue("@fee_type7", SqlDbType.NVarChar).Value = feeTypeCode7;
                    cmd.Parameters.AddWithValue("@fee_amount7", SqlDbType.Decimal).Value = feeAmount7;
                    cmd.Parameters.AddWithValue("@fee_type8", SqlDbType.NVarChar).Value = feeTypeCode8;
                    cmd.Parameters.AddWithValue("@fee_amount8", SqlDbType.Decimal).Value = feeAmount8;
                    cmd.Parameters.AddWithValue("@fee_type9", SqlDbType.NVarChar).Value = feeTypeCode9;
                    cmd.Parameters.AddWithValue("@fee_amount9", SqlDbType.Decimal).Value = feeAmount9;
                    cmd.Parameters.AddWithValue("@fee_type10", SqlDbType.NVarChar).Value = feeTypeCode10;
                    cmd.Parameters.AddWithValue("@fee_amount10", SqlDbType.Decimal).Value = feeAmount10;
                    cmd.Parameters.AddWithValue("@fee_type11", SqlDbType.NVarChar).Value = feeTypeCode11;
                    cmd.Parameters.AddWithValue("@fee_amount11", SqlDbType.Decimal).Value = feeAmount11;
                    cmd.Parameters.AddWithValue("@fee_type12", SqlDbType.NVarChar).Value = feeTypeCode12;
                    cmd.Parameters.AddWithValue("@fee_amount12", SqlDbType.Decimal).Value = feeAmount12;
                    cmd.Parameters.AddWithValue("@fee_type13", SqlDbType.NVarChar).Value = feeTypeCode13;
                    cmd.Parameters.AddWithValue("@fee_amount13", SqlDbType.Decimal).Value = feeAmount13;
                    cmd.Parameters.AddWithValue("@fee_type14", SqlDbType.NVarChar).Value = feeTypeCode14;
                    cmd.Parameters.AddWithValue("@fee_amount14", SqlDbType.Decimal).Value = feeAmount14;
                    cmd.Parameters.AddWithValue("@fee_type15", SqlDbType.NVarChar).Value = feeTypeCode15;
                    cmd.Parameters.AddWithValue("@fee_amount15", SqlDbType.Decimal).Value = feeAmount15;
                    cmd.Parameters.AddWithValue("@fee_type16", SqlDbType.NVarChar).Value = feeTypeCode16;
                    cmd.Parameters.AddWithValue("@fee_amount16", SqlDbType.Decimal).Value = feeAmount16;
                    cmd.Parameters.AddWithValue("@effective_date", SqlDbType.Date).Value = effectiveDate;
                    cmd.Parameters.AddWithValue("@tenor", SqlDbType.Int).Value = tenor;
                    cmd.Parameters.AddWithValue("@expiry_date", SqlDbType.Date).Value = expiryDate;
                    cmd.Parameters.AddWithValue("@repayment_agreement_mode", SqlDbType.NVarChar).Value =
                        repaymentAgreementCode;
                    cmd.Parameters.AddWithValue("@specialised_loan", SqlDbType.NVarChar).Value = specialisedLoan;
                    cmd.Parameters.AddWithValue("@specialised_loan_period", SqlDbType.Int).Value = specialisedLoanPeriod;
                    cmd.Parameters.AddWithValue("@interest_rate", SqlDbType.Decimal).Value = interestRate;
                    cmd.Parameters.AddWithValue("@collateral_present1", SqlDbType.NVarChar).Value = collateralPresent1;
                    cmd.Parameters.AddWithValue("@collateral_secure1", SqlDbType.NVarChar).Value = collateralSecure1 ?? "";
                    cmd.Parameters.AddWithValue("@security_type1", SqlDbType.NVarChar).Value = securityCode1 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure2", SqlDbType.NVarChar).Value = collateralSecure2 ?? "";
                    cmd.Parameters.AddWithValue("@security_type2", SqlDbType.NVarChar).Value = securityCode2 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure3", SqlDbType.NVarChar).Value = collateralSecure3 ?? "";
                    cmd.Parameters.AddWithValue("@security_type3", SqlDbType.NVarChar).Value = securityCode3 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure4", SqlDbType.NVarChar).Value = collateralSecure4 ?? "";
                    cmd.Parameters.AddWithValue("@security_type4", SqlDbType.NVarChar).Value = securityCode4 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure5", SqlDbType.NVarChar).Value = collateralSecure5 ?? "";
                    cmd.Parameters.AddWithValue("@security_type5", SqlDbType.NVarChar).Value = securityCode5 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure6", SqlDbType.NVarChar).Value = collateralSecure6 ?? "";
                    cmd.Parameters.AddWithValue("@security_type6", SqlDbType.NVarChar).Value = securityCode6 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure7", SqlDbType.NVarChar).Value = collateralSecure7 ?? "";
                    cmd.Parameters.AddWithValue("@security_type7", SqlDbType.NVarChar).Value = securityCode7 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure8", SqlDbType.NVarChar).Value = collateralSecure8 ?? "";
                    cmd.Parameters.AddWithValue("@security_type8", SqlDbType.NVarChar).Value = securityCode8 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure9", SqlDbType.NVarChar).Value = collateralSecure9 ?? "";
                    cmd.Parameters.AddWithValue("@security_type9", SqlDbType.NVarChar).Value = securityCode9 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure10", SqlDbType.NVarChar).Value = collateralSecure10 ?? "";
                    cmd.Parameters.AddWithValue("@security_type10", SqlDbType.NVarChar).Value = securityCode10 ?? "";
                    cmd.Parameters.AddWithValue("@repayment_source", SqlDbType.NVarChar).Value = repaymentSource;
                    cmd.Parameters.AddWithValue("@syndication", SqlDbType.NVarChar).Value = syndication;
                    cmd.Parameters.AddWithValue("@syndication_status", SqlDbType.NVarChar).Value = syndicationStatus;
                    cmd.Parameters.AddWithValue("@syndication_reference_number", SqlDbType.NVarChar).Value =
                        syndicationReferenceNumber;
                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean SaveCrms200(String code, String customerId, String accountNumber, String customerName, String governmentMdatin, String legalCode,
           String creditType, String businessLinesCode, String businessLinesSubsectorCode, decimal creditLimit, decimal outstandingAmount,
           String feeTypeCode1, decimal feeAmount1, String feeTypeCode2, decimal feeAmount2, String feeTypeCode3, decimal feeAmount3, String feeTypeCode4, decimal feeAmount4,
           String feeTypeCode5, decimal feeAmount5, String feeTypeCode6, decimal feeAmount6, String feeTypeCode7, decimal feeAmount7, String feeTypeCode8, decimal feeAmount8,
           String feeTypeCode9, decimal feeAmount9, String feeTypeCode10, decimal feeAmount10, String feeTypeCode11, decimal feeAmount11, String feeTypeCode12, decimal feeAmount12,
           String feeTypeCode13, decimal feeAmount13, String feeTypeCode14, decimal feeAmount14, String feeTypeCode15, decimal feeAmount15, String feeTypeCode16, decimal feeAmount16,
           DateTime effectiveDate, int tenor, DateTime expiryDate, String repaymentAgreementCode, String performanceRepaymentStatus,
           String specialisedLoan, int specialisedLoanPeriod, decimal interestRate, String collateralPresent1, string collateralSecure1, String securityCode1, string collateralSecure2, String securityCode2,
           string collateralSecure3, String securityCode3, string collateralSecure4, String securityCode4,
           string collateralSecure5, String securityCode5, string collateralSecure6, String securityCode6,
           string collateralSecure7, String securityCode7, string collateralSecure8, String securityCode8,
           string collateralSecure9, String securityCode9, string collateralSecure10, String securityCode10, String repaymentSource, String syndication, String syndicationStatus, String syndicationReferenceNumber,
           String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_200 (Code, Customer_ID, Customer_Account_Number, Customer_Name, Government_Mda_Tin, legal_status, " +
                        "credit_type, Credit_Purpose_By_Business_Lines, Credit_Purpose_By_Business_Lines_Subsector, credit_limit, outstanding_amount, " +
                        "fee_type1, fee_amount1, fee_type2, fee_amount2, fee_type3, fee_amount3, fee_type4, fee_amount4, fee_type5, fee_amount5, " +
                        "fee_type6, fee_amount6, fee_type7, fee_amount7, fee_type8, fee_amount8, fee_type9, fee_amount9, fee_type10, fee_amount10, " +
                        "fee_type11, fee_amount11, fee_type12, fee_amount12, fee_type13, fee_amount13, fee_type14, fee_amount14, fee_type15, fee_amount15, " +
                        "fee_type16, fee_amount16, effective_date, tenor, expiry_date, repayment_agreement_mode, Performance_Repayment_Status, specialised_loan, Specialised_Loan_Period, " +
                        "interest_rate, collateral_present1, collateral_secure1, security_type1, " +
                        "collateral_secure2, security_type2, collateral_secure3, security_type3, " +
                        "collateral_secure4, security_type4, collateral_secure5, security_type5, " +
                        "collateral_secure6, security_type6, collateral_secure7, security_type7, " +
                        "collateral_secure8, security_type8, collateral_secure9, security_type9, " +
                        "collateral_secure10, security_type10, " +
                        "repayment_source, syndication, syndication_status, " +
                        "syndication_reference_number, inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @Government_Mda_Tin, @legal_status, " +
                        "@credit_type, @credit_purpose_by_businesslines, @credit_purpose_by_businesslines_subsector, @credit_limit, @outstanding_amount, " +
                        "@fee_type1, @fee_amount1, @fee_type2, @fee_amount2, @fee_type3, @fee_amount3, @fee_type4, @fee_amount4, @fee_type5, @fee_amount5, " +
                        "@fee_type6, @fee_amount6, @fee_type7, @fee_amount7, @fee_type8, @fee_amount8, @fee_type9, @fee_amount9, @fee_type10, @fee_amount10," +
                        "@fee_type11, @fee_amount11, @fee_type12, @fee_amount12, @fee_type13, @fee_amount13, @fee_type14, @fee_amount14, @fee_type15, @fee_amount15," +
                        "@fee_type16, @fee_amount16, @effective_date, @tenor, @expiry_date, @repayment_agreement_mode, @Performance_Repayment_Status, @specialised_loan, @specialised_loan_period, " +
                        "@interest_rate, @collateral_present1, @collateral_secure1, @security_type1, " +
                        "@collateral_secure2, @security_type2, @collateral_secure3, @security_type3, " +
                        "@collateral_secure4, @security_type4, @collateral_secure5, @security_type5, " +
                        "@collateral_secure6, @security_type6, @collateral_secure7, @security_type7, " +
                        "@collateral_secure8, @security_type8, @collateral_secure9, @security_type9, " +
                        "@collateral_secure10, @security_type10, " +
                        "@repayment_source, @syndication, @syndication_status, " +
                        "@syndication_reference_number, @inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@Government_Mda_Tin", SqlDbType.NVarChar).Value = governmentMdatin;
                    cmd.Parameters.AddWithValue("@legal_status", SqlDbType.NVarChar).Value = legalCode;
                    cmd.Parameters.AddWithValue("@credit_type", SqlDbType.NVarChar).Value = creditType;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines", SqlDbType.NVarChar).Value =
                        businessLinesCode;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines_subsector", SqlDbType.NVarChar).Value =
                        businessLinesSubsectorCode;
                    cmd.Parameters.AddWithValue("@credit_limit", SqlDbType.Decimal).Value = creditLimit;
                    cmd.Parameters.AddWithValue("@outstanding_amount", SqlDbType.Decimal).Value = outstandingAmount;
                    cmd.Parameters.AddWithValue("@fee_type1", SqlDbType.NVarChar).Value = feeTypeCode1;
                    cmd.Parameters.AddWithValue("@fee_amount1", SqlDbType.Decimal).Value = feeAmount1;
                    cmd.Parameters.AddWithValue("@fee_type2", SqlDbType.NVarChar).Value = feeTypeCode2;
                    cmd.Parameters.AddWithValue("@fee_amount2", SqlDbType.Decimal).Value = feeAmount2;
                    cmd.Parameters.AddWithValue("@fee_type3", SqlDbType.NVarChar).Value = feeTypeCode3;
                    cmd.Parameters.AddWithValue("@fee_amount3", SqlDbType.Decimal).Value = feeAmount3;
                    cmd.Parameters.AddWithValue("@fee_type4", SqlDbType.NVarChar).Value = feeTypeCode4;
                    cmd.Parameters.AddWithValue("@fee_amount4", SqlDbType.Decimal).Value = feeAmount4;
                    cmd.Parameters.AddWithValue("@fee_type5", SqlDbType.NVarChar).Value = feeTypeCode5;
                    cmd.Parameters.AddWithValue("@fee_amount5", SqlDbType.Decimal).Value = feeAmount5;
                    cmd.Parameters.AddWithValue("@fee_type6", SqlDbType.NVarChar).Value = feeTypeCode6;
                    cmd.Parameters.AddWithValue("@fee_amount6", SqlDbType.Decimal).Value = feeAmount6;
                    cmd.Parameters.AddWithValue("@fee_type7", SqlDbType.NVarChar).Value = feeTypeCode7;
                    cmd.Parameters.AddWithValue("@fee_amount7", SqlDbType.Decimal).Value = feeAmount7;
                    cmd.Parameters.AddWithValue("@fee_type8", SqlDbType.NVarChar).Value = feeTypeCode8;
                    cmd.Parameters.AddWithValue("@fee_amount8", SqlDbType.Decimal).Value = feeAmount8;
                    cmd.Parameters.AddWithValue("@fee_type9", SqlDbType.NVarChar).Value = feeTypeCode9;
                    cmd.Parameters.AddWithValue("@fee_amount9", SqlDbType.Decimal).Value = feeAmount9;
                    cmd.Parameters.AddWithValue("@fee_type10", SqlDbType.NVarChar).Value = feeTypeCode10;
                    cmd.Parameters.AddWithValue("@fee_amount10", SqlDbType.Decimal).Value = feeAmount10;
                    cmd.Parameters.AddWithValue("@fee_type11", SqlDbType.NVarChar).Value = feeTypeCode11;
                    cmd.Parameters.AddWithValue("@fee_amount11", SqlDbType.Decimal).Value = feeAmount11;
                    cmd.Parameters.AddWithValue("@fee_type12", SqlDbType.NVarChar).Value = feeTypeCode12;
                    cmd.Parameters.AddWithValue("@fee_amount12", SqlDbType.Decimal).Value = feeAmount12;
                    cmd.Parameters.AddWithValue("@fee_type13", SqlDbType.NVarChar).Value = feeTypeCode13;
                    cmd.Parameters.AddWithValue("@fee_amount13", SqlDbType.Decimal).Value = feeAmount13;
                    cmd.Parameters.AddWithValue("@fee_type14", SqlDbType.NVarChar).Value = feeTypeCode14;
                    cmd.Parameters.AddWithValue("@fee_amount14", SqlDbType.Decimal).Value = feeAmount14;
                    cmd.Parameters.AddWithValue("@fee_type15", SqlDbType.NVarChar).Value = feeTypeCode15;
                    cmd.Parameters.AddWithValue("@fee_amount15", SqlDbType.Decimal).Value = feeAmount15;
                    cmd.Parameters.AddWithValue("@fee_type16", SqlDbType.NVarChar).Value = feeTypeCode16;
                    cmd.Parameters.AddWithValue("@fee_amount16", SqlDbType.Decimal).Value = feeAmount16;
                    cmd.Parameters.AddWithValue("@effective_date", SqlDbType.Date).Value = effectiveDate;
                    cmd.Parameters.AddWithValue("@tenor", SqlDbType.Int).Value = tenor;
                    cmd.Parameters.AddWithValue("@expiry_date", SqlDbType.Date).Value = expiryDate;
                    cmd.Parameters.AddWithValue("@repayment_agreement_mode", SqlDbType.NVarChar).Value =
                        repaymentAgreementCode;
                    cmd.Parameters.AddWithValue("@Performance_Repayment_Status", SqlDbType.NVarChar).Value =
                        performanceRepaymentStatus;
                    cmd.Parameters.AddWithValue("@specialised_loan", SqlDbType.NVarChar).Value = specialisedLoan;
                    cmd.Parameters.AddWithValue("@specialised_loan_period", SqlDbType.Int).Value = specialisedLoanPeriod;
                    cmd.Parameters.AddWithValue("@interest_rate", SqlDbType.Decimal).Value = interestRate;
                    cmd.Parameters.AddWithValue("@collateral_present1", SqlDbType.NVarChar).Value = collateralPresent1;
                    cmd.Parameters.AddWithValue("@collateral_secure1", SqlDbType.NVarChar).Value = collateralSecure1 ?? "";
                    cmd.Parameters.AddWithValue("@security_type1", SqlDbType.NVarChar).Value = securityCode1 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure2", SqlDbType.NVarChar).Value = collateralSecure2 ?? "";
                    cmd.Parameters.AddWithValue("@security_type2", SqlDbType.NVarChar).Value = securityCode2 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure3", SqlDbType.NVarChar).Value = collateralSecure3 ?? "";
                    cmd.Parameters.AddWithValue("@security_type3", SqlDbType.NVarChar).Value = securityCode3 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure4", SqlDbType.NVarChar).Value = collateralSecure4 ?? "";
                    cmd.Parameters.AddWithValue("@security_type4", SqlDbType.NVarChar).Value = securityCode4 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure5", SqlDbType.NVarChar).Value = collateralSecure5 ?? "";
                    cmd.Parameters.AddWithValue("@security_type5", SqlDbType.NVarChar).Value = securityCode5 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure6", SqlDbType.NVarChar).Value = collateralSecure6 ?? "";
                    cmd.Parameters.AddWithValue("@security_type6", SqlDbType.NVarChar).Value = securityCode6 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure7", SqlDbType.NVarChar).Value = collateralSecure7 ?? "";
                    cmd.Parameters.AddWithValue("@security_type7", SqlDbType.NVarChar).Value = securityCode7 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure8", SqlDbType.NVarChar).Value = collateralSecure8 ?? "";
                    cmd.Parameters.AddWithValue("@security_type8", SqlDbType.NVarChar).Value = securityCode8 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure9", SqlDbType.NVarChar).Value = collateralSecure9 ?? "";
                    cmd.Parameters.AddWithValue("@security_type9", SqlDbType.NVarChar).Value = securityCode9 ?? "";
                    cmd.Parameters.AddWithValue("@collateral_secure10", SqlDbType.NVarChar).Value = collateralSecure10 ?? "";
                    cmd.Parameters.AddWithValue("@security_type10", SqlDbType.NVarChar).Value = securityCode10 ?? "";
                    cmd.Parameters.AddWithValue("@repayment_source", SqlDbType.NVarChar).Value = repaymentSource;
                    cmd.Parameters.AddWithValue("@syndication", SqlDbType.NVarChar).Value = syndication;
                    cmd.Parameters.AddWithValue("@syndication_status", SqlDbType.NVarChar).Value = syndicationStatus;
                    cmd.Parameters.AddWithValue("@syndication_reference_number", SqlDbType.NVarChar).Value =
                        syndicationReferenceNumber;
                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean SaveCrms300(String code, String customerId, String accountNumber, String customerName, String uniqueIdentificaionType, String uniqueIdentificaionNumber,
           String creditType, String businessLinesCode, String businessLinesSubsectorCode, decimal creditLimit, decimal outstandingAmount,
           String feeTypeCode1, decimal feeAmount1, String feeTypeCode2, decimal feeAmount2, String feeTypeCode3, decimal feeAmount3, String feeTypeCode4, decimal feeAmount4,
           String feeTypeCode5, decimal feeAmount5, String feeTypeCode6, decimal feeAmount6, String feeTypeCode7, decimal feeAmount7, String feeTypeCode8, decimal feeAmount8,
           String feeTypeCode9, decimal feeAmount9, String feeTypeCode10, decimal feeAmount10, String feeTypeCode11, decimal feeAmount11, String feeTypeCode12, decimal feeAmount12,
           String feeTypeCode13, decimal feeAmount13, String feeTypeCode14, decimal feeAmount14, String feeTypeCode15, decimal feeAmount15, String feeTypeCode16, decimal feeAmount16,
           DateTime effectiveDate, int tenor, DateTime expiryDate, String repaymentAgreementMode, decimal interestRate, String beneficiaryAccount, String beneficiaryLocation,
            String relationshipType, String companySize, String fundingSourceCategory, String ecciNumber, String fundingSource, String legalCode, String cBusinessLinesCode,
            String cBusinessLinesSubsectorCode, String specialisedLoan, int specialisedLoanPeriod, String dUniqueIdentificaionType1, String dUniqueIdentificaionNumber1,
            String dEmail1, String dUniqueIdentificaionType2, String dUniqueIdentificaionNumber2, String dEmail2, String dUniqueIdentificaionType3, String dUniqueIdentificaionNumber3,
            String dEmail3, String dUniqueIdentificaionType4, String dUniqueIdentificaionNumber4, String dEmail4, String dUniqueIdentificaionType5, String dUniqueIdentificaionNumber5,
            String dEmail5, String syndication, String syndicationStatus, String syndicationReferenceNumber,
            String collateralPresent1, string collateralSecure1, String securityCode1, String addressOfSecurity1, String ownerOfSecurity1, String sUniqueIdentificaionType1, String sUniqueIdentificaionNumber1,
            string collateralSecure2, String securityCode2, String addressOfSecurity2, String ownerOfSecurity2, String sUniqueIdentificaionType2, String sUniqueIdentificaionNumber2,
            string collateralSecure3, String securityCode3, String addressOfSecurity3, String ownerOfSecurity3, String sUniqueIdentificaionType3, String sUniqueIdentificaionNumber3,
            string collateralSecure4, String securityCode4, String addressOfSecurity4, String ownerOfSecurity4, String sUniqueIdentificaionType4, String sUniqueIdentificaionNumber4,
            string collateralSecure5, String securityCode5, String addressOfSecurity5, String ownerOfSecurity5, String sUniqueIdentificaionType5, String sUniqueIdentificaionNumber5,
            string collateralSecure6, String securityCode6, String addressOfSecurity6, String ownerOfSecurity6, String sUniqueIdentificaionType6, String sUniqueIdentificaionNumber6,
            string collateralSecure7, String securityCode7, String addressOfSecurity7, String ownerOfSecurity7, String sUniqueIdentificaionType7, String sUniqueIdentificaionNumber7,
            string collateralSecure8, String securityCode8, String addressOfSecurity8, String ownerOfSecurity8, String sUniqueIdentificaionType8, String sUniqueIdentificaionNumber8,
            string collateralSecure9, String securityCode9, String addressOfSecurity9, String ownerOfSecurity9, String sUniqueIdentificaionType9, String sUniqueIdentificaionNumber9,
            string collateralSecure10, String securityCode10, String addressOfSecurity10, String ownerOfSecurity10, String sUniqueIdentificaionType10, String sUniqueIdentificaionNumber10,
            String guarantee1, String guaranteeType1, String gUniqueIdentificaionType1, String gUniqueIdentificaionNumber1, decimal amountGuaranteed1,
            String guaranteeType2, String gUniqueIdentificaionType2, String gUniqueIdentificaionNumber2, decimal amountGuaranteed2,
            String guaranteeType3, String gUniqueIdentificaionType3, String gUniqueIdentificaionNumber3, decimal amountGuaranteed3,
            String guaranteeType4, String gUniqueIdentificaionType4, String gUniqueIdentificaionNumber4, decimal amountGuaranteed4,
            String guaranteeType5, String gUniqueIdentificaionType5, String gUniqueIdentificaionNumber5, decimal amountGuaranteed5,
           String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_300 (Code, Customer_ID, Customer_Account_Number, Customer_Name, Unique_Identifcation_Type, Unique_Identifcation_Number, " +
                        "credit_type, Credit_Purpose_By_Business_Lines, Credit_Purpose_By_Business_Lines_Subsector, credit_limit, outstanding_amount, " +
                        "fee_type1, fee_amount1, fee_type2, fee_amount2, fee_type3, fee_amount3, fee_type4, fee_amount4, fee_type5, fee_amount5, " +
                        "fee_type6, fee_amount6, fee_type7, fee_amount7, fee_type8, fee_amount8, fee_type9, fee_amount9, fee_type10, fee_amount10, " +
                        "fee_type11, fee_amount11, fee_type12, fee_amount12, fee_type13, fee_amount13, fee_type14, fee_amount14, fee_type15, fee_amount15, " +
                        "fee_type16, fee_amount16, effective_date, tenor, expiry_date, Repayment_Agreement_Mode, Interest_Rate, Beneficiary_Account_Number, Location_of_Beneficiary, " +
                        "Relationship_Type, Company_Size, Funding_Source_Category, ECCI_Number, Funding_Source, Legal_Status, Classification_By_Business_Lines, Classification_By_Business_Lines_Subsector, Specialised_Loan, Specialised_Loan_Period, " +
                        "Director_Id_Type1, Director_Id_Number1, Director_Id_Email1, Director_Id_Type2, Director_Id_Number2, Director_Id_Email2, Director_Id_Type3, Director_Id_Number3, Director_Id_Email3, " +
                        "Director_Id_Type4, Director_Id_Number4, Director_Id_Email4, Director_Id_Type5, Director_Id_Number5, Director_Id_Email5, " +
                        "Syndication, Syndication_Status, Syndication_Reference_Number, Collateral_Present1, " +
                        "Collateral_Secure1, Security_Type1, Address_of_Security1, Owner_of_Security1, Security_Id_Type1, Security_Id_Number1, " +
                        "Collateral_Secure2, Security_Type2, Address_of_Security2, Owner_of_Security2, Security_Id_Type2, Security_Id_Number2, " +
                        "Collateral_Secure3, Security_Type3, Address_of_Security3, Owner_of_Security3, Security_Id_Type3, Security_Id_Number3, " +
                        "Collateral_Secure4, Security_Type4, Address_of_Security4, Owner_of_Security4, Security_Id_Type4, Security_Id_Number4, " +
                        "Collateral_Secure5, Security_Type5, Address_of_Security5, Owner_of_Security5, Security_Id_Type5, Security_Id_Number5, " +
                        "Collateral_Secure6, Security_Type6, Address_of_Security6, Owner_of_Security6, Security_Id_Type6, Security_Id_Number6, " +
                        "Collateral_Secure7, Security_Type7, Address_of_Security7, Owner_of_Security7, Security_Id_Type7, Security_Id_Number7, " +
                        "Collateral_Secure8, Security_Type8, Address_of_Security8, Owner_of_Security8, Security_Id_Type8, Security_Id_Number8, " +
                        "Collateral_Secure9, Security_Type9, Address_of_Security9, Owner_of_Security9, Security_Id_Type9, Security_Id_Number9, " +
                        "Collateral_Secure10, Security_Type10, Address_of_Security10, Owner_of_Security10, Security_Id_Type10, Security_Id_Number10, " +
                        "Guarantee1, Guarantee_Type1, Guarantor_Id_Type1, Guarantor_Id_Number1, Amount_Guaranteed1, " +
                        "Guarantee_Type2, Guarantor_Id_Type2, Guarantor_Id_Number2, Amount_Guaranteed2, " +
                        "Guarantee_Type3, Guarantor_Id_Type3, Guarantor_Id_Number3, Amount_Guaranteed3, " +
                        "Guarantee_Type4, Guarantor_Id_Type4, Guarantor_Id_Number4, Amount_Guaranteed4, " +
                        "Guarantee_Type5, Guarantor_Id_Type5, Guarantor_Id_Number5, Amount_Guaranteed5, " +
                        "inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @Unique_Identifcation_Type, @Unique_Identifcation_Number, " +
                        "@credit_type, @credit_purpose_by_businesslines, @credit_purpose_by_businesslines_subsector, @credit_limit, @outstanding_amount, " +
                        "@fee_type1, @fee_amount1, @fee_type2, @fee_amount2, @fee_type3, @fee_amount3, @fee_type4, @fee_amount4, @fee_type5, @fee_amount5, " +
                        "@fee_type6, @fee_amount6, @fee_type7, @fee_amount7, @fee_type8, @fee_amount8, @fee_type9, @fee_amount9, @fee_type10, @fee_amount10," +
                        "@fee_type11, @fee_amount11, @fee_type12, @fee_amount12, @fee_type13, @fee_amount13, @fee_type14, @fee_amount14, @fee_type15, @fee_amount15," +
                        "@fee_type16, @fee_amount16, @effective_date, @tenor, @expiry_date, @Repayment_Agreement_Mode, @interest_rate, @Beneficiary_Account_Number, @Location_of_Beneficiary, @Relationship_Type, @Company_Size, " +
                        "@Funding_Source_Category, @ECCI_Number, @Funding_Source, @Legal_Status, @Classification_By_Business_Lines, @Classification_By_Business_Lines_Subsector, @Specialised_Loan, @Specialised_Loan_Period, " +
                        "@Director_Id_Type1, @Director_Id_Number1, @Director_Id_Email1, @Director_Id_Type2, @Director_Id_Number2, @Director_Id_Email2, " +
                        "@Director_Id_Type3, @Director_Id_Number3, @Director_Id_Email3, @Director_Id_Type4, @Director_Id_Number4, @Director_Id_Email4, " +
                        "@Director_Id_Type5, @Director_Id_Number5, @Director_Id_Email5, " +
                        "@Syndication, @Syndication_Status, @Syndication_Reference_Number, " +
                        "@Collateral_Present1, @Collateral_Secure1, @Security_Type1, @Address_of_Security1, @Owner_of_Security1, @Security_Id_Type1, @Security_Id_Number1, " +
                        "@Collateral_Secure2, @Security_Type2, @Address_of_Security2, @Owner_of_Security2, @Security_Id_Type2, @Security_Id_Number2, " +
                        "@Collateral_Secure3, @Security_Type3, @Address_of_Security3, @Owner_of_Security3, @Security_Id_Type3, @Security_Id_Number3, " +
                        "@Collateral_Secure4, @Security_Type4, @Address_of_Security4, @Owner_of_Security4, @Security_Id_Type4, @Security_Id_Number4, " +
                        "@Collateral_Secure5, @Security_Type5, @Address_of_Security5, @Owner_of_Security5, @Security_Id_Type5, @Security_Id_Number5, " +
                        "@Collateral_Secure6, @Security_Type6, @Address_of_Security6, @Owner_of_Security6, @Security_Id_Type6, @Security_Id_Number6, " +
                        "@Collateral_Secure7, @Security_Type7, @Address_of_Security7, @Owner_of_Security7, @Security_Id_Type7, @Security_Id_Number7, " +
                        "@Collateral_Secure8, @Security_Type8, @Address_of_Security8, @Owner_of_Security8, @Security_Id_Type8, @Security_Id_Number8, " +
                        "@Collateral_Secure9, @Security_Type9, @Address_of_Security9, @Owner_of_Security9, @Security_Id_Type9, @Security_Id_Number9, " +
                        "@Collateral_Secure10, @Security_Type10, @Address_of_Security10, @Owner_of_Security10, @Security_Id_Type10, @Security_Id_Number10, " +
                        "@Guarantee1, @Guarantee_Type1, @Guarantor_Id_Type1, @Guarantor_Id_Number1, @Amount_Guaranteed1, " +
                        " @Guarantee_Type2, @Guarantor_Id_Type2, @Guarantor_Id_Number2, @Amount_Guaranteed2, " +
                        " @Guarantee_Type3, @Guarantor_Id_Type3, @Guarantor_Id_Number3, @Amount_Guaranteed3, " +
                        " @Guarantee_Type4, @Guarantor_Id_Type4, @Guarantor_Id_Number4, @Amount_Guaranteed4, " +
                        " @Guarantee_Type5, @Guarantor_Id_Type5, @Guarantor_Id_Number5, @Amount_Guaranteed5, " +
                        "@inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Type", SqlDbType.NVarChar).Value = uniqueIdentificaionType;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Number", SqlDbType.NVarChar).Value = uniqueIdentificaionNumber;
                    cmd.Parameters.AddWithValue("@credit_type", SqlDbType.NVarChar).Value = creditType;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines", SqlDbType.NVarChar).Value =
                        businessLinesCode;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines_subsector", SqlDbType.NVarChar).Value =
                        businessLinesSubsectorCode;
                    cmd.Parameters.AddWithValue("@credit_limit", SqlDbType.Decimal).Value = creditLimit;
                    cmd.Parameters.AddWithValue("@outstanding_amount", SqlDbType.Decimal).Value = outstandingAmount;
                    cmd.Parameters.AddWithValue("@fee_type1", SqlDbType.NVarChar).Value = feeTypeCode1;
                    cmd.Parameters.AddWithValue("@fee_amount1", SqlDbType.Decimal).Value = feeAmount1;
                    cmd.Parameters.AddWithValue("@fee_type2", SqlDbType.NVarChar).Value = feeTypeCode2;
                    cmd.Parameters.AddWithValue("@fee_amount2", SqlDbType.Decimal).Value = feeAmount2;
                    cmd.Parameters.AddWithValue("@fee_type3", SqlDbType.NVarChar).Value = feeTypeCode3;
                    cmd.Parameters.AddWithValue("@fee_amount3", SqlDbType.Decimal).Value = feeAmount3;
                    cmd.Parameters.AddWithValue("@fee_type4", SqlDbType.NVarChar).Value = feeTypeCode4;
                    cmd.Parameters.AddWithValue("@fee_amount4", SqlDbType.Decimal).Value = feeAmount4;
                    cmd.Parameters.AddWithValue("@fee_type5", SqlDbType.NVarChar).Value = feeTypeCode5;
                    cmd.Parameters.AddWithValue("@fee_amount5", SqlDbType.Decimal).Value = feeAmount5;
                    cmd.Parameters.AddWithValue("@fee_type6", SqlDbType.NVarChar).Value = feeTypeCode6;
                    cmd.Parameters.AddWithValue("@fee_amount6", SqlDbType.Decimal).Value = feeAmount6;
                    cmd.Parameters.AddWithValue("@fee_type7", SqlDbType.NVarChar).Value = feeTypeCode7;
                    cmd.Parameters.AddWithValue("@fee_amount7", SqlDbType.Decimal).Value = feeAmount7;
                    cmd.Parameters.AddWithValue("@fee_type8", SqlDbType.NVarChar).Value = feeTypeCode8;
                    cmd.Parameters.AddWithValue("@fee_amount8", SqlDbType.Decimal).Value = feeAmount8;
                    cmd.Parameters.AddWithValue("@fee_type9", SqlDbType.NVarChar).Value = feeTypeCode9;
                    cmd.Parameters.AddWithValue("@fee_amount9", SqlDbType.Decimal).Value = feeAmount9;
                    cmd.Parameters.AddWithValue("@fee_type10", SqlDbType.NVarChar).Value = feeTypeCode10;
                    cmd.Parameters.AddWithValue("@fee_amount10", SqlDbType.Decimal).Value = feeAmount10;
                    cmd.Parameters.AddWithValue("@fee_type11", SqlDbType.NVarChar).Value = feeTypeCode11;
                    cmd.Parameters.AddWithValue("@fee_amount11", SqlDbType.Decimal).Value = feeAmount11;
                    cmd.Parameters.AddWithValue("@fee_type12", SqlDbType.NVarChar).Value = feeTypeCode12;
                    cmd.Parameters.AddWithValue("@fee_amount12", SqlDbType.Decimal).Value = feeAmount12;
                    cmd.Parameters.AddWithValue("@fee_type13", SqlDbType.NVarChar).Value = feeTypeCode13;
                    cmd.Parameters.AddWithValue("@fee_amount13", SqlDbType.Decimal).Value = feeAmount13;
                    cmd.Parameters.AddWithValue("@fee_type14", SqlDbType.NVarChar).Value = feeTypeCode14;
                    cmd.Parameters.AddWithValue("@fee_amount14", SqlDbType.Decimal).Value = feeAmount14;
                    cmd.Parameters.AddWithValue("@fee_type15", SqlDbType.NVarChar).Value = feeTypeCode15;
                    cmd.Parameters.AddWithValue("@fee_amount15", SqlDbType.Decimal).Value = feeAmount15;
                    cmd.Parameters.AddWithValue("@fee_type16", SqlDbType.NVarChar).Value = feeTypeCode16;
                    cmd.Parameters.AddWithValue("@fee_amount16", SqlDbType.Decimal).Value = feeAmount16;
                    cmd.Parameters.AddWithValue("@effective_date", SqlDbType.Date).Value = effectiveDate;
                    cmd.Parameters.AddWithValue("@tenor", SqlDbType.Int).Value = tenor;
                    cmd.Parameters.AddWithValue("@expiry_date", SqlDbType.Date).Value = expiryDate;
                    cmd.Parameters.AddWithValue("@Repayment_Agreement_Mode", SqlDbType.NVarChar).Value = repaymentAgreementMode;
                    cmd.Parameters.AddWithValue("@interest_rate", SqlDbType.Decimal).Value = interestRate;
                    cmd.Parameters.AddWithValue("@Beneficiary_Account_Number", SqlDbType.NVarChar).Value = beneficiaryAccount;
                    cmd.Parameters.AddWithValue("@Location_of_Beneficiary", SqlDbType.NVarChar).Value = beneficiaryLocation;
                    cmd.Parameters.AddWithValue("@Relationship_Type", SqlDbType.NVarChar).Value = relationshipType;
                    cmd.Parameters.AddWithValue("@Company_Size", SqlDbType.NVarChar).Value = companySize;
                    cmd.Parameters.AddWithValue("@Funding_Source_Category", SqlDbType.NVarChar).Value = fundingSourceCategory;
                    cmd.Parameters.AddWithValue("@ECCI_Number", SqlDbType.NVarChar).Value = ecciNumber ?? "";
                    cmd.Parameters.AddWithValue("@Funding_Source", SqlDbType.NVarChar).Value = fundingSource;
                    cmd.Parameters.AddWithValue("@Legal_Status", SqlDbType.NVarChar).Value = legalCode;
                    cmd.Parameters.AddWithValue("@Classification_By_Business_Lines", SqlDbType.NVarChar).Value = cBusinessLinesCode;
                    cmd.Parameters.AddWithValue("@Classification_By_Business_Lines_Subsector", SqlDbType.NVarChar).Value = cBusinessLinesSubsectorCode;
                    cmd.Parameters.AddWithValue("@Specialised_Loan", SqlDbType.NVarChar).Value = specialisedLoan;
                    cmd.Parameters.AddWithValue("@Specialised_Loan_Period", SqlDbType.Int).Value = specialisedLoanPeriod;

                    cmd.Parameters.AddWithValue("@Director_Id_Type1", SqlDbType.NVarChar).Value = dUniqueIdentificaionType1;
                    cmd.Parameters.AddWithValue("@Director_Id_Number1", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber1;
                    cmd.Parameters.AddWithValue("@Director_Id_Email1", SqlDbType.NVarChar).Value = dEmail1;

                    cmd.Parameters.AddWithValue("@Director_Id_Type2", SqlDbType.NVarChar).Value = dUniqueIdentificaionType2 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number2", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber2 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email2", SqlDbType.NVarChar).Value = dEmail2 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type3", SqlDbType.NVarChar).Value = dUniqueIdentificaionType3 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number3", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber3 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email3", SqlDbType.NVarChar).Value = dEmail3 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type4", SqlDbType.NVarChar).Value = dUniqueIdentificaionType4 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number4", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber4 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email4", SqlDbType.NVarChar).Value = dEmail4 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type5", SqlDbType.NVarChar).Value = dUniqueIdentificaionType5 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number5", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber5 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email5", SqlDbType.NVarChar).Value = dEmail5 ?? "";

                    cmd.Parameters.AddWithValue("@syndication", SqlDbType.NVarChar).Value = syndication;
                    cmd.Parameters.AddWithValue("@syndication_status", SqlDbType.NVarChar).Value = syndicationStatus;
                    cmd.Parameters.AddWithValue("@syndication_reference_number", SqlDbType.NVarChar).Value = syndicationReferenceNumber;
                    cmd.Parameters.AddWithValue("@collateral_present1", SqlDbType.NVarChar).Value = collateralPresent1;

                    cmd.Parameters.AddWithValue("@collateral_secure1", SqlDbType.NVarChar).Value = collateralSecure1 ?? "";
                    cmd.Parameters.AddWithValue("@security_type1", SqlDbType.NVarChar).Value = securityCode1 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security1", SqlDbType.NVarChar).Value = addressOfSecurity1 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security1", SqlDbType.NVarChar).Value = ownerOfSecurity1 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type1", SqlDbType.NVarChar).Value = sUniqueIdentificaionType1 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number1", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber1 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure2", SqlDbType.NVarChar).Value = collateralSecure2 ?? "";
                    cmd.Parameters.AddWithValue("@security_type2", SqlDbType.NVarChar).Value = securityCode2 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security2", SqlDbType.NVarChar).Value = addressOfSecurity2 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security2", SqlDbType.NVarChar).Value = ownerOfSecurity2 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type2", SqlDbType.NVarChar).Value = sUniqueIdentificaionType2 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number2", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber2 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure3", SqlDbType.NVarChar).Value = collateralSecure3 ?? "";
                    cmd.Parameters.AddWithValue("@security_type3", SqlDbType.NVarChar).Value = securityCode3 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security3", SqlDbType.NVarChar).Value = addressOfSecurity3 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security3", SqlDbType.NVarChar).Value = ownerOfSecurity3 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type3", SqlDbType.NVarChar).Value = sUniqueIdentificaionType3 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number3", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber3 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure4", SqlDbType.NVarChar).Value = collateralSecure4 ?? "";
                    cmd.Parameters.AddWithValue("@security_type4", SqlDbType.NVarChar).Value = securityCode4 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security4", SqlDbType.NVarChar).Value = addressOfSecurity4 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security4", SqlDbType.NVarChar).Value = ownerOfSecurity4 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type4", SqlDbType.NVarChar).Value = sUniqueIdentificaionType4 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number4", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber4 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure5", SqlDbType.NVarChar).Value = collateralSecure5 ?? "";
                    cmd.Parameters.AddWithValue("@security_type5", SqlDbType.NVarChar).Value = securityCode5 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security5", SqlDbType.NVarChar).Value = addressOfSecurity5 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security5", SqlDbType.NVarChar).Value = ownerOfSecurity5 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type5", SqlDbType.NVarChar).Value = sUniqueIdentificaionType5 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number5", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber5 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure6", SqlDbType.NVarChar).Value = collateralSecure6 ?? "";
                    cmd.Parameters.AddWithValue("@security_type6", SqlDbType.NVarChar).Value = securityCode6 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security6", SqlDbType.NVarChar).Value = addressOfSecurity6 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security6", SqlDbType.NVarChar).Value = ownerOfSecurity6 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type6", SqlDbType.NVarChar).Value = sUniqueIdentificaionType6 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number6", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber6 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure7", SqlDbType.NVarChar).Value = collateralSecure7 ?? "";
                    cmd.Parameters.AddWithValue("@security_type7", SqlDbType.NVarChar).Value = securityCode7 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security7", SqlDbType.NVarChar).Value = addressOfSecurity7 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security7", SqlDbType.NVarChar).Value = ownerOfSecurity7 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type7", SqlDbType.NVarChar).Value = sUniqueIdentificaionType7 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number7", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber7 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure8", SqlDbType.NVarChar).Value = collateralSecure8 ?? "";
                    cmd.Parameters.AddWithValue("@security_type8", SqlDbType.NVarChar).Value = securityCode8 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security8", SqlDbType.NVarChar).Value = addressOfSecurity8 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security8", SqlDbType.NVarChar).Value = ownerOfSecurity8 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type8", SqlDbType.NVarChar).Value = sUniqueIdentificaionType8 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number8", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber8 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure9", SqlDbType.NVarChar).Value = collateralSecure9 ?? "";
                    cmd.Parameters.AddWithValue("@security_type9", SqlDbType.NVarChar).Value = securityCode9 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security9", SqlDbType.NVarChar).Value = addressOfSecurity9 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security9", SqlDbType.NVarChar).Value = ownerOfSecurity9 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type9", SqlDbType.NVarChar).Value = sUniqueIdentificaionType9 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number9", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber9 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure10", SqlDbType.NVarChar).Value = collateralSecure10 ?? "";
                    cmd.Parameters.AddWithValue("@security_type10", SqlDbType.NVarChar).Value = securityCode10 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security10", SqlDbType.NVarChar).Value = addressOfSecurity10 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security10", SqlDbType.NVarChar).Value = ownerOfSecurity10 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type10", SqlDbType.NVarChar).Value = sUniqueIdentificaionType10 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number10", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber10 ?? "";

                    cmd.Parameters.AddWithValue("@Guarantee1", SqlDbType.NVarChar).Value = guarantee1;

                    cmd.Parameters.AddWithValue("@Guarantee_Type1", SqlDbType.NVarChar).Value = guaranteeType1 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type1", SqlDbType.NVarChar).Value = gUniqueIdentificaionType1;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number1", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber1 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed1", SqlDbType.Decimal).Value = amountGuaranteed1;

                    cmd.Parameters.AddWithValue("@Guarantee_Type2", SqlDbType.NVarChar).Value = guaranteeType2 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type2", SqlDbType.NVarChar).Value = gUniqueIdentificaionType2;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number2", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber2 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed2", SqlDbType.Decimal).Value = amountGuaranteed2;

                    cmd.Parameters.AddWithValue("@Guarantee_Type3", SqlDbType.NVarChar).Value = guaranteeType3 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type3", SqlDbType.NVarChar).Value = gUniqueIdentificaionType3;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number3", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber3 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed3", SqlDbType.Decimal).Value = amountGuaranteed3;

                    cmd.Parameters.AddWithValue("@Guarantee_Type4", SqlDbType.NVarChar).Value = guaranteeType4 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type4", SqlDbType.NVarChar).Value = gUniqueIdentificaionType4;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number4", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber4 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed4", SqlDbType.Decimal).Value = amountGuaranteed4;

                    cmd.Parameters.AddWithValue("@Guarantee_Type5", SqlDbType.NVarChar).Value = guaranteeType5 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type5", SqlDbType.NVarChar).Value = gUniqueIdentificaionType5;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number5", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber5 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed5", SqlDbType.Decimal).Value = amountGuaranteed5;

                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean SaveCrms400A(String code, String customerId, String accountNumber, String customerName, String uniqueIdentificationType, String uniqueIdentificationNo,
           String crmsRefNo, DateTime effectiveDate, int tenor, DateTime expiryDate, String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_400A (Code, Customer_ID, Customer_Account_Number, Customer_Name, Unique_Identifcation_Type, Unique_Identifcation_Number, " +
                        "CRMS_Reference_Number, effective_date, tenor, expiry_date, inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @Unique_Identifcation_Type, @Unique_Identifcation_Number, " +
                        "@CRMS_Reference_Number, @effective_date, @tenor, @expiry_date, @inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Type", SqlDbType.NVarChar).Value = uniqueIdentificationType;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Number", SqlDbType.NVarChar).Value = uniqueIdentificationNo;
                    cmd.Parameters.AddWithValue("@CRMS_Reference_Number", SqlDbType.NVarChar).Value = crmsRefNo;
                    cmd.Parameters.AddWithValue("@effective_date", SqlDbType.Date).Value = effectiveDate;
                    cmd.Parameters.AddWithValue("@tenor", SqlDbType.Int).Value = tenor;
                    cmd.Parameters.AddWithValue("@expiry_date", SqlDbType.Date).Value = expiryDate;
                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean SaveCrms400B(String code, String customerId, String accountNumber, String customerName, String uniqueIdentificaionType, String uniqueIdentificaionNumber,
            String crmsRefNo, String creditType, decimal creditLimit, decimal outstandingAmount, String feeTypeCode1, decimal feeAmount1, String feeTypeCode2,
            decimal feeAmount2, String feeTypeCode3, decimal feeAmount3, String feeTypeCode4, decimal feeAmount4, String feeTypeCode5, decimal feeAmount5,
            String feeTypeCode6, decimal feeAmount6, String feeTypeCode7, decimal feeAmount7, String feeTypeCode8, decimal feeAmount8, String feeTypeCode9,
            decimal feeAmount9, String feeTypeCode10, decimal feeAmount10, String feeTypeCode11, decimal feeAmount11, String feeTypeCode12,
            decimal feeAmount12, String feeTypeCode13, decimal feeAmount13, String feeTypeCode14, decimal feeAmount14, String feeTypeCode15,
            decimal feeAmount15, String feeTypeCode16, decimal feeAmount16, DateTime effectiveDate, int tenor, DateTime expiryDate, String repaymentAgreement,
            String performanceRepayment, String reasonForRestructuring, decimal interestRate, String beneficiaryAccount, String beneficiaryLocation,
            String relationshipType, String fundingSourceCategory, String ecciNumber, String fundingSource, String specialisedLoan, int specialisedLoanPeriod,
            String dUniqueIdentificaionType1, String dUniqueIdentificaionNumber1,
            String dEmail1, String dUniqueIdentificaionType2, String dUniqueIdentificaionNumber2, String dEmail2, String dUniqueIdentificaionType3, String dUniqueIdentificaionNumber3,
            String dEmail3, String dUniqueIdentificaionType4, String dUniqueIdentificaionNumber4, String dEmail4, String dUniqueIdentificaionType5, String dUniqueIdentificaionNumber5, String dEmail5,
           String collateralPresent1, string collateralSecure1, String securityCode1, String addressOfSecurity1, String ownerOfSecurity1, String sUniqueIdentificaionType1, String sUniqueIdentificaionNumber1,
            string collateralSecure2, String securityCode2, String addressOfSecurity2, String ownerOfSecurity2, String sUniqueIdentificaionType2, String sUniqueIdentificaionNumber2,
            string collateralSecure3, String securityCode3, String addressOfSecurity3, String ownerOfSecurity3, String sUniqueIdentificaionType3, String sUniqueIdentificaionNumber3,
            string collateralSecure4, String securityCode4, String addressOfSecurity4, String ownerOfSecurity4, String sUniqueIdentificaionType4, String sUniqueIdentificaionNumber4,
            string collateralSecure5, String securityCode5, String addressOfSecurity5, String ownerOfSecurity5, String sUniqueIdentificaionType5, String sUniqueIdentificaionNumber5,
            string collateralSecure6, String securityCode6, String addressOfSecurity6, String ownerOfSecurity6, String sUniqueIdentificaionType6, String sUniqueIdentificaionNumber6,
            string collateralSecure7, String securityCode7, String addressOfSecurity7, String ownerOfSecurity7, String sUniqueIdentificaionType7, String sUniqueIdentificaionNumber7,
            string collateralSecure8, String securityCode8, String addressOfSecurity8, String ownerOfSecurity8, String sUniqueIdentificaionType8, String sUniqueIdentificaionNumber8,
            string collateralSecure9, String securityCode9, String addressOfSecurity9, String ownerOfSecurity9, String sUniqueIdentificaionType9, String sUniqueIdentificaionNumber9,
            string collateralSecure10, String securityCode10, String addressOfSecurity10, String ownerOfSecurity10, String sUniqueIdentificaionType10, String sUniqueIdentificaionNumber10,
            String guarantee1, String guaranteeType1, String gUniqueIdentificaionType1, String gUniqueIdentificaionNumber1, decimal amountGuaranteed1,
            String guaranteeType2, String gUniqueIdentificaionType2, String gUniqueIdentificaionNumber2, decimal amountGuaranteed2,
            String guaranteeType3, String gUniqueIdentificaionType3, String gUniqueIdentificaionNumber3, decimal amountGuaranteed3,
            String guaranteeType4, String gUniqueIdentificaionType4, String gUniqueIdentificaionNumber4, decimal amountGuaranteed4,
            String guaranteeType5, String gUniqueIdentificaionType5, String gUniqueIdentificaionNumber5, decimal amountGuaranteed5,
            String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_400B (Code, Customer_ID, Customer_Account_Number, Customer_Name, Unique_Identifcation_Type, Unique_Identifcation_Number, " +
                        "CRMS_Reference_Number, credit_type, credit_limit, outstanding_amount, " +
                        "fee_type1, fee_amount1, fee_type2, fee_amount2, fee_type3, fee_amount3, fee_type4, fee_amount4, fee_type5, fee_amount5, " +
                        "fee_type6, fee_amount6, fee_type7, fee_amount7, fee_type8, fee_amount8, fee_type9, fee_amount9, fee_type10, fee_amount10, " +
                        "fee_type11, fee_amount11, fee_type12, fee_amount12, fee_type13, fee_amount13, fee_type14, fee_amount14, fee_type15, fee_amount15, " +
                        "fee_type16, fee_amount16, effective_date, tenor, expiry_date, Repayment_Agreement_Mode, Performance_Repayment_Status, Reason_For_Restructuring," +
                        "Interest_Rate, Beneficiary_Account_Number, Location_of_Beneficiary, Relationship_Type, Funding_Source_Category, ECCI_Number, Funding_Source, Specialised_Loan, Specialised_Loan_Period, " +
                        "Director_Id_Type1, Director_Id_Number1, Director_Id_Email1, Director_Id_Type2, Director_Id_Number2, Director_Id_Email2, Director_Id_Type3, Director_Id_Number3, Director_Id_Email3, " +
                        "Director_Id_Type4, Director_Id_Number4, Director_Id_Email4, Director_Id_Type5, Director_Id_Number5, Director_Id_Email5, " +
                        "Collateral_Present1, " +
                        "Collateral_Secure1, Security_Type1, Address_of_Security1, Owner_of_Security1, Security_Id_Type1, Security_Id_Number1, " +
                        "Collateral_Secure2, Security_Type2, Address_of_Security2, Owner_of_Security2, Security_Id_Type2, Security_Id_Number2, " +
                        "Collateral_Secure3, Security_Type3, Address_of_Security3, Owner_of_Security3, Security_Id_Type3, Security_Id_Number3, " +
                        "Collateral_Secure4, Security_Type4, Address_of_Security4, Owner_of_Security4, Security_Id_Type4, Security_Id_Number4, " +
                        "Collateral_Secure5, Security_Type5, Address_of_Security5, Owner_of_Security5, Security_Id_Type5, Security_Id_Number5, " +
                        "Collateral_Secure6, Security_Type6, Address_of_Security6, Owner_of_Security6, Security_Id_Type6, Security_Id_Number6, " +
                        "Collateral_Secure7, Security_Type7, Address_of_Security7, Owner_of_Security7, Security_Id_Type7, Security_Id_Number7, " +
                        "Collateral_Secure8, Security_Type8, Address_of_Security8, Owner_of_Security8, Security_Id_Type8, Security_Id_Number8, " +
                        "Collateral_Secure9, Security_Type9, Address_of_Security9, Owner_of_Security9, Security_Id_Type9, Security_Id_Number9, " +
                        "Collateral_Secure10, Security_Type10, Address_of_Security10, Owner_of_Security10, Security_Id_Type10, Security_Id_Number10, " +
                        "Guarantee1, Guarantee_Type1, Guarantor_Id_Type1, Guarantor_Id_Number1, Amount_Guaranteed1, " +
                        "Guarantee_Type2, Guarantor_Id_Type2, Guarantor_Id_Number2, Amount_Guaranteed2, " +
                        "Guarantee_Type3, Guarantor_Id_Type3, Guarantor_Id_Number3, Amount_Guaranteed3, " +
                        "Guarantee_Type4, Guarantor_Id_Type4, Guarantor_Id_Number4, Amount_Guaranteed4, " +
                        "Guarantee_Type5, Guarantor_Id_Type5, Guarantor_Id_Number5, Amount_Guaranteed5, " +
                        "inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @Unique_Identifcation_Type, @Unique_Identifcation_Number, " +
                        "@CRMS_Reference_Number, @credit_type, @credit_limit, @outstanding_amount, " +
                        "@fee_type1, @fee_amount1, @fee_type2, @fee_amount2, @fee_type3, @fee_amount3, @fee_type4, @fee_amount4, @fee_type5, @fee_amount5, " +
                        "@fee_type6, @fee_amount6, @fee_type7, @fee_amount7, @fee_type8, @fee_amount8, @fee_type9, @fee_amount9, @fee_type10, @fee_amount10," +
                        "@fee_type11, @fee_amount11, @fee_type12, @fee_amount12, @fee_type13, @fee_amount13, @fee_type14, @fee_amount14, @fee_type15, @fee_amount15," +
                        "@fee_type16, @fee_amount16, @effective_date, @tenor, @expiry_date, @Repayment_Agreement_Mode, @Performance_Repayment_Status, @Reason_For_Restructuring, " +
                        "@interest_rate, @Beneficiary_Account_Number, @Location_of_Beneficiary, @Relationship_Type, @Funding_Source_Category, @ECCI_Number, @Funding_Source, @Specialised_Loan, @Specialised_Loan_Period, " +
                        "@Director_Id_Type1, @Director_Id_Number1, @Director_Id_Email1, @Director_Id_Type2, @Director_Id_Number2, @Director_Id_Email2, " +
                        "@Director_Id_Type3, @Director_Id_Number3, @Director_Id_Email3, @Director_Id_Type4, @Director_Id_Number4, @Director_Id_Email4, " +
                        "@Director_Id_Type5, @Director_Id_Number5, @Director_Id_Email5, " +
                        "@Collateral_Present1, @Collateral_Secure1, @Security_Type1, @Address_of_Security1, @Owner_of_Security1, @Security_Id_Type1, @Security_Id_Number1, " +
                        "@Collateral_Secure2, @Security_Type2, @Address_of_Security2, @Owner_of_Security2, @Security_Id_Type2, @Security_Id_Number2, " +
                        "@Collateral_Secure3, @Security_Type3, @Address_of_Security3, @Owner_of_Security3, @Security_Id_Type3, @Security_Id_Number3, " +
                        "@Collateral_Secure4, @Security_Type4, @Address_of_Security4, @Owner_of_Security4, @Security_Id_Type4, @Security_Id_Number4, " +
                        "@Collateral_Secure5, @Security_Type5, @Address_of_Security5, @Owner_of_Security5, @Security_Id_Type5, @Security_Id_Number5, " +
                        "@Collateral_Secure6, @Security_Type6, @Address_of_Security6, @Owner_of_Security6, @Security_Id_Type6, @Security_Id_Number6, " +
                        "@Collateral_Secure7, @Security_Type7, @Address_of_Security7, @Owner_of_Security7, @Security_Id_Type7, @Security_Id_Number7, " +
                        "@Collateral_Secure8, @Security_Type8, @Address_of_Security8, @Owner_of_Security8, @Security_Id_Type8, @Security_Id_Number8, " +
                        "@Collateral_Secure9, @Security_Type9, @Address_of_Security9, @Owner_of_Security9, @Security_Id_Type9, @Security_Id_Number9, " +
                        "@Collateral_Secure10, @Security_Type10, @Address_of_Security10, @Owner_of_Security10, @Security_Id_Type10, @Security_Id_Number10, " +
                        "@Guarantee1, @Guarantee_Type1, @Guarantor_Id_Type1, @Guarantor_Id_Number1, @Amount_Guaranteed1, " +
                        " @Guarantee_Type2, @Guarantor_Id_Type2, @Guarantor_Id_Number2, @Amount_Guaranteed2, " +
                        " @Guarantee_Type3, @Guarantor_Id_Type3, @Guarantor_Id_Number3, @Amount_Guaranteed3, " +
                        " @Guarantee_Type4, @Guarantor_Id_Type4, @Guarantor_Id_Number4, @Amount_Guaranteed4, " +
                        " @Guarantee_Type5, @Guarantor_Id_Type5, @Guarantor_Id_Number5, @Amount_Guaranteed5, " +
                        "@inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Type", SqlDbType.NVarChar).Value = uniqueIdentificaionType;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Number", SqlDbType.NVarChar).Value = uniqueIdentificaionNumber;
                    cmd.Parameters.AddWithValue("@CRMS_Reference_Number", SqlDbType.NVarChar).Value = crmsRefNo;
                    cmd.Parameters.AddWithValue("@credit_type", SqlDbType.NVarChar).Value = creditType;
                    cmd.Parameters.AddWithValue("@credit_limit", SqlDbType.Decimal).Value = creditLimit;
                    cmd.Parameters.AddWithValue("@outstanding_amount", SqlDbType.Decimal).Value = outstandingAmount;
                    cmd.Parameters.AddWithValue("@fee_type1", SqlDbType.NVarChar).Value = feeTypeCode1;
                    cmd.Parameters.AddWithValue("@fee_amount1", SqlDbType.Decimal).Value = feeAmount1;
                    cmd.Parameters.AddWithValue("@fee_type2", SqlDbType.NVarChar).Value = feeTypeCode2;
                    cmd.Parameters.AddWithValue("@fee_amount2", SqlDbType.Decimal).Value = feeAmount2;
                    cmd.Parameters.AddWithValue("@fee_type3", SqlDbType.NVarChar).Value = feeTypeCode3;
                    cmd.Parameters.AddWithValue("@fee_amount3", SqlDbType.Decimal).Value = feeAmount3;
                    cmd.Parameters.AddWithValue("@fee_type4", SqlDbType.NVarChar).Value = feeTypeCode4;
                    cmd.Parameters.AddWithValue("@fee_amount4", SqlDbType.Decimal).Value = feeAmount4;
                    cmd.Parameters.AddWithValue("@fee_type5", SqlDbType.NVarChar).Value = feeTypeCode5;
                    cmd.Parameters.AddWithValue("@fee_amount5", SqlDbType.Decimal).Value = feeAmount5;
                    cmd.Parameters.AddWithValue("@fee_type6", SqlDbType.NVarChar).Value = feeTypeCode6;
                    cmd.Parameters.AddWithValue("@fee_amount6", SqlDbType.Decimal).Value = feeAmount6;
                    cmd.Parameters.AddWithValue("@fee_type7", SqlDbType.NVarChar).Value = feeTypeCode7;
                    cmd.Parameters.AddWithValue("@fee_amount7", SqlDbType.Decimal).Value = feeAmount7;
                    cmd.Parameters.AddWithValue("@fee_type8", SqlDbType.NVarChar).Value = feeTypeCode8;
                    cmd.Parameters.AddWithValue("@fee_amount8", SqlDbType.Decimal).Value = feeAmount8;
                    cmd.Parameters.AddWithValue("@fee_type9", SqlDbType.NVarChar).Value = feeTypeCode9;
                    cmd.Parameters.AddWithValue("@fee_amount9", SqlDbType.Decimal).Value = feeAmount9;
                    cmd.Parameters.AddWithValue("@fee_type10", SqlDbType.NVarChar).Value = feeTypeCode10;
                    cmd.Parameters.AddWithValue("@fee_amount10", SqlDbType.Decimal).Value = feeAmount10;
                    cmd.Parameters.AddWithValue("@fee_type11", SqlDbType.NVarChar).Value = feeTypeCode11;
                    cmd.Parameters.AddWithValue("@fee_amount11", SqlDbType.Decimal).Value = feeAmount11;
                    cmd.Parameters.AddWithValue("@fee_type12", SqlDbType.NVarChar).Value = feeTypeCode12;
                    cmd.Parameters.AddWithValue("@fee_amount12", SqlDbType.Decimal).Value = feeAmount12;
                    cmd.Parameters.AddWithValue("@fee_type13", SqlDbType.NVarChar).Value = feeTypeCode13;
                    cmd.Parameters.AddWithValue("@fee_amount13", SqlDbType.Decimal).Value = feeAmount13;
                    cmd.Parameters.AddWithValue("@fee_type14", SqlDbType.NVarChar).Value = feeTypeCode14;
                    cmd.Parameters.AddWithValue("@fee_amount14", SqlDbType.Decimal).Value = feeAmount14;
                    cmd.Parameters.AddWithValue("@fee_type15", SqlDbType.NVarChar).Value = feeTypeCode15;
                    cmd.Parameters.AddWithValue("@fee_amount15", SqlDbType.Decimal).Value = feeAmount15;
                    cmd.Parameters.AddWithValue("@fee_type16", SqlDbType.NVarChar).Value = feeTypeCode16;
                    cmd.Parameters.AddWithValue("@fee_amount16", SqlDbType.Decimal).Value = feeAmount16;
                    cmd.Parameters.AddWithValue("@effective_date", SqlDbType.Date).Value = effectiveDate;
                    cmd.Parameters.AddWithValue("@tenor", SqlDbType.Int).Value = tenor;
                    cmd.Parameters.AddWithValue("@expiry_date", SqlDbType.Date).Value = expiryDate;
                    cmd.Parameters.AddWithValue("@Repayment_Agreement_Mode", SqlDbType.NVarChar).Value = repaymentAgreement;
                    cmd.Parameters.AddWithValue("@Performance_Repayment_Status", SqlDbType.NVarChar).Value = performanceRepayment;
                    cmd.Parameters.AddWithValue("@Reason_For_Restructuring", SqlDbType.Text).Value = reasonForRestructuring;
                    cmd.Parameters.AddWithValue("@interest_rate", SqlDbType.Decimal).Value = interestRate;
                    cmd.Parameters.AddWithValue("@Beneficiary_Account_Number", SqlDbType.NVarChar).Value = beneficiaryAccount;
                    cmd.Parameters.AddWithValue("@Location_of_Beneficiary", SqlDbType.NVarChar).Value = beneficiaryLocation;
                    cmd.Parameters.AddWithValue("@Relationship_Type", SqlDbType.NVarChar).Value = relationshipType;
                    cmd.Parameters.AddWithValue("@Funding_Source_Category", SqlDbType.NVarChar).Value = fundingSourceCategory;
                    cmd.Parameters.AddWithValue("@ECCI_Number", SqlDbType.NVarChar).Value = ecciNumber;
                    cmd.Parameters.AddWithValue("@Funding_Source", SqlDbType.NVarChar).Value = fundingSource;
                    cmd.Parameters.AddWithValue("@Specialised_Loan", SqlDbType.NVarChar).Value = specialisedLoan;
                    cmd.Parameters.AddWithValue("@Specialised_Loan_Period", SqlDbType.Int).Value = specialisedLoanPeriod;

                    cmd.Parameters.AddWithValue("@Director_Id_Type1", SqlDbType.NVarChar).Value = dUniqueIdentificaionType1;
                    cmd.Parameters.AddWithValue("@Director_Id_Number1", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber1;
                    cmd.Parameters.AddWithValue("@Director_Id_Email1", SqlDbType.NVarChar).Value = dEmail1;

                    cmd.Parameters.AddWithValue("@Director_Id_Type2", SqlDbType.NVarChar).Value = dUniqueIdentificaionType2 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number2", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber2 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email2", SqlDbType.NVarChar).Value = dEmail2 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type3", SqlDbType.NVarChar).Value = dUniqueIdentificaionType3 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number3", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber3 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email3", SqlDbType.NVarChar).Value = dEmail3 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type4", SqlDbType.NVarChar).Value = dUniqueIdentificaionType4 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number4", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber4 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email4", SqlDbType.NVarChar).Value = dEmail4 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type5", SqlDbType.NVarChar).Value = dUniqueIdentificaionType5 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number5", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber5 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email5", SqlDbType.NVarChar).Value = dEmail5 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_present1", SqlDbType.NVarChar).Value = collateralPresent1;
                    cmd.Parameters.AddWithValue("@collateral_secure1", SqlDbType.NVarChar).Value = collateralSecure1 ?? "";
                    cmd.Parameters.AddWithValue("@security_type1", SqlDbType.NVarChar).Value = securityCode1 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security1", SqlDbType.NVarChar).Value = addressOfSecurity1 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security1", SqlDbType.NVarChar).Value = ownerOfSecurity1 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type1", SqlDbType.NVarChar).Value = sUniqueIdentificaionType1 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number1", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber1 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure2", SqlDbType.NVarChar).Value = collateralSecure2 ?? "";
                    cmd.Parameters.AddWithValue("@security_type2", SqlDbType.NVarChar).Value = securityCode2 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security2", SqlDbType.NVarChar).Value = addressOfSecurity2 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security2", SqlDbType.NVarChar).Value = ownerOfSecurity2 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type2", SqlDbType.NVarChar).Value = sUniqueIdentificaionType2 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number2", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber2 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure3", SqlDbType.NVarChar).Value = collateralSecure3 ?? "";
                    cmd.Parameters.AddWithValue("@security_type3", SqlDbType.NVarChar).Value = securityCode3 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security3", SqlDbType.NVarChar).Value = addressOfSecurity3 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security3", SqlDbType.NVarChar).Value = ownerOfSecurity3 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type3", SqlDbType.NVarChar).Value = sUniqueIdentificaionType3 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number3", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber3 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure4", SqlDbType.NVarChar).Value = collateralSecure4 ?? "";
                    cmd.Parameters.AddWithValue("@security_type4", SqlDbType.NVarChar).Value = securityCode4 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security4", SqlDbType.NVarChar).Value = addressOfSecurity4 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security4", SqlDbType.NVarChar).Value = ownerOfSecurity4 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type4", SqlDbType.NVarChar).Value = sUniqueIdentificaionType4 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number4", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber4 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure5", SqlDbType.NVarChar).Value = collateralSecure5 ?? "";
                    cmd.Parameters.AddWithValue("@security_type5", SqlDbType.NVarChar).Value = securityCode5 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security5", SqlDbType.NVarChar).Value = addressOfSecurity5 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security5", SqlDbType.NVarChar).Value = ownerOfSecurity5 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type5", SqlDbType.NVarChar).Value = sUniqueIdentificaionType5 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number5", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber5 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure6", SqlDbType.NVarChar).Value = collateralSecure6 ?? "";
                    cmd.Parameters.AddWithValue("@security_type6", SqlDbType.NVarChar).Value = securityCode6 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security6", SqlDbType.NVarChar).Value = addressOfSecurity6 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security6", SqlDbType.NVarChar).Value = ownerOfSecurity6 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type6", SqlDbType.NVarChar).Value = sUniqueIdentificaionType6 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number6", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber6 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure7", SqlDbType.NVarChar).Value = collateralSecure7 ?? "";
                    cmd.Parameters.AddWithValue("@security_type7", SqlDbType.NVarChar).Value = securityCode7 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security7", SqlDbType.NVarChar).Value = addressOfSecurity7 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security7", SqlDbType.NVarChar).Value = ownerOfSecurity7 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type7", SqlDbType.NVarChar).Value = sUniqueIdentificaionType7 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number7", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber7 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure8", SqlDbType.NVarChar).Value = collateralSecure8 ?? "";
                    cmd.Parameters.AddWithValue("@security_type8", SqlDbType.NVarChar).Value = securityCode8 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security8", SqlDbType.NVarChar).Value = addressOfSecurity8 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security8", SqlDbType.NVarChar).Value = ownerOfSecurity8 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type8", SqlDbType.NVarChar).Value = sUniqueIdentificaionType8 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number8", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber8 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure9", SqlDbType.NVarChar).Value = collateralSecure9 ?? "";
                    cmd.Parameters.AddWithValue("@security_type9", SqlDbType.NVarChar).Value = securityCode9 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security9", SqlDbType.NVarChar).Value = addressOfSecurity9 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security9", SqlDbType.NVarChar).Value = ownerOfSecurity9 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type9", SqlDbType.NVarChar).Value = sUniqueIdentificaionType9 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number9", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber9 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure10", SqlDbType.NVarChar).Value = collateralSecure10 ?? "";
                    cmd.Parameters.AddWithValue("@security_type10", SqlDbType.NVarChar).Value = securityCode10 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security10", SqlDbType.NVarChar).Value = addressOfSecurity10 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security10", SqlDbType.NVarChar).Value = ownerOfSecurity10 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type10", SqlDbType.NVarChar).Value = sUniqueIdentificaionType10 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number10", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber10 ?? "";

                    cmd.Parameters.AddWithValue("@Guarantee1", SqlDbType.NVarChar).Value = guarantee1;

                    cmd.Parameters.AddWithValue("@Guarantee_Type1", SqlDbType.NVarChar).Value = guaranteeType1 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type1", SqlDbType.NVarChar).Value = gUniqueIdentificaionType1;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number1", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber1 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed1", SqlDbType.Decimal).Value = amountGuaranteed1;

                    cmd.Parameters.AddWithValue("@Guarantee_Type2", SqlDbType.NVarChar).Value = guaranteeType2 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type2", SqlDbType.NVarChar).Value = gUniqueIdentificaionType2;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number2", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber2 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed2", SqlDbType.Decimal).Value = amountGuaranteed2;

                    cmd.Parameters.AddWithValue("@Guarantee_Type3", SqlDbType.NVarChar).Value = guaranteeType3 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type3", SqlDbType.NVarChar).Value = gUniqueIdentificaionType3;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number3", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber3 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed3", SqlDbType.Decimal).Value = amountGuaranteed3;

                    cmd.Parameters.AddWithValue("@Guarantee_Type4", SqlDbType.NVarChar).Value = guaranteeType4 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type4", SqlDbType.NVarChar).Value = gUniqueIdentificaionType4;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number4", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber4 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed4", SqlDbType.Decimal).Value = amountGuaranteed4;

                    cmd.Parameters.AddWithValue("@Guarantee_Type5", SqlDbType.NVarChar).Value = guaranteeType5 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type5", SqlDbType.NVarChar).Value = gUniqueIdentificaionType5;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number5", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber5 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed5", SqlDbType.Decimal).Value = amountGuaranteed5;

                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean SaveCrms600(String code, String customerId, String accountNumber, String customerName, String syndicationRefNumber, String syndicationName,
           decimal syndicationTotalAmount, String participatingBankCode, String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_600 (Code, Customer_ID, Customer_Account_Number, Customer_Name, Syndication_Reference_Number, Syndication_Name, " +
                        "Syndication_Total_Amount, Participating_Bank_Code, inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @Syndication_Reference_Number, @Syndication_Name, " +
                        "@Syndication_Total_Amount, @Participating_Bank_Code, @inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@Syndication_Reference_Number", SqlDbType.NVarChar).Value = syndicationRefNumber;
                    cmd.Parameters.AddWithValue("@Syndication_Name", SqlDbType.NVarChar).Value = syndicationName;
                    cmd.Parameters.AddWithValue("@Syndication_Total_Amount", SqlDbType.Date).Value = syndicationTotalAmount;
                    cmd.Parameters.AddWithValue("@Participating_Bank_Code", SqlDbType.Int).Value = participatingBankCode;
                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean SaveCrms700(String code, String customerId, String accountNumber, String customerName, String uniqueIdentificaionType, String uniqueIdentificaionNumber,
           String crmsRefNumber, String businessLinesCode, String businessLinesSubsectorCode,
           String feeTypeCode1, decimal feeAmount1, String feeTypeCode2, decimal feeAmount2, String feeTypeCode3, decimal feeAmount3, String feeTypeCode4, decimal feeAmount4,
           String feeTypeCode5, decimal feeAmount5, String feeTypeCode6, decimal feeAmount6, String feeTypeCode7, decimal feeAmount7, String feeTypeCode8, decimal feeAmount8,
           String feeTypeCode9, decimal feeAmount9, String feeTypeCode10, decimal feeAmount10, String feeTypeCode11, decimal feeAmount11, String feeTypeCode12, decimal feeAmount12,
           String feeTypeCode13, decimal feeAmount13, String feeTypeCode14, decimal feeAmount14, String feeTypeCode15, decimal feeAmount15, String feeTypeCode16, decimal feeAmount16,
            int tenor, String beneficiaryAccount, String beneficiaryLocation,
            String relationshipType, String companySize, String fundingSourceCategory, String ecciNumber, String fundingSource, String legalCode, String cBusinessLinesCode,
            String cBusinessLinesSubsectorCode, String specialisedLoan, int specialisedLoanPeriod, String dUniqueIdentificaionType1, String dUniqueIdentificaionNumber1,
            String dEmail1, String dUniqueIdentificaionType2, String dUniqueIdentificaionNumber2, String dEmail2, String dUniqueIdentificaionType3, String dUniqueIdentificaionNumber3,
            String dEmail3, String dUniqueIdentificaionType4, String dUniqueIdentificaionNumber4, String dEmail4, String dUniqueIdentificaionType5, String dUniqueIdentificaionNumber5,
            String dEmail5, String syndication, String syndicationStatus, String syndicationName, decimal syndicationTotalAmount, String syndicationReferenceNumber,
            String collateralPresent1, string collateralSecure1, String securityCode1, String addressOfSecurity1, String ownerOfSecurity1, String sUniqueIdentificaionType1, String sUniqueIdentificaionNumber1,
            string collateralSecure2, String securityCode2, String addressOfSecurity2, String ownerOfSecurity2, String sUniqueIdentificaionType2, String sUniqueIdentificaionNumber2,
            string collateralSecure3, String securityCode3, String addressOfSecurity3, String ownerOfSecurity3, String sUniqueIdentificaionType3, String sUniqueIdentificaionNumber3,
            string collateralSecure4, String securityCode4, String addressOfSecurity4, String ownerOfSecurity4, String sUniqueIdentificaionType4, String sUniqueIdentificaionNumber4,
            string collateralSecure5, String securityCode5, String addressOfSecurity5, String ownerOfSecurity5, String sUniqueIdentificaionType5, String sUniqueIdentificaionNumber5,
            string collateralSecure6, String securityCode6, String addressOfSecurity6, String ownerOfSecurity6, String sUniqueIdentificaionType6, String sUniqueIdentificaionNumber6,
            string collateralSecure7, String securityCode7, String addressOfSecurity7, String ownerOfSecurity7, String sUniqueIdentificaionType7, String sUniqueIdentificaionNumber7,
            string collateralSecure8, String securityCode8, String addressOfSecurity8, String ownerOfSecurity8, String sUniqueIdentificaionType8, String sUniqueIdentificaionNumber8,
            string collateralSecure9, String securityCode9, String addressOfSecurity9, String ownerOfSecurity9, String sUniqueIdentificaionType9, String sUniqueIdentificaionNumber9,
            string collateralSecure10, String securityCode10, String addressOfSecurity10, String ownerOfSecurity10, String sUniqueIdentificaionType10, String sUniqueIdentificaionNumber10,
            String guarantee1, String guaranteeType1, String gUniqueIdentificaionType1, String gUniqueIdentificaionNumber1, decimal amountGuaranteed1,
            String guaranteeType2, String gUniqueIdentificaionType2, String gUniqueIdentificaionNumber2, decimal amountGuaranteed2,
            String guaranteeType3, String gUniqueIdentificaionType3, String gUniqueIdentificaionNumber3, decimal amountGuaranteed3,
            String guaranteeType4, String gUniqueIdentificaionType4, String gUniqueIdentificaionNumber4, decimal amountGuaranteed4,
            String guaranteeType5, String gUniqueIdentificaionType5, String gUniqueIdentificaionNumber5, decimal amountGuaranteed5,
           String inputterId, DateTime inputterDateStamp, String modifierId)
        {
            using (SqlConnection con = new SqlConnection(_databaseCS))
            {
                int rowAffected = 0;
                try
                {
                    con.Open();
                    const string insertQuery =
                        "BEGIN insert into CRMS_700 (Code, Customer_ID, Customer_Account_Number, Customer_Name, Unique_Identifcation_Type, Unique_Identifcation_Number, " +
                        "CRMS_Reference_Number, Credit_Purpose_By_Business_Lines, Credit_Purpose_By_Business_Lines_Subsector, " +
                        "fee_type1, fee_amount1, fee_type2, fee_amount2, fee_type3, fee_amount3, fee_type4, fee_amount4, fee_type5, fee_amount5, " +
                        "fee_type6, fee_amount6, fee_type7, fee_amount7, fee_type8, fee_amount8, fee_type9, fee_amount9, fee_type10, fee_amount10, " +
                        "fee_type11, fee_amount11, fee_type12, fee_amount12, fee_type13, fee_amount13, fee_type14, fee_amount14, fee_type15, fee_amount15, " +
                        "fee_type16, fee_amount16, tenor, Beneficiary_Account_Number, Location_of_Beneficiary, " +
                        "Relationship_Type, Company_Size, Funding_Source_Category, ECCI_Number, Funding_Source, Legal_Status, Classification_By_Business_Lines, Classification_By_Business_Lines_Subsector, Specialised_Loan, Specialised_Loan_Period, " +
                        "Director_Id_Type1, Director_Id_Number1, Director_Id_Email1, Director_Id_Type2, Director_Id_Number2, Director_Id_Email2, Director_Id_Type3, Director_Id_Number3, Director_Id_Email3, " +
                        "Director_Id_Type4, Director_Id_Number4, Director_Id_Email4, Director_Id_Type5, Director_Id_Number5, Director_Id_Email5, " +
                        "Syndication, Syndication_Status, Syndication_Name, Syndication_Total_Amount, Syndication_Reference_Number, Collateral_Present1, " +
                        "Collateral_Secure1, Security_Type1, Address_of_Security1, Owner_of_Security1, Security_Id_Type1, Security_Id_Number1, " +
                        "Collateral_Secure2, Security_Type2, Address_of_Security2, Owner_of_Security2, Security_Id_Type2, Security_Id_Number2, " +
                        "Collateral_Secure3, Security_Type3, Address_of_Security3, Owner_of_Security3, Security_Id_Type3, Security_Id_Number3, " +
                        "Collateral_Secure4, Security_Type4, Address_of_Security4, Owner_of_Security4, Security_Id_Type4, Security_Id_Number4, " +
                        "Collateral_Secure5, Security_Type5, Address_of_Security5, Owner_of_Security5, Security_Id_Type5, Security_Id_Number5, " +
                        "Collateral_Secure6, Security_Type6, Address_of_Security6, Owner_of_Security6, Security_Id_Type6, Security_Id_Number6, " +
                        "Collateral_Secure7, Security_Type7, Address_of_Security7, Owner_of_Security7, Security_Id_Type7, Security_Id_Number7, " +
                        "Collateral_Secure8, Security_Type8, Address_of_Security8, Owner_of_Security8, Security_Id_Type8, Security_Id_Number8, " +
                        "Collateral_Secure9, Security_Type9, Address_of_Security9, Owner_of_Security9, Security_Id_Type9, Security_Id_Number9, " +
                        "Collateral_Secure10, Security_Type10, Address_of_Security10, Owner_of_Security10, Security_Id_Type10, Security_Id_Number10, " +
                        "Guarantee1, Guarantee_Type1, Guarantor_Id_Type1, Guarantor_Id_Number1, Amount_Guaranteed1, " +
                        "Guarantee_Type2, Guarantor_Id_Type2, Guarantor_Id_Number2, Amount_Guaranteed2, " +
                        "Guarantee_Type3, Guarantor_Id_Type3, Guarantor_Id_Number3, Amount_Guaranteed3, " +
                        "Guarantee_Type4, Guarantor_Id_Type4, Guarantor_Id_Number4, Amount_Guaranteed4, " +
                        "Guarantee_Type5, Guarantor_Id_Type5, Guarantor_Id_Number5, Amount_Guaranteed5, " +
                        "inputter_id, inputter_date_stamp, modifier_id, modifier_date_stamp) " +
                        "values " +
                        "(@code, @customer_id, @customer_account_number, @Customer_Name, @Unique_Identifcation_Type, @Unique_Identifcation_Number, " +
                        "@CRMS_Reference_Number, @credit_purpose_by_businesslines, @credit_purpose_by_businesslines_subsector, " +
                        "@fee_type1, @fee_amount1, @fee_type2, @fee_amount2, @fee_type3, @fee_amount3, @fee_type4, @fee_amount4, @fee_type5, @fee_amount5, " +
                        "@fee_type6, @fee_amount6, @fee_type7, @fee_amount7, @fee_type8, @fee_amount8, @fee_type9, @fee_amount9, @fee_type10, @fee_amount10," +
                        "@fee_type11, @fee_amount11, @fee_type12, @fee_amount12, @fee_type13, @fee_amount13, @fee_type14, @fee_amount14, @fee_type15, @fee_amount15," +
                        "@fee_type16, @fee_amount16, @tenor, @Beneficiary_Account_Number, @Location_of_Beneficiary, @Relationship_Type, @Company_Size, " +
                        "@Funding_Source_Category, @ECCI_Number, @Funding_Source, @Legal_Status, @Classification_By_Business_Lines, @Classification_By_Business_Lines_Subsector, @Specialised_Loan, @Specialised_Loan_Period, " +
                        "@Director_Id_Type1, @Director_Id_Number1, @Director_Id_Email1, @Director_Id_Type2, @Director_Id_Number2, @Director_Id_Email2, " +
                        "@Director_Id_Type3, @Director_Id_Number3, @Director_Id_Email3, @Director_Id_Type4, @Director_Id_Number4, @Director_Id_Email4, " +
                        "@Director_Id_Type5, @Director_Id_Number5, @Director_Id_Email5, " +
                        "@Syndication, @Syndication_Status, @Syndication_Name, @Syndication_Total_Amount, @Syndication_Reference_Number, " +
                        "@Collateral_Present1, @Collateral_Secure1, @Security_Type1, @Address_of_Security1, @Owner_of_Security1, @Security_Id_Type1, @Security_Id_Number1, " +
                        "@Collateral_Secure2, @Security_Type2, @Address_of_Security2, @Owner_of_Security2, @Security_Id_Type2, @Security_Id_Number2, " +
                        "@Collateral_Secure3, @Security_Type3, @Address_of_Security3, @Owner_of_Security3, @Security_Id_Type3, @Security_Id_Number3, " +
                        "@Collateral_Secure4, @Security_Type4, @Address_of_Security4, @Owner_of_Security4, @Security_Id_Type4, @Security_Id_Number4, " +
                        "@Collateral_Secure5, @Security_Type5, @Address_of_Security5, @Owner_of_Security5, @Security_Id_Type5, @Security_Id_Number5, " +
                        "@Collateral_Secure6, @Security_Type6, @Address_of_Security6, @Owner_of_Security6, @Security_Id_Type6, @Security_Id_Number6, " +
                        "@Collateral_Secure7, @Security_Type7, @Address_of_Security7, @Owner_of_Security7, @Security_Id_Type7, @Security_Id_Number7, " +
                        "@Collateral_Secure8, @Security_Type8, @Address_of_Security8, @Owner_of_Security8, @Security_Id_Type8, @Security_Id_Number8, " +
                        "@Collateral_Secure9, @Security_Type9, @Address_of_Security9, @Owner_of_Security9, @Security_Id_Type9, @Security_Id_Number9, " +
                        "@Collateral_Secure10, @Security_Type10, @Address_of_Security10, @Owner_of_Security10, @Security_Id_Type10, @Security_Id_Number10, " +
                        "@Guarantee1, @Guarantee_Type1, @Guarantor_Id_Type1, @Guarantor_Id_Number1, @Amount_Guaranteed1, " +
                        " @Guarantee_Type2, @Guarantor_Id_Type2, @Guarantor_Id_Number2, @Amount_Guaranteed2, " +
                        " @Guarantee_Type3, @Guarantor_Id_Type3, @Guarantor_Id_Number3, @Amount_Guaranteed3, " +
                        " @Guarantee_Type4, @Guarantor_Id_Type4, @Guarantor_Id_Number4, @Amount_Guaranteed4, " +
                        " @Guarantee_Type5, @Guarantor_Id_Type5, @Guarantor_Id_Number5, @Amount_Guaranteed5, " +
                        "@inputter_id, @inputter_date_stamp, @modifier_id, @modifier_date_stamp); END;";

                    SqlCommand cmd = new SqlCommand(insertQuery, con);

                    cmd.Parameters.AddWithValue("@code", SqlDbType.NVarChar).Value = code;
                    cmd.Parameters.AddWithValue("@customer_id", SqlDbType.NVarChar).Value = customerId;
                    cmd.Parameters.AddWithValue("@customer_account_number", SqlDbType.NVarChar).Value = accountNumber;
                    cmd.Parameters.AddWithValue("@Customer_Name", SqlDbType.NVarChar).Value = customerName;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Type", SqlDbType.NVarChar).Value = uniqueIdentificaionType;
                    cmd.Parameters.AddWithValue("@Unique_Identifcation_Number", SqlDbType.NVarChar).Value = uniqueIdentificaionNumber;
                    cmd.Parameters.AddWithValue("@CRMS_Reference_Number", SqlDbType.NVarChar).Value = crmsRefNumber;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines", SqlDbType.NVarChar).Value =
                        businessLinesCode;
                    cmd.Parameters.AddWithValue("@credit_purpose_by_businesslines_subsector", SqlDbType.NVarChar).Value =
                        businessLinesSubsectorCode;
                    cmd.Parameters.AddWithValue("@fee_type1", SqlDbType.NVarChar).Value = feeTypeCode1;
                    cmd.Parameters.AddWithValue("@fee_amount1", SqlDbType.Decimal).Value = feeAmount1;
                    cmd.Parameters.AddWithValue("@fee_type2", SqlDbType.NVarChar).Value = feeTypeCode2;
                    cmd.Parameters.AddWithValue("@fee_amount2", SqlDbType.Decimal).Value = feeAmount2;
                    cmd.Parameters.AddWithValue("@fee_type3", SqlDbType.NVarChar).Value = feeTypeCode3;
                    cmd.Parameters.AddWithValue("@fee_amount3", SqlDbType.Decimal).Value = feeAmount3;
                    cmd.Parameters.AddWithValue("@fee_type4", SqlDbType.NVarChar).Value = feeTypeCode4;
                    cmd.Parameters.AddWithValue("@fee_amount4", SqlDbType.Decimal).Value = feeAmount4;
                    cmd.Parameters.AddWithValue("@fee_type5", SqlDbType.NVarChar).Value = feeTypeCode5;
                    cmd.Parameters.AddWithValue("@fee_amount5", SqlDbType.Decimal).Value = feeAmount5;
                    cmd.Parameters.AddWithValue("@fee_type6", SqlDbType.NVarChar).Value = feeTypeCode6;
                    cmd.Parameters.AddWithValue("@fee_amount6", SqlDbType.Decimal).Value = feeAmount6;
                    cmd.Parameters.AddWithValue("@fee_type7", SqlDbType.NVarChar).Value = feeTypeCode7;
                    cmd.Parameters.AddWithValue("@fee_amount7", SqlDbType.Decimal).Value = feeAmount7;
                    cmd.Parameters.AddWithValue("@fee_type8", SqlDbType.NVarChar).Value = feeTypeCode8;
                    cmd.Parameters.AddWithValue("@fee_amount8", SqlDbType.Decimal).Value = feeAmount8;
                    cmd.Parameters.AddWithValue("@fee_type9", SqlDbType.NVarChar).Value = feeTypeCode9;
                    cmd.Parameters.AddWithValue("@fee_amount9", SqlDbType.Decimal).Value = feeAmount9;
                    cmd.Parameters.AddWithValue("@fee_type10", SqlDbType.NVarChar).Value = feeTypeCode10;
                    cmd.Parameters.AddWithValue("@fee_amount10", SqlDbType.Decimal).Value = feeAmount10;
                    cmd.Parameters.AddWithValue("@fee_type11", SqlDbType.NVarChar).Value = feeTypeCode11;
                    cmd.Parameters.AddWithValue("@fee_amount11", SqlDbType.Decimal).Value = feeAmount11;
                    cmd.Parameters.AddWithValue("@fee_type12", SqlDbType.NVarChar).Value = feeTypeCode12;
                    cmd.Parameters.AddWithValue("@fee_amount12", SqlDbType.Decimal).Value = feeAmount12;
                    cmd.Parameters.AddWithValue("@fee_type13", SqlDbType.NVarChar).Value = feeTypeCode13;
                    cmd.Parameters.AddWithValue("@fee_amount13", SqlDbType.Decimal).Value = feeAmount13;
                    cmd.Parameters.AddWithValue("@fee_type14", SqlDbType.NVarChar).Value = feeTypeCode14;
                    cmd.Parameters.AddWithValue("@fee_amount14", SqlDbType.Decimal).Value = feeAmount14;
                    cmd.Parameters.AddWithValue("@fee_type15", SqlDbType.NVarChar).Value = feeTypeCode15;
                    cmd.Parameters.AddWithValue("@fee_amount15", SqlDbType.Decimal).Value = feeAmount15;
                    cmd.Parameters.AddWithValue("@fee_type16", SqlDbType.NVarChar).Value = feeTypeCode16;
                    cmd.Parameters.AddWithValue("@fee_amount16", SqlDbType.Decimal).Value = feeAmount16;
                    cmd.Parameters.AddWithValue("@tenor", SqlDbType.Int).Value = tenor;
                    cmd.Parameters.AddWithValue("@Beneficiary_Account_Number", SqlDbType.NVarChar).Value = beneficiaryAccount;
                    cmd.Parameters.AddWithValue("@Location_of_Beneficiary", SqlDbType.NVarChar).Value = beneficiaryLocation;
                    cmd.Parameters.AddWithValue("@Relationship_Type", SqlDbType.NVarChar).Value = relationshipType;
                    cmd.Parameters.AddWithValue("@Company_Size", SqlDbType.NVarChar).Value = companySize;
                    cmd.Parameters.AddWithValue("@Funding_Source_Category", SqlDbType.NVarChar).Value = fundingSourceCategory;
                    cmd.Parameters.AddWithValue("@ECCI_Number", SqlDbType.NVarChar).Value = ecciNumber ?? "";
                    cmd.Parameters.AddWithValue("@Funding_Source", SqlDbType.NVarChar).Value = fundingSource;
                    cmd.Parameters.AddWithValue("@Legal_Status", SqlDbType.NVarChar).Value = legalCode;
                    cmd.Parameters.AddWithValue("@Classification_By_Business_Lines", SqlDbType.NVarChar).Value = cBusinessLinesCode;
                    cmd.Parameters.AddWithValue("@Classification_By_Business_Lines_Subsector", SqlDbType.NVarChar).Value = cBusinessLinesSubsectorCode;
                    cmd.Parameters.AddWithValue("@Specialised_Loan", SqlDbType.NVarChar).Value = specialisedLoan;
                    cmd.Parameters.AddWithValue("@Specialised_Loan_Period", SqlDbType.Int).Value = specialisedLoanPeriod;

                    cmd.Parameters.AddWithValue("@Director_Id_Type1", SqlDbType.NVarChar).Value = dUniqueIdentificaionType1;
                    cmd.Parameters.AddWithValue("@Director_Id_Number1", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber1;
                    cmd.Parameters.AddWithValue("@Director_Id_Email1", SqlDbType.NVarChar).Value = dEmail1;

                    cmd.Parameters.AddWithValue("@Director_Id_Type2", SqlDbType.NVarChar).Value = dUniqueIdentificaionType2 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number2", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber2 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email2", SqlDbType.NVarChar).Value = dEmail2 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type3", SqlDbType.NVarChar).Value = dUniqueIdentificaionType3 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number3", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber3 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email3", SqlDbType.NVarChar).Value = dEmail3 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type4", SqlDbType.NVarChar).Value = dUniqueIdentificaionType4 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number4", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber4 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email4", SqlDbType.NVarChar).Value = dEmail4 ?? "";

                    cmd.Parameters.AddWithValue("@Director_Id_Type5", SqlDbType.NVarChar).Value = dUniqueIdentificaionType5 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Number5", SqlDbType.NVarChar).Value = dUniqueIdentificaionNumber5 ?? "";
                    cmd.Parameters.AddWithValue("@Director_Id_Email5", SqlDbType.NVarChar).Value = dEmail5 ?? "";

                    cmd.Parameters.AddWithValue("@syndication", SqlDbType.NVarChar).Value = syndication;
                    cmd.Parameters.AddWithValue("@syndication_status", SqlDbType.NVarChar).Value = syndicationStatus;
                    cmd.Parameters.AddWithValue("@Syndication_Name", SqlDbType.NVarChar).Value = syndicationName;
                    cmd.Parameters.AddWithValue("@Syndication_Total_Amount", SqlDbType.Decimal).Value = syndicationTotalAmount;
                    cmd.Parameters.AddWithValue("@syndication_reference_number", SqlDbType.NVarChar).Value = syndicationReferenceNumber;

                    cmd.Parameters.AddWithValue("@collateral_present1", SqlDbType.NVarChar).Value = collateralPresent1;
                    cmd.Parameters.AddWithValue("@collateral_secure1", SqlDbType.NVarChar).Value = collateralSecure1 ?? "";
                    cmd.Parameters.AddWithValue("@security_type1", SqlDbType.NVarChar).Value = securityCode1 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security1", SqlDbType.NVarChar).Value = addressOfSecurity1 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security1", SqlDbType.NVarChar).Value = ownerOfSecurity1 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type1", SqlDbType.NVarChar).Value = sUniqueIdentificaionType1 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number1", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber1 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure2", SqlDbType.NVarChar).Value = collateralSecure2 ?? "";
                    cmd.Parameters.AddWithValue("@security_type2", SqlDbType.NVarChar).Value = securityCode2 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security2", SqlDbType.NVarChar).Value = addressOfSecurity2 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security2", SqlDbType.NVarChar).Value = ownerOfSecurity2 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type2", SqlDbType.NVarChar).Value = sUniqueIdentificaionType2 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number2", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber2 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure3", SqlDbType.NVarChar).Value = collateralSecure3 ?? "";
                    cmd.Parameters.AddWithValue("@security_type3", SqlDbType.NVarChar).Value = securityCode3 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security3", SqlDbType.NVarChar).Value = addressOfSecurity3 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security3", SqlDbType.NVarChar).Value = ownerOfSecurity3 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type3", SqlDbType.NVarChar).Value = sUniqueIdentificaionType3 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number3", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber3 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure4", SqlDbType.NVarChar).Value = collateralSecure4 ?? "";
                    cmd.Parameters.AddWithValue("@security_type4", SqlDbType.NVarChar).Value = securityCode4 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security4", SqlDbType.NVarChar).Value = addressOfSecurity4 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security4", SqlDbType.NVarChar).Value = ownerOfSecurity4 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type4", SqlDbType.NVarChar).Value = sUniqueIdentificaionType4 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number4", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber4 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure5", SqlDbType.NVarChar).Value = collateralSecure5 ?? "";
                    cmd.Parameters.AddWithValue("@security_type5", SqlDbType.NVarChar).Value = securityCode5 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security5", SqlDbType.NVarChar).Value = addressOfSecurity5 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security5", SqlDbType.NVarChar).Value = ownerOfSecurity5 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type5", SqlDbType.NVarChar).Value = sUniqueIdentificaionType5 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number5", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber5 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure6", SqlDbType.NVarChar).Value = collateralSecure6 ?? "";
                    cmd.Parameters.AddWithValue("@security_type6", SqlDbType.NVarChar).Value = securityCode6 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security6", SqlDbType.NVarChar).Value = addressOfSecurity6 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security6", SqlDbType.NVarChar).Value = ownerOfSecurity6 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type6", SqlDbType.NVarChar).Value = sUniqueIdentificaionType6 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number6", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber6 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure7", SqlDbType.NVarChar).Value = collateralSecure7 ?? "";
                    cmd.Parameters.AddWithValue("@security_type7", SqlDbType.NVarChar).Value = securityCode7 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security7", SqlDbType.NVarChar).Value = addressOfSecurity7 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security7", SqlDbType.NVarChar).Value = ownerOfSecurity7 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type7", SqlDbType.NVarChar).Value = sUniqueIdentificaionType7 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number7", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber7 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure8", SqlDbType.NVarChar).Value = collateralSecure8 ?? "";
                    cmd.Parameters.AddWithValue("@security_type8", SqlDbType.NVarChar).Value = securityCode8 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security8", SqlDbType.NVarChar).Value = addressOfSecurity8 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security8", SqlDbType.NVarChar).Value = ownerOfSecurity8 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type8", SqlDbType.NVarChar).Value = sUniqueIdentificaionType8 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number8", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber8 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure9", SqlDbType.NVarChar).Value = collateralSecure9 ?? "";
                    cmd.Parameters.AddWithValue("@security_type9", SqlDbType.NVarChar).Value = securityCode9 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security9", SqlDbType.NVarChar).Value = addressOfSecurity9 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security9", SqlDbType.NVarChar).Value = ownerOfSecurity9 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type9", SqlDbType.NVarChar).Value = sUniqueIdentificaionType9 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number9", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber9 ?? "";

                    cmd.Parameters.AddWithValue("@collateral_secure10", SqlDbType.NVarChar).Value = collateralSecure10 ?? "";
                    cmd.Parameters.AddWithValue("@security_type10", SqlDbType.NVarChar).Value = securityCode10 ?? "";
                    cmd.Parameters.AddWithValue("@Address_of_Security10", SqlDbType.NVarChar).Value = addressOfSecurity10 ?? "";
                    cmd.Parameters.AddWithValue("@Owner_of_Security10", SqlDbType.NVarChar).Value = ownerOfSecurity10 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Type10", SqlDbType.NVarChar).Value = sUniqueIdentificaionType10 ?? "";
                    cmd.Parameters.AddWithValue("@Security_Id_Number10", SqlDbType.NVarChar).Value = sUniqueIdentificaionNumber10 ?? "";

                    cmd.Parameters.AddWithValue("@Guarantee1", SqlDbType.NVarChar).Value = guarantee1;

                    cmd.Parameters.AddWithValue("@Guarantee_Type1", SqlDbType.NVarChar).Value = guaranteeType1 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type1", SqlDbType.NVarChar).Value = gUniqueIdentificaionType1;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number1", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber1 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed1", SqlDbType.Decimal).Value = amountGuaranteed1;

                    cmd.Parameters.AddWithValue("@Guarantee_Type2", SqlDbType.NVarChar).Value = guaranteeType2 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type2", SqlDbType.NVarChar).Value = gUniqueIdentificaionType2;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number2", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber2 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed2", SqlDbType.Decimal).Value = amountGuaranteed2;

                    cmd.Parameters.AddWithValue("@Guarantee_Type3", SqlDbType.NVarChar).Value = guaranteeType3 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type3", SqlDbType.NVarChar).Value = gUniqueIdentificaionType3;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number3", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber3 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed3", SqlDbType.Decimal).Value = amountGuaranteed3;

                    cmd.Parameters.AddWithValue("@Guarantee_Type4", SqlDbType.NVarChar).Value = guaranteeType4 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type4", SqlDbType.NVarChar).Value = gUniqueIdentificaionType4;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number4", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber4 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed4", SqlDbType.Decimal).Value = amountGuaranteed4;

                    cmd.Parameters.AddWithValue("@Guarantee_Type5", SqlDbType.NVarChar).Value = guaranteeType5 ?? "";
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Type5", SqlDbType.NVarChar).Value = gUniqueIdentificaionType5;
                    cmd.Parameters.AddWithValue("@Guarantor_Id_Number5", SqlDbType.NVarChar).Value = gUniqueIdentificaionNumber5 ?? "";
                    cmd.Parameters.AddWithValue("@Amount_Guaranteed5", SqlDbType.Decimal).Value = amountGuaranteed5;

                    cmd.Parameters.AddWithValue("@inputter_id", SqlDbType.NVarChar).Value = inputterId;
                    cmd.Parameters.AddWithValue("@inputter_date_stamp", SqlDbType.Date).Value = inputterDateStamp;
                    cmd.Parameters.AddWithValue("@modifier_id", SqlDbType.NVarChar).Value = modifierId;
                    cmd.Parameters.AddWithValue("@modifier_date_stamp", SqlDbType.NVarChar).Value = DBNull.Value;

                    rowAffected += cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    con.Close();
                }
                if (rowAffected > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}