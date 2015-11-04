using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RobotController.Classes
{
    public class UartHandShake
    {
        private int id;
        private string name;

        public static List<UartHandShake> UartHandShakes
        {
            get
            {
                List<UartHandShake> result = new List<UartHandShake>();

                result.Add(new UartHandShake(0, Handshake.None.ToString()));
                result.Add(new UartHandShake(1, Handshake.XOnXOff.ToString()));
                result.Add(new UartHandShake(2, Handshake.RequestToSend.ToString()));
                result.Add(new UartHandShake(3, Handshake.RequestToSendXOnXOff.ToString()));

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

        public UartHandShake(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
