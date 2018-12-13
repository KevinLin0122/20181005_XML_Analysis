using HC.Models;
using HC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XML_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
        

           ImportService importService = ImportService.CreateForEF(); ;

            var nodes = importService.FindOpenDataFromDb();

            ShowOpenData(nodes);
            Console.ReadKey();
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
