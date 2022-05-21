namespace AdonetCoreMVC.Services
{
    public class HesapMakinesiKdv8 : IHesapMakinesi
    {
        public decimal Hesapla(decimal miktar)
        {
            return miktar + (miktar * 8 / 100);
        }
    }
}
