using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PROJECT1.BusinessLayer.Interface;
using PROJECT1.DataAcessLayer.DataAcess;
using PROJECT1.DataAcessLayer.Entities;

namespace PROJECT1.BusinessLayer
{
    class NhanVienBus : CRUD<NhanVien>
    {
        NhanVienDA NhanVienDA = new NhanVienDA();
        public void Add(NhanVien myObject)
        {
            NhanVienDA.AddNV(myObject);
        }

        public void Delete(string id)
        {
            NhanVienDA.Xoa(id);
        }

        public int Find(string id)
        {
            return NhanVienDA.Find(id);
        }

        public int Find(string id, List<NhanVien> nhanViens)
        {
            for(int i = 0; i<nhanViens.Count; i++)
            {
                if (nhanViens[i].ID == id)
                    return i;
            }
            return -1;
        }

        public List<NhanVien> GetList()
        {
            return NhanVienDA.LayDanhSachNhanVien();
        }

        public void SaveAll(List<NhanVien> list)
        {
            NhanVienDA.GhiDanhsachNhanVien(list);
        }

        public void Update(string id, NhanVien newInfo)
        {
            NhanVienDA.EditNV( id, newInfo);
        }

        public NhanVienRole GetVienRole(string qualification)
        {
            qualification = qualification.Trim();
            qualification = qualification.ToLower();
            if (qualification == "bác sĩ" || qualification == "hộ lý" || qualification == "điều dưỡng")
                return NhanVienRole.NvYte;
            else if (qualification == "lễ tân" || qualification == "thu ngân")
                return NhanVienRole.LeTan;
            else if (qualification == "lao công")
                return NhanVienRole.LaoCong;
            return NhanVienRole.BaoVe;
        }
        public bool KTraMaTonTai(string id)
        {
            if (GetList().Count == 0)
            {
                return false;
            }
            else
            {
                foreach (NhanVien TTin in GetList())
                {
                    if (TTin.ID == id)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool KTraId(string id)
        {
            bool Check = true;
            if (id.Length != 5)
            {
                Check = false;
            }
            return Check;
        }
        public bool KTname( string hoten)
        {
            bool Check = true;
            while (true)
            {
                if (hoten.Length >= 10)
                    Check = false;
                break;
            }
            return Check;
        }
        public bool KTphone(string SDT)
        {
            bool check = true;
            while (true)
            {
                if (SDT.Length == 10)
                    check = false;
                break;
               
            }
            return check;
        }
    }
}
