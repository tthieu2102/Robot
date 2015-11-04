namespace RobotController
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.keyConfigTabPage = new System.Windows.Forms.TabPage();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.textBoxConfigTerm = new System.Windows.Forms.TextBox();
            this.textBoxConfigLeft = new System.Windows.Forms.TextBox();
            this.textBoxConfigDown = new System.Windows.Forms.TextBox();
            this.textBoxConfigUp = new System.Windows.Forms.TextBox();
            this.textBoxConfigRight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UartConfigTabPage = new System.Windows.Forms.TabPage();
            this.buttonUartAccept = new System.Windows.Forms.Button();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxHandShake = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPortName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.keyConfigTabPage.SuspendLayout();
            this.UartConfigTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.keyConfigTabPage);
            this.tabControl1.Controls.Add(this.UartConfigTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 340);
            this.tabControl1.TabIndex = 0;
            // 
            // keyConfigTabPage
            // 
            this.keyConfigTabPage.Controls.Add(this.buttonAccept);
            this.keyConfigTabPage.Controls.Add(this.textBoxConfigTerm);
            this.keyConfigTabPage.Controls.Add(this.textBoxConfigLeft);
            this.keyConfigTabPage.Controls.Add(this.textBoxConfigDown);
            this.keyConfigTabPage.Controls.Add(this.textBoxConfigUp);
            this.keyConfigTabPage.Controls.Add(this.textBoxConfigRight);
            this.keyConfigTabPage.Controls.Add(this.label5);
            this.keyConfigTabPage.Controls.Add(this.label4);
            this.keyConfigTabPage.Controls.Add(this.label3);
            this.keyConfigTabPage.Controls.Add(this.label2);
            this.keyConfigTabPage.Controls.Add(this.label1);
            this.keyConfigTabPage.Location = new System.Drawing.Point(4, 23);
            this.keyConfigTabPage.Name = "keyConfigTabPage";
            this.keyConfigTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.keyConfigTabPage.Size = new System.Drawing.Size(312, 313);
            this.keyConfigTabPage.TabIndex = 0;
            this.keyConfigTabPage.Text = "Key Config";
            this.keyConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(123, 262);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 10;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // textBoxConfigTerm
            // 
            this.textBoxConfigTerm.Location = new System.Drawing.Point(132, 213);
            this.textBoxConfigTerm.Name = "textBoxConfigTerm";
            this.textBoxConfigTerm.Size = new System.Drawing.Size(172, 20);
            this.textBoxConfigTerm.TabIndex = 9;
            // 
            // textBoxConfigLeft
            // 
            this.textBoxConfigLeft.Location = new System.Drawing.Point(132, 116);
            this.textBoxConfigLeft.Name = "textBoxConfigLeft";
            this.textBoxConfigLeft.Size = new System.Drawing.Size(172, 20);
            this.textBoxConfigLeft.TabIndex = 8;
            // 
            // textBoxConfigDown
            // 
            this.textBoxConfigDown.Location = new System.Drawing.Point(132, 67);
            this.textBoxConfigDown.Name = "textBoxConfigDown";
            this.textBoxConfigDown.Size = new System.Drawing.Size(172, 20);
            this.textBoxConfigDown.TabIndex = 7;
            // 
            // textBoxConfigUp
            // 
            this.textBoxConfigUp.Location = new System.Drawing.Point(132, 20);
            this.textBoxConfigUp.Name = "textBoxConfigUp";
            this.textBoxConfigUp.Size = new System.Drawing.Size(172, 20);
            this.textBoxConfigUp.TabIndex = 6;
            // 
            // textBoxConfigRight
            // 
            this.textBoxConfigRight.Location = new System.Drawing.Point(132, 165);
            this.textBoxConfigRight.Name = "textBoxConfigRight";
            this.textBoxConfigRight.Size = new System.Drawing.Size(172, 20);
            this.textBoxConfigRight.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Down Character: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Termination Character: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Left Character: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Right Character: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Up Character: ";
            // 
            // UartConfigTabPage
            // 
            this.UartConfigTabPage.Controls.Add(this.textBoxPortName);
            this.UartConfigTabPage.Controls.Add(this.label11);
            this.UartConfigTabPage.Controls.Add(this.buttonUartAccept);
            this.UartConfigTabPage.Controls.Add(this.comboBoxBaudRate);
            this.UartConfigTabPage.Controls.Add(this.comboBoxDataBits);
            this.UartConfigTabPage.Controls.Add(this.comboBoxStopBits);
            this.UartConfigTabPage.Controls.Add(this.comboBoxParity);
            this.UartConfigTabPage.Controls.Add(this.comboBoxHandShake);
            this.UartConfigTabPage.Controls.Add(this.label10);
            this.UartConfigTabPage.Controls.Add(this.label9);
            this.UartConfigTabPage.Controls.Add(this.label8);
            this.UartConfigTabPage.Controls.Add(this.label7);
            this.UartConfigTabPage.Controls.Add(this.label6);
            this.UartConfigTabPage.Location = new System.Drawing.Point(4, 23);
            this.UartConfigTabPage.Name = "UartConfigTabPage";
            this.UartConfigTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UartConfigTabPage.Size = new System.Drawing.Size(312, 313);
            this.UartConfigTabPage.TabIndex = 1;
            this.UartConfigTabPage.Text = "UART Config";
            this.UartConfigTabPage.UseVisualStyleBackColor = true;
            // 
            // buttonUartAccept
            // 
            this.buttonUartAccept.Location = new System.Drawing.Point(122, 278);
            this.buttonUartAccept.Name = "buttonUartAccept";
            this.buttonUartAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonUartAccept.TabIndex = 10;
            this.buttonUartAccept.Text = "Accept";
            this.buttonUartAccept.UseVisualStyleBackColor = true;
            this.buttonUartAccept.Click += new System.EventHandler(this.buttonUartAccept_Click);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(99, 60);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(203, 22);
            this.comboBoxBaudRate.TabIndex = 9;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(99, 103);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(203, 22);
            this.comboBoxDataBits.TabIndex = 8;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(99, 191);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(203, 22);
            this.comboBoxStopBits.TabIndex = 7;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(99, 145);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(203, 22);
            this.comboBoxParity.TabIndex = 6;
            // 
            // comboBoxHandShake
            // 
            this.comboBoxHandShake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHandShake.FormattingEnabled = true;
            this.comboBoxHandShake.Location = new System.Drawing.Point(99, 235);
            this.comboBoxHandShake.Name = "comboBoxHandShake";
            this.comboBoxHandShake.Size = new System.Drawing.Size(203, 22);
            this.comboBoxHandShake.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "Data bits";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "Hand shake";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Stop bits";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Parity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Bits per second";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "Port name";
            // 
            // textBoxPortName
            // 
            this.textBoxPortName.Location = new System.Drawing.Point(99, 19);
            this.textBoxPortName.Name = "textBoxPortName";
            this.textBoxPortName.Size = new System.Drawing.Size(203, 20);
            this.textBoxPortName.TabIndex = 12;
            // 
            // SettingForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(320, 340);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "Setting Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.keyConfigTabPage.ResumeLayout(false);
            this.keyConfigTabPage.PerformLayout();
            this.UartConfigTabPage.ResumeLayout(false);
            this.UartConfigTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage keyConfigTabPage;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TextBox textBoxConfigTerm;
        private System.Windows.Forms.TextBox textBoxConfigLeft;
        private System.Windows.Forms.TextBox textBoxConfigDown;
        private System.Windows.Forms.TextBox textBoxConfigUp;
        private System.Windows.Forms.TextBox textBoxConfigRight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage UartConfigTabPage;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxHandShake;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonUartAccept;
        private System.Windows.Forms.TextBox textBoxPortName;
        private System.Windows.Forms.Label label11;
    }
}