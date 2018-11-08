using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XML_Analysis.Models;


namespace XML_Analysis.DataBase
{
    public class OpenDataDbContext : DbContext
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Github\20181005_XML_Analysis\20181005_XML_Analysis\XML_Analysis\XML_Analysis\App_Data\Database1.mdf;Integrated Security=True";

            }

        }
        public DbSet<OpenData> OpenData { get; set; }

        public OpenDataDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }



    }
}
