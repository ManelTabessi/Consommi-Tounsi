using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consommi_Tounsi.Controllers
{
    public class DecisionController : Controller
    {
        // GET: Decision
        public ActionResult Index()
        {
            return View();
        }

        // GET: Decision/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Decision/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Decision/Create
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

        // GET: Decision/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Decision/Edit/5
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

        // GET: Decision/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Decision/Delete/5
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
