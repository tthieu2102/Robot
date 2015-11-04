using RobotController.Classes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace RobotController
{
    public partial class SettingForm : Form
    {
        MainForm containerForm;
        string xmlKeyFilePath;
        string xmlUartFilePath;
        KeysReader keyReader;
        UartReader uartReader;

        ControlKeys keys;

        UartConfig uartConfig;

        public UartConfig UartConfig
        {
            get { return uartConfig; }
            set
            {
                if (value != null)
                {
                    uartConfig = value;
                }
            }
        }

        public UartReader UartReader
        {
            get { return uartReader; }
            set
            {
                if (value != null)
                {
                    uartReader = value;
                }
            }
        }

        public ControlKeys Keys
        {
            get { return keys; }
            set
            {
                if (value != null)
                {
                    keys = value;
                }
            }
        }

        public string XmlKeyFilePath
        {
            get { return xmlKeyFilePath; }
            set { xmlKeyFilePath = value; }
        }

        public string XmlUartFilePath
        {
            get { return xmlUartFilePath; }
            set { xmlUartFilePath = value; }
        }

        public MainForm ContainerForm
        {
            get { return containerForm; }
            set
            {
                if (value != null)
                {
                    containerForm = value;
                }
            }
        }

        public KeysReader KeyReader
        {
            get { return keyReader; }
            set
            {
                if (value != null)
                {
                    keyReader = value;
                }
            }
        }

        public SettingForm(MainForm container, string xmlKeyFilePath, string xmlUartFilePath)
        {
            InitializeComponent();

            ContainerForm = container;
            XmlKeyFilePath = xmlKeyFilePath;
            XmlUartFilePath = xmlUartFilePath;
            KeyReader = new KeysReader(XmlKeyFilePath);
            UartReader = new UartReader(xmlUartFilePath);

            // Update control Keys
            Keys = KeyReader.ReadKeys();
            UartConfig = UartReader.ReadUart();

            // Initialize uart port
            InitializeUartControls();

            // Write data to controls
            WriteKeysToTextboxes();
            WriteUartConfigToControls();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (CheckKeysCondition() == true)
            {
                // Create Keys instance
                WriteTextBoxesToKeys();

                // Write to xml
                KeyReader.WriteKeys(keys);

                // Update new control keys for container
                ContainerForm.ControlKeys = keys;

                // Show message
                MessageBox.Show("Update successfully!");
            }
            else
            {
                // Show message
                MessageBox.Show("Update failed! Rolling changes back");

                WriteKeysToTextboxes();
            }
        }

        private bool CheckKeysCondition()
        {
            int keyUpCount = textBoxConfigUp.Text.Length;
            int keyDownCount = textBoxConfigDown.Text.Length;
            int keyLeftCount = textBoxConfigLeft.Text.Length;
            int keyRightCount = textBoxConfigRight.Text.Length;
            int keyTermCount = textBoxConfigTerm.Text.Length;

            return ((keyUpCount == 1) && (keyDownCount == 1) && (keyLeftCount == 1) &&
                (keyRightCount == 1) && (keyTermCount == 1));
        }

        private void WriteKeysToTextboxes()
        {
            textBoxConfigUp.Text = keys.KeyUp.ToString();
            textBoxConfigDown.Text = keys.KeyDown.ToString();
            textBoxConfigLeft.Text = keys.KeyLeft.ToString();
            textBoxConfigRight.Text = keys.KeyRight.ToString();
            textBoxConfigTerm.Text = keys.KeyTerm.ToString();
        }

        private void WriteTextBoxesToKeys()
        {
            keys.KeyUp = Char.Parse(textBoxConfigUp.Text);
            keys.KeyDown = Char.Parse(textBoxConfigDown.Text);
            keys.KeyLeft = Char.Parse(textBoxConfigLeft.Text);
            keys.KeyRight = Char.Parse(textBoxConfigRight.Text);
            keys.KeyTerm = Char.Parse(textBoxConfigTerm.Text);
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContainerForm.Show();
        }

        private void buttonUartAccept_Click(object sender, EventArgs e)
        {
            if (CheckUartConfigCondition())
            {
                // Create Keys instance
                WriteControlsToUartConfig();

                // Write to xml
                UartReader.WriteUart(UartConfig);

                // Update new control keys for container
                ContainerForm.SerialPort = UartConfig.CreateSearialPort();

                // Show message
                MessageBox.Show("Update successfully!");
            }
            else
            {
                // Show message
                MessageBox.Show("Update failed! Rolling changes back");

                WriteUartConfigToControls();
            }
        }

        private void WriteControlsToUartConfig()
        {
            UartConfig.PortName = textBoxPortName.Text;
            UartConfig.BaudRate = (int)comboBoxBaudRate.SelectedItem;
            UartConfig.DataBit = (int)comboBoxDataBits.SelectedItem;
            UartConfig.Parity = (Parity)comboBoxParity.SelectedValue;
            UartConfig.StopBit = (StopBits)comboBoxStopBits.SelectedValue;
            UartConfig.HandShake = (Handshake)comboBoxHandShake.SelectedValue;
        }

        private bool CheckUartConfigCondition()
        {
            return (textBoxPortName.Text.Length >= 4);
        }

        private void InitializeUartControls()
        {
            InitializeBaudRateControls();
            InitializeDataBitControls();
            InitializeParityControls();
            InitializeStopBitControls();
            InitializeHandShakeControls();
        }

        private void InitializeHandShakeControls()
        {
            comboBoxHandShake.DataSource = UartHandShake.UartHandShakes;
            comboBoxHandShake.DisplayMember = "Name";
            comboBoxHandShake.ValueMember = "ID";
        }

        private void InitializeStopBitControls()
        {
            comboBoxStopBits.DataSource = UartStopBit.UartStopBits;
            comboBoxStopBits.DisplayMember = "Name";
            comboBoxStopBits.ValueMember = "ID";
        }

        private void InitializeParityControls()
        {
            comboBoxParity.DataSource = UartParity.UartParities;
            comboBoxParity.DisplayMember = "Name";
            comboBoxParity.ValueMember = "ID";
        }

        private void InitializeBaudRateControls()
        {
            List<int> baudRates = new List<int>();
            baudRates.Add(110);
            baudRates.Add(300);
            baudRates.Add(1200);
            baudRates.Add(2400);
            baudRates.Add(4800);
            baudRates.Add(9600);
            baudRates.Add(19200);
            baudRates.Add(38400);
            baudRates.Add(57600);
            baudRates.Add(115200);
            baudRates.Add(230400);
            baudRates.Add(460800);
            baudRates.Add(921600);

            comboBoxBaudRate.DataSource = baudRates;
        }

        private void InitializeDataBitControls()
        {
            List<int> dataBits = new List<int>();
            dataBits.Add(5);
            dataBits.Add(6);
            dataBits.Add(7);
            dataBits.Add(8);

            comboBoxDataBits.DataSource = dataBits;
        }

        private void WriteUartConfigToControls()
        {
            textBoxPortName.Text = UartConfig.PortName;
            comboBoxBaudRate.SelectedItem = UartConfig.BaudRate;
            comboBoxDataBits.SelectedItem = UartConfig.DataBit;
            comboBoxParity.SelectedValue = (int)UartConfig.Parity;
            comboBoxStopBits.SelectedValue = (int)UartConfig.StopBit;
            comboBoxHandShake.SelectedValue = (int)UartConfig.HandShake;
        }
    }
}
