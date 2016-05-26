using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public interface IConditionerMode
    {
        void SetCoolMode();
        void SetHeatMode();
        void SetFanMode();
        void SetDryMode();
    }
}
