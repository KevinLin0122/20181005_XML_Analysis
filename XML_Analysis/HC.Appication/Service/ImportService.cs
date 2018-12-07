using HC.Models;
using HC.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace HC.Service
{
    public class ImportService
    {

        public static ImportService CreateForEF()
        {
            return new ImportService(new EFrepository());
        }

        public IOpenDataRepository Repository { get; set; }
        private ImportService(EFrepository repository) { Repository = repository; }

        public List<OpenData> FindOpenDataFromXml()
        {
            List<OpenData> result = new List<OpenData>();

            string baseDir = Directory.GetCurrentDirectory();



            var xml = XElement.Load(System.IO.Path.Combine(baseDir, "App_Data/datagovtw_dataset_20181005.xml"));


            //XNamespace gml = @"http://www.opengis.net/gml/3.2";
            //XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var nodes = xml.Descendants("node").ToList();


            result = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();
                    item.id = int.Parse(getValue(node, "id"));
                    item.companyname = getValue(node, "companyname");
                    item.Address = getValue(node, "Address");
                    item.Category = getValue(node, "Category");
                    return item;
                }).ToList();
            return result;

        }
        public List<OpenData> FindOpenDataFromDb(string name = null)
        {
            return Repository.SelectAll(name);
        }


        public void ImportToDb(List<OpenData> openDatas)
        {

            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });

        }


        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();

        }
    }
}
