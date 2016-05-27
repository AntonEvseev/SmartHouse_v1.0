using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public class Fridge : Device, IFridgeMode
    {
        private int temp;
        private FridgeMode mode;
        public Fridge(bool status)
            : base(status)
        {
            Status = status;
        }
        public void SetSuperFreezing()
        {
            if (Status)
            {
                mode = FridgeMode.superfreezing;
            }
        }
        public void SetFreezing()
        {
            if (Status)
            {
                mode = FridgeMode.freezing;
            }
        }
        public void SetDefrost()
        {
            if (Status)
            {
                mode = FridgeMode.defrost;
            }
        }
        public override string ToString()
        {
            string mod;
            if (mode == FridgeMode.defrost)
            {
                mod = "разморозка";
                temp = 0;
            }
            else if (mode == FridgeMode.freezing)
            {
                mod = "заморозка";
                temp = -15;
            }
            else if (mode == FridgeMode.superfreezing)
            {
                mod = "суперзаморозка";
                temp = -24;
            }
            else
            {
                mod = "не задан";
                temp = 0;
            }
            return base.ToString() + ", режим: " + mod + ", \nуровень температуры: " + temp + "*C";
        }
    }
}
