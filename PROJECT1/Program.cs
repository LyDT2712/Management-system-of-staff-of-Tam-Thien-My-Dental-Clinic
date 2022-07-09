using PROJECT1.DataAcessLayer.DataAcess;
using PROJECT1.DataAcessLayer.Entities;
using PROJECT1.BusinessLayer;
using PROJECT1.UI.component;
using PROJECT1.UI;
using System;
using System.Text;
using System.IO;
using System.Threading;

namespace PROJECT1
{ 
    class Program
    {
        static public void GiaoDien()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Menu Chính";
            Console.CursorVisible = true; //con trỏ có thể chia sẻ
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                            TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT HƯNG YÊN                                           ║");
            Console.WriteLine("\t\t║                                                    KHOA CÔNG NGHỆ THÔNG TIN                                                   ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                    ********   *********     *******   ********** *********   ********  **********       ***                   ║");
            Console.WriteLine("\t\t║                    ***    **  ***    ***   ***   ***       ***    ***       ***           ***          *****                  ║");
            Console.WriteLine("\t\t║                    ***    *** ***    ***  ***     ***      ***    ***       ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    *********  *********   ***     ***      ***    ********* ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    ***        ***    ***  ***     ***      ***    ***       ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    ***        ***     ***  ***   ***      ***     ***       ***           ***            ***                  ║");
            Console.WriteLine("\t\t║                    ***        ***      ***  *******   ******     *********   ********     ***          *******                ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                        ╔═══════════════════════════════════════════════════════════════════════════════╗                      ║");
            Console.WriteLine("\t\t║                        ║   CHÀO MỪNG BẠN ĐẾN VỚI ỨNG DỤNG QUẢN LÝ NHÂN VIÊN PHÒNG KHÁM TÂM THIỆN MĨ    ║                      ║");
            Console.WriteLine("\t\t║                        ╚═══════════════════════════════════════════════════════════════════════════════╝                      ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                              Giáo Viên Hướng dẫn: NGUYỄN VĂN QUYẾT                                            ║");
            Console.WriteLine("\t\t║                                              Sinh Viên thực hiện: ĐỖ THỊ LY                                                   ║");
            Console.WriteLine("\t\t║                                              Lớp                : 101191A                                                     ║");
            Console.WriteLine("\t\t║                                              Mã sinh viên       : 10119487                                                    ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                        Hưng Yên 2020                                                          ║");
            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t                                              Nhấn đúp phím bất kì để vào menu chính!!!");
            Console.ReadKey();
        }
        static public void MenuQL()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Menu Quản Lý";
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\t\t║                        ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                 ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌                                                   ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.Write("\t\t║                        ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                 ▐   MENU QUẢN LÍ  ▌                                                   ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.Write("\t\t║                        ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                                 ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌                                                   ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                  ╔══════════════════════════════╗                                             ║");
            Console.WriteLine("\t\t║                                                  ║     1.Quản Lý Nhân viên      ║                                             ║");
            Console.WriteLine("\t\t║                                                  ╚══════════════════════════════╝                                             ║");
            Console.WriteLine("\t\t║                                                  ╔══════════════════════════════╗                                             ║");
            Console.WriteLine("\t\t║                                                  ║     2.Quản lý Phòng ban      ║                                             ║");
            Console.WriteLine("\t\t║                                                  ╚══════════════════════════════╝                                             ║");
            Console.WriteLine("\t\t║                                                  ╔══════════════════════════════╗                                             ║");
            Console.WriteLine("\t\t║                                                  ║     3.Quản Lý Chấm công      ║                                             ║");
            Console.WriteLine("\t\t║                                                  ╚══════════════════════════════╝                                             ║");
            Console.WriteLine("\t\t║                                                  ╔══════════════════════════════╗                                             ║");
            Console.WriteLine("\t\t║                                                  ║     4.Quản Lý Lương          ║                                             ║");
            Console.WriteLine("\t\t║                                                  ╚══════════════════════════════╝                                             ║");
            Console.WriteLine("\t\t║                                                  ╔══════════════════════════════╗                                             ║");
            Console.WriteLine("\t\t║                                                  ║     5.Thống kê               ║                                             ║");
            Console.WriteLine("\t\t║                                                  ╚══════════════════════════════╝                                             ║");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t║                                                                                                                               ║");
            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetCursorPosition(Console.CursorTop, Console.CursorLeft);
            Console.SetWindowPosition(Console.CursorLeft, Console.CursorTop);
            ConsoleKeyInfo k;
            do
            {
                Console.Clear();
                GiaoDien();
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                int check = 0;
                while (check == 0)
                {
                    MenuQL();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("Nhập chức năng: ");
                    int tm = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (tm)
                    {
                        case 1:
                            {
                                NhanVienUI nhanVienUI = new NhanVienUI();
                                nhanVienUI.Menu();
                                break;
                            }
                        case 2:
                            {
                                PhongBanUI phongBanUI = new PhongBanUI();
                                phongBanUI.Menu();
                                break;
                            }
                        case 3:
                            {
                                ChamCongUI chamCongUI = new ChamCongUI();
                                chamCongUI.Menu();
                                break;
                            }
                        case 4:
                            LuongUI luong = new LuongUI();
                            luong.Menu();
                            break;
                        case 5:
                            ThongKeUI thongKe = new ThongKeUI();
                            thongKe.Menu();
                            break;
                        case 0:
                            check = 1;
                            MenuQL();
                            break;

                        default:

                            Console.WriteLine("Sai cú pháp!");

                            break;
                    }
                }
            } while (true);
        }
       
           
        
    }
}
