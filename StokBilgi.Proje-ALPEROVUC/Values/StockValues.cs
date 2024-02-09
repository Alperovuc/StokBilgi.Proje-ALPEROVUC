using StokBilgi.Proje_ALPEROVUC.Model;

namespace StokBilgi.Proje_ALPEROVUC.Values
{
    public class StockValues
    {
        public static int counter { get; set; } // counterın kümülatif olarak birikmesi amaçlandığı için static yapıldı
        public string calculatedBarkodNo { get; set; }
        public static List<StokKartBilgi> stokkartbilgiList { get; set; } = new List<StokKartBilgi>();
        public static List<Barkod> barkodList { get; set; } = new List<Barkod>(); // listenin kümülatif olarak birikmesi amaçlandığı için static yapıldı

    }
}
