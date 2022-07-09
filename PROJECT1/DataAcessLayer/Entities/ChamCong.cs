using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT1.DataAcessLayer.Entities
{
    class ChamCong
    {
        private string nhanVienId;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime workDay;

        public ChamCong()
        {

        }

        public ChamCong(string nhanVienId, DateTime startTime, DateTime endTime, DateTime workDay)
        {
            this.nhanVienId = nhanVienId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.workDay = workDay;
        }

        public string NhanVienId { get => nhanVienId; set => nhanVienId = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public DateTime WorkDay { get => workDay; set => workDay = value; }

        public override string ToString()
        {
            return NhanVienId  + "#" + startTime.ToString("HH:mm") + "#" + endTime.ToString("HH:mm") + "#" + workDay.ToString("MM/dd/yyyy");
        }
    }
}
