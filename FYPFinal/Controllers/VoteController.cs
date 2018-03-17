using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYPFinal.Models;
using System.Web.Helpers;

namespace FYPFinal.Controllers
{
    public class VoteController : Controller
    {
        // Get: Index view for vote
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Vid,Date,Email,VBitcoin,VEthereum,VBitcoinCash,VLitecoin,VRipple")]VoteFinal vote)
        {
            if (ModelState.IsValid)
            {
                using (FYPEntities db = new FYPEntities())
                {
                    db.VoteFinals.Add(vote);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("Dash", "Dash");
        }

        public ActionResult VoteResults()
        {
            return View();
        }

        //usused for now
        public ActionResult CreateVotePie()
        {
            //Create bar chart
            var Vchart = new Chart(width: 300, height: 200)
            .AddSeries(chartType: "pie",
                            xValue: new[] { "10 ", "50", "30 ", "70" },
                            yValues: new[] { "50", "70", "90", "110" })
                            .GetBytes("png");
            return File(Vchart, "~/images");
        }
    }
}