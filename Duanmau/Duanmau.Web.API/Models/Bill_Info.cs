namespace Duanmau.Web.API.Models
{
    public class BillInfo
    {
        public int BillInfoId { get; set; }
        public int IdBill { get; set; }
        public int IdFood { get; set; }
        public int IdAccount { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string? GiamGia { get; set; }
        public Bill? Bills { get; set; }
        public Food? Foods { get; set; }
    }

}
