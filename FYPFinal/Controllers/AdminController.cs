using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYPFinal.Models;
using System.Net;
using System.Data.Entity;

namespace FYPFinal.Controllers
{
    public class AdminController : Controller
    {
        private FYPEntities db = new FYPEntities();
        // GET: VTestTbls
        public ActionResult Index()
        {
            return View(db.VoteFinals.ToList());
        }

        // GET: VTestTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteFinal voteFinal = db.VoteFinals.Find(id);
            if (voteFinal == null)
            {
                return HttpNotFound();
            }
            return View(voteFinal);
        }

        // GET: VTestTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VTestTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vid,Date,VBitcoin,VEthereum,VBitcoinCash,VLitecoin,VRipple")] VoteFinal voteFinal)
        {
            if (ModelState.IsValid)
            {
                db.VoteFinals.Add(voteFinal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voteFinal);
        }

        // GET: VTestTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteFinal voteFinal = db.VoteFinals.Find(id);
            if (voteFinal == null)
            {
                return HttpNotFound();
            }
            return View(voteFinal);
        }

        // POST: VTestTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vid,Date,VBitcoin,VEthereum,VBitcoinCash,VLitecoin,VRipple")] VoteFinal voteFinal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voteFinal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voteFinal);
        }

        // List action
        public ActionResult List()
        {
            //VoteFinal db = new VoteFinal();
            List<VoteFinal> votelist = new List<VoteFinal>();
            votelist = db.VoteFinals.ToList();
            return View(votelist);
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
                //VoteFinal db = new VoteFinal();
                allSelected = db.VoteFinals.Where(x => id.Contains(x.Vid)).ToList();
                foreach (var i in allSelected)
                {
                    db.VoteFinals.Remove(i);
                }
                db.SaveChanges();
            }
            return RedirectToAction("List", "Admin");
        }
    }
}