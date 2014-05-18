using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            //LoadXml();
            Db = new ApplicationDbContext();
        }
        
        public List<string> streets { get; set; }
        public ApplicationDbContext Db { get; private set; }

        public ActionResult Index()
        {
            //streets = LoadXml();
            //string path = HttpContext.Server.MapPath("~/App_Data/streets.xml");
            //var xml = XDocument.Load(new System.IO.StreamReader(path, System.Text.Encoding.GetEncoding(1255)));
            //List<string> streets = new List<string>();
            //if (xml.Root != null)
            //{
            //    foreach (var item in xml.Root.Elements("ROW"))
            //    {
            //        var street = new Street();
            //        street.Name = item.Element("שם_רחוב").Value;
            //        street.City = item.Element("שם_ישוב").Value;
            //        Db.Cities.Add(street);
            //        Db.SaveChanges();
            //        //streets.Add(name);
            //    }
            //}




            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<string> LoadXml()
        {
            var path = Server.MapPath("/App_Data/streets.xml");
          
            //string path = HttpContext.Server.MapPath("~/App_Data/streets.xml");
            var xml = XDocument.Load(new System.IO.StreamReader(path, System.Text.Encoding.GetEncoding(1255)));
            List<string> streets = new List<string>();
            if (xml.Root != null)
            {
                foreach (var item in xml.Root.Elements("ROW"))
                {
                    string name = item.Element("שם_רחוב").Value;
                    streets.Add(name);
                }
            }
            return streets;
        }

        public ActionResult Autocomplete(string term)
       {
           //windows-1255
           //string path = HttpContext.Server.MapPath("~/App_Data/streets.xml");

           //var streets = XDocument.Load(new System.IO.StreamReader(path, System.Text.Encoding.GetEncoding(1255))); 
           //List<string> list = new List<string>();
           //if (streets.Root != null)
           //{
           //    foreach (var item in streets.Root.Elements("ROW"))
           //    {
           //        string name = item.Element("שם_רחוב").Value;
           //        list.Add(name);
           //    }
           //}
           //if (streets == null)
           //    return Json("", JsonRequestBehavior.AllowGet);
           int ctr =Db.Cities.Count();
           var filteredItems = Db.Cities.Where(
             item => item.Name.StartsWith(term)
             ).Distinct().ToList();
           List<string> res = filteredItems.Select(x => x.Name).Take(20).ToList();
           return Json(res, JsonRequestBehavior.AllowGet);
           //var items = new[] { "ActionScript",
           //     "AppleScript",
           //     "Asp",
           //     "BASIC",
           //     "C",
           //     "C++",
           //     "Clojure",
           //     "COBOL",
           //     "ColdFusion",
           //     "Erlang",
           //     "Fortran",
           //     "Groovy",
           //     "Haskell",
           //     "Java",
           //     "JavaScript",
           //     "Lisp",
           //     "Perl",
           //     "PHP",
           //     "Python",
           //     "Ruby",
           //     "בדיקה 2",
           //     "בדיקה 1" };

           // var filteredItems = items.Where(
           //     item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
           //     );
           // return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }
    }
}