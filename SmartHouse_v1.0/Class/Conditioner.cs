using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public class Conditioner : Device, IConditionerMode, ISetTemp
    {
        private ConditionerMode mode;
        private int temp;
        public Conditioner(bool status)
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
        public void SetCoolMode()
        {
            if (Status)
            {
                mode = ConditionerMode.Cool;
            }
        }
        public void SetHeatMode()
        {
            if (Status)
            {
                mode = ConditionerMode.Heat;
            }
        }
        public void SetFanMode()
        {
            if (Status)
            {
                mode = ConditionerMode.Fan;
            }
        }
        public void SetDryMode()
        {
            if (Status)
            {
                mode = ConditionerMode.Dry;
            }
        }
        public void SetTemp(int input)
        {
            if (Status)
            {
                temp = input;
            }
        }
        public int Temp
        {
            get
            {
                return temp;
            }
            set
            {
                if (value >= 16 && value <= 30)
                {
                    temp = value;
                }
            }
        }
        public override string ToString()
        {
            string mod;
            if (mode == ConditionerMode.Cool)
            {
                mod = "охлаждение";
            }
            else if (mode == ConditionerMode.Heat)
            {
                mod = "обогрев";
            }
            else if (mode == ConditionerMode.Fan)
            {
                mod = "вентилятор";
            }
            else if (mode == ConditionerMode.Dry)
            {
                mod = "очистка";
            }
            else
            {
                mod = "не задан";
            }
            return base.ToString() + ", режим: " + mod + ", \nуровень температуры: " + temp;
        }
    }
}
