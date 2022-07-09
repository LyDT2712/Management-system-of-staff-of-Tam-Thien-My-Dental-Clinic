using System;
using System.Collections.Generic;
using System.Text;
using PROJECT1.BusinessLayer;
using PROJECT1.BusinessLayer.Interface;
using PROJECT1.DataAcessLayer.Entities;
using PROJECT1.DataAcessLayer.DataAcess;
using PROJECT1.UI.component;


namespace PROJECT1.UI
{
    class ThongKeUI
    {
        public void Menu()
        {
            Console.Clear();
            int check = 0;
            while (check == 0)
            {
                Table table = new Table(70);
                table.PrintLine();
                Console.WriteLine();
                Console.WriteLine("============================= THỐNG KÊ =============================");
                Console.WriteLine();
                table.PrintLine();
                table.PrintRow("1. Thống kê nhân viên theo từng phòng ban");
                table.PrintLine();
                table.PrintRow("2. Thống kê lương theo phòng ban");
                table.PrintLine();
                table.PrintRow("0. Nhấn 0 để thoát");
                table.PrintLine();
                Console.Write("Mời bạn chọn chức năng: ");
                int mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    
                    case 1:
                        Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
                        ThongKeNVTheoPhongBan();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
                        Console.Write("Tháng: ");
                        int month = int.Parse(Console.ReadLine());
                        Console.Write("Năm: ");
                        int year = int.Parse(Console.ReadLine());
                        PhongBanBus PhongBanBus = new PhongBanBus();
                        Table Table2 = new Table(120);
                        Table2.PrintLine();
                        Console.WriteLine();
                        Console.WriteLine("============================================================ THỐNG KÊ ======================================================");
                        Console.WriteLine();
                        Table2.PrintLine();
                        Table2.PrintRow("Mã phòng ban", "Tên phòng ban", "Tiền lương");
                        Table2.PrintLine();
                        foreach (PhongBan Phongban in PhongBanBus.GetList())
                        {
                            Table2.PrintRow(Phongban.ID.ToString(), Phongban.Name.ToString(), Math.Round(Statistic(Phongban.ID, month, year), 2).ToString());
                        }
                        Table2.PrintLine();
                        break;
                    case 0:
                        check = 1;
                        break;
                    default:
                        Console.WriteLine("Sai cú pháp!");
                        break;
                }

            }
        }
        public void ThongKeNVTheoPhongBan()
        {
            Console.Clear();
            PhongBanBus phongBanBus = new PhongBanBus();
            PhongBanUI phongBanUI = new PhongBanUI();
            phongBanUI.Show();
            Console.Write("Mã phòng ban: ");
            string pbID = Console.ReadLine();
            PhongBan phongBan = phongBanBus.GetPhongBan(x => x.ID.ToUpper() == pbID.ToUpper());
            if (phongBan == null)
                Console.WriteLine("Phòng ban không tồn tại");
            else
            {
                Console.WriteLine($"{phongBan.ID}" + $" - Phòng ban: {phongBan.Name}");
                NhanVienBus nhanVienBus = new NhanVienBus();
                List<NhanVien> nhanViens = nhanVienBus.GetList();
                Table table = new Table(168);
                table.PrintLine();
                Console.WriteLine();
                Console.WriteLine("================================================================================= THỐNG KÊ =================================================================================");
                Console.WriteLine();
                table.PrintLine();
                table.PrintRow("Mã NV", "Họ tên", "Giới tính", "Ngày sinh", "Địa chỉ", "SĐT", "Trình độ chuyên môn");
                table.PrintLine();
                foreach (var nv in nhanViens)
                {
                    if (pbID == nv.Pbid)
                        table.PrintRow(nv.ID, nv.Name, nv.General, nv.Dob, nv.Address, nv.Phone, nv.Qualification);
                }
                table.PrintLine();

            }
            Console.ReadLine();
        }
        public double Statistic(string Maphongban,int month,int year)
        {
            ChamCongBus chamCong = new ChamCongBus();
            NhanVienBus nhanVienBus = new NhanVienBus();
            List<ChamCong> chamCongs = chamCong.GetList(x => x.WorkDay.Year == year && x.WorkDay.Month == month);
            List<NhanVien> nhanViens = nhanVienBus.GetList();
            double LuongtheoPB = 0;
            foreach (var nv in nhanViens)
            {
                if (nv.Pbid == Maphongban)
                {
                    List<ChamCong> chamCongCaNhan = chamCong.GetList(x => x.NhanVienId == nv.ID, chamCongs);
                    double workingTime = 0;
                    NhanVienRole role = nhanVienBus.GetVienRole(nv.Qualification);
                    double standardTime = chamCong.GetStandardTime(role);
                    foreach (var item in chamCongCaNhan)
                    {
                        workingTime += item.EndTime.Subtract(item.StartTime).TotalHours;
                        standardTime += standardTime;
                    }
                    double tangCa = (workingTime - standardTime) < 0 ? 0 : (workingTime - standardTime);
                    double luong = chamCong.GetStandardLuong(role) * (workingTime +tangCa);
                    LuongtheoPB += luong;
                }
            }
            return LuongtheoPB;
        }
    }
}
