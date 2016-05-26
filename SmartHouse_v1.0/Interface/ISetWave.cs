using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public interface ISetWave
    {
        double Wave { get; set; }
        void SetWave(double input);
        void UpWave();
        void LessWave();
    }
}
