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
    class PhongBanUI
    {
        CRUD<PhongBan> phongBanCRUD = new PhongBanBus();
        PhongBanBus phongBanBus = new PhongBanBus();
        public void Menu()
        {
            Console.Clear();
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
                Console.Write("                                 ▐  QUẢN LÝ PHÒNG BAN  ▌                                                      ");
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
                Console.WriteLine("\t\t║                                                  ║     1.Nhập thông tin phòng ban      ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     2.Hiển thị thông tin phòng ban  ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     3.Tìm kiếm phòng ban            ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     4.Sửa thông tin phòng ban       ║                                             ║");
                Console.WriteLine("\t\t║                                                  ╚═════════════════════════════════════╝                                             ║");
                Console.WriteLine("\t\t║                                                  ╔═════════════════════════════════════╗                                             ║");
                Console.WriteLine("\t\t║                                                  ║     5.Xóa thông tin phòng ban       ║                                             ║");
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
                        Console.WriteLine("Mời bạn bắt đầu nhập thông tin");
                        Add();
                        break;
                    case 2:
                        Show();
                        break;
                    case 3:
                        Console.Clear();
                        Show();
                        Console.Write("Nhập Mã PB cần tìm kiếm: ");
                        string id1 = Console.ReadLine();
                        GetIndex(id1);
                        break;

                    case 4:
                        Console.Clear();
                        Show();
                        Console.WriteLine("Sửa thông tin phòng ban");
                        Console.Write("Nhập Mã PB cần sửa: ");
                        string id2 = Console.ReadLine();
                        Update(id2);
                        break;
                    case 5:
                        Console.Clear();
                        Show();
                        Console.Write("Nhập Mã PB cần xóa: ");
                        string id3 = Console.ReadLine();
                        Delete(id3);
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
            while (check == "y")
            {
                PhongBan pb = new PhongBan();
                do
                {
                    Console.WriteLine("Nhập thông tin phòng ban");
                    Console.Write("Mã PB: "); pb.ID = Console.ReadLine();
                    if (phongBanBus.KTraMaTonTai(pb.ID))
                    {
                        Console.WriteLine("Mã tồn tại - Mời nhập lại\n");
                    }
                } while (phongBanBus.KTraMaTonTai(pb.ID));
                do
                {
                    Console.Write("Tên PB: "); pb.Name = Console.ReadLine();
                    if (!phongBanBus.KTname(pb.Name))
                    {
                        Console.WriteLine("Tên NV không được để trống và phải là chữ - Mời nhập lại\n");
                    }
                } while (!phongBanBus.KTname(pb.Name));
                Console.Write("Chức năng: "); pb.Function = Console.ReadLine();
                phongBanCRUD.Add(pb);
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
            List<PhongBan> phongBans = phongBanCRUD.GetList();
            Table table = new Table(120);
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("================================================== THÔNG TIN PHÒNG BAN ==================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintRow("Mã PB", "Tên PB", "Chức năng");
            table.PrintLine();
            foreach (PhongBan ttin in phongBans)
            {
                table.PrintRow(ttin.ID, ttin.Name, ttin.Function);
            }
            table.PrintLine();
        }
        public void GetIndex(string id)
        {
            
            List<PhongBan> phongBans = phongBanCRUD.GetList();
            Table table = new Table(120);
            table.PrintLine();
            Console.WriteLine();
            Console.WriteLine("================================================== THỐNG KÊ ==================================================");
            Console.WriteLine();
            table.PrintLine();
            table.PrintRow("Mã PB", "Tên PB", "Chức năng"); 
            table.PrintLine();
            foreach (PhongBan ttin in phongBans)
            {
                if (ttin.ID.Contains(id))
                    table.PrintRow(ttin.ID, ttin.Name, ttin.Function);
            }
            table.PrintLine();
        }
        public void Update(string id)
        {
            
            PhongBan newInfo = new PhongBan();
            do
            {
                Console.Write("Mã PB: "); newInfo.ID = Console.ReadLine();
                if (phongBanBus.KTraMaTonTai(newInfo.ID))
                {
                    Console.WriteLine("Mã tồn tại - Mời nhập lại\n");
                }
            } while (phongBanBus.KTraMaTonTai(newInfo.ID));
            do
            {
                Console.Write("Tên PB: "); newInfo.Name = Console.ReadLine();
                if (!phongBanBus.KTname(newInfo.Name))
                {
                    Console.WriteLine("Tên NV không được để trống và phải là chữ - Mời nhập lại\n");
                }
            } while (!phongBanBus.KTname(newInfo.Name));
            Console.Write("Chức năng: "); newInfo.Function = Console.ReadLine();
            Console.WriteLine("Bạn đã sửa thành công!");
            phongBanCRUD.Update(id, newInfo);
        }
        public void Delete(string id)
        {
            
            phongBanCRUD.Delete(id);
            Console.WriteLine("Bạn đã xóa thành công!");
        }
    }
}
