using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ConsumeWebAPI.Models;
using ConsumeWebAPI.Helper;
using System.Collections;

namespace ConsumeWebAPI.Controllers
{
    public class PatientRecordController : Controller
    {
        static readonly IPatientDataRestClient RestClient = new PatientDataRestClient();
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
            var result = RestClient.GetRecords();

            ArrayList x_Array = new ArrayList();
            ArrayList y_Array = new ArrayList();

            foreach (var item in result)
            {
                x_Array.Add(item.Time.ToShortDateString());
                y_Array.Add(item.value.ToString());
            }

            new Chart(600, 400, ChartTheme.Vanilla)
                .AddTitle("Blood Pressure")
                .AddSeries(
                    chartType: "Line",
                    xField: "Date",
                    markerStep: 1,
                    xValue: x_Array,
                    yValues: y_Array)
                .Write();

            return null;
        }
    }
}
