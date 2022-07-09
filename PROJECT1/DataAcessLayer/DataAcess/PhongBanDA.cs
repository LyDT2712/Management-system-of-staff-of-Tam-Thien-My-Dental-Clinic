using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PROJECT1.DataAcessLayer.Entities;

namespace PROJECT1.DataAcessLayer.DataAcess
{
    class PhongBanDA
    {
        private string FilePath = "PhongBan.txt";
        //Lấy danh sách
        public List<PhongBan> LayDanhSachPhongBan()
        {
            //Tạo danh sách
            List<PhongBan> phongBans = new List<PhongBan>();
            if (!File.Exists(FilePath))
                File.Create(FilePath).Close();

            StreamReader ReadFile = new StreamReader(FilePath);
            string line = ReadFile.ReadLine();
            while (line != null)
            {
                string[] Tachthongtin = line.Split('|'); //Idpb#namepb#function
                PhongBan ttin = new PhongBan(Tachthongtin[0], Tachthongtin[1], Tachthongtin[2]);
                phongBans.Add(ttin);
                line = ReadFile.ReadLine();
            }
            ReadFile.Close();
            return phongBans;
        }
        //Thêm phòng ban
        public void AddPB(PhongBan phongBan)
        {
            StreamWriter w = new StreamWriter(FilePath, true);
            //Chuyển thông tin lớp thành xâu idpb, string namepb, string function)
            string st = phongBan.ID + "|" + phongBan.Name + "|" + phongBan.Function;
            w.WriteLine(st);
            w.Flush();
            w.Close();
        }
        //Thuật toán phương thức sửa, xoa lớp, đọc tệp lớp ra một danh sách, sửa hoặc xóa trên danh sách, ghi lại tệp.
        public void GhiDanhsachPhongBan(List<PhongBan> phongBans)
        {
            StreamWriter gf = new StreamWriter(FilePath, false);
            foreach (PhongBan phongBan in phongBans)
            {
                string st = phongBan.ID + "|" + phongBan.Name + "|" + phongBan.Function;
                gf.WriteLine(st);
            }
            gf.Flush();
            gf.Close();
        }
        //Sửa thông tin
        public void EditPB(string id, PhongBan newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<PhongBan> phongBans = LayDanhSachPhongBan();
            //Sửa trên DS và ghi đè vào tệp
            phongBans[GetIndex(id)] = newInfo;
            GhiDanhsachPhongBan(phongBans);//Sửa ds ghi lại tệp
        }

        internal void GhiDanhsachPhongBan()
        {
            List<PhongBan> phongBans = LayDanhSachPhongBan();
            GhiDanhsachPhongBan(phongBans);

        }

        //Xóa thông tin
        public void Xoa(string id)
        {
            List<PhongBan> phongBans = LayDanhSachPhongBan();
            phongBans.RemoveAt(GetIndex(id));
            GhiDanhsachPhongBan(phongBans);

        }

        public int GetIndex(string id)
        {
            List<PhongBan> phongBans = LayDanhSachPhongBan();
            for (int i = 0; i < phongBans.Count; i++)
            {
                if (phongBans[i].ID == id)
                    return i;
            }
            return -1;
        }

        internal void Show()
        {
            Console.WriteLine();
        }
    }
}
