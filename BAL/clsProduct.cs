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
    public class clsProduct
    {
        Authentication clsAut = new Authentication();
        public string Product_Code, Product_Name, product_uom, Product_hsn,  Remarks,category;
        public float gst, cgst, igst, sgst,product_price;
      

        public int InsertEmployee()
        {
            int result;
            string strQry;
            string strCon = clsAut.GetConnection();
            try
            {
                strQry = "Insert into Product_detailsmaster (Product_code,Product_name,Product_uom,Product_hsn,gst_percentage,sgst_percentage,cgst_percentage,igst_percentage,remarks,is_active,product_price,category_type) values ('" + Product_Code + "','" + Product_Name + "','" + product_uom + "','" + Product_hsn + "','" + gst + "','" + sgst + "','" + cgst + "','" + igst + "','" + Remarks + "',1,'" + product_price + "','" + category + "')";
                
                int Res = sqlhelper.ExecuteNonQuery(strCon, CommandType.Text, strQry);
                return 1;



            }
            catch (Exception ex)
            { throw ex; }
            finally
            { }
        }
        public int fnDeleteEmployee(int intId)
        {
            int intRes;
            string strQry = string.Empty;

            try
            {
                strQry = "update Product_detailsmaster set IS_Active =0 where Product_id=" + intId;
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
        public DataTable fnFillEmployee()
        {
            string strqry = string.Empty;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "select product_id,category_type,product_name,product_uom,product_hsn,product_price,product_code,remarks,gst_percentage,cgst_percentage,sgst_percentage,igst_percentage from Product_detailsmaster where IS_Active= 1 order by product_name ";
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
        public DataTable fnFillgst()
        {
            string strqry = string.Empty;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "select gst_percentage from GST_values ";
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
        public DataTable fnFillgstvalues(string gstpercentage)
        {
            string strqry = string.Empty;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "select cgst_percentage,sgst_percentage,igst_percentage from GST_values where gst_percentage='"+ gstpercentage + "' ";
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
        public DataTable fnFillcategory()
        {
            string strqry = string.Empty;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "select category_type from category_detailsmaster where isactive= 1 ";
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

        public int updateEmployee(string productid)
        {
            int result;
            string strQry;
            string strCon = clsAut.GetConnection();
            try
            {
                strQry = "update Product_detailsmaster set Product_code='" + Product_Code + "',Product_name='" + Product_Name + "',Product_uom='" + product_uom + "',Product_hsn='" + Product_hsn + "',gst_percentage='" + gst + "',sgst_percentage='" + sgst + "',cgst_percentage='" + cgst + "',igst_percentage='" + igst + "',remarks='" + Remarks + "',product_price='" + product_price + "',category_type='"+category+"' where product_id='" + productid + "'";
                int Res = sqlhelper.ExecuteNonQuery(strCon, CommandType.Text, strQry);
                return 1;



            }
            catch (Exception ex)
            { throw ex; }
            finally
            { }
        }
    }
}
