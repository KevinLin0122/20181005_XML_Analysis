using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using XML_Analysis.Models;

namespace XML_Analysis.repositories
{
    class repository
    {
        public SqlConnection Connection()
        {
            //建立連線
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\20181005_XML_Analysis\20181005_XML_Analysis\XML_Analysis\XML_Analysis\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection myConn = new SqlConnection(strConn);
            return myConn;
        }

    
        public void Insert_Data(SqlConnection conn , OpenData item)
        {
            conn.Open();

            string sql_Insert = "  INSERT INTO sOpenData(companyname, Address, Category) VALUES ( N'" +item.companyname + "',N'" + item.Address +"',N'"+ item.Category + "')" ;

            SqlCommand mySqlCmd = new SqlCommand(sql_Insert, conn);

            mySqlCmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
