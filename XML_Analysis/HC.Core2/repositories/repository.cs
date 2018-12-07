using HC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HC.Repository
{
    class repository
    {
        public SqlConnection Connection()
        {
            //建立連線
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\20181005_XML_Analysis\20181005_XML_Analysis\XML_Analysis\XML_Analysis\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection myConn = new SqlConnection(ConnectionString.opendataDB);
            return myConn;
        }

    
        public void Insert_Data(SqlConnection conn , OpenData item)
        {
            try
            {
                conn.Open();

                string sql_Insert = "  INSERT INTO OpenData(companyname, Address, Category) VALUES ( N'" + item.companyname + "',N'" + item.Address + "',N'" + item.Category + "')";

                SqlCommand mySqlCmd = new SqlCommand(sql_Insert, conn);

                mySqlCmd.ExecuteNonQuery();
          
            }
            catch (SqlException e)
            {
               
            }
            finally
            {
                conn.Close();
            }
        }

        public List<OpenData> Select_All_Data(SqlConnection conn, string name)
        {
            
            var result = new List<OpenData>();

            conn.Open();

            var sql_command = new SqlCommand("", conn)  ;
            // SqlCommand mySqlCmd = new SqlCommand(string, conn);
            sql_command.CommandText = string.Format(@"Select Id,companyname,Address,Category From OpenData");
            /*
            if (!string.IsNullOrEmpty(name))
                sql_command.CommandText = $"{sql_command.CommandText}Where Category =N'{name}'";
            */
            var reader = sql_command.ExecuteReader();

            
            while (reader.Read() )
            {
                var item = new OpenData();
                item.id = reader.GetInt32(0);
                item.companyname = reader.GetString(1);
                item.Address = reader.GetString(2);
                item.Category = reader.GetString(3);
                result.Add(item);
            }
          
            conn.Close();
            return result;
           
        }

    }
}
