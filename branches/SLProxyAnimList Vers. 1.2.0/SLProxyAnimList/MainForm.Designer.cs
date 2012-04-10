namespace AnimList
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
            this.Console = new System.Windows.Forms.TextBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.proxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusName = new System.Windows.Forms.TextBox();
            this.StatusUUID = new System.Windows.Forms.TextBox();
            this.StatusMsg = new System.Windows.Forms.TextBox();
            this.HeartBeat = new System.Windows.Forms.RadioButton();
            this.StatusLocalID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectedAvatar = new System.Windows.Forms.TextBox();
            this.textMonitoring = new System.Windows.Forms.TextBox();
            this.textMonTot = new System.Windows.Forms.TextBox();
            this.bMonOn = new System.Windows.Forms.Button();
            this.bMonOff = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Console.BackColor = System.Drawing.SystemColors.Window;
            this.Console.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Console.Location = new System.Drawing.Point(139, 37);
            this.Console.Multiline = true;
            this.Console.Name = "Console";
            this.Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console.Size = new System.Drawing.Size(423, 212);
            this.Console.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proxyToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(574, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // proxyToolStripMenuItem
            // 
            this.proxyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.proxyToolStripMenuItem.Name = "proxyToolStripMenuItem";
            this.proxyToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.proxyToolStripMenuItem.Text = "Proxy";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // StatusName
            // 
            this.StatusName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusName.Location = new System.Drawing.Point(12, 269);
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            this.StatusName.Size = new System.Drawing.Size(131, 20);
            this.StatusName.TabIndex = 5;
            this.StatusName.TabStop = false;
            // 
            // StatusUUID
            // 
            this.StatusUUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusUUID.Location = new System.Drawing.Point(149, 269);
            this.StatusUUID.Name = "StatusUUID";
            this.StatusUUID.ReadOnly = true;
            this.StatusUUID.Size = new System.Drawing.Size(225, 20);
            this.StatusUUID.TabIndex = 6;
            this.StatusUUID.TabStop = false;
            // 
            // StatusMsg
            // 
            this.StatusMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusMsg.Location = new System.Drawing.Point(453, 269);
            this.StatusMsg.Name = "StatusMsg";
            this.StatusMsg.ReadOnly = true;
            this.StatusMsg.Size = new System.Drawing.Size(109, 20);
            this.StatusMsg.TabIndex = 7;
            this.StatusMsg.TabStop = false;
            // 
            // HeartBeat
            // 
            this.HeartBeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HeartBeat.AutoSize = true;
            this.HeartBeat.Enabled = false;
            this.HeartBeat.Location = new System.Drawing.Point(549, 5);
            this.HeartBeat.Name = "HeartBeat";
            this.HeartBeat.Size = new System.Drawing.Size(14, 13);
            this.HeartBeat.TabIndex = 8;
            this.HeartBeat.TabStop = true;
            this.HeartBeat.UseVisualStyleBackColor = true;
            // 
            // StatusLocalID
            // 
            this.StatusLocalID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLocalID.Location = new System.Drawing.Point(380, 269);
            this.StatusLocalID.Name = "StatusLocalID";
            this.StatusLocalID.ReadOnly = true;
            this.StatusLocalID.Size = new System.Drawing.Size(67, 20);
            this.StatusLocalID.TabIndex = 9;
            this.StatusLocalID.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Selected Avatar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monitoring";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Anim monitored";
            // 
            // SelectedAvatar
            // 
            this.SelectedAvatar.BackColor = System.Drawing.SystemColors.Window;
            this.SelectedAvatar.Location = new System.Drawing.Point(15, 56);
            this.SelectedAvatar.Name = "SelectedAvatar";
            this.SelectedAvatar.Size = new System.Drawing.Size(118, 20);
            this.SelectedAvatar.TabIndex = 2;
            // 
            // textMonitoring
            // 
            this.textMonitoring.BackColor = System.Drawing.SystemColors.Window;
            this.textMonitoring.Location = new System.Drawing.Point(15, 119);
            this.textMonitoring.Name = "textMonitoring";
            this.textMonitoring.ReadOnly = true;
            this.textMonitoring.Size = new System.Drawing.Size(118, 20);
            this.textMonitoring.TabIndex = 19;
            this.textMonitoring.TabStop = false;
            // 
            // textMonTot
            // 
            this.textMonTot.BackColor = System.Drawing.SystemColors.Window;
            this.textMonTot.Location = new System.Drawing.Point(15, 158);
            this.textMonTot.Name = "textMonTot";
            this.textMonTot.ReadOnly = true;
            this.textMonTot.Size = new System.Drawing.Size(74, 20);
            this.textMonTot.TabIndex = 20;
            this.textMonTot.TabStop = false;
            this.textMonTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bMonOn
            // 
            this.bMonOn.Location = new System.Drawing.Point(15, 200);
            this.bMonOn.Name = "bMonOn";
            this.bMonOn.Size = new System.Drawing.Size(118, 22);
            this.bMonOn.TabIndex = 3;
            this.bMonOn.Text = "Monitore on";
            this.bMonOn.UseVisualStyleBackColor = true;
            this.bMonOn.Click += new System.EventHandler(this.bMonOn_Click);
            // 
            // bMonOff
            // 
            this.bMonOff.Enabled = false;
            this.bMonOff.Location = new System.Drawing.Point(15, 228);
            this.bMonOff.Name = "bMonOff";
            this.bMonOff.Size = new System.Drawing.Size(118, 22);
            this.bMonOff.TabIndex = 4;
            this.bMonOff.Text = "Monitore off";
            this.bMonOff.UseVisualStyleBackColor = true;
            this.bMonOff.Click += new System.EventHandler(this.bMonOff_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 301);
            this.Controls.Add(this.bMonOff);
            this.Controls.Add(this.bMonOn);
            this.Controls.Add(this.textMonTot);
            this.Controls.Add(this.textMonitoring);
            this.Controls.Add(this.SelectedAvatar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusLocalID);
            this.Controls.Add(this.HeartBeat);
            this.Controls.Add(this.StatusMsg);
            this.Controls.Add(this.StatusUUID);
            this.Controls.Add(this.StatusName);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "AnimList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Console;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem proxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox StatusName;
        private System.Windows.Forms.TextBox StatusUUID;
        private System.Windows.Forms.TextBox StatusMsg;
        private System.Windows.Forms.RadioButton HeartBeat;
        private System.Windows.Forms.TextBox StatusLocalID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SelectedAvatar;
        private System.Windows.Forms.TextBox textMonitoring;
        private System.Windows.Forms.TextBox textMonTot;
        private System.Windows.Forms.Button bMonOn;
        private System.Windows.Forms.Button bMonOff;
    }
}

