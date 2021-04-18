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
    public class publicationController : Controller
    {
        public ActionResult Index()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("getAllPublicationByDate").Result;

        IEnumerable<publication> pub;
        //  long pub1;
        if (httpResponseMessage.IsSuccessStatusCode)
        {

            pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<publication>>().Result;


        }
        else
        {
            pub = null;
        }

        HttpResponseMessage httpResponseMessage1 = client.GetAsync("nbrpub").Result;
        ViewBag.result = httpResponseMessage1.Content.ReadAsAsync<long>().Result;
        return View(pub);
    }



    [HttpPost]
    public ActionResult Index(String subject)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("getPublicationBySubject/" + subject).Result;

        IEnumerable<publication> pub;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<publication>>().Result;


        }
        else
        {
            pub = null;
        }


        return View(pub);
    }


    // GET: publication/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: publication/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(publication pub)
    {
        string Baseurl = "http://localhost:8082/SpringMVC/servlet/";

        using (var pb = new HttpClient())
        {
            pb.BaseAddress = new Uri(Baseurl);
            pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
            var response = await pb.PostAsJsonAsync("addpublication", pub);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("../publication/Index");
            }
        }
        return View(pub);
    }
    public ActionResult Edit(int idpub)
    {
        publication epm = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");
            //HTTP GET
            var responseTask = client.GetAsync("update-publication/" + idpub.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<publication>();
                readTask.Wait();

                epm = readTask.Result;
            }
        }
        return View(epm);
    }


    //
    // POST: /Products/Edit/5

    [HttpPost]
    public ActionResult Edit(publication epm)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.PutAsJsonAsync<publication>("update-publication", epm);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
        }
        return View(epm);
    }
    public ActionResult EditRating(int idpub)
    {
        publication epm = null;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");
            //HTTP GET
            var responseTask = client.GetAsync("updateRating/" + idpub.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<publication>();
                readTask.Wait();

                epm = readTask.Result;
            }
        }
        return View(epm);
    }


    //
    // POST: /Products/Edit/5

    [HttpPost]
    public ActionResult EditRating(publication epm)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.PutAsJsonAsync<publication>("updateRating", epm);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
        }
        return View(epm);
    }

    public ActionResult Delete(int idpub)
    {
        return PartialView();
    }

    // POST: publication/Delete/5
    [HttpPost]
    public ActionResult Delete(int idpub, FormCollection collection)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.DeleteAsync("remove-pub/" + idpub.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
        }
        return PartialView();
    }






    public ActionResult IndexAdmin()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("getAllpubEtatWaiting").Result;

        IEnumerable<publication> pub;
        if (httpResponseMessage.IsSuccessStatusCode)
        {

            pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<publication>>().Result;


        }
        else
        {
            pub = null;
        }


        return View(pub);
    }

    [HttpPost]
    public ActionResult IndexAdmin(String subject)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("getPublicationBySubject/" + subject).Result;

        IEnumerable<publication> pub;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<publication>>().Result;


        }
        else
        {
            pub = null;
        }


        return View(pub);
    }

    public ActionResult DeletepubAdmin(int idpub)
    {
        return View();
    }

    // POST: publication/Delete/5
    [HttpPost]
    public ActionResult DeletepubAdmin(int idpub, FormCollection collection)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.DeleteAsync("remove-pub/" + idpub.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("IndexAdmin");
            }
        }
        return View();
    }
    public ActionResult Accepter(int idpub)
    {
        return View();
    }
    // POST: publication/Delete/5
    [HttpPost]
    public ActionResult Accepter(int idpub, publication pub)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.PutAsJsonAsync<publication>("accpeterpublication/" + idpub.ToString(), pub);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("IndexAdminaccepted");
            }
        }
        return View();
    }

    public ActionResult Refuser(int idpub)
    {
        return View();
    }

    // POST: publication/Delete/5
    [HttpPost]
    public ActionResult Refuser(int idpub, publication pub)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.PutAsJsonAsync<publication>("Refuserpublication/" + idpub.ToString(), pub);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("IndexAdmin");
            }
        }
        return View();
    }


    public ActionResult IndexAdminaccepted()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("getAllPublicationByDate").Result;

        IEnumerable<publication> pub;
        if (httpResponseMessage.IsSuccessStatusCode)
        {

            pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<publication>>().Result;


        }
        else
        {
            pub = null;
        }

        HttpResponseMessage httpResponseMessage1 = client.GetAsync("nbrpub").Result;
        ViewBag.result = httpResponseMessage1.Content.ReadAsAsync<long>().Result;
        return View(pub);
    }

    [HttpPost]
    public ActionResult IndexAdminaccepted(String subject)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage httpResponseMessage = client.GetAsync("getPublicationBySubject/" + subject).Result;

        IEnumerable<publication> pub;
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<publication>>().Result;


        }
        else
        {
            pub = null;
        }


        return View(pub);
    }
    public ActionResult deletePubsWithNoInteraction()
    {
        return View();
    }

    // POST: publication/Delete/5
    [HttpPost]
    public ActionResult deletePubsWithNoInteraction(FormCollection collection)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            //HTTP POST
            var putTask = client.DeleteAsync("deletePubsWithNoInteractionJPQL");
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("IndexAdminaccepted");
            }
        }
        return View();
    }


  }
}
