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
    public class Delivery_ManController : Controller
    {
        // GET: Delivery_Man
        public ActionResult ListLivreur()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/findAllDelivMan").Result;

            IEnumerable<Delivery_Man> delivm;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                delivm = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery_Man>>().Result;
            }
            else
            {
                delivm = null;
            }
            return View(delivm);
        }

        public ActionResult LivreurDispo()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/Disponibilité").Result;

            IEnumerable<Delivery_Man> delivm;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                delivm = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery_Man>>().Result;
            }
            else
            {
                delivm = null;
            }
            return View(delivm);
        }

        public ActionResult LivreurNoDispo()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/NoDisponibilité").Result;

            IEnumerable<Delivery_Man> delivm;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                delivm = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery_Man>>().Result;
            }
            else
            {
                delivm = null;
            }
            return View(delivm);
        }

        [HttpPost]
        public ActionResult ListLivreur(int id_deliv_man)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/searchDelivery_ManById/" + id_deliv_man.ToString()).Result;

            IEnumerable<Delivery_Man> delivm;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                delivm = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Delivery_Man>>().Result;
            }
            else
            {
                delivm = null;
            }
            return View(delivm);
        }

        public ActionResult BestLivreur()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8089");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage1 = client.GetAsync("SpringMVC/servlet/BestLivreur").Result;

            ViewBag.result = httpResponseMessage1.Content.ReadAsAsync<int>().Result;

            return View();
        }

        // GET: Delivery_Man/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delivery_Man/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Delivery_Man delm)
        {
            string Baseurl = "http://localhost:8089/SpringMVC/servlet/";

            using (var dm = new HttpClient())
            {
                dm.BaseAddress = new Uri(Baseurl);
                dm.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await dm.PostAsJsonAsync("saveDelivMan", delm);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListLivreur");
                }
            }
            return View(delm);
        }

        // GET: Delivery_Man/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Delivery_Man/Edit/5
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

        // GET: Delivery_Man/Delete/5
        public ActionResult Delete(int id_deliv_man)
        {
            return View();
        }

        // POST: Delivery_Man/Delete/5
        [HttpPost]
        public ActionResult Delete(int id_deliv_man, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("removeDelivMan/" + id_deliv_man.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListLivreur");
                }
            }
            return View();
        }

        // GET: Delivery_Man/Prime
        public ActionResult Prime()
        {
            return View();
        }

        // POST: Delivery_Man/Prime
        [HttpPost]
        public ActionResult Prime(Delivery_Man deliv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Delivery_Man>("Prime", deliv);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("BestLivreur");
                }
            }
            return View();
        }

        // GET: Delivery_Man/ChargeDeTravail
        public ActionResult ChargeDeTravail(int id_deliv_man)
        {
            return View();
        }

        // POST: Delivery_Man/ChargeDeTravail
        [HttpPost]
        public ActionResult ChargeDeTravail(int id_deliv_man, Delivery_Man deliv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Delivery_Man>("ChargeDeTravail/" + id_deliv_man.ToString(), deliv);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ListLivreur");
                }
            }
            return View();
        }

        // GET: Delivery_Man/Etat
        public ActionResult Etat()
        {
            return View();
        }

        // POST: Delivery_Man/Etat
        [HttpPost]
        public ActionResult Etat(int id_deliv_man, Boolean etat, Delivery_Man deliv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8089/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Delivery_Man>("mettreAjourLivreurBydispo/" + id_deliv_man.ToString() + "/" + etat.ToString(), deliv);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListLivreur");
                }
            }
            return View();
        }



    }

}
