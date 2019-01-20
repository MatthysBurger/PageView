using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PageViewer.Data;
using PageViewer.Models;

namespace PageViewer.Controllers
{
    public class HomeController : Controller
    {
        // GET: PageViews
        public ActionResult Index(string searchString)
        {
            PageDirectory availablepageviews = GetAvailablePageViews();
            return View(availablepageviews.ApplyFilter(searchString != null?searchString:string.Empty));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static PageDirectory _RootPD;

        public static PageDirectory GetAvailablePageViews()
        {
            if (_RootPD == null)
            {
                FileInfo fi = new FileInfo(typeof(PageView).Assembly.Location);

                string simupagepath = fi.Directory.FullName + @"\wwwroot\simupages\";

                DirectoryInfo pdi = new DirectoryInfo(simupagepath);

                _RootPD = PageDirectory.BuildRootPageDirectory(pdi);
            }

            return _RootPD;
        }

    }
}
