using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.Data.OleDb;
using System.Linq;


namespace DAL
{
    public class Authentication
    {
        public string GetConnection()
        {
            try
            {
                //String ConString;
                //ConString = Properties.Settings.Default.DBConnectionString;
                //return ConString;
               //  return "server=.\\SQLEXPRESS;integrated security=true;database=Accounts";
                return "server=.\\SQLEXPRESS;integrated security=true;database=Fcat";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void testing()
        {
        }
    }
}
