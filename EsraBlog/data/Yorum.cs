using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsraBlog.data
{
    public class Yorum
    {
        public int YorumId { get; set; }

        [Required(ErrorMessage = "Lütfen yorumunuzu giriniz.")]
        public string Icerik { get; set; }

        [Required(ErrorMessage = "Lütfen yorumun yapılma tarihini giriniz.")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen yorum yapılma tarihini, doğru bir şekilde giriniz.")]
        public DateTime Tarih { get; set; }

        public virtual Makale Makale { get; set; }

       
        public virtual uye Uye { get; set; }
    }
}