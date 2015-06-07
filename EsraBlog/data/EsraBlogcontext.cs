using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EsraBlog.data
{
    public class EsraBlogcontext : DbContext
    {
     
        public DbSet<Etiket> Etikets { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<uye> Uyes { get; set; }
        public DbSet<Yorum> Yorums { get; set; }

      
    }
}