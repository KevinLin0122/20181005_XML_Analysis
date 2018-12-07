using HC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Repository
{
    public interface IOpenDataRepository
    {
        void Delete(int id);
        void Insert(OpenData item);
        List<OpenData> SelectAll(string name);
        void Update(OpenData item);
    }
}
