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
    class ChamCongUI
    {
        CRUD<ChamCong> chamCongCRUD = new ChamCongBus();
        public void Menu()
        {
            Console.Clear();
            int check = 0;
            while (check==0)
            {
                Table table = new Table(70);
                table.PrintLine();
                Console.WriteLine();
                table.PrintRow("======================== QUẢN LÝ CHẤM CÔNG ========================");
                Console.WriteLine();
                table.PrintLine();
                table.PrintRow("1. Điểm danh đến"); table.PrintLine();
                table.PrintRow("2. Điểm danh về"); table.PrintLine();
                table.PrintRow("3. Bảng chấm công của tất cả nhân viên theo ngày/tháng/năm"); table.PrintLine();
                table.PrintRow("4. Bảng chấm công ngày làm việc của 1 nhân viên theo tháng/năm"); table.PrintLine();
                table.PrintRow("0. Nhấn 0 để thoát");
                table.PrintLine();
                Console.Write("Mời bạn chọn chức năng: ");
                int mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1:
                        Console.Clear();
                        NhanVienUI nvui = new NhanVienUI();
                        nvui.Show();
                        Console.WriteLine("Hãy nhập Mã NV của bạn để điểm danh");
                        DiemDanhDen();
                        Console.WriteLine("Xin cảm ơn!");
                        break;
                    case 2:
                        Console.Clear();
                        NhanVienUI nvui2 = new NhanVienUI();
                        nvui2.Show();
                        Console.WriteLine("Hãy nhập Mã NV của bạn để điểm danh");
                        DiemDanhVe();
                        Console.WriteLine("Xin cảm ơn!");
                        break;
                    case 3:
                        Show();
                        break;
                    case 4:
                        Find();
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
        public void DiemDanhDen()
        {
            
            NhanVienBus nhanVienBus = new NhanVienBus();
            List<NhanVien> nhanViens = nhanVienBus.GetList();
            Console.Write("Nhập mã nhân viên: ");
            string nhanvienId = Console.ReadLine();
            DateTime workingTime = DateTime.Now;
            ChamCong chamCong = new ChamCong(nhanvienId, DateTime.Parse(workingTime.ToString("HH:mm")), DateTime.Parse(workingTime.ToString("HH:mm")), workingTime);
            ChamCongBus chamCongBus = new ChamCongBus();
            chamCongBus.Add(chamCong);
        }

        public void DiemDanhVe()  
        {
            NhanVienBus nhanVienBus = new NhanVienBus();
            List<NhanVien> nhanViens = nhanVienBus.GetList();
            Console.Write("Nhập mã nhân viên: ");
            string nhanvienId = Console.ReadLine();
            DateTime workingTime = DateTime.Now;
            ChamCongBus chamCongBus = new ChamCongBus();
            ChamCong chamCong = chamCongBus.GetChamCong(nhanvienId + workingTime.ToString("MM/dd/yyyy"));
            chamCong.EndTime = DateTime.Parse(workingTime.ToString("HH:mm"));
            chamCongBus.Update(nhanvienId + workingTime.ToString("MM/dd/yyyy"), chamCong);
        }
        public void Show()
        {
            Console.Clear();
            Console.Write("Ngày: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Tháng: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Năm: ");
            int year = int.Parse(Console.ReadLine());
            ChamCongBus chamCongBus = new ChamCongBus();
            List<ChamCong> chamCongs = chamCongBus.GetList(x => x.WorkDay.Day == day && x.WorkDay.Month == month && x.WorkDay.Year == year);
            Table table = new Table(132);
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("========================================================== BẢNG CHẤM CÔNG ==========================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintTitle("Mã NV", "Thời gian vào", "Thời gian ra", "Ngày tháng năm");
            Console.WriteLine("");
            table.PrintLine();
            foreach (ChamCong tt in chamCongs)
            {
                table.PrintRow(tt.NhanVienId, tt.StartTime.ToString("HH:mm"), tt.EndTime.ToString("HH:mm"), tt.WorkDay.ToString("MM/dd/yyyy"));
            }
            table.PrintLine();
        }
        
        public void Find()
        {
            Console.Clear();
            Console.Write("Tháng: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Năm: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Mã NV: ");
            string maNV = Console.ReadLine();
            ChamCongBus chamCongBus = new ChamCongBus();
            List<ChamCong> chamCongs = chamCongBus.GetList(x=> x.WorkDay.Month == month && x.WorkDay.Year == year && x.NhanVienId == maNV);
            Table table = new Table(132);
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("========================================================== BẢNG CHẤM CÔNG ========================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintTitle("Mã NV", "Thời gian vào", "Thời gian ra", "Ngày tháng năm");
            table.PrintLine();
            foreach (ChamCong tt in chamCongs)
            {
                    table.PrintRow(tt.NhanVienId, tt.StartTime.ToString("HH:mm"), tt.EndTime.ToString("HH:mm"), tt.WorkDay.ToString("MM/dd/yyyy"));
            }
            table.PrintLine();
        }
        
    }
}
