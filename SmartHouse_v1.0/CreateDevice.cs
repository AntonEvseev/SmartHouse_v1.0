using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public class CreateDevice : ICreate
    {
        public Conditioner CreateConditioner()
        {
            return new Conditioner(false);
        }
        public Lamp CreateLamp()
        {
            return new Lamp(false);
        }
        public TV CreateTV()
        {
            return new TV(false);
        }
        public Radio CreateRadio()
        {
            return new Radio(false);
        }
        public Fridge CreateFridge()
        {
            return new Fridge(false);
        }
    }
}
