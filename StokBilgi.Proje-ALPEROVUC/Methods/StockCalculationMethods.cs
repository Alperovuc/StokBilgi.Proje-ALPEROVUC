using StokBilgi.Proje_ALPEROVUC.Model;
using StokBilgi.Proje_ALPEROVUC.Values;

namespace StokBilgi.Proje_ALPEROVUC.Methods
{


    public class StockCalculationMethods
    {
        private readonly string customDate = new DateTime(2008, 6, 22).ToString("ddMMyy");// Örnek Projedeki tarih baz alınmıştır. Bugünün tarihi alınmak istiyorsa bi alttaki kod satırı aktif edilmelidir.
        //private readonly string customDate = DateTime.Now.ToString("ddMMyy"); // Bugünün tarihi

        StockValues _stockValues = new StockValues();

        public void CalculateStokMethod(int _miktar, StokKartBilgi stokKartBilgi)
        {
            int kasaSayisi = (int)(_miktar / stokKartBilgi.KasaIciMiktar);
            decimal kalanMiktar = _miktar % stokKartBilgi.KasaIciMiktar; //Son oluşan etiketin eksiltme miktarı stok kartındaki eksiltme miktarından küçük olup olmadığı kontrol edilir.

            for (int i = 1; i <= kasaSayisi; i++)
            {
                StockValues.counter++;

                AddBarkodListMethod(stokKartBilgi, stokKartBilgi.KasaIciMiktar, stokKartBilgi.EksiltmeMiktar);
            }

            if (kalanMiktar > 0)
            {
                StockValues.counter++;

                AddBarkodListMethod(stokKartBilgi, kalanMiktar, kalanMiktar);
            }
        }

        private void AddBarkodListMethod(StokKartBilgi stokKartBilgi, decimal miktar, decimal eksiltmemiktar)
        {
            _stockValues.calculatedBarkodNo = customDate + StockValues.counter.ToString("D4"); // Uniqe değerin atanması

            StockValues.barkodList.Add(new Barkod
            {
                BarkodNo = _stockValues.calculatedBarkodNo,
                StokNo = stokKartBilgi.StokNo,
                KasaIciMiktar = miktar,              
                EksiltmeMiktar = eksiltmemiktar
            });
        }

    }
}
