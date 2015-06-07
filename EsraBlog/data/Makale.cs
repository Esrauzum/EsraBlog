using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsraBlog.data
{
    public class Makale
    {
        public int MakaleId { get; set; }

        [Required(ErrorMessage = "Lütfen makalenin başlığını giriniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Makale başlığı 3-50 karakter arasında olmalıdır.")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Lütfen makalenin içeriğini giriniz.")]
        //Girilen metnin, html formatında girilmesini sağlıyoruz.
        [DataType(DataType.Html, ErrorMessage = "Lütfen makale içeriğini html formatında giriniz.")]
        public string Icerik { get; set; }

        [Required(ErrorMessage = "Lütfen makalenin eklenme tarihini giriniz.")]
        [DataType(DataType.DateTime, ErrorMessage = "Lütfen makalenin eklenme  tarihini, doğru bir şekilde giriniz.")]
        public DateTime Tarih { get; set; }

        public virtual uye Uye { get; set; }

        
        public virtual List<Yorum> Yorums { get; set; }

        
        public virtual List<Etiket> Etikets { get; set; }
    }
}