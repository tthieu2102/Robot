using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Classes
{
    public class UartStopBit
    {
        int id;
        string name;

        public static List<UartStopBit> UartStopBits
        {
            get
            {
                List<UartStopBit> result = new List<UartStopBit>();

                result.Add(new UartStopBit(0, StopBits.None.ToString()));
                result.Add(new UartStopBit(1, StopBits.One.ToString()));
                result.Add(new UartStopBit(2, StopBits.Two.ToString()));
                result.Add(new UartStopBit(3, StopBits.OnePointFive.ToString()));

                return result;
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public UartStopBit(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
