using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XML_Analysis.DataBase;
using XML_Analysis.Models;

namespace XML_Analysis.repositories
{
    public class EFrepository
    {
        private OpenDataDbContext OpenDataDbContext { get; set; }

        public EFrepository()
        {
            OpenDataDbContext = new OpenDataDbContext();
        }

        public List<OpenData> SelectAll(string name)
        {
            var result = new List<OpenData>();
            var query = OpenDataDbContext.OpenData.AsQueryable(); 
           
            return query.ToList();
        }
        public void Insert(OpenData item)
        {
            OpenDataDbContext.OpenData.Add(item);
            OpenDataDbContext.SaveChanges();
        }
        public void Update(OpenData item)
        {
            var exist = OpenDataDbContext.OpenData
                .Where(x => x.id == item.id).SingleOrDefault();
            if (exist == null)
                return;
            exist.companyname = item.companyname;
            exist.Address = item.Address;
            exist.Category = item.Category;
            OpenDataDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var exist = OpenDataDbContext.OpenData
                .Where(x => x.id == id).SingleOrDefault();
            if (exist == null)
                return;
            OpenDataDbContext.OpenData.Remove(exist);
            OpenDataDbContext.SaveChanges();

        }



    }
}
