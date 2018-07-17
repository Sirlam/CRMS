using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMS.Utils
{
    public class CrmsUtil
    {
        private readonly string _databaseCs;
        private readonly string _flexCubeCs;

        public CrmsUtil()
        {
            _databaseCs = ConfigurationManager.ConnectionStrings["DatabaseCS"].ConnectionString;
            _flexCubeCs = ConfigurationManager.ConnectionStrings["FlexCubeCS"].ConnectionString;
        }
        public List<CrmsData> GetGovernmentCodes()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "SELECT Crms_Code, Name from Govt_Codes";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            GovernmentCode = (rdr["Crms_Code"].ToString()),
                            GovernmentState = (rdr["Name"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetLegalStatus()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "SELECT Code, Status from Legal_Status";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            LegalCode = (rdr["Code"].ToString()),
                            LegalStatus = (rdr["Status"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetCreditType()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "SELECT Crms_Code, Credit_Type from Loan_Types";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            CreditTypeCode = (rdr["Crms_Code"].ToString()),
                            CreditType = (rdr["Credit_Type"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetBusinessLines()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "SELECT Crms_Code, Business_Type from Business_lines";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            BusinessLinesCode = (rdr["Crms_Code"].ToString()),
                            BusinessLines = (rdr["Business_Type"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetBusinessLinesSubSector()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select crms_code, Associated_Business_Line, Business_Type from business_lines_subsectors";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            AssociatedBusinessLine = (rdr["Associated_Business_Line"].ToString()),
                            BusinessLinesSubsectorCode = (rdr["Crms_Code"].ToString()),
                            BusinessLinesSubsector = (rdr["Business_Type"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetFeeType()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Type_Code, Type_Name from fees";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            FeeTypeCode = (rdr["Type_Code"].ToString()),
                            FeeType = (rdr["Type_Name"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetRepaymentAgreementMode()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Code, Repayment_Status from REPAYMENT_AGREEMENT";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            RepaymentAgreementCode = (rdr["Code"].ToString()),
                            RepaymentAgreementMode = (rdr["Repayment_Status"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetSecurityType()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Code, Security_Type from SECURITY_TYPE";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            SecurityCode = (rdr["Code"].ToString()),
                            SecurityType = (rdr["Security_Type"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetRepaymentSource()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Code, Govt_Repayment_Source from REPAYMENT_SOURCE";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            RepaymentSourceCode = (rdr["Code"].ToString()),
                            RepaymentSource = (rdr["Govt_Repayment_Source"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetLocationOfBeneficiary()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select City_code, City_Name, State from LOCATION_OF_BENEFICIARY order by State ASC";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            CityCode = (rdr["City_code"].ToString()),
                            CityName = (rdr["City_Name"].ToString()),
                            State = (rdr["State"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetRelationshipType()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Relationship_code, Type from RELATIONSHIP_TYPE";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            RelationshipCode = (rdr["Relationship_code"].ToString()),
                            RelationshipType = (rdr["Type"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetCompanySize()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Size_code, Size from COMPANY_SIZE";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            CompanySizeCode = (rdr["Size_code"].ToString()),
                            CompanySize = (rdr["Size"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetFundingSource()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "SELECT Funding_Code, Source FROM FUNDING_SOURCE";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            FundingSourceCode = (rdr["Funding_Code"].ToString()),
                            FundingSource = (rdr["Source"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<CrmsData> GetPerformanceRepaymentStatus()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "SELECT Code, Repayment_Status FROM PERFORMANCE_REPAYMENT_STATUS";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            PerformanceRepaymentCode = (rdr["Code"].ToString()),
                            PerformanceRepaymentStatus = (rdr["Repayment_Status"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
        public List<AccountDetails> GetAccountDetails(String accountNumber)
        {
            List<AccountDetails> accountDetails = new List<AccountDetails>();
            string sqlSelect = "select cust_ac_no, ac_desc from fccngn.sttm_cust_account where cust_ac_no = '" + accountNumber + "'";
            using (OracleConnection con = new OracleConnection(_flexCubeCs))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand(sqlSelect, con);
                    con.Open();
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var accountDetail = new AccountDetails()
                        {
                            AccountNumber = (rdr["cust_ac_no"].ToString()),
                            AccountName = (rdr["ac_desc"].ToString())
                        };

                        accountDetails.Add(accountDetail);
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

            return accountDetails;
        }

        public List<CrmsData> GetBankCodes()
        {
            List<CrmsData> crmsDatas = new List<CrmsData>();
            string sqlSelect = "select Bank_Code,Bank_Name from Participating_Bank_Code";
            using (SqlConnection con = new SqlConnection(_databaseCs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var crmsData = new CrmsData()
                        {
                            BankCode = (rdr["Bank_Code"].ToString()),
                            BankName = (rdr["Bank_Name"].ToString())
                        };

                        crmsDatas.Add(crmsData);
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

            return crmsDatas;
        }
    }
}