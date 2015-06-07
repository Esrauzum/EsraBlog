using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsraBlog.data;
namespace EsraBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult SonBesMakale()
        {
            
            EsraBlogcontext db = new EsraBlogcontext();

       
           
            List<Makale> makaleListe = db.Makales.OrderByDescending(i => i.Tarih).Take(5).ToList();

           
            return PartialView(makaleListe);
        }

        public ActionResult SonBesYorum()
        {
            EsraBlogcontext db = new EsraBlogcontext();

          
            List<Yorum> yorumListe = db.Yorums.OrderByDescending(i => i.Tarih).Take(5).ToList();

            
            return PartialView(yorumListe);

        }
        public ActionResult MakaleDetay(int makaleId)
        {
            EsraBlogcontext db = new EsraBlogcontext();

       
            Makale makale = (from i in db.Makales where i.MakaleId == makaleId select i).SingleOrDefault();
            return View(makale);
        }
        public ActionResult YorumMakalesi(int yorumId)
        {
            EsraBlogcontext db = new EsraBlogcontext();

            Makale makale = (from i in db.Yorums where i.YorumId == yorumId select i.Makale).SingleOrDefault();
            return View(makale);
        }
     
    }
}