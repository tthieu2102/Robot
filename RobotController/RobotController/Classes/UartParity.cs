using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Classes
{
    public class UartParity
    {
        private int id;
        private string name;

        public static List<UartParity> UartParities
        {
            get
            {
                List<UartParity> result = new List<UartParity>();

                result.Add(new UartParity(0, Parity.None.ToString()));
                result.Add(new UartParity(1, Parity.Odd.ToString()));
                result.Add(new UartParity(2, Parity.Even.ToString()));
                result.Add(new UartParity(3, Parity.Mark.ToString()));
                result.Add(new UartParity(4, Parity.Space.ToString()));

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

        public UartParity(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
