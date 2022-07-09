using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using PROJECT1.BusinessLayer.Interface;
using PROJECT1.DataAcessLayer.DataAcess;
using PROJECT1.DataAcessLayer.Entities;

namespace PROJECT1.BusinessLayer
{
    class PhongBanBus : CRUD<PhongBan>
    {
        public delegate bool Condition(PhongBan phongBan);
        PhongBanDA PhongBanDA = new PhongBanDA();
        public void Add(PhongBan myObject)
        {
            PhongBanDA.AddPB(myObject);
        }

        public void Delete(string id)
        {
            PhongBanDA.Xoa(id);
        }

        public int Find(string id)
        {
            throw new NotImplementedException();
        }

        public int GetIndex(string id)
        {
            return PhongBanDA.GetIndex(id);
        }

        public List<PhongBan> GetList()
        {
            return PhongBanDA.LayDanhSachPhongBan();
        }

        public PhongBan GetPhongBan(Condition condition)
        {
            List<PhongBan> resource = GetList();
            foreach (var item in resource)
                if (condition(item))
                    return item;
            return null;
        }

        public void SaveAll(List<PhongBan> list)
        {
            PhongBanDA.GhiDanhsachPhongBan();
        }

        public void Update(string id, PhongBan newInfo)
        {
            PhongBanDA.EditPB(id, newInfo);
        }
        public bool KTraMaTonTai(string id)
        {
            bool Check = false;
            if (GetList().Count == 0)
            {
                return Check;
            }
            else
            {
                foreach (PhongBan TTin in GetList())
                {
                    if (TTin.ID == id)
                    {
                        Check = true;
                        break;
                    }
                }
                return Check;
            }
        }
        public bool KTraId(string id)
        {
            bool Check = true;
            Regex Pattern = new Regex(@"[a-zA-Z0-9]");
            for (int i = 0; i < id.Length; i++)
            {
                if (Pattern.IsMatch(id.Substring(i, 1)) == false)
                {
                    Check = false;
                    break;
                }
                if (id.Length != 8)
                {
                    Check = false;
                    break;
                }
            }
            return Check;
        }
        public bool KTname(string tenpb)
        {
            bool Check = true;
            while (true)
            {
                if (tenpb.Length >= 10)
                    Check = false;
                break;
            }
            return Check;
        }
    }
}
