﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XML_Analysis.Models;
//張祈安姬掰
namespace XML_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var Ebhsdata_Count = findOpenData();
            ShowOpenData(Ebhsdata_Count);
            Console.ReadKey(); 
        }

        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"D:\Github\20181005_XML_Analysis\20181005_XML_Analysis\factory.xml");

            var Ebhsdata_count = xml.Descendants("EBHSDATA").ToList();

            for (var i = 0; i < Ebhsdata_count.Count ; i++)
            {
                var Ebhsdata = Ebhsdata_count[i];
                OpenData item = new OpenData();

                item.companyname = getValue(Ebhsdata, "NAME");
                item.Address = getValue(Ebhsdata, "ADDR");
                item.Category = getValue(Ebhsdata, "CATEGORY");
                result.Add(item);
            };


            return result;
        }

        private static string getValue(XElement Ebhsdata , string propertyName)
        {
            return Ebhsdata.Element(propertyName)?.Value?.Trim();
        }

        public static void ShowOpenData(List<OpenData> Ebhsdata_count)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料 ", Ebhsdata_count.Count ) );
            Ebhsdata_count.GroupBy(Ebhsdata => Ebhsdata.Category).ToList()
                .ForEach(group =>
                    {
                        var key = group.Key;
                        var groupDatas = group.ToList();
                        var message = $"Category:{key},共有{groupDatas.Count()}筆資料";
                        Console.WriteLine(message);
                    }
                );

     
        }
    }
}
