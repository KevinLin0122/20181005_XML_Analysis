using System;
using System.Collections.Generic;
using System.Text;

namespace XML_Analysis.Models
{
    class OpenData
    {
        private string _company;
        private string _address;
        private string _category;
        
        public string companyname { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        
        /*
        public string CompanyName
        { 
            set
            {
                _company = value;
            }

            get
            {
                return _company;
            }
        }

        public string Address
        {
            set
            {
                _address = value;
            }

            get
            {
                return _address;
            }
        }
        public string Category
        {
            set
            {
                _category = value;
            }

            get
            {
                return _category;
            }
        }

        */
    }
}
