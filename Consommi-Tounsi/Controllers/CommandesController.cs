using Consommi_Tounsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Consommi_Tounsi.Controllers
{
    public class CommandesController : Controller
    {
        // GET: Commandes
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("getallCommandes").Result;

            IEnumerable<Commandes> commande;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                commande = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Commandes>>().Result;


            }
            else
            {
                commande = null;
            }


            return View(commande);
        }

        // GET: Commandes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commandes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Commandes cmd)
        {
            string Baseurl = "http://localhost:8080/SpringMVC/servlet/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await pb.PostAsJsonAsync("addCommande", cmd);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(cmd);
        }

        public async Task<ActionResult> CreatePayment(PaymentIntentDTO pym)
        {
            string Baseurl = "http://localhost:8080/SpringMVC/servlet/stripe/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await pb.PostAsJsonAsync("paymentintent", pym);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(pym);
        }

        // GET: Commandes/Edit/5
        public ActionResult Edit(int id)
        {
            Commandes cmd = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
                //HTTP GET
                var responseTask = client.GetAsync("updateCommandes/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Commandes>();
                    readTask.Wait();

                    cmd = readTask.Result;
                }
            }
            return View(cmd);
        }

        // POST: Commandes/Edit/5
        [HttpPost]
        public ActionResult Edit(Commandes cmd)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Commandes>("updateCommandes", cmd);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(cmd);
        }

        // GET: Commandes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commandes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("removeCommandes/" + id.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return PartialView();
        }
        public ActionResult ListFacture()
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

        /*
        public ActionResult PaymentType(Payment_TYPE? paymentType)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("getFactureByPaymentType/" + paymentType).Result;

            IEnumerable<Commandes> cmd;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                cmd = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Commandes>>().Result;


            }
            else
            {
                cmd = null;
            }


            return View(cmd);
        }
         */

        public ActionResult PaymentTypebyCard()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("getFactureByPaymentType/by_card").Result;

            IEnumerable<Commandes> commande;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                commande = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Commandes>>().Result;


            }
            else
            {
                commande = null;
            }


            return View(commande);
        }

        public ActionResult PaymentTypeatdelivery()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("getFactureByPaymentType/at_delivery").Result;

            IEnumerable<Commandes> commande;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                commande = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Commandes>>().Result;


            }
            else
            {
                commande = null;
            }


            return View(commande);
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


            return RedirectToAction("ListFacture");



            // return View(facture);
        }

        public ActionResult MoreDetails(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("getAllBill_by_Order/" + id.ToString()).Result;

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

