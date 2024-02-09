using Microsoft.AspNetCore.Mvc;
using StokBilgi.Proje_ALPEROVUC.Methods;
using StokBilgi.Proje_ALPEROVUC.Model;
using StokBilgi.Proje_ALPEROVUC.Values;

namespace StokBilgi.Proje_ALPEROVUC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockCalculationController : Controller
    {
        StockCalculationMethods stockCalculationMethods = new StockCalculationMethods();

        private static bool stokkartbilgiListFilled = false; // Sadece ilk açılışta çalışması için amaçlandı , sürekli değişen tabloda değişkenkerin(stokkartbilgiListFilled,stokkartbilgiList) static ten çıkartılıp if bloğunun ortadan kaldırılması gerekir.

        public StockCalculationController()
        {
            if (!stokkartbilgiListFilled)
            {
                FillstokkartbilgiList(StockValues.stokkartbilgiList);
                stokkartbilgiListFilled = true;
            }
        }

        [HttpGet("IrsaliyeEntryMethod")]
        public IActionResult IrsaliyeEntryMethod(string _stokNo, int _miktar)// Tekli giriş için tasarlanmıştır. Çoklu giriş için json formatında liste halinde veri girişi yapılması gerekir.
        {
            var matchingStokNo = StockValues.stokkartbilgiList.FirstOrDefault(b => b.StokNo == _stokNo);

            if (matchingStokNo != null)
            {
                stockCalculationMethods.CalculateStok(_miktar, matchingStokNo);
            }
            else
            {
                return NotFound(new { Message = $"StokNo {_stokNo} bulunamadı.Girişleri Yapılan StokNo değerlerini kontrol ediniz." });
            }

            return Ok(StockValues.barkodList);
        }

        private void FillstokkartbilgiList(List<StokKartBilgi> stokkartbilgiList) // SANAL TABLO
        {
            stokkartbilgiList.Add(new StokKartBilgi { StokNo = "A", KasaIciMiktar = 50, EksiltmeMiktar = 10 });
            stokkartbilgiList.Add(new StokKartBilgi { StokNo = "B", KasaIciMiktar = 20, EksiltmeMiktar = 5 });
            stokkartbilgiList.Add(new StokKartBilgi { StokNo = "C", KasaIciMiktar = 1200, EksiltmeMiktar = 300 });
        }
    }
}
