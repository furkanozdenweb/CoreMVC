using AdonetCoreMVC.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdonetCoreMVC
{
    public class CalisanAddViewModel
    {
        public Calisan Calisan { get; set; }
        public List<SelectListItem> sehirler { get; set; }

    }
}