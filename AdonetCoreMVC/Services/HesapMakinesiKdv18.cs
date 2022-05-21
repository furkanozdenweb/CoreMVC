namespace AdonetCoreMVC.Services
{
    public class HesapMakinesiKdv18 : IHesapMakinesi
    {
        public decimal Hesapla(decimal miktar)
        {
            return miktar + (miktar * 18 / 100);
        }
    }
}
