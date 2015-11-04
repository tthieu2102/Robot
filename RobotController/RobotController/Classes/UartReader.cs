using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RobotController.Classes
{
    public class UartReader
    {
        string uartXmlFilePath;
        XmlDocument xmlDocument;

        public string UartXmlFilePath
        {
            get { return uartXmlFilePath; }
            private set { uartXmlFilePath = value; }
        }

        private XmlDocument XmlDocument
        {
            get { return xmlDocument; }
            set
            {
                if (value != null)
                {
                    xmlDocument = value;
                }
            }
        }

        public UartReader(string uartXmlFilePath)
        {
            // Assign file path
            UartXmlFilePath = uartXmlFilePath;

            // Initialize documents
            XmlDocument = new XmlDocument();
            XmlDocument.Load(UartXmlFilePath);
        }

        public UartConfig ReadUart()
        {
            // Preparations
            UartConfig result = new UartConfig();

            // Get Keys Xml element
            XmlElement portNameElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/port_name");
            XmlElement baudRateElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/baud_rate");
            XmlElement dataBitElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/data_bits");
            XmlElement parityElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/parity");
            XmlElement stopBitElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/stop_bits");
            XmlElement handShakeElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/hand_shake");

            result.PortName = portNameElement.InnerText;
            result.BaudRate = int.Parse(baudRateElement.InnerText);
            result.DataBit = int.Parse(dataBitElement.InnerText);
            result.Parity = (Parity)int.Parse(parityElement.InnerText);
            result.StopBit = (StopBits)int.Parse(stopBitElement.InnerText);
            result.HandShake = (Handshake)int.Parse(handShakeElement.InnerText);

            return result;
        }

        public void WriteUart(UartConfig uartConfig)
        {
            if (uartConfig != null)
            {
                // Get Keys Xml element
                XmlElement portNameElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/port_name");
                XmlElement baudRateElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/baud_rate");
                XmlElement dataBitElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/data_bits");
                XmlElement parityElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/parity");
                XmlElement stopBitElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/stop_bits");
                XmlElement handShakeElement = (XmlElement)XmlDocument.SelectSingleNode("/uart/hand_shake");

                portNameElement.InnerText = uartConfig.PortName;
                baudRateElement.InnerText = uartConfig.BaudRate.ToString();
                dataBitElement.InnerText = uartConfig.DataBit.ToString();
                parityElement.InnerText = ((int)uartConfig.Parity).ToString();
                stopBitElement.InnerText = ((int)uartConfig.StopBit).ToString();
                handShakeElement.InnerText = ((int)uartConfig.HandShake).ToString();

                // Write to file
                XmlDocument.Save(UartXmlFilePath);
            }
        }
    }
}
