using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChartLibrary;
using FYPFinal.Models;

namespace FYPFinal.Controllers
{
    public class FundController : Controller
    {
        // GET: Fund
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FundChart()
        {
            FundInstance objFundInstance = new FundInstance();
            FundDAL objFundRecord = new FundDAL();
            try
            {
                objFundInstance.FundInstanceList = objFundRecord.GetFundDetails();
                return View("~/Views/Fund/FundChart.cshtml", objFundInstance);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public JsonResult FundDashboardList(Int16? fundId)
        {
            FundInstance objFundInstance = new FundInstance();
            FundDAL objFundRecords = new FundDAL();
            if (object.Equals(fundId, null))
            {
                fundId = 1;
            }
            try
            {
                var response = objFundRecords.GetFundRecordByFundId(fundId);
                if (!object.Equals(response, null))
                {
                    objFundInstance.FundRecordsList = response.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(objFundInstance.FundRecordsList, JsonRequestBehavior.AllowGet);
        }

        //    private FundInstance db = new FundInstance();
        //    // GET: VTestTbls/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: VTestTbls/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "Vid,Date,VBitcoin,VEthereum,VBitcoinCash,VLitecoin,VRipple")] VoteFinal voteFinal)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.VoteFinals.Add(voteFinal);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        return View(voteFinal);
        //    }
    }
}