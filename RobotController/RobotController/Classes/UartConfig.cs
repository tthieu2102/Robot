using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RobotController.Classes
{
    public class UartConfig
    {
        string portName;
        int baudRate;
        int dataBit;
        Parity parity;
        StopBits stopBit;
        Handshake handShake;

        public string PortName
        {
            get { return portName; }
            set { portName = value; }
        }

        public int BaudRate
        {
            get { return baudRate; }
            set { baudRate = value; }
        }

        public int DataBit
        {
            get { return dataBit; }
            set { dataBit = value; }
        } 

        public Parity Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        public StopBits StopBit
        {
            get { return stopBit; }
            set { stopBit = value; }
        }

        public Handshake HandShake
        {
            get { return handShake; }
            set { handShake = value; }
        }

        public UartConfig(string portName, int baudRate, int dataBit, 
            Parity parity, StopBits stopBit, Handshake handShake)
        {
            PortName = portName;
            BaudRate = baudRate;
            DataBit = dataBit;
            Parity = parity;
            StopBit = stopBit;
            HandShake = handShake;
        }

        public UartConfig()
        {
            // Do nothing
        }

        public SerialPort CreateSearialPort()
        {
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = PortName;
            serialPort.BaudRate = BaudRate;
            serialPort.DataBits = DataBit;
            serialPort.Parity = Parity;
            serialPort.StopBits = StopBit;
            serialPort.Handshake = HandShake;

            return serialPort;
        }
    }
}
