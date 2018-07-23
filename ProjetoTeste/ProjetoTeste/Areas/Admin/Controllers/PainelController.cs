using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoTeste.Areas.Admin.Controllers
{
    public class PainelController : Controller
    {
        // GET: Admin/Painel
        public ActionResult Index()
        {
            return View();
        }
    }
}