using RobotController.Classes;
using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace RobotController
{
    public partial class MainForm : Form
    {
        string keyXmlFilePath = "Keys.xml";
        string uartXmlFilePath = "Uart.xml";
        ControlKeys controlKeys;
        SerialPort serialPort;

        public SerialPort SerialPort
        {
            get { return serialPort; }
            set
            {
                if (value != null)
                {
                    serialPort = value;
                }
            }
        }

        public string KeyXmlFilePath
        {
            get { return keyXmlFilePath; }
            set { keyXmlFilePath = value; }
        }

        public ControlKeys ControlKeys
        {
            get { return controlKeys; }
            set
            {
                if (value != null)
                {
                    controlKeys = value;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();

            KeysReader keyReader = new KeysReader(keyXmlFilePath);
            ControlKeys = keyReader.ReadKeys();

            UartReader uartReader = new UartReader(uartXmlFilePath);
            SerialPort = uartReader.ReadUart().CreateSearialPort();
        }

        private void buttonController_Click(object sender, EventArgs e)
        {
            ControlForm controlForm = new ControlForm(this);
            controlForm.Show();

            this.Hide();
        }

        private void buttonKeySettings_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(this, keyXmlFilePath, uartXmlFilePath);
            settingForm.Show(this);

            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
