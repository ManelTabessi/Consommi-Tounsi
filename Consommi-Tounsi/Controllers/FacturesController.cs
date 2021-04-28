using Consommi_Tounsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Consommi_Tounsi.Controllers
{
    public class FacturesController : Controller
    {
        // GET: Factures
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("getallInvoices").Result;

            IEnumerable<Factures> facture;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                facture = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Factures>>().Result;


            }
            else
            {
                facture = null;
            }


            return View(facture);
        }

        // GET: Factures/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factures/Create
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

        // GET: Factures/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Factures/Edit/5
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

        // GET: Factures/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Factures/Delete/5
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

        public ActionResult GeneratePDF(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("afficherPDF/" + id.ToString()).Result;

            IEnumerable<Factures> facture;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                facture = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Factures>>().Result;


            }
            else
            {
                facture = null;
            }


            return View(facture);
        }

    }
}
