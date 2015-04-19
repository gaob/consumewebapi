using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ConsumeWebAPI.Models;

namespace ConsumeWebAPI.Controllers
{
    public class PatientRecordController : Controller
    {
        //
        // GET: /PatientRecord/

        public ActionResult Index()
        {
            List<PatientRecordModel> aList = new List<PatientRecordModel>();

            aList.Add(new PatientRecordModel());

            return View(aList);
        }

        //
        // GET: /PatientRecord/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PatientRecord/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PatientRecord/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PatientRecord/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PatientRecord/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PatientRecord/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PatientRecord/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ChartArrayBasic()
        {
            new Chart(600, 400, ChartTheme.Vanilla)
                .AddTitle("Blood Glucose")
                .AddSeries(
                    chartType: "Line",
                    xField: "Date",
                    markerStep: 1,
                    xValue: new[] { "2015-04-10", "2015-04-11", "2015-04-12", "2015-04-13", "2015-04-14", "2015-04-15", "2015-04-16" },
                    yValues: new[] { "120", "122", "121", "123", "125", "130", "129" })
                .Write();

            return null;
        }
    }
}
