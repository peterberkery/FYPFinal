using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPFinal.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        // GET: post1
        public ActionResult Post1()
        {
            return View();
        }

        // GET: post2
        public ActionResult Post2()
        {
            return View();
        }
    }
}