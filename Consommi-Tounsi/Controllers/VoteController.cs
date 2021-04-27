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
    public class VoteController : Controller
    {
        // GET: Vote
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8082/SpringMVC/servlet/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("comtplusperienents").Result;

            IEnumerable<Vote> pub;
            //  long pub1;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                pub = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Vote>>().Result;


            }
            else
            {
                pub = null;
            }

          
            return View(pub);
        }

        public ActionResult Addlike()
        {
            return View();
        }

        // POST: publication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Addlike(Vote v,int idpub)
        {
            string Baseurl = "http://localhost:8082/SpringMVC/servlet/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await pb.PostAsJsonAsync("addlike/"+idpub, v);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("../publication/Index");
                }
            }
            return View(v);
        }

        public ActionResult Addlikebycmt()
        {
            return View();
        }

        // POST: publication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Addlikebycmt(Vote v,int idcomment)
        {
            string Baseurl = "http://localhost:8082/SpringMVC/servlet/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await pb.PostAsJsonAsync("AddLikeBycmt/" + idcomment, v);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("../publication/Index");
                }
            }
            return View(v);
        }

        public ActionResult Adddislikebycmt()
        {
            return View();
        }

        // POST: publication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Adddislikebycmt(Vote v, int idcomment)
        {
            string Baseurl = "http://localhost:8082/SpringMVC/servlet/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await pb.PostAsJsonAsync("AdddisLikeBycmt/" + idcomment, v);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("../publication/Index");
                }
            }
            return View(v);
        }

        public ActionResult AddDislike()
        {
            return View();
        }

        // POST: publication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDislike(Vote v, int idpub)
        {
            string Baseurl = "http://localhost:8082/SpringMVC/servlet/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await pb.PostAsJsonAsync("adddislike/" + idpub, v);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("../publication/Index");
                }
            }
            return View(v);
        }

        // GET: Vote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vote/Create
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

        // GET: Vote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vote/Edit/5
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

        // GET: Vote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vote/Delete/5
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
    }
}
