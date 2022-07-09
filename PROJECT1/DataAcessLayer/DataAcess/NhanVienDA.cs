using PROJECT1.DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PROJECT1.DataAcessLayer.DataAcess
{
    class NhanVienDA
    {
        private string FilePath = "NhanVien.txt";
        //Lấy danh sách
        public List<NhanVien> LayDanhSachNhanVien()
        {
            //Tạo danh sách
            List<NhanVien> nhanViens = new List<NhanVien>();
            if (!File.Exists(FilePath))
                File.Create(FilePath).Close();

                StreamReader ReadFile = new StreamReader(FilePath);
                string line = ReadFile.ReadLine();
                while (line != null)
                {
                    string[] Tachthongtin = line.Split("|");
                    NhanVien ttin = new NhanVien(Tachthongtin[0], Tachthongtin[1], Tachthongtin[2], Tachthongtin[3], Tachthongtin[4], Tachthongtin[5], Tachthongtin[6], Tachthongtin[7]);
                    nhanViens.Add(ttin);
                    line = ReadFile.ReadLine();
                }
                ReadFile.Close();
            return nhanViens;
        }

        //Thêm nhân viên
        public void AddNV(NhanVien nhanVien)
        {
            StreamWriter w = new StreamWriter(FilePath, true);
            //Chuyển thông tin lớp thành xâu
            string st= nhanVien.ID + "|" + nhanVien.Name + "|" + nhanVien.General + "|" + nhanVien.Dob + "|" + nhanVien.Address + "|" + nhanVien.Phone + "|" + nhanVien.Pbid + "|" + nhanVien.Qualification;
            w.WriteLine(st);
            w.Flush();
            w.Close();
        }
        //Thuật toán phương thức sửa, xoa lớp, đọc tệp lớp ra một danh sách, sửa hoặc xóa trên danh sách, ghi lại tệp.
        public void GhiDanhsachNhanVien(List<NhanVien> nhanViens)
        {
            StreamWriter gf = new StreamWriter(FilePath, false);
            foreach (NhanVien nhanVien in nhanViens)
            {
                string st = nhanVien.ID + "|" + nhanVien.Name + "|" + nhanVien.General + "|" + nhanVien.Dob + "|" + nhanVien.Address + "|" + nhanVien.Phone + "|" + nhanVien.Pbid + "|" + nhanVien.Qualification;
                gf.WriteLine(st);
            }
            gf.Flush();
            gf.Close();
        }
        //Sửa thông tin
        public void EditNV(string id, NhanVien newInfo)
        {
            //Đọc toàn bộ tập lớn về
            List<NhanVien> nhanViens = LayDanhSachNhanVien();
            //Sửa trên DS và ghi đè vào tệp
            nhanViens[Find(id)] = newInfo;
            GhiDanhsachNhanVien(nhanViens);//Sửa ds ghi lại tệp
        }

        internal void GhiDanhsachNhanVien()
        {
            List<NhanVien> nhanViens = LayDanhSachNhanVien();
            GhiDanhsachNhanVien(nhanViens);
            
        }

        //Xóa thông tin
        public void Xoa(string id)
        {
            List<NhanVien> nhanViens = LayDanhSachNhanVien();
            nhanViens.RemoveAt(Find(id));
            GhiDanhsachNhanVien(nhanViens);

        }

        public int Find(string id)
        {
            List<NhanVien> nhanViens = LayDanhSachNhanVien();
            for(int i = 0; i<nhanViens.Count; i++)
            {
                if (nhanViens[i].ID == id)
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
