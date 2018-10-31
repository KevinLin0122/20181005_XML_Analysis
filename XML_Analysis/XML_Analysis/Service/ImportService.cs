using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XML_Analysis.Models;
using XML_Analysis.repositories;

namespace XML_Analysis.Service
{
    class ImportService
    {



        public List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"D:\Github\20181005_XML_Analysis\20181005_XML_Analysis\factory.xml");

            var Ebhsdata_count = xml.Descendants("EBHSDATA").ToList();

            Ebhsdata_count.ToList()
                .ForEach(Ebhsdata =>
                {
                    OpenData item = new OpenData();
                    item.companyname = getValue(Ebhsdata, "NAME");
                    item.Address = getValue(Ebhsdata, "ADDR");
                    item.Category = getValue(Ebhsdata, "CATEGORY");
                    result.Add(item);

                });

            return result;
        }

        public void ImportToDb(List<OpenData> openDatas)
        {
            repository DBoperation = new repository();
            var SqlConn = DBoperation.Connection();
            openDatas.ForEach(new_items =>
            {
                DBoperation.Insert_Data(SqlConn, new_items);
            });

        }

        public List<OpenData> Find_Data_From_Db(string name)
        {
            repository DBoperation = new repository();
            var SqlConn = DBoperation.Connection();
            return  DBoperation.Select_All_Data(SqlConn, name);
            
        }

        private static string getValue(XElement Ebhsdata, string propertyName)
        {
            return Ebhsdata.Element(propertyName)?.Value?.Trim();
        }
    }
}
