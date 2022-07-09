using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT1.DataAcessLayer.Entities
{
    enum NhanVienRole
    {
        NvYte, LeTan, LaoCong, BaoVe
    }
    class NhanVien
    {
        private string id;
        private string name;
        private string general;
        private string dob;
        private string address;
        private string phone;
        private string pbid;
        private string qualification; 
        public NhanVien()
        {

        }
        public NhanVien(string id, string name, string general, string dob, string address, string phone, string pbid, string qualification)
        {
            this.id = id;
            this.name = name;
            this.general = general;
            this.dob = dob;
            this.address = address;
            this.phone = phone;
            this.pbid = pbid;
            this.qualification = qualification;
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string General
        {
            get { return this.general; }
            set { this.general = value; }
        }

        public string Dob
        {
            get { return this.dob; }
            set { this.dob = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Pbid
        {
            get { return this.pbid; }
            set { this.pbid = value; }
        }

        public string Qualification
        {
            get { return this.qualification; }
            set { this.qualification = value; }
        }
    }
}
