using PROJECT1.BusinessLayer;
using PROJECT1.BusinessLayer.Interface;
using PROJECT1.DataAcessLayer.Entities;
using PROJECT1.UI.component;
using System;
using System.Collections.Generic;


namespace PROJECT1.UI
{
    class NhanVienUI
    {
        CRUD<NhanVien> nhanVienCRUD = new NhanVienBus();
        NhanVienBus nhanVienBus = new NhanVienBus();
        public void Menu()
        {
            int check = 0;
            while (check == 0)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\t\t║                        ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                      ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("║");
                Console.Write("\t\t║                        ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                                 ▐  QUẢN LÝ NHÂN VIÊN  ▌                                                      ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("║");
                Console.Write("\t\t║                        ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                      ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin nhân viên      ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin nhân viên  ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm nhân viên            ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin nhân viên       ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin nhân viên       ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t║                                                                                                                                      ║");
                Console.WriteLine("\t\t╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                Console.Write("Mời bạn chọn chức năng: ");
                int mode = int.Parse(Console.ReadLine());
                switch (mode)
                {
                    case 1:     
                        Add();
                        break;
                    case 2:
                        Show();
                        break;
                    case 3:
                        Show();
                        Console.WriteLine("Tìm kiếm NV ");
                        string id1 = "";
                        do
                        {
                            Console.Write("Nhập Mã NV cần tìm kiếm: ");
                            id1 = Console.ReadLine();
                            if (nhanVienBus.KTraId(id1)==false)
                            {
                                Console.WriteLine("Mã NV không hợp lệ- Mời nhập lại\n");
                            }
                        } while (nhanVienBus.KTraId(id1)==false);
                        Find(id1);
                        Console.WriteLine();
                        break;

                    case 4:
                        Show();
                        Console.WriteLine("Sửa thông tin nhân viên");
                        string id2 = "";
                        do
                        {
                            Console.Write("Nhập Mã NV cần sửa: ");
                            id2 = Console.ReadLine();
                            if (nhanVienBus.KTraMaTonTai(id2) == false)
                            {
                                Console.WriteLine("Mã NV đã tồn tại- Mời nhập lại\n");
                            }
                        } while (nhanVienBus.KTraMaTonTai(id2)==false);
                        Update(id2);
                        break;
                    case 5:
                        Delete();
                        Console.WriteLine();
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
        public void Add()
        {
            Console.Clear();
            Show();
            string check = "y";
            Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
            while (check == "y")
            {
                NhanVien nv = new NhanVien();
                do
                {
                    Console.Write("Nhập mã NV cần thêm: "); nv.ID = Console.ReadLine();
                    if (nhanVienBus.KTraMaTonTai(nv.ID))
                    {
                        Console.WriteLine("Mã tồn tại - Mời nhập lại\n");
                    }
                } while (nhanVienBus.KTraMaTonTai(nv.ID));
                do 
                {
                    Console.Write("Họ tên: "); nv.Name = Console.ReadLine();
                    if (!nhanVienBus.KTname(nv.Name))
                    {
                        Console.WriteLine("Tên NV không được để trống và phải là chữ - Mời nhập lại\n");
                    }
                } while (!nhanVienBus.KTname(nv.Name));
                Console.Write("Giới tính: "); nv.General = Console.ReadLine();
                Console.Write("Ngày sinh: "); nv.Dob = Console.ReadLine();
                Console.Write("Địa chỉ: "); nv.Address = Console.ReadLine();
                do
                {
                    Console.Write("SĐT: "); nv.Phone = Console.ReadLine();
                    if (nhanVienBus.KTphone(nv.Phone))
                    {
                        Console.WriteLine("SĐT phải là số có 10 số và không có khoảng cách - Mời nhập lại\n");
                    }
                } while (nhanVienBus.KTphone(nv.Phone));
                Console.Write("Phòng ban: "); nv.Pbid = Console.ReadLine();
                Console.Write("Trình độ chuyên môn: "); nv.Qualification = Console.ReadLine();
                nhanVienCRUD.Add(nv);
                Console.WriteLine("Bạn đã nhập thành công!");
                Console.Write("Bạn có muốn nhập tiếp (y/n) : ");
                check = Console.ReadLine().ToLower();
                if (check == "n")
                    break;
            }
        }
        public void Show()
        {
            Console.Clear();

            List<NhanVien> nhanViens = nhanVienCRUD.GetList();
            Table table = new Table(180);
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("============================================================================== THÔNG TIN NHÂN VIÊN ==============================================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintRow("Mã NV", "Họ tên", "Giới tính", "Ngày sinh", "Địa chỉ", "SĐT", "Phòng ban", "Trình độ chuyên môn");
            table.PrintLine();
            
            if (nhanViens.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên trống!");
            }  
            else
            {
                foreach (NhanVien ttin in nhanViens)
                {
                    table.PrintRow(ttin.ID, ttin.Name, ttin.General, ttin.Dob, ttin.Address, ttin.Phone, ttin.Pbid, ttin.Qualification);
                }
                table.PrintLine();
                Console.WriteLine();
            }
        }
        public void Find(string id)
        {
            Console.Clear();
            List<NhanVien> nhanViens = nhanVienCRUD.GetList();
            Table table = new Table(240);
            table.PrintLine();
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("============================================================================== THÔNG TIN NHÂN VIÊN ==============================================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintRow("Mã NV", "Họ tên", "Giới tính", "Ngày sinh", "Địa chỉ", "SĐT", "Phòng ban", "Trình độ chuyên môn");
            Console.WriteLine("");
            table.PrintLine();
            foreach (NhanVien tt in nhanViens)
            {
                if (tt.ID.Contains(id))
                    table.PrintRow(tt.ID, tt.Name, tt.General, tt.Dob, tt.Address, tt.Phone, tt.Pbid, tt.Qualification);
            }
            Console.WriteLine();
            table.PrintLine();
        }
        public void Update(string id)
        {
            Console.Clear();
            NhanVien newInfo = new NhanVien();
            newInfo.ID = id;
            do
            {
                Console.Write("Họ tên: "); newInfo.Name = Console.ReadLine();
                if (!nhanVienBus.KTname(newInfo.Name))
                {
                    Console.WriteLine("Tên NV không được để trống và phải là chữ - Mời nhập lại\n");
                }
            } while (!nhanVienBus.KTname(newInfo.Name));
            Console.Write("Giới tính: "); newInfo.General = Console.ReadLine();
            Console.Write("Ngày sinh: "); newInfo.Dob = Console.ReadLine();
            Console.Write("Địa chỉ: "); newInfo.Address = Console.ReadLine();
            do
            {
                Console.Write("SĐT: "); newInfo.Phone = Console.ReadLine();
                if (nhanVienBus.KTphone(newInfo.Phone))
                {
                    Console.WriteLine("SĐT phải là số có 10 số và không có khoảng cách - Mời nhập lại\n");
                }
            } while (nhanVienBus.KTphone(newInfo.Phone));
            Console.Write("Mã PB: "); newInfo.Pbid = Console.ReadLine();
            Console.Write("Trình độ chuyên môn: "); newInfo.Qualification = Console.ReadLine();
            Console.WriteLine("Bạn đã sửa thành công!");
            nhanVienCRUD.Update(id, newInfo);
        }
        public void Delete()
        {
            Console.Clear();
            Show();
            Console.Write("Nhập Mã NV cần xóa: ");
            string id3 = Console.ReadLine();
            int id = nhanVienCRUD.Find(id3);
            if (id >= 0)
            {
                Console.WriteLine("Ban co muon xoa khong? (Enter xóa) ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    nhanVienCRUD.Delete(id3);
                    Console.WriteLine("Bạn đã xóa thành công!");
                }
            }
        }

        


    }
}
