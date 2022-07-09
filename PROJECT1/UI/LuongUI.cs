using System;
using System.Collections.Generic;
using System.Text;
using PROJECT1.BusinessLayer;
using PROJECT1.DataAcessLayer.Entities;
using PROJECT1.UI.component;

namespace PROJECT1.UI
{
    class LuongUI
    {
        public void Menu()
        {
            Console.Clear();
            Statistic();
            Console.ReadLine();
        }

        public void Statistic()
        {
            Console.Clear();
            Console.Write("Tháng: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Năm: ");
            int year = int.Parse(Console.ReadLine());
            ChamCongBus chamCong = new ChamCongBus();
            NhanVienBus nhanVienBus = new NhanVienBus();
            List<ChamCong> chamCongs = chamCong.GetList(x=>x.WorkDay.Year == year && x.WorkDay.Month == month);
            List<NhanVien> nhanViens = nhanVienBus.GetList();
            Table table = new Table(120);
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("====================================================== BẢNG LƯƠNG ======================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintRow("Mã NV", "Họ tên","Số giờ làm việc", "Số giờ tăng ca","Lương");
            table.PrintLine();
            foreach(var nv in nhanViens)
            {
                List<ChamCong> chamCongCaNhan = chamCong.GetList(x => x.NhanVienId == nv.ID, chamCongs);
                double workingTime = 0;
                NhanVienRole role = nhanVienBus.GetVienRole(nv.Qualification);
                double standardTime = chamCong.GetStandardTime(role);
                foreach(var item in chamCongCaNhan)
                {
                    workingTime += item.EndTime.Subtract(item.StartTime).TotalHours;
                    standardTime += standardTime;
                }
                double tangCa = (workingTime - standardTime) < 0? 0: (workingTime - standardTime);
                double luong = chamCong.GetStandardLuong(role) * (workingTime+tangCa);
                table.PrintRow(nv.ID, nv.Name, Math.Round(workingTime,2).ToString(), tangCa.ToString(), Math.Round(luong,2).ToString());
                table.PrintLine();
            } 
        }
    }
}
