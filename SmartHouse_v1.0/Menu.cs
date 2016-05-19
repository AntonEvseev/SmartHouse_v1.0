using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartHouse_v1._0
{
    public class Menu
    {
        private IDictionary<string, Device> DevicesDictionary = new Dictionary<string, Device>();
        private int temp;
        private int ch;
        public string Input { get; set; }
        public ICreate NewDevice { set; get; }
        public void Show()
        {
            NewDevice = new CreateDevice();
            DevicesDictionary.Add("conditioner", NewDevice.CreateConditioner());
            DevicesDictionary.Add("lamp", NewDevice.CreateLamp());
            DevicesDictionary.Add("tv", NewDevice.CreateTV());
            DevicesDictionary.Add("radio", NewDevice.CreateRadio());
            DevicesDictionary.Add("fridge", NewDevice.CreateFridge());
            while (true)
            {
                Console.Clear();
                foreach (var dev in DevicesDictionary)
                {
                    Console.WriteLine("Название: " + dev.Key + ", " + dev.Value.ToString());
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");
                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    return;
                }
                if (commands.Length != 3)
                {
                    Help();
                    continue;
                }
                if (commands[0].ToLower() == "add" && !DevicesDictionary.ContainsKey(commands[2]))
                {
                    if (commands[1] == "conditioner")
                    {
                        DevicesDictionary.Add(commands[2], NewDevice.CreateConditioner());
                        continue;
                    }
                    if (commands[1] == "lamp")
                    {
                        DevicesDictionary.Add(commands[2], NewDevice.CreateLamp());
                        continue;
                    }
                    if (commands[1] == "tv")
                    {
                        DevicesDictionary.Add(commands[2], NewDevice.CreateTV());
                        continue;
                    }
                    if (commands[1] == "radio")
                    {
                        DevicesDictionary.Add(commands[2], NewDevice.CreateRadio());
                        continue;
                    }
                    if (commands[1] == "fridge")
                    {
                        DevicesDictionary.Add(commands[2], NewDevice.CreateRadio());
                        continue;
                    }
                }
                if (commands[0].ToLower() == "add" && DevicesDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    continue;
                }
                if (commands[0].ToLower() == "del" && !DevicesDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Выполнение команды невозможно, т.к. устройство с таким именем не существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    continue;
                }
                if (!DevicesDictionary.ContainsKey(commands[2]))
                {
                    Help();
                    continue;
                }

                if (commands[0].ToLower() == "del" && DevicesDictionary.ContainsKey(commands[2]))
                {
                    DevicesDictionary.Remove(commands[2]);
                    continue;
                }
                switch (commands[0].ToLower())
                {
                    case "on":
                        DevicesDictionary[commands[2]].OnDevice();
                        break;
                    case "off":
                        DevicesDictionary[commands[2]].OffDevice();
                        break;
                }
                if (DevicesDictionary[commands[2]] is IConditionerMode)
                {
                    IConditionerMode m = (IConditionerMode)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "cool":
                            m.SetCoolMode();
                            break;
                        case "heat":
                            m.SetHeatMode();
                            break;
                        case "dry":
                            m.SetDryMode();
                            break;
                        case "fan":
                            m.SetFanMode();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ISetTemp)
                {
                    ISetTemp t = (ISetTemp)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {

                        case "settemp":
                            Console.WriteLine("Введите уровень температуры в пределах 16...30: ");
                            Input = Console.ReadLine();
                            if (Int32.TryParse(Input, out temp))
                            {
                                if (temp < 16 || temp > 30)
                                {
                                    Console.WriteLine("Ошибка! Недопустимое значение температуры!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    t.SetTemp(temp);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Некорректный ввод температуры!");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ISetVolume)
                {
                    ISetVolume v = (ISetVolume)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "upvolume":
                            v.UpVolume();
                            break;
                        case "lessvolume":
                            v.LessVolume();
                            break;
                        case "setvolume":
                            Console.WriteLine("Введите громкость в пределах 0...100: ");
                            Input = Console.ReadLine();
                            if (Int32.TryParse(Input, out temp))
                            {
                                if (temp < 0 || temp > 100)
                                {
                                    Console.WriteLine("Ошибка! Недопустимое значение громкости!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    v.SetVolume(temp);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Некорректный ввод громкости!");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ISetChannel)
                {
                    ISetChannel c = (ISetChannel)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "nextchannel":
                            c.NextChannel();
                            break;
                        case "previouschannel":
                            c.PreviousChannel();
                            break;
                        case "setchannel":
                            Console.WriteLine("Введите канал в пределах 0...200: ");
                            Input = Console.ReadLine();
                            if (Int32.TryParse(Input, out ch))
                            {
                                if (ch < 0 || ch > 200)
                                {
                                    Console.WriteLine("Ошибка! Недопустимое значение канала!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    c.SetChannel(ch);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Некорректный ввод канала!");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ILampMode)
                {
                    ILampMode l = (ILampMode)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "low":
                            l.SetLowBrightness();
                            break;
                        case "medium":
                            l.SetMediumBrightness();
                            break;
                        case "high":
                            l.SetHighBrightness();
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is ISetWave)
                {
                    ISetWave w = (ISetWave)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "upwave":
                            w.UpWave();
                            break;
                        case "lesswave":
                            w.LessWave();
                            break;
                        case "setwave":
                            Console.WriteLine("Введите волну FM в пределах 87.5...108: ");
                            Input = Console.ReadLine();
                            if (Int32.TryParse(Input, out temp))
                            {
                                if (temp < 87.5 || temp > 108)
                                {
                                    Console.WriteLine("Ошибка! Недопустимое значение волны FM!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    w.SetWave(temp);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Некорректный ввод волны FM!");
                                Console.ReadKey();
                            }
                            break;
                    }
                }
                if (DevicesDictionary[commands[2]] is IFridgeMode)
                {
                    IFridgeMode f = (IFridgeMode)DevicesDictionary[commands[2]];
                    switch (commands[0].ToLower())
                    {
                        case "superfreezing":
                            f.SetSuperFreezing();
                            break;
                        case "freezing":
                            f.SetFreezing();
                            break;
                        case "defrost":
                            f.SetDefrost();
                            break;
                    }
                }
            }
        }
        private static void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd Device nameDevice");
            Console.WriteLine("\tdel Device nameDevice");
            Console.WriteLine("\ton Device nameDevice");
            Console.WriteLine("\toff Device nameDevice");
            Console.WriteLine("Доступные команды для кондиционера:");
            Console.WriteLine("\tcool conditioner nameDevice");
            Console.WriteLine("\theat conditioner nameDevice");
            Console.WriteLine("\tfan conditioner nameDevice");
            Console.WriteLine("\tdry conditioner nameDevice");
            Console.WriteLine("\tsettemp conditioner nameDevice");
            Console.WriteLine("Доступные команды для лампы:");
            Console.WriteLine("\tlow lamp nameDevice");
            Console.WriteLine("\tmedium lamp nameDevice");
            Console.WriteLine("\thigh lamp nameDevice");
            Console.WriteLine("Доступные команды для телевизора:");
            Console.WriteLine("\tsetvolume tv nameDevice");
            Console.WriteLine("\tsetchannel tv nameDevice");
            Console.WriteLine("\tnextchannel tv nameDevice");
            Console.WriteLine("\tpreviouschannel tv nameDevice");
            Console.WriteLine("\tupvolume tv nameDevice");
            Console.WriteLine("\tlessvolume tv nameDevice");
            Console.WriteLine("Доступные команды для радио:");
            Console.WriteLine("\tsetvolume radio nameDevice");
            Console.WriteLine("\tupvolume radio nameDevice");
            Console.WriteLine("\tlessvolume radio nameDevice");
            Console.WriteLine("\tsetwave radio nameDevice");
            Console.WriteLine("\tupwave radio nameDevice");
            Console.WriteLine("\tlesswave radio nameDevice");
            Console.WriteLine("Доступные команды для холодильника:");
            Console.WriteLine("\tsuperfreezing fridge nameDevice");
            Console.WriteLine("\tfreezing fridge nameDevice");
            Console.WriteLine("\tdefrost fridge nameDevice");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
