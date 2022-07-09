using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT1.DataAcessLayer.Entities
{
    class PhongBan
    {
        private string idpb;
        private string namepb;
        private string function; //Chức năng
        public PhongBan()
        {

        }
        public PhongBan(string idpb, string namepb, string function)
        {
            this.idpb = idpb;
            this.namepb = namepb;
            this.function = function;
        }
        public string ID
        {
            get { return this.idpb; }
            set { this.idpb = value; }
        }
        public string Name
        {
            get { return this.namepb; }
            set { this.namepb = value; }
        }
        public string Function
        {
            get { return this.function; }
            set { this.function = value; }
        }
    }
}
