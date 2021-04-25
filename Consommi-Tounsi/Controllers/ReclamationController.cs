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
    public class ReclamationController : Controller
    {
        // GET: Reclamation
        public ActionResult ListReclamation()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/findAllCompl").Result;

            IEnumerable<Reclamation> rec;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                rec = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Reclamation>>().Result;
            }
            else
            {
                rec = null;
            }
            return View(rec);
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reclamation rec)
        {
            string Baseurl = "http://localhost:8089/SpringMVC/servlet/";

            using (var dm = new HttpClient())
            {
                dm.BaseAddress = new Uri(Baseurl);
                dm.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await dm.PostAsJsonAsync("saveCompl/{id_client}", rec);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListReclamation");
                }
            }
            return View(rec);
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reclamation/Edit/5
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

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id_recl)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id_recl, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("removeCompl/" + id_recl.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListReclamation");
                }
            }
            return View();
        }

        public ActionResult recl()
        {
            return View();
        }
    }
}
