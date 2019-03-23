using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAS.v1.Controllers
{
    public class AcountController : Controller
    {
        // GET: Acount
        public ActionResult Index()
        {
            return View();
        }

        // GET: Acount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Acount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acount/Create
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

        // GET: Acount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Acount/Edit/5
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

        // GET: Acount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acount/Delete/5
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
