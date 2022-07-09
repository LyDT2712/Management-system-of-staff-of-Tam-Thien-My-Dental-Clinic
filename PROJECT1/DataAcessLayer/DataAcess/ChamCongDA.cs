using PROJECT1.DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PROJECT1.BusinessLayer.Interface;

namespace PROJECT1.DataAcessLayer.DataAcess
{
    class ChamCongDA
    {
        private string FilePath = "ChamCong.txt";

        
        public List<ChamCong> Laydschamcong()
        {
            if (!File.Exists(FilePath))
                File.Create(FilePath).Close();
            List<ChamCong> chamCongs = new List<ChamCong>();
            StreamReader reader = new StreamReader(FilePath);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] infos = line.Split('#');
                chamCongs.Add(new ChamCong(infos[0], DateTime.Parse(infos[1]), DateTime.Parse(infos[2]), DateTime.Parse(infos[3])));
            }
            reader.Close();
            return chamCongs;
        }
        public void Add(ChamCong myObject)
        {
            StreamWriter writer = new StreamWriter(FilePath, true);
            writer.WriteLine(myObject);
            writer.Close();
        }
        public void Ghidschamcong(List<ChamCong> list)
        {
            StreamWriter streamWriter = new StreamWriter(FilePath);
            foreach (var item in list)
            {
                streamWriter.WriteLine(item);
            }
            streamWriter.Close();
        }

        public void Xoa(string id)
        {
            List<ChamCong> chamCongs = Laydschamcong();
            chamCongs.RemoveAt(Find(id));
            Ghidschamcong(chamCongs);
        }

        public int Find(string id)
        {
            List<ChamCong> chamCongs = Laydschamcong();
            for(int i = 0; i<chamCongs.Count; i++)
            {
                if (chamCongs[i].NhanVienId + chamCongs[i].WorkDay.ToString("MM/dd/yyyy") == id)
                    return i;
            }
            return -1;
            
        }

        public void Update(string id, ChamCong newInfo)
        {
            List<ChamCong> chamCongs = Laydschamcong();
            chamCongs[Find(id)] = newInfo;
            Ghidschamcong(chamCongs);
        }
        //Lấy danh sách
        internal void Ghidschamcong()
        {
            List<ChamCong> chamCongs = Laydschamcong();
            Ghidschamcong(chamCongs);

        }
        internal void Show()
        {
            Console.WriteLine();
        }
    }
}
