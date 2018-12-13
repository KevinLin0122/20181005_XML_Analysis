
using HC.DataBase;
using HC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HC.Web2.Controllers
{
    public class OpenDataController: Controller
    {
        public IActionResult Index()
        {
            OpenDataDbContext db = new OpenDataDbContext();
           
            List<OpenData> models = db.OpenData.ToList();

            return View(models);
        }
    }
}
