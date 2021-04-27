using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Consommi_Tounsi.Models;
using System.Threading.Tasks;

namespace Consommi_Tounsi.Controllers
{
    public class DecisionController : Controller
    {
        // GET: Decision
        public ActionResult ListDecision(int id_recl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("afficherlesDecisions/" + id_recl.ToString()).Result;

            IEnumerable<Decision> dec;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                dec = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Decision>>().Result;
            }
            else
            {
                dec = null;
            }
            return View(dec);
        }

        // GET: Decision/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Decision/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Decision dec, int id_recl)
        {
            string Baseurl = "http://localhost:8089/SpringMVC/servlet/";

            using (var d = new HttpClient())
            {
                d.BaseAddress = new Uri(Baseurl);
                d.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await d.PostAsJsonAsync("saveDecision/" + id_recl.ToString(), dec);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("../Reclamation/ListReclamation");
                }
            }
            return View(dec);
        }

        // GET: Decision/Edit/5
        public ActionResult Edit()
        {
            
            return View();
        }

        // POST: Decision/Edit/5
        [HttpPost]
        public ActionResult Edit(int id_deci, string typedecision, Decision dec)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Decision>("updateDecision/" + id_deci.ToString() + "/" + typedecision.ToString(), dec);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("../Reclamation/ListReclamation");
                }
            }
            return View(dec);
        }

        // GET: Decision/Delete/5
        public ActionResult Delete(int id_deci)
        {
            return View();
        }

        // POST: Decision/Delete/5
        [HttpPost]
        public ActionResult Delete(int id_deci, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("deleteDecision/" + id_deci.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("../Reclamation/ListReclamation");
                }
            }
            return View();
        }

        // GET: Decision/affecterDecisionAReclamation/5
        public ActionResult affecterDecisionAReclamation(int id_deci)
        {
            return View();
        }

        // POST: Decision/affecterDecisionAReclamation/5
        [HttpPost]
        public ActionResult affecterDecisionAReclamation(Decision deci, int id_deci, int id_client)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Decision>("affecterDecisionAReclamation/" + id_client.ToString() + "/" + id_deci.ToString(), deci);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("../Reclamation/ListReclamation");
                }
            }
            return View();
        }

    }
}
