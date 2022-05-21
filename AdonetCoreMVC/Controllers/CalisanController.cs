using AdonetCoreMVC.Entities;
using AdonetCoreMVC.Services;  // IHesap Makinesi için tanımlandı klasör
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;//SelectListItem kullanımı

namespace AdonetCoreMVC.Controllers
{

    public class CalisanController : Controller
    {
        private IHesapMakinesi _hesapmakinesi;

        public CalisanController(IHesapMakinesi hesapmakinesi) //ctro ile bir constructor methodu oluşturuyoruz.
        {
            _hesapmakinesi = hesapmakinesi;
        }


        // IHesapMakinesi hesapMakinesi = new HesapMakinesiKdv8(); // newlediğimizde ikisinede ulaşabiliyoruz ve tek bir değerden erişim sağlıyoruz.
        public string Hesapla()
        {
            return _hesapmakinesi.Hesapla(100).ToString();
        }

        public ViewResult Ornek()
        {
            return View();
        }
     

        public IActionResult Add()
        { 
            var calisanAddViewModel = new CalisanAddViewModel // CalisanAddViewModelini oluşturup döndüreceğimiz nesneyi newliyoruz.
            {
                Calisan = new Calisan(),// 1. Tanım,
                sehirler = new List<SelectListItem> //2. Tanım
                {
                    new SelectListItem{Text="Tekirdağ",Value="59"},
                    new SelectListItem{Text="İstanbul",Value="34"},
                    new SelectListItem{Text="Ankara",Value="06"}
                }
            };
            return View(calisanAddViewModel); //Bizim tag helperlarla çalışabilmemiz için bir view 'e ihtiyaç var. Bir view oluşturuyoruz.
        }


        [HttpPost] //Submit yapılırsa post işlemi ile çalışacak method tanımı   
        public IActionResult Add(Calisan calisan)
        {
            return View();
        }

        


    }
}
