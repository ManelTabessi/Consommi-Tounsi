using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Consommi_Tounsi.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Consommi_Tounsi.Controllers
{
    public class DeliveryController : Controller
    {

        // GET: Delivery
        public ActionResult ListLivraison()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/findAllDeli").Result;

            IEnumerable<Delivery> deliv;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                deliv = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery>>().Result;
            }
            else
            {
                deliv = null;
            }
            return View(deliv);
        }


        [HttpPost]
        public ActionResult ListLivraison(DateTime dated, DateTime datef)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/afficheDispo/" + dated.ToString() + "/" + datef.ToString()).Result;

            IEnumerable<Delivery> deliv;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                deliv = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery>>().Result;
            }
            else
            {
                deliv = null;
            }
            return View(deliv);
        }

        // GET: Delivery/Create

        public ActionResult Create()
        {

            return View();
        }
        // POST: Delivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Delivery del, int id_deliv_man)
        {
            string Baseurl = "http://localhost:8089/SpringMVC/servlet/";

            using (var d = new HttpClient())
            {
                d.BaseAddress = new Uri(Baseurl);
                d.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await d.PostAsJsonAsync("saveDeliv/" + id_deliv_man.ToString(), del);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListLivraison");
                }
            }
            return View(del);
        }

        // GET: Delivery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Delivery/Edit/5
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

        // GET: Delivery/Delete/5
        public ActionResult Delete(int id_deliv)
        {
            return View();
        }

        // POST: Delivery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id_deliv, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("removeDeliv/" + id_deliv.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListLivraison");
                }
            }
            return View();
        }


        // GET: Delivery/Delete/5
        public ActionResult DeleteAuto()
        {
            return View();
        }

        // POST: Delivery/Delete/5
        [HttpPost]
        public ActionResult DeleteAuto(FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("dedeleteDileveryAutolete/");
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListLivraison");
                }
            }
            return View();
        }

        // GET: Delivery_Man/affecterLivraisonALivreur
        public ActionResult affecterLivraisonALivreur()
        {
            return View();
        }

        // POST: Delivery_Man/affecterLivraisonALivreur
        [HttpPost]
        public ActionResult affecterLivraisonALivreur(Delivery deliv, int id_deliv_man, int id_deliv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Delivery>("affecterLivraisonALivreur/" + id_deliv.ToString() + "/" + id_deliv_man.ToString(), deliv);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListLivraison");
                }
            }
            return View();
        }


    }
}
