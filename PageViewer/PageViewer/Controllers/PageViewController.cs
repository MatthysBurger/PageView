using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PageViewer.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PageViewer.Controllers
{
    public class PageViewController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string searchString)
        {
            PageDirectory availablepageviews = HomeController.GetAvailablePageViews();
            return View(availablepageviews.ApplyFilter(searchString != null ? searchString : string.Empty));
        }

        // GET: Components/Details/5
        public ActionResult Details(int id)
        {
            PageDirectory availablepageviews = HomeController.GetAvailablePageViews();
            PageView pv = availablepageviews.FindPageView(id);
            return View(pv);
        }
    }
}
