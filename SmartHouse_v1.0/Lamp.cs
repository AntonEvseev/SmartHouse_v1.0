using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public class Lamp : Device, ILampMode
    {
        private BrightnessLevel mode;
        public Lamp(bool status)
            : base(status)
        {
            Status = status;
        }
        public override void OnDevice()
        {
            if (Status == false)
            {
                Status = true;
            }
        }
        public override void OffDevice()
        {
            if (Status)
            {
                Status = false;
            }
        }
        public void SetLowBrightness()
        {
            if (Status)
            {
                mode = BrightnessLevel.Low;
            }
        }
        public void SetMediumBrightness()
        {
            if (Status)
            {
                mode = BrightnessLevel.Medium;
            }
        }
        public void SetHighBrightness()
        {
            if (Status)
            {
                mode = BrightnessLevel.High;
            }
        }
        public override string ToString()
        {
            string mod;
            if (mode == BrightnessLevel.Low)
            {
                mod = "низкий";
            }
            else if (mode == BrightnessLevel.Medium)
            {
                mod = "средний";
            }
            else if (mode == BrightnessLevel.High)
            {
                mod = "высокий";
            }
            else
            {
                mod = "не задан";
            }
            return base.ToString() + ", режим яркости: " + mod;
        }
    }
}
