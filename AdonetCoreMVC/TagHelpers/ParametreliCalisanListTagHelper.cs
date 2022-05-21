using AdonetCoreMVC.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers; //Taghelpers kullanıyorsak bunun kütüphanesini sisteme eklemeliyiz.
using System.Configuration;
using System.Text; //StringBuilder kullanım şeklimiz.

namespace AdonetCoreMVC.TagHelpers
{
    [HtmlTargetElement("parametreli-calisan-list")]  //Tag halpers olarak kullanılabilmesi için bir attribute attribute (bağlantı) ile kullanılması gerekiyor ve bunu tanımlıyoruz. Html Tagi standartında yazdığımız için küçük harflerle ve araya tre koyarak oluşturuyorum.
    public class ParametreliCalisanListTagHelper : TagHelper
    {


        private List<Calisan> _calisans; //Calisan tipinde bir değişken oluşturuyoruz.
        public ParametreliCalisanListTagHelper() //ctor ile yapı denetimi methodu oluşturuyoruz.
        {
            _calisans = new List<Calisan> {  //Çalışanlarımızı tanımladık normalde veritabanından çekeriz.
                new Calisan{Id=1, Adi="Samet", Soyadi="Erdem",Maas=2500, Sehir=59},
                new Calisan{Id=2, Adi="Ahmet", Soyadi="Sarıkaya",Maas=2500, Sehir=59},
                new Calisan{Id=3, Adi="Furkan", Soyadi="Furkan",Maas=2500, Sehir=59},
                new Calisan{Id=4, Adi="Mehmet", Soyadi="Mehmet",Maas=2500, Sehir=59}
                };
        }

        private const string sayiyaGoreGetirBaglantiAdi = "sayi"; // Gonderilen 'sayi' yı 'sayiyaGoreGetirBaglantiAdi' değişkene eşle

        [HtmlAttributeName(sayiyaGoreGetirBaglantiAdi)] //Aşağıdaki field'a bir attribute bağlantı eklemiş olduk.yani değerini şuradan al diyoruz.
        public int SayiyaGoreGetir { get; set; } // Public bir field oluşturuyorum.

        public override void Process(TagHelperContext context, TagHelperOutput output) // Override ile process methodunu ezmemiz gerekiyor Bizim için önemli olan parametre output yani bu methoddan sonra dışarı çıkaracağımız
        {
            output.TagName = "div"; // Buradan çıkan listenin div içerisine yazılacağını belirtir.
            var query = _calisans.Take(SayiyaGoreGetir); //Sorgu oluşturmak istiyorum şuandalık datamız içerisinde. Take ile'de gelen değer kadarını al demek.
            StringBuilder metinOlusturucu = new StringBuilder();

            foreach (var calisan in query)
            {
                metinOlusturucu.AppendFormat("<h2><a href='/calisan/detay/{0}'>{1}</a></h2>", calisan.Id, (calisan.Adi + " " + calisan.Soyadi));
            }

            output.Content.SetHtmlContent(metinOlusturucu.ToString()); //output ta tanımlanan div içerisine stringbuilderımızı ekliyoruz.
            base.Process(context, output);
        }

    }
}