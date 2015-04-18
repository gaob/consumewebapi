using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumeWebAPI.Helper;
using ConsumeWebAPI.Models;

namespace ConsumeWebAPI.Controllers
{
    public class PatientDataController : Controller
    {
        //
        // GET: /PatientData/

        public ActionResult Index()
        {
            //Dummy data.
            List<PatientDataModel> aList = new List<PatientDataModel>();

            aList.Add(new PatientDataModel());

            return View(aList);
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
    }
}
