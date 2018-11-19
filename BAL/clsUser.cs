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
    public class clsUser
    {
        Authentication clsAut = new Authentication();


        public int createuser(string user,string pwd)
        {
            string strqry;
            int intRes;
            DataTable dtDesignation = new DataTable();
            try
            {
                strqry = "insert into users(username,password) values('"+user+"','"+pwd+"') ";
                string connection = clsAut.GetConnection();
                intRes = sqlhelper.ExecuteNonQuery(connection, CommandType.Text, strqry);
                return intRes;

            }

            catch (Exception ex)
            { throw ex; }
        }
        public DataTable getusers()
        {
            string strqry;
            DataTable dtDesignation = new DataTable();
            strqry = "select username from users";
            string connection = clsAut.GetConnection();
            dtDesignation = sqlhelper.ExecuteDatatable(connection, CommandType.Text, strqry);
            return dtDesignation;

        }
        public DataTable getusers(string user)
        {
            string strqry;
            DataTable dtDesignation = new DataTable();
            strqry = "select username,password from users where username='"+user+"'";
            string connection = clsAut.GetConnection();
            dtDesignation = sqlhelper.ExecuteDatatable(connection, CommandType.Text, strqry);
            return dtDesignation;

        }

    }
    
}
