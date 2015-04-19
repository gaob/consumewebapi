using System.Web.Mvc;
using ConsumeWebAPI.Helper;
using ConsumeWebAPI.Models;
using System.Web.Helpers;
using System.Collections;

namespace ConsumeWebAPI.Controllers
{
    public class ServerDataController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();
        //
        // GET: /ServerData/

        public ActionResult Index()
        {
            return View(RestClient.GetAll());
        }

        //
        // GET: /ServerData/Details/5

        public ActionResult Details(int id)
        {
            return View(RestClient.GetById(id));
        }

        //
        // GET: /ServerData/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ServerData/Create

        [HttpPost]
        public ActionResult Create(ServerDataModel serverData)
        {
            try
            {
                RestClient.Add(serverData);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ServerData/Edit/5

        public ActionResult Edit(int id)
        {
            return View(RestClient.GetById(id));
        }

        //
        // POST: /ServerData/Edit/5

        [HttpPost]
        public ActionResult Edit(ServerDataModel serverData)
        {
            try
            {
                RestClient.Update(serverData);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ServerData/Delete/5

        public ActionResult Delete(int id)
        {
            return View(RestClient.GetById(id));
        }

        //
        // POST: /ServerData/Delete/5

        [HttpPost]
        public ActionResult Delete(ServerDataModel serverData)
        {
            try
            {
                RestClient.Delete(serverData.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //To be removed.
        public ActionResult ChartArrayBasic()
        {
            var result = RestClient.GetAll();

            ArrayList x_Array = new ArrayList();
            ArrayList y_Array = new ArrayList();

            foreach (var item in result)
            {
                x_Array.Add(item.InitialDate.ToShortDateString());
                y_Array.Add(item.OrderNumber.ToString());
            }

            new Chart(600, 400, ChartTheme.Vanilla)
                .AddTitle("Blood Glucose")
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
