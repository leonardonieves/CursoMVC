using CursoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string user, string password)
        {
            try 
            {
                using (cursomvcEntities db = new cursomvcEntities())
                {
                    var lst = from u in db.user
                              where u.email == user && u.password == password && u.idState == 1
                              select u;
                    if (lst.Count() > 0)
                    {
                        user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else 
                    {
                        return Content("Usuario invalido:(");
                    }
                }
                    
            }
            catch (Exception e) 
            {
                return Content("Ocurrio un error:(" + e.Message);
            }
        }
    }
}