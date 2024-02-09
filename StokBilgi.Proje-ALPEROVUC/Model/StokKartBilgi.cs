using System.ComponentModel.DataAnnotations;

namespace StokBilgi.Proje_ALPEROVUC.Model
{
    public class StokKartBilgi
    {

        [MaxLength(18)]
        public string StokNo { get; set; } // Stok numarası

        public decimal KasaIciMiktar { get; set; } // Kasa içi miktar

        public decimal EksiltmeMiktar { get; set; } // Eksiltme miktarı
    }
}
