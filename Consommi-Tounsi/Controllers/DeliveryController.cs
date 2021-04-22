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
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                deliv = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery>>().Result;
            }
            else
            {
                deliv = null;
            }
            return View(deliv);
        }

        public ActionResult RechercheLivraisonParLivreur()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/afficherleslivraison/1").Result;

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
        public ActionResult ListLivraison(int id_deliv)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("/SpringMVC/servlet/searchDeliveryById/"+id_deliv).Result;

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
        public ActionResult DispoParDate(DateTime date_debut , DateTime date_fin)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("afficheDispo/"+date_debut+"/"+date_fin).Result;

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


        // GET: Delivery/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
    }
}
