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
    class LuongDA
    {
        private string FilePath = "Luong.txt";
        public List<Luong> Laydsluong()
        {
            List<Luong> luongs = new List<Luong>();
            if (!File.Exists(FilePath))
                File.Create(FilePath).Close();

            StreamReader ReadFile = new StreamReader(FilePath);
            string line = ReadFile.ReadLine();
            while (line != null)
            {
                string[] Tachthongtin = line.Split('|');
                Luong ttin = new Luong(Tachthongtin[0], int.Parse(Tachthongtin[1]), int.Parse(Tachthongtin[2]), int.Parse(Tachthongtin[3]));
                luongs.Add(ttin);
                line = ReadFile.ReadLine();
            }
            ReadFile.Close();
            return luongs;
        }

        internal void Ghidsluong(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Luong myObject)
        {
            StreamWriter writer = new StreamWriter(FilePath, true);
            writer.WriteLine(myObject);
            writer.Close();
        }

        internal void Ghidsluong()
        {
            throw new NotImplementedException();
        }

        public void Ghidsluong(List<Luong> list)
        {
            StreamWriter streamWriter = new StreamWriter(FilePath);
            foreach (var item in list)
            {
                streamWriter.WriteLine(item);
            }
            streamWriter.Close();
        }

        internal void Ghidsluong(string id, Luong newInfo)
        {
            throw new NotImplementedException();
        }

        public void Xoa(string id)
        {
            List<Luong> luongs = Laydsluong();
            luongs.RemoveAt(Find(id));
            Ghidsluong(luongs);
        }

        public int Find(string id)
        {
            List<Luong> luongs = Laydsluong();
            for (int i = 0; i < luongs.Count; i++)
            {
                if (luongs[i].NhanVienId +luongs[i].Basicsalary.ToString() +luongs[i].Subsidiessalary.ToString()+luongs[i].Bonuses.ToString() ==id)
                    return i;
            }
            return -1;

        }
    }
}
