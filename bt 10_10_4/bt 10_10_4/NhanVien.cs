using System;

namespace bt_10_10_4
{
    public class NhanVien
    {
        public string MaNV { get; set; }        // Mã Nhân Viên
        public string HoTen { get; set; }       // Họ và Tên
        public string ChucVu { get; set; }      // Chức vụ
        public DateTime NgayVaoLam { get; set; } // Ngày vào làm
        public string NodeTag { get; set; }     // Mã định danh nhóm/phòng ban để lọc

        public NhanVien() { }

        public NhanVien(string maNV, string hoTen, string chucVu, DateTime ngayVaoLam, string nodeTag)
        {
            MaNV = maNV;
            HoTen = hoTen;
            ChucVu = chucVu;
            NgayVaoLam = ngayVaoLam;
            NodeTag = nodeTag;
        }
    }
}
