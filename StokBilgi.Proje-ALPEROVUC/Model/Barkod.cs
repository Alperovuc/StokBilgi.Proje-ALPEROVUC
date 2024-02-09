using System.ComponentModel.DataAnnotations;

namespace StokBilgi.Proje_ALPEROVUC.Model
{
    public class Barkod
    {
        [MaxLength(10)]
        public string BarkodNo { get; set; }

        [MaxLength(18)]
        public string StokNo { get; set; }
        public decimal KasaIciMiktar { get; set; }
        public decimal EksiltmeMiktar { get; set; }
    }
}
