using System;
using System.Collections.Generic;
using System.Text;
using PROJECT1.BusinessLayer.Interface;
using PROJECT1.DataAcessLayer.DataAcess;
using PROJECT1.DataAcessLayer.Entities;

namespace PROJECT1.BusinessLayer
{
    class ChamCongBus:CRUD<ChamCong>
    {
        public delegate bool Condition(ChamCong chamCong);

        private float standardTime = 8;

        ChamCongDA chamCongDA = new ChamCongDA(); 
        public void Add(ChamCong myObject)
        {
            chamCongDA.Add(myObject);
        }

        public void Delete(string id)
        {
            chamCongDA.Xoa(id);
        }

        public int Find(string id)
        {
            return chamCongDA.Find(id);
        }

        public ChamCong GetChamCong(string id)
        {
            List<ChamCong> chamCongs = GetList();
            foreach(var item in chamCongs)
            {
                if (item.NhanVienId + item.WorkDay.ToString("MM/dd/yyyy") == id)
                    return item;
            }
            return null;
        }

        public List<ChamCong> GetList()
        {
            return chamCongDA.Laydschamcong();
        }

        public List<ChamCong> GetList(Condition condition)
        {
            List<ChamCong> chamCongs = GetList();
            List<ChamCong> result = new List<ChamCong>();
            for (int i = 0; i<chamCongs.Count; i++)
            {
                if (condition(chamCongs[i]))
                    result.Add(chamCongs[i]);
            }
            return result;
        }

        public double GetStandardTime(NhanVienRole role)
        {
            switch (role)
            {
                case NhanVienRole.NvYte:
                    return standardTime - standardTime * (30 / 100);
                case NhanVienRole.LeTan:
                    return standardTime - standardTime * (20 / 100);
                case NhanVienRole.LaoCong:
                    return standardTime - standardTime * (10 / 100);
                default:
                    return standardTime - standardTime * (5 / 100);
            }
        }

        public double GetStandardLuong(NhanVienRole role)
        {
            switch (role)
            {
                case NhanVienRole.NvYte:
                    return 20000;
                case NhanVienRole.LeTan:
                    return 15000;
                default:
                    return 12000;
            }
        }

        public List<ChamCong> GetList(Condition condition, List<ChamCong> chamCongs)
        {
            List<ChamCong> result = new List<ChamCong>();
            foreach(var i in chamCongs)
                if (condition(i))
                    result.Add(i);
            return result;
        }

        public void SaveAll(List<ChamCong> list)
        {
            chamCongDA.Ghidschamcong();
        }

        public void Update(string id, ChamCong newInfo)
        {
            chamCongDA.Update(id, newInfo);
        }

        public int Find(Condition condition)
        {
            List<ChamCong> chamCongs = GetList();
            for (int i = 0; i < chamCongs.Count; i++)
            {
                if (condition(chamCongs[i]))
                    return i;
            }
            return -1;
        }
        public ChamCong GetChamcCong(Condition condition)
        {
            List<ChamCong> resource = GetList();
            foreach (var item in resource)
                if (condition(item))
                    return item;
            return null;
        }
    }
}
