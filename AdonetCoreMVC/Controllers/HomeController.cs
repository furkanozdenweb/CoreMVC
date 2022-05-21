
using AdonetCoreMVC.Entities;
using AdonetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace AdonetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()  //Controller ilk isteği alıyor. view ise görüntüleme işini hallediyor.
        {
            return View();
        }

        public string Merhaba() // Controllerımızın içerisindeki methodlarra Action diyeceğiz !
        {
            return "Samet Erdem";  //Burada bize view olarak string döndürüyor      
        }


        public ViewResult IlkHtmlSayfam()
        {
            return View();
        }

        public ViewResult IkinciHtmlSayfam()
        {
            return View();
        }


        public ViewResult UcuncuHtmlSayfam()
        {
            return View();
        }


        public ViewResult Ornek1() //ViewResult Döndürecek tipte bir Ornek1 methodu oluşturur.
        {
            List<Calisan> calisanlar = new List<Calisan>
            {
                new Calisan{Id=1, Adi="Samet", Soyadi="Erdem",Maas=2500},
                new Calisan{Id=2, Adi="Ahmet", Soyadi="Sarıkaya",Maas=2500},
                new Calisan{Id=3, Adi="Furkan", Soyadi="Furkan",Maas=2500},
                new Calisan{Id=4, Adi="Mehmet", Soyadi="Mehmet",Maas=2500}
            };
            return View(calisanlar);
        }

        public ViewResult Ornek11() //ViewResult Döndürecek tipte bir Ornek1 methodu oluşturur.
        {
            List<Calisan> calisanlar = new List<Calisan>
            {
                new Calisan{Id=1, Adi="Samet", Soyadi="Erdem",Maas=2500},
                new Calisan{Id=2, Adi="Ahmet", Soyadi="Sarıkaya",Maas=2500},
                new Calisan{Id=3, Adi="Furkan", Soyadi="Furkan",Maas=2500},
                new Calisan{Id=4, Adi="Mehmet", Soyadi="Mehmet",Maas=2500}
            };

            string[] sehirler = new string[] {"Tekirdağ","İstanbul","Ankara" };

            string[] isimler = new string[] { "Tekirdağ", "İstanbul", "Ankara" };

            var calisanGetirModel = new CalisanGetirModel
            {
                Calisanlar = calisanlar,
                Sehirler = sehirler,
                Isimler = isimler
            };

            return View(calisanGetirModel);
        }




        public ViewResult Ornek2() //ViewResult Döndürecek tipte bir Ornek2 methodu oluşturur.
        {
            List<Calisan> calisanlar = new List<Calisan>
            {
                new Calisan{Id=1, Adi="Samet", Soyadi="Erdem",Maas=2500},
                new Calisan{Id=2, Adi="Ahmet", Soyadi="Sarıkaya",Maas=2500},
                new Calisan{Id=3, Adi="Furkan", Soyadi="Furkan",Maas=2500},
                new Calisan{Id=4, Adi="Mehmet", Soyadi="Mehmet",Maas=2500}
            };

            List<string> sehirler = new List<string> { "Tekirdağ", "İstanbul" };

            //encapsulation  - 2 Datayı alıp birleştirip gönderme.

            var calisanListViewModal = new CalisanListViewModel //Yeni bir modal yaratıyoruz.  class ekliyoruz ve public olacak şekilde tanımladık.
            {
                Calisanlar = calisanlar,
                Sehirler = sehirler
            };

            return View(calisanListViewModal);
        }


        public IActionResult Ornek3() // ActionResult türünde nesneler döndürebiliriz. Yapılan istekde bir sıkıntı olmadığında 200 geri döndürürüz.
        {
            return StatusCode(200);
            // return Ok() ;
        }

        public IActionResult Ornek4() // ActionResult türünde nesneler döndürebiliriz. Yapılan istekte Bad request 400 hatası verdirdik. Sayfa kaynağını görüntülediğimizde görebiliriz.
        {
            return StatusCode(400);
            //return BadRequest();
        }

        public IActionResult Ornek5() // ActionResult türünde nesneler döndürebiliriz. Yapılan istekte Bad request 404 hatası verdirdik. Sayfa bulunmadı hatası. Sayfa kaynağını görüntülediğimizde görebiliriz.
        {
            return StatusCode(404); 
            //return NotFound();
        }
      

        public StatusCodeResult Ornek6() // Durum kodu göndereceğimiz belirtiriz.
        {
            return StatusCode(404);
            //return NotFound();
        }

        public RedirectResult Ornek7() // Bir aksiyon sonucunda başka bir linke yönlendirme işleminde kullanılır. Örneğin veritabanına bir kayıt eklendiğinde ana sayfaya dönülecek ise RedirectResult tan yararlanabiliriz.
        {

            return Redirect("/Home/Ornek1");
        
        }

        public IActionResult Ornek8() // Bir aksiyon sonucunda başka bir aksiyona yönlendirme işleminde kullanılır. Örneğin veritabanına bir kayıt eklendiğinde ana sayfaya dönülecek ise IActionResult tan yararlanabiliriz.
        {
            return RedirectToAction("admin");
        }

        public JsonResult Ornek9() // JsonResult İşlemi json formatında data döndürme işleminde kullanırız.
        {
            List<Calisan> calisanlar = new List<Calisan>
            {
                new Calisan{Id=1, Adi="Samet", Soyadi="Erdem",Maas=2500},
                new Calisan{Id=2, Adi="Ahmet", Soyadi="Sarıkaya",Maas=2500},
                new Calisan{Id=3, Adi="Furkan", Soyadi="Furkan",Maas=2500},
                new Calisan{Id=4, Adi="Mehmet", Soyadi="Mehmet",Maas=2500}
            };
            return Json(calisanlar);
        }


        public ViewResult RazorDemo() // Razor syntaxı ile html sayfasında kullanım örnekleri.
        {
            return View();
        }


        public JsonResult AramaYap(string key) // JsonResult İşlemi json formatında data döndürme işleminde kullanırız. Key parametresini querystringte default olarak arar
        {
            List<Calisan> calisanlar = new List<Calisan>
            {
                new Calisan{Id=1, Adi="Samet", Soyadi="Erdem",Maas=2500},
                new Calisan{Id=2, Adi="Ahmet", Soyadi="Sarıkaya",Maas=2500},
                new Calisan{Id=3, Adi="Furkan", Soyadi="Furkan",Maas=2500},
                new Calisan{Id=4, Adi="Mehmet", Soyadi="Mehmet",Maas=2500}
            };
            if (String.IsNullOrEmpty(key)) //Boş veya null ise tüm herkesi döndür demek true değer verir.
            {
                return Json(calisanlar);
            }
            else
            {
                var icerik = calisanlar.Where(c => c.Adi.ToLower().Contains(key)).ToList();
                return Json(icerik);
            }
        }

        public ViewResult FormIleArama()
        {
            return View();
        }

        public string RouteDataKullanimi(int id) //Querystring ve Route datasından veri almak. Default id 
        {
            return id.ToString();
        }

        //FormTag Helper

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}