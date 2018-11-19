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
    public class clsTaxDetails
    {
        public int Tax_Id,Year_Config_Id;
        public string Tax_Type, Remarks;
        public double Tax_Percentage;
        Authentication clsAut = new Authentication();
        public int GetMaxnumber()
        {
            int id = 0;
            string strQry = string.Empty;
            try
            {
                strQry = "select isnull(max(Tax_Id),0)+1 as id  from TaxDetails";
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
        public int InsertTax()
        {
            int result;
            string strCon = clsAut.GetConnection();
            try
            {
                SqlParameter[] p = new SqlParameter[5];

                p[0] = new SqlParameter("@Tax_Id", Tax_Id);
                p[1] = new SqlParameter("@Tax_Type", Tax_Type);
                p[2] = new SqlParameter("@Remarks", Remarks);
                p[3] = new SqlParameter("@Tax_Percentage", Tax_Percentage);
                p[4] = new SqlParameter("@Year_Config_Id", Year_Config_Id);
               
              
                result = sqlhelper.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "NM_Insert_Tax", p);
                return result;
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { }
        }
        public DataTable fnFillTax()
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
     
       
     
     
    }
}
