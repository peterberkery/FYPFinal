using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYPFinal.Models;

namespace FYPFinal.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // List action
        public ActionResult Index()
        {
            FYPEntities db = new FYPEntities();
            List<VoteFinal> votefinal = new List<VoteFinal>();
            votefinal = db.VoteFinals.ToList();
            return View(votefinal);
        }

        // deleting rows action
        public ActionResult Delete(string[] ids)
        {
            // delete selected rows
            int[] id = null;
            if (ids != null)
            {
                id = new int[ids.Length];
                int j = 0;
                foreach (string i in ids)
                {
                    int.TryParse(i, out id[j++]);
                }
            }

            if (id != null && id.Length > 0)
            {
                List<VoteFinal> allSelected = new List<VoteFinal>();
                FYPEntities db = new FYPEntities();
                allSelected = db.VoteFinals.Where(x => id.Contains(x.Vid)).ToList();
                foreach (var i in allSelected)
                {
                    db.VoteFinals.Remove(i);
                }
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}