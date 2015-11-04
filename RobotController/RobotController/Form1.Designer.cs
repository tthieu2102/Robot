namespace RobotController
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonController = new System.Windows.Forms.Button();
            this.buttonKeySettings = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonController
            // 
            this.buttonController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonController.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonController.Image = ((System.Drawing.Image)(resources.GetObject("buttonController.Image")));
            this.buttonController.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonController.Location = new System.Drawing.Point(56, 39);
            this.buttonController.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonController.Name = "buttonController";
            this.buttonController.Size = new System.Drawing.Size(154, 59);
            this.buttonController.TabIndex = 0;
            this.buttonController.Text = "Mission Control";
            this.buttonController.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonController.UseVisualStyleBackColor = true;
            this.buttonController.Click += new System.EventHandler(this.buttonController_Click);
            // 
            // buttonKeySettings
            // 
            this.buttonKeySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKeySettings.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeySettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonKeySettings.Image")));
            this.buttonKeySettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKeySettings.Location = new System.Drawing.Point(56, 108);
            this.buttonKeySettings.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonKeySettings.Name = "buttonKeySettings";
            this.buttonKeySettings.Size = new System.Drawing.Size(154, 59);
            this.buttonKeySettings.TabIndex = 1;
            this.buttonKeySettings.Text = "Config settings";
            this.buttonKeySettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonKeySettings.UseVisualStyleBackColor = true;
            this.buttonKeySettings.Click += new System.EventHandler(this.buttonKeySettings_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(56, 177);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(154, 59);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit program";
            this.buttonExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonExit, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonController, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonKeySettings, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 279);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(292, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonController;
        private System.Windows.Forms.Button buttonKeySettings;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

