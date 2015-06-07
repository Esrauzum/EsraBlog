using System;
using EsraBlog.data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace EsraBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            using (EsraBlogcontext db = new EsraBlogcontext())
            {
               
                db.Database.CreateIfNotExists();

                 
                int makaleAdet = (from i in db.Makales select i).Count();
                int yorumAdet = (from i in db.Yorums select i).Count();
                int uyeAdet = (from i in db.Uyes select i).Count();
 
                
                if (makaleAdet < 5 || yorumAdet < 5 || uyeAdet < 1)
                {
                  
                    uye uye = new uye() { Ad = "Esra", Soyad = "ÜZÜM", EPosta = "esra_uzum_19@hotmail.com", ResimYol = "", UyeOlmaTarih = DateTime.Now, WebSite = "",Sifre="deneme" };

                    db.Uyes.Add(uye);


                    Makale makale1 = new Makale() { Baslik = "Bükreş/BELCİKA", Icerik = "Bükres resmi", Tarih = DateTime.Now, Uye = uye };
                    Makale makale2 = new Makale() { Baslik = "Barselona/İSPANYA", Icerik = " Barcelona resmi", Tarih = DateTime.Now, Uye = uye };
                    Makale makale3 = new Makale() { Baslik = "Amsterdam/HOLLANDA", Icerik = "Amsterdam resmi", Tarih = DateTime.Now, Uye = uye };
                    Makale makale4 = new Makale() { Baslik = "Venedik/İTALYA", Icerik = "Venedik resmi", Tarih = DateTime.Now, Uye = uye };
                    Makale makale5 = new Makale() { Baslik = "Budapeste/MACARİSTAN", Icerik = "Budapeste resmi", Tarih = DateTime.Now, Uye = uye };
                    Makale makale6 = new Makale() { Baslik = "Granada/ENDÜLÜS", Icerik = "Granada resmi", Tarih = DateTime.Now, Uye = uye };

                    
                    db.Makales.Add(makale1);
                    db.Makales.Add(makale2);
                    db.Makales.Add(makale3);
                    db.Makales.Add(makale4);
                    db.Makales.Add(makale5);
                    db.Makales.Add(makale6);

                   
                    Yorum yorum1 = new Yorum() { Icerik = "Güzel", Tarih = DateTime.Now, Makale = makale1, Uye = uye };
                    Yorum yorum2 = new Yorum() { Icerik = "harika", Tarih = DateTime.Now, Makale = makale1, Uye = uye };
                    Yorum yorum3 = new Yorum() { Icerik = "süper", Tarih = DateTime.Now, Makale = makale1, Uye = uye };
                    Yorum yorum4 = new Yorum() { Icerik = "Beğenmedim", Tarih = DateTime.Now, Makale = makale1, Uye = uye };
                    Yorum yorum5 = new Yorum() { Icerik = "so so", Tarih = DateTime.Now, Makale = makale1, Uye = uye };
                    Yorum yorum6 = new Yorum() { Icerik = "İdare eder", Tarih = DateTime.Now, Makale = makale1, Uye = uye };

                   
                    db.Yorums.Add(yorum1);
                    db.Yorums.Add(yorum2);
                    db.Yorums.Add(yorum3);
                    db.Yorums.Add(yorum4);
                    db.Yorums.Add(yorum5);
                    db.Yorums.Add(yorum6);

                    
                    db.SaveChanges();
                }
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
