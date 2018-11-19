using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BAL
{
    public class clsProductDetails
    {
        public int Product_Id;
           public string Product_Code;
           public string Product_Name;
         
           public double Rate;
           public string Remarks;
           public int Year_Config_Id;
           public int Is_Active=1;
        Authentication clsAut = new Authentication();
        public DataTable fnFillTaxDetails()
        {
            string strqry = string.Empty;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "select * from TaxDetails";
                string strCon = clsAut.GetConnection();
                dtDesignation = sqlhelper.ExecuteDatatable(strCon, CommandType.Text, strqry);


            }

            catch (Exception ex)
            { throw ex; }
            finally
            {

            }
            return dtDesignation;
        }
        public DataTable fnFillProductDetails()
        {
            string strqry = string.Empty;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "select * from product_details Where Is_Active=1";
                string strCon = clsAut.GetConnection();
                dtDesignation = sqlhelper.ExecuteDatatable(strCon, CommandType.Text, strqry);


            }

            catch (Exception ex)
            { throw ex; }
            finally
            {

            }
            return dtDesignation;
        }
        public int GetMaxnumber()
        {
            int id = 0;
            string strQry = string.Empty;
            try
            {
                strQry = "select isnull(max(Product_Id),0)+1 as id  from Product_Details";
                string connection = clsAut.GetConnection();
                using (SqlDataReader rdr = sqlhelper.ExecuteReader(connection, CommandType.Text, strQry))
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            id = Convert.ToInt16(rdr[0]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return id;
        }
        public int InsertProduct()
        {
            int result;
            string strCon = clsAut.GetConnection();
            try
            {
                SqlParameter[] p = new SqlParameter[17];

                p[0] = new SqlParameter("@Product_Id", Product_Id);
                p[1] = new SqlParameter("@Product_Code", Product_Code);
                p[2] = new SqlParameter("@Product_Name", Product_Name);
                p[3] = new SqlParameter("@Rate", Rate);
                p[4] = new SqlParameter("@Remarks", Remarks);


                result = sqlhelper.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "IN_Insert_Product", p);
                return result;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { }
        }
        public int GetFinYearId()
        {
            int id = 0;
            string strQry = string.Empty;
            try
            {
                strQry = "select FinId from FinancialYear Where IsActive=1";
                string connection = clsAut.GetConnection();
                using (SqlDataReader rdr = sqlhelper.ExecuteReader(connection, CommandType.Text, strQry))
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            id = Convert.ToInt16(rdr[0]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return id;
        }
        public int fnDeleteProdcut(int intId)
        {
            int intRes;
            string strQry = string.Empty;

            try
            {
                strQry = "update Product_Details set IS_Active =0 where Product_Id=" + intId;
                string connection = clsAut.GetConnection();
                intRes = sqlhelper.ExecuteNonQuery(connection, CommandType.Text, strQry);
                return intRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

        }
        public double GetTaxPercentage(int TaxID)
        {
            double id = 0;
            string strQry = string.Empty;
            try
            {
                strQry = "select Tax_Percentage  from TaxDetails where Tax_Id="+TaxID;
                string connection = clsAut.GetConnection();
                using (SqlDataReader rdr = sqlhelper.ExecuteReader(connection, CommandType.Text, strQry))
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            id = Convert.ToDouble(rdr[0]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return id;
        }
        public double GetVATPercentage()
        {
            double id = 0;
            string strQry = string.Empty;
            try
            {
                strQry = "select Tax_Percentage  from TaxDetails where Tax_Type like 'VAT%'";
                string connection = clsAut.GetConnection();
                using (SqlDataReader rdr = sqlhelper.ExecuteReader(connection, CommandType.Text, strQry))
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            id = Convert.ToDouble(rdr[0]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return id;
        }
        public int fnFillProductById(int Id)
        {
            int id = 0;
            string strQry = string.Empty;
            try
            {
                strQry = "select *  from Product_Details where Product_Id=" + Id + "";
                string connection = clsAut.GetConnection();
                using (SqlDataReader rdr = sqlhelper.ExecuteReader(connection, CommandType.Text, strQry))
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {

                            Product_Code = Convert.ToString(rdr["Product_Code"]);
                            Product_Name = Convert.ToString(rdr["Product_Name"]);
                          Rate = Convert.ToDouble(rdr["rate_kg"]);
                           
                            Remarks = Convert.ToString(rdr["Remarks"]);
                           

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return id;
        }
     
    }
}
