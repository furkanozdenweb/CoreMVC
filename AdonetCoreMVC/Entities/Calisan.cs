using System.ComponentModel.DataAnnotations;  //Label Tag Helper Kullanımı

namespace AdonetCoreMVC.Entities
{
    public class Calisan
    {
        [Display(Name="Id Bilgisi")]
        public int Id { get; set; }
        [Display(Name = "Adınızı Giriniz")]
        public string Adi { get; set; }
        [Display(Name = "Soyadınızı Giriniz")]
        public string Soyadi { get; set; }
        [Display(Name = "Maaş Bilgisi")]
        public decimal Maas { get; set; }
        [Display(Name = "Şehir Bilgisi")]
        public int Sehir { get; set; }
    }
}
