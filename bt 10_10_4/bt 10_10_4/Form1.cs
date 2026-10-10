using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace  bt_10_10_4
{
    public partial class Form1 : Form
    {
        // Danh sách nhân viên bộ nhớ
        private List<NhanVien> dsNhanVien = new List<NhanVien>();

        // ImageList lưu biểu tượng
        private ImageList imgListTree = new ImageList();
        private ImageList imgListSmall = new ImageList();
        private ImageList imgListLarge = new ImageList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoImageList();
            KhoiTaoComboBoxViewMode();
            KhoiTaoDuLieuMau();
            NapCayPhongBan();
            DinhDangListView();
        }

        // 1. Khởi tạo biểu tượng mẫu bằng Code (không cần tải file ảnh ngoài)
        private void KhoiTaoImageList()
        {
            // Set kích thước
            imgListTree.ImageSize = new Size(16, 16);
            imgListSmall.ImageSize = new Size(16, 16);
            imgListLarge.ImageSize = new Size(32, 32);

            // Tạo icon màu đơn giản
            imgListTree.Images.Add("company", TaoBitmapIcon(Color.Navy, 16));
            imgListTree.Images.Add("dept", TaoBitmapIcon(Color.Orange, 16));
            imgListTree.Images.Add("group", TaoBitmapIcon(Color.Green, 16));

            imgListSmall.Images.Add("user", TaoBitmapIcon(Color.DodgerBlue, 16));
            imgListLarge.Images.Add("user", TaoBitmapIcon(Color.DodgerBlue, 32));

            // Gán ImageList cho các Control
            tvDepartments.ImageList = imgListTree;
            lsvEmployees.SmallImageList = imgListSmall;
            lsvEmployees.LargeImageList = imgListLarge;
        }

        private Bitmap TaoBitmapIcon(Color color, int size)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(color);
            }
            return bmp;
        }

        // 2. Khởi tạo ComboBox đổi chế độ hiển thị ListView
        private void KhoiTaoComboBoxViewMode()
        {
            cboViewMode.Items.Clear();
            cboViewMode.Items.AddRange(new string[] { "Details", "LargeIcon", "SmallIcon", "List", "Tile" });
            cboViewMode.SelectedIndex = 0; // Mặc định Details
            cboViewMode.SelectedIndexChanged += cboViewMode_SelectedIndexChanged;
        }

        // 3. Khởi tạo Dữ liệu mẫu Nhân viên
        private void KhoiTaoDuLieuMau()
        {
            dsNhanVien = new List<NhanVien>
            {
                // Phòng Nhân sự - Nhóm Tuyển Dụng (N_TD)
                new NhanVien("NV01", "Nguyễn Văn A", "Trưởng nhóm", new DateTime(2020, 3, 15), "N_TD"),
                new NhanVien("NV02", "Trần Thị B", "Chuyên viên Tuyển dụng", new DateTime(2021, 6, 10), "N_TD"),

                // Phòng Nhân sự - Nhóm Đào Tạo (N_DT)
                new NhanVien("NV03", "Lê Văn C", "Chuyên viên Đào tạo", new DateTime(2019, 8, 20), "N_DT"),

                // Phòng Kỹ thuật - Nhóm Lập Trình (N_LT)
                new NhanVien("NV04", "Phạm Minh D", "Trưởng phòng Kỹ thuật", new DateTime(2018, 1, 10), "N_LT"),
                new NhanVien("NV05", "Hoàng Anh E", "Lập trình viên Senior", new DateTime(2022, 4, 1), "N_LT"),
                new NhanVien("NV06", "Vũ Tuyết F", "Lập trình viên Junior", new DateTime(2023, 9, 15), "N_LT"),

                // Phòng Kỹ thuật - Nhóm Kiểm Thử (N_KT)
                new NhanVien("NV07", "Đặng Quang G", "Kiểm thử viên (QA)", new DateTime(2021, 11, 5), "N_KT")
            };
        }

        // 4. Xây dựng cây dữ liệu tổ chức TreeView
        private void NapCayPhongBan()
        {
            tvDepartments.Nodes.Clear();

            // Root: Công ty
            TreeNode root = new TreeNode("Công Ty ABC")
            {
                Tag = "ROOT",
                ImageKey = "company",
                SelectedImageKey = "company"
            };

            // Phòng Nhân sự
            TreeNode pNhanSu = new TreeNode("Phòng Nhân Sự")
            {
                Tag = "P_NS",
                ImageKey = "dept",
                SelectedImageKey = "dept"
            };
            pNhanSu.Nodes.Add(new TreeNode("Nhóm Tuyển Dụng") { Tag = "N_TD", ImageKey = "group", SelectedImageKey = "group" });
            pNhanSu.Nodes.Add(new TreeNode("Nhóm Đào Tạo") { Tag = "N_DT", ImageKey = "group", SelectedImageKey = "group" });

            // Phòng Kỹ thuật
            TreeNode pKyThuat = new TreeNode("Phòng Kỹ Thuật")
            {
                Tag = "P_KT",
                ImageKey = "dept",
                SelectedImageKey = "dept"
            };
            pKyThuat.Nodes.Add(new TreeNode("Nhóm Lập Trình") { Tag = "N_LT", ImageKey = "group", SelectedImageKey = "group" });
            pKyThuat.Nodes.Add(new TreeNode("Nhóm Kiểm Thử") { Tag = "N_KT", ImageKey = "group", SelectedImageKey = "group" });

            root.Nodes.Add(pNhanSu);
            root.Nodes.Add(pKyThuat);

            tvDepartments.Nodes.Add(root);
            tvDepartments.ExpandAll(); // Mở rộng tất cả các nhánh
        }

        // 5. Định dạng các cột cho ListView ở chế độ Details
        private void DinhDangListView()
        {
            lsvEmployees.Columns.Clear();
            lsvEmployees.Columns.Add("Mã NV", 90);
            lsvEmployees.Columns.Add("Họ Tên", 180);
            lsvEmployees.Columns.Add("Chức Vụ", 160);
            lsvEmployees.Columns.Add("Ngày Vào Làm", 120);
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
        }

        // 6. Sự kiện Click chọn Node trên TreeView -> Lọc dữ liệu lên ListView
        private void tvDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            string selectedTag = e.Node.Tag?.ToString();
            List<NhanVien> listFiltered = new List<NhanVien>();

            if (selectedTag == "ROOT")
            {
                // Chọn Công ty -> Hiển thị toàn bộ nhân viên
                listFiltered = dsNhanVien;
            }
            else if (selectedTag == "P_NS")
            {
                // Chọn Phòng Nhân sự -> Lấy các nhóm con thuộc P_NS
                listFiltered = dsNhanVien.Where(nv => nv.NodeTag == "N_TD" || nv.NodeTag == "N_DT").ToList();
            }
            else if (selectedTag == "P_KT")
            {
                // Chọn Phòng Kỹ thuật -> Lấy các nhóm con thuộc P_KT
                listFiltered = dsNhanVien.Where(nv => nv.NodeTag == "N_LT" || nv.NodeTag == "N_KT").ToList();
            }
            else
            {
                // Chọn nhóm cụ thể
                listFiltered = dsNhanVien.Where(nv => nv.NodeTag == selectedTag).ToList();
            }

            HienThiDanhSachNhanVien(listFiltered);
        }

        // Nạp danh sách vào ListView
        private void HienThiDanhSachNhanVien(List<NhanVien> list)
        {
            lsvEmployees.Items.Clear();

            foreach (var nv in list)
            {
                ListViewItem item = new ListViewItem(nv.MaNV)
                {
                    ImageKey = "user"
                };
                item.SubItems.Add(nv.HoTen);
                item.SubItems.Add(nv.ChucVu);
                item.SubItems.Add(nv.NgayVaoLam.ToString("dd/MM/yyyy"));

                lsvEmployees.Items.Add(item);
            }
        }

        // 7. Chuyển đổi View Mode cho ListView bằng ComboBox
        private void cboViewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboViewMode.SelectedItem.ToString())
            {
                case "Details":
                    lsvEmployees.View = View.Details;
                    break;
                case "LargeIcon":
                    lsvEmployees.View = View.LargeIcon;
                    break;
                case "SmallIcon":
                    lsvEmployees.View = View.SmallIcon;
                    break;
                case "List":
                    lsvEmployees.View = View.List;
                    break;
                case "Tile":
                    lsvEmployees.View = View.Tile;
                    break;
            }
        }
    }
}