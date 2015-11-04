using RobotController.Classes;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace RobotController
{
    public partial class ControlForm : Form
    {
        MainForm containerForm;
        ControlKeys controlKeys;
        SerialPort serialPort;
        ControlKeys sender;
        List<Keys> listKeyPressed;

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

        public ControlKeys Sender
        {
            get
            {
                if (sender == null)
                {
                    sender = new ControlKeys();
                    sender.KeyUp = 'w';
                    sender.KeyDown = 's';
                    sender.KeyLeft = 'a';
                    sender.KeyRight = 'd';
                }
                return sender;
            }

            set
            {
                sender = value;
            }
        }

        public List<Keys> ListKeyPressed
        {
            get
            {
                if (listKeyPressed == null) listKeyPressed = new List<Keys>();
                return listKeyPressed;
            }

            set
            {
                listKeyPressed = value;
            }
        }

        private void KeyPressedChange()
        {
            if (ListKeyPressed.Count == 0) return;
            Keys keyLast = listKeyPressed.Last();
           if ((char)keyLast == ControlKeys.KeyUp)
            {
                buttonControlUp.BackColor = Color.Aqua;

                // Send uart data
                SerialPort.Write(Sender.KeyUp.ToString());
            }
           else if ((char)keyLast == ControlKeys.KeyDown)
            {
                buttonControlDown.BackColor = Color.Aqua;

                // Send uart data
                SerialPort.Write(Sender.KeyDown.ToString());
            }
            else if ((char)keyLast == ControlKeys.KeyLeft)
            {
                buttonControlLeft.BackColor = Color.Aqua;

                // Send uart data
                SerialPort.Write(Sender.KeyLeft.ToString());
            }
            else if ((char)keyLast == ControlKeys.KeyRight)
            {
                buttonControlRight.BackColor = Color.Aqua;

                // Send uart data
                SerialPort.Write(Sender.KeyRight.ToString());
            }
           
         
            // Send info str
            textBoxControlInfo.AppendText("Pressed " + keyLast + "\r\n");

        }

        public ControlForm(MainForm containerForm)
        {
            InitializeComponent();

            ContainerForm = containerForm;
            ControlKeys = ContainerForm.ControlKeys;
            SerialPort = ContainerForm.SerialPort;
            

            // Open Serial Port
            try
            {
                SerialPort.RtsEnable = true;
                SerialPort.DtrEnable = true;

                SerialPort.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to connect to UART!");
            }
        }

        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SerialPort.Close();
            ContainerForm.Show();
        }

        private void buttonControlUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (ListKeyPressed.Contains(e.KeyCode))
                return;
            ListKeyPressed.Add(e.KeyCode);
            KeyPressedChange();

        }

        private void buttonControlUp_KeyUp(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyCode == ControlKeys.KeyUp
                || (char)e.KeyCode == ControlKeys.KeyDown
                || (char)e.KeyCode == ControlKeys.KeyLeft
                || (char)e.KeyCode == ControlKeys.KeyRight)

            if (ListKeyPressed.Contains(e.KeyCode))
                {
                //    InitializeButtonsColor();
                    // Send uart data 
                    SerialPort.Write(ControlKeys.KeyTerm.ToString());
                    if ((char)e.KeyCode == ControlKeys.KeyUp)
                        buttonControlUp.BackColor = Color.FromKnownColor(KnownColor.Control);
                    if ((char)e.KeyCode == ControlKeys.KeyDown)
                        buttonControlDown.BackColor = Color.FromKnownColor(KnownColor.Control);
                    if ((char)e.KeyCode == ControlKeys.KeyLeft)
                        buttonControlLeft.BackColor = Color.FromKnownColor(KnownColor.Control);
                    if ((char)e.KeyCode == ControlKeys.KeyRight)
                        buttonControlRight.BackColor = Color.FromKnownColor(KnownColor.Control);
                    ListKeyPressed.Remove(e.KeyCode);
                    KeyPressedChange();
                }           
        }

        private void InitializeButtonsColor()
        {
            buttonControlUp.BackColor = Color.FromKnownColor(KnownColor.Control);
            buttonControlDown.BackColor = Color.FromKnownColor(KnownColor.Control);
            buttonControlLeft.BackColor = Color.FromKnownColor(KnownColor.Control);
            buttonControlRight.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
    }
}
