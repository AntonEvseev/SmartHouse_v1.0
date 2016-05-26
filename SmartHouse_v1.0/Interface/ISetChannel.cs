using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public interface ISetChannel
    {
        int Channel { get; set; }
        void SetChannel(int input);
        void NextChannel();
        void PreviousChannel();
    }
}
