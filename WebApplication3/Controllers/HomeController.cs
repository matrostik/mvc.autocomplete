using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Autocomplete(string term)
       {
           //windows-1255
           string path = HttpContext.Server.MapPath("~/App_Data/streets.xml");

           var text = System.IO.File.ReadAllText(path, System.Text.Encoding.GetEncoding(1255));
           var streets = XDocument.Load(new System.IO.StreamReader(path, System.Text.Encoding.GetEncoding(1255))); 
           List<string> list = new List<string>();
           if (streets.Root != null)
           {
               foreach (var item in streets.Root.Elements("ROW"))
               {
                   string name = item.Element("שם_רחוב").Value;
                   list.Add(name);
               }
           }
           var filteredItems = list.Where(
             item => item.StartsWith(term, StringComparison.InvariantCultureIgnoreCase)
             ).Distinct();
           return Json(filteredItems, JsonRequestBehavior.AllowGet);
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