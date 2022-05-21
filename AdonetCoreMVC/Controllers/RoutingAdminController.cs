using Microsoft.AspNetCore.Mvc;

namespace AdonetCoreMVC.Controllers
{
    [Route("admin2")]
    public class RoutingAdminController : Controller
    {
        [Route("")] // default olarak çalış
        [Route("save")] // save actionunda çalış    
        [Route("~/save")] // Önündeki herşeyi iptal et save dediğimde çalış
        public string Save()
        {
            return "Kayıt edildi";
        }

        [Route("delete/{id?}")]
        public string Delete(int id=0)
        {
            return String.Format("Kayıt silindi {0}",id); // String format içinde index bilgisi olarak değişken atayabiliriz.
        }

        [Route("Update")]
        public string Update()
        {
            return "Kayıt güncellendi.";
        }

        [Route("list")]
        public string List()
        {
            return "Kayıtlar çekildi";
        }
    }
}
