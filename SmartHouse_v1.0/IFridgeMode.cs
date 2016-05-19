using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public interface IFridgeMode
    {
        void SetSuperFreezing();
        void SetFreezing();
        void SetDefrost();
    }
}
