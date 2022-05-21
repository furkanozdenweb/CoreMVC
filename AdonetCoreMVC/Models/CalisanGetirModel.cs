using AdonetCoreMVC.Entities;

namespace AdonetCoreMVC
{
    public class CalisanGetirModel
    {
        public List<Calisan> Calisanlar { get; set; }
        public string[] Sehirler { get; set; }
        public string[] Isimler { get; set; }
    }
}