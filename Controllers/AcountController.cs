using SAS.v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SAS.v1.Controllers
{
    public class AcountController : Controller
    {
        // GET: Acount
        public ActionResult Index()
        {
            return View();
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Login(ModeloContainer model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (ModeloContainer objContext = new ModeloContainer())
        //        {
        //            var objUser = objContext.Usuarios.FirstOrDefault(x => x.Cuenta == model.Usuarios.Select(r=>r.Cuenta).ToString() && x.Password == model.Usuarios.Select(p=>p.Password).ToString());
        //            if (objUser == null)
        //            {
        //                ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");
        //            }
        //            else
        //            {
        //                FormsAuthentication.SetAuthCookie(model.Usuarios.Select(x=>x.Cuenta).ToString(), true);

        //                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
        //                   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        //                {
        //                    return Redirect(returnUrl);
        //                }
        //                else
        //                {
        //                    //Redirect to default page
        //                    return RedirectToAction("RedirectToDefault");
        //                }
        //            }
        //        }
        //    }
        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        public ActionResult RedirectToDefault()
        {

            String[] roles = Roles.GetRolesForUser();
            if (roles.Contains("Administrator"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (roles.Contains("Dealer"))
            {
                return RedirectToAction("Index", "Dealer");
            }
            else if (roles.Contains("PublicUser"))
            {
                return RedirectToAction("Index", "PublicUser");
            }
            else
            {
                return RedirectToAction("Index");
            }
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
