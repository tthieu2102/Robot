namespace RobotController
{
    partial class ControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.buttonControlUp = new System.Windows.Forms.Button();
            this.buttonControlLeft = new System.Windows.Forms.Button();
            this.buttonControlDown = new System.Windows.Forms.Button();
            this.buttonControlRight = new System.Windows.Forms.Button();
            this.textBoxControlInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonControlUp
            // 
            this.buttonControlUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonControlUp.Image")));
            this.buttonControlUp.Location = new System.Drawing.Point(128, 32);
            this.buttonControlUp.Name = "buttonControlUp";
            this.buttonControlUp.Size = new System.Drawing.Size(80, 74);
            this.buttonControlUp.TabIndex = 0;
            this.buttonControlUp.UseVisualStyleBackColor = true;
            // 
            // buttonControlLeft
            // 
            this.buttonControlLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonControlLeft.Image")));
            this.buttonControlLeft.Location = new System.Drawing.Point(33, 122);
            this.buttonControlLeft.Name = "buttonControlLeft";
            this.buttonControlLeft.Size = new System.Drawing.Size(80, 74);
            this.buttonControlLeft.TabIndex = 1;
            this.buttonControlLeft.UseVisualStyleBackColor = true;
            // 
            // buttonControlDown
            // 
            this.buttonControlDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonControlDown.Image")));
            this.buttonControlDown.Location = new System.Drawing.Point(128, 122);
            this.buttonControlDown.Name = "buttonControlDown";
            this.buttonControlDown.Size = new System.Drawing.Size(80, 74);
            this.buttonControlDown.TabIndex = 2;
            this.buttonControlDown.UseVisualStyleBackColor = true;
            // 
            // buttonControlRight
            // 
            this.buttonControlRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonControlRight.Image")));
            this.buttonControlRight.Location = new System.Drawing.Point(224, 122);
            this.buttonControlRight.Name = "buttonControlRight";
            this.buttonControlRight.Size = new System.Drawing.Size(80, 74);
            this.buttonControlRight.TabIndex = 3;
            this.buttonControlRight.UseVisualStyleBackColor = true;
            // 
            // textBoxControlInfo
            // 
            this.textBoxControlInfo.Location = new System.Drawing.Point(12, 232);
            this.textBoxControlInfo.Multiline = true;
            this.textBoxControlInfo.Name = "textBoxControlInfo";
            this.textBoxControlInfo.ReadOnly = true;
            this.textBoxControlInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxControlInfo.Size = new System.Drawing.Size(320, 110);
            this.textBoxControlInfo.TabIndex = 4;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 353);
            this.Controls.Add(this.textBoxControlInfo);
            this.Controls.Add(this.buttonControlRight);
            this.Controls.Add(this.buttonControlDown);
            this.Controls.Add(this.buttonControlLeft);
            this.Controls.Add(this.buttonControlUp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonControlUp_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonControlUp_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonControlUp;
        private System.Windows.Forms.Button buttonControlLeft;
        private System.Windows.Forms.Button buttonControlDown;
        private System.Windows.Forms.Button buttonControlRight;
        private System.Windows.Forms.TextBox textBoxControlInfo;
    }
}