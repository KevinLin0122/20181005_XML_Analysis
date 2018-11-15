using System;
using System.Collections.Generic;
using System.Text;
using XML_Analysis.Models;

namespace XML_Analysis.Service
{
    public class EFImportService
    {
        private repositories.EFrepository _efRepository;
        public EFImportService()
        {
            _efRepository = new repositories.EFrepository();
        }
        public List<OpenData> FindOpenDataFromDb(string name)
        {
            return _efRepository.SelectAll(name);
        }

        


    }
}
