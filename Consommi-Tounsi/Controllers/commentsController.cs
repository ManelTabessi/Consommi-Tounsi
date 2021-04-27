using Consommi_Tounsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Consommi_Tounsi.Controllers
{
    public class commentsController : Controller
    {
        // GET: comments
        public ActionResult ListCmtrByPub(int idpub)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("findcmtrbypublication/" +idpub.ToString()).Result;

            IEnumerable<comments> com;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                com = httpResponseMessage.Content.ReadAsAsync<IEnumerable<comments>>().Result;


            }
            else
            {
                com = null;
            }

             HttpResponseMessage httpResponseMessage1 = client.GetAsync("nbrcmt/" + idpub.ToString()).Result;
             ViewBag.result = httpResponseMessage1.Content.ReadAsAsync<long>().Result;

            HttpResponseMessage httpResponseMessage2 = client.GetAsync("comtplusperienents").Result;
            ViewBag.result1 = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<Vote>>().Result;

            return View(com);
        }
        public ActionResult ListCmtrByPubEspaceClient(int idpub)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("findcmtrbypublication/" + idpub.ToString()).Result;

            IEnumerable<comments> com;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                com = httpResponseMessage.Content.ReadAsAsync<IEnumerable<comments>>().Result;


            }
            else
            {
                com = null;
            }

            HttpResponseMessage httpResponseMessage1 = client.GetAsync("nbrcmt/" + idpub.ToString()).Result;
            ViewBag.result = httpResponseMessage1.Content.ReadAsAsync<long>().Result;

            HttpResponseMessage httpResponseMessage2 = client.GetAsync("comtplusperienents").Result;
            ViewBag.result1 = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<Vote>>().Result;

            return View(com);
        }
        public ActionResult ListCmtrByPubAdmin(int idpub)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("findcmtrbypublication/" + idpub.ToString()).Result;

            IEnumerable<comments> com;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                com = httpResponseMessage.Content.ReadAsAsync<IEnumerable<comments>>().Result;


            }
            else
            {
                com = null;
            }

            HttpResponseMessage httpResponseMessage1 = client.GetAsync("nbrcmt/" + idpub.ToString()).Result;
            ViewBag.result = httpResponseMessage1.Content.ReadAsAsync<long>().Result;
            return View(com);
        }

        // GET: comments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(comments com,int idpub)
        {
            string Baseurl = "http://localhost:8082/SpringMVC/servlet/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await pb.PostAsJsonAsync("addcomments/"+ idpub.ToString(), com);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("../publication/Index");
                }
            }
            return View(com);
        }

        public ActionResult deleteBadJPQL()
        {
            return View();
        }

        // POST: publication/Delete/5
        [HttpPost]
        public ActionResult deleteBadJPQL(FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("deleteBadJPQL");
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("../publication/IndexAdminaccepted");
                }
            }
            return View();
        }
        public ActionResult Delete(int idcomment)
        {
            return PartialView();
        }

        // POST: publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int idcomment, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.DeleteAsync("remove-com/" + idcomment.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("../publication/IndexEspaceClient");
                }
            }
            return PartialView();
        }

        public ActionResult Edit(int idcomment)
        {
            comments epm = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");
                //HTTP GET
                var responseTask = client.GetAsync("showbycomid/" + idcomment);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<comments>();
                    readTask.Wait();

                    epm = readTask.Result;
                }
            }
            return View(epm);
        }


        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(comments epm, int idpub)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<comments>("update-comment/" + idpub.ToString(), epm);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("../publication/IndexEspaceClient");
                }
            }
            return View(epm);
        }
        public ActionResult NombreLIKEcmt(int idcomment)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("nbrlikecmt/" + idcomment).Result;

            //  long pub1;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                ViewBag.result3 = httpResponseMessage.Content.ReadAsAsync<long>().Result;


            }
            else
            {
                ViewBag.result3 = null;
            }
            HttpResponseMessage httpResponseMessage2 = client.GetAsync("nbrdislikecmt/" + idcomment).Result;
            ViewBag.result4 = httpResponseMessage2.Content.ReadAsAsync<long>().Result;

          
            return View(ViewBag.result3);
        }
    }
}

