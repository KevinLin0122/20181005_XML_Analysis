using HC.DataBase;
using HC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace HC.Web2.Controllers
{
    public class OpenDataController: Controller
    {
        private OpenDataDbContext db;
        public OpenDataDbContext DbContext
        {
            get
            {
                return this.db;
            }
        }
        public OpenDataController()
        {
            db = new OpenDataDbContext();
        }
        public IActionResult Index()
        {
                
            List<OpenData> models = db.OpenData.ToList();

            return View(models);
        }

        public IActionResult Detail(int id, string name)
        {

            var model = db.OpenData.Find(id);
            return View(model);
        }
    }
}
