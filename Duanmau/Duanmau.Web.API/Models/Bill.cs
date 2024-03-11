
namespace Duanmau.Web.API.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime DateCheckOut { get; set; }
        public int IdTableFood { get; set; }
        public int IdNhanVien { get; set; }
        public int IdKhachHang { get; set; }
        public int IdKM { get; set; }
        public int Status { get; set; }
        public KhachHang? KhachHangs { get; set; }
        public NhanVien? NhanViens { get; set; }
        public Tablefood? Tablefoods { get; set; }

    }

}
