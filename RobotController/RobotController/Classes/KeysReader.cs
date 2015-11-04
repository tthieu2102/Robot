using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RobotController.Classes
{
    public class KeysReader
    {
        string filePath;
        XmlDocument xmlDocument;
       
        public string FilePath
        {
            get { return filePath; }
            private set { filePath = value; }
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

        public KeysReader(string filePath)
        {
            // Assign class fields
            FilePath = filePath;

            // Initialize documents
            XmlDocument = new XmlDocument();
            XmlDocument.Load(FilePath);
        }

        public ControlKeys ReadKeys()
        {
            // Preparations
            ControlKeys result = new ControlKeys();

            // Get Keys Xml element
            XmlElement keyUpElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/up");
            XmlElement keyDownElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/down");
            XmlElement keyLeftElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/left");
            XmlElement keyRightElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/right");
            XmlElement keyTermElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/term");

            result.KeyUp = Char.Parse(keyUpElement.InnerText.ToUpper());
            result.KeyDown = Char.Parse(keyDownElement.InnerText.ToUpper());
            result.KeyLeft = Char.Parse(keyLeftElement.InnerText.ToUpper());
            result.KeyRight = Char.Parse(keyRightElement.InnerText.ToUpper());
            result.KeyTerm = Char.Parse(keyTermElement.InnerText);

            return result;
        }

        public void WriteKeys(ControlKeys keys)
        {
            if (keys != null)
            {
                XmlElement keyUpElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/up");
                XmlElement keyDownElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/down");
                XmlElement keyLeftElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/left");
                XmlElement keyRightElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/right");
                XmlElement keyTermElement = (XmlElement)XmlDocument.SelectSingleNode("/keys/term");

                keyUpElement.InnerText = keys.KeyUp.ToString();
                keyDownElement.InnerText = keys.KeyDown.ToString();
                keyLeftElement.InnerText = keys.KeyLeft.ToString();
                keyRightElement.InnerText = keys.KeyRight.ToString();
                keyTermElement.InnerText = keys.KeyTerm.ToString();

                // Save to file
                XmlDocument.Save(FilePath);
            }
        }
    }
}
