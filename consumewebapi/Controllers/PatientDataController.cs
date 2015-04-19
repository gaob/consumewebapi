using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumeWebAPI.Helper;
using ConsumeWebAPI.Models;
using System.Web.Helpers;

namespace ConsumeWebAPI.Controllers
{
    public class PatientDataController : Controller
    {
        static readonly IPatientDataRestClient RestClient = new PatientDataRestClient();
        //
        // GET: /PatientData/

        public ActionResult Index()
        {
            //Dummy data.
            List<PatientDataModel> aList = new List<PatientDataModel>();

            aList.Add(new PatientDataModel());

            return View(aList);

            //return View(RestClient.GetAll());
        }

        //
        // GET: /PatientData/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PatientData/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PatientData/Create

        [HttpPost]
        public ActionResult Create(PatientDataModel theModel)
        {
            try
            {
                RestClient.Add(theModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PatientData/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PatientData/Edit/5

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
        // GET: /PatientData/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PatientData/Delete/5

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

        //To be removed
        public ActionResult ChartArrayBasic()
        {
            new Chart(600, 400, ChartTheme.Vanilla)
                .AddTitle("Blood Glucose")
                .AddSeries(
                    chartType: "Line",
                    xField: "Date",
                    markerStep: 1,
                    xValue: new[] { "2015-04-10", "2015-04-11", "2015-04-12", "2015-04-13", "2015-04-14", "2015-04-15", "2015-04-16"},
                    yValues: new[] { "120", "122", "121", "123", "125", "130", "129"})
                .Write(); 

            return null;
        }
    }
}
