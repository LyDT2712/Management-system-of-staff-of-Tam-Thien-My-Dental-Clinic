using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT1.DataAcessLayer.Entities
{
    class Luong
    {
        private string nhanVienId;
        private int basicsalary; //Lương cơ bản
        private int subsidiessalary;  //Lương phụ cấp
        private int bonuses; //Thưởng

        public Luong()
        {

        }
        public Luong(string nhanVienId, int basicsalary, int subsidiessalary, int bonuses)
        {
            this.nhanVienId = nhanVienId;
            this.basicsalary = basicsalary;
            this.Subsidiessalary = subsidiessalary;
            this.bonuses = bonuses;
        }
        public string NhanVienId { get => nhanVienId; set => nhanVienId = value; }
        public int Basicsalary { get => basicsalary; set => basicsalary = value; }
        public int Subsidiessalary { get => subsidiessalary; set => subsidiessalary = value; }
        public int Bonuses { get => bonuses; set => bonuses = value; }
    }
}
