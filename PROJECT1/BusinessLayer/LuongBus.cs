using System;
using System.Collections.Generic;
using System.Text;
using PROJECT1.BusinessLayer.Interface;
using PROJECT1.DataAcessLayer.DataAcess;
using PROJECT1.DataAcessLayer.Entities;

namespace PROJECT1.BusinessLayer
{
    class LuongBus:CRUD<Luong>
    {
        public delegate bool Condition(Luong luong);
        private float NvYte = 20;
        private float LeTan = 15;
        private float LaoCong = 12;
        private float Baove = 12;

        LuongDA luongDA = new LuongDA();
        public void Add(Luong myObject)
        {
            luongDA.Add(myObject);
        }

        public void Delete(string id)
        {
            luongDA.Xoa(id);
        }

        public int Find(string id)
        {
            return luongDA.Find(id);
        }

        public List<Luong> GetList()
        {
            return luongDA.Laydsluong();
        }
        public List<Luong> GetList(Condition condition)
        {
            List<Luong> luongs = GetList();
            List<Luong> result = new List<Luong>();
            for (int i = 0; i < luongs.Count; i++)
            {
                if (condition(luongs[i]))
                    result.Add(luongs[i]);
            }
            return result;
        }
        public void SaveAll(List<Luong> list)
        {
            luongDA.Ghidsluong();
        }

        public void Update(string id, Luong newInfo)
        {
            luongDA.Ghidsluong(id, newInfo);
        }
        
    }
}
