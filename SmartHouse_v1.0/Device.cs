using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public abstract class Device : IStatus
    {
        public Device(bool status)
        {
            Status = status;
        }

        public bool Status { get; set; }

        public virtual void OnDevice()
        {
            if (Status == false)
            {
                Status = true;
            }
        }
        public virtual void OffDevice()
        {
            if (Status)
            {
                Status = false;
            }
        }
        public override string ToString()
        {
            string status;
            if (Status)
            {
                status = "включено";
            }
            else
            {
                status = "выключено";
            }
            return "Состояние устройства: " + status;
        }
    }
}
