using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public interface ISetVolume
    {
        int Volume { get; set; }
        void SetVolume(int input);
        void UpVolume();
        void LessVolume();
    }
}
