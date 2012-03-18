namespace SLCachedb2
{
    partial class Form1
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
            this.CacheDB2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputDir = new System.Windows.Forms.TextBox();
            this.bCacheDB2 = new System.Windows.Forms.Button();
            this.bOutputDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bProsegui = new System.Windows.Forms.Button();
            this.UUIDtotal = new System.Windows.Forms.TextBox();
            this.UUIDfound = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.bBVH = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.lfilescreated = new System.Windows.Forms.Label();
            this.checkByDate = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textFrom = new System.Windows.Forms.TextBox();
            this.textTo = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.UpDownFromHour = new System.Windows.Forms.NumericUpDown();
            this.UpDownFromMin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.UpDownToHour = new System.Windows.Forms.NumericUpDown();
            this.UpDownToMin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownFromHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownFromMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownToHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownToMin)).BeginInit();
            this.SuspendLayout();
            // 
            // CacheDB2
            // 
            this.CacheDB2.Location = new System.Drawing.Point(99, 124);
            this.CacheDB2.Name = "CacheDB2";
            this.CacheDB2.Size = new System.Drawing.Size(447, 20);
            this.CacheDB2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UUID List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output Dir";
            // 
            // OutputDir
            // 
            this.OutputDir.Location = new System.Drawing.Point(99, 161);
            this.OutputDir.Name = "OutputDir";
            this.OutputDir.Size = new System.Drawing.Size(447, 20);
            this.OutputDir.TabIndex = 3;
            // 
            // bCacheDB2
            // 
            this.bCacheDB2.Location = new System.Drawing.Point(552, 122);
            this.bCacheDB2.Name = "bCacheDB2";
            this.bCacheDB2.Size = new System.Drawing.Size(41, 23);
            this.bCacheDB2.TabIndex = 4;
            this.bCacheDB2.Text = "......";
            this.bCacheDB2.UseVisualStyleBackColor = true;
            this.bCacheDB2.Click += new System.EventHandler(this.bCacheDB2_Click);
            // 
            // bOutputDir
            // 
            this.bOutputDir.Location = new System.Drawing.Point(552, 159);
            this.bOutputDir.Name = "bOutputDir";
            this.bOutputDir.Size = new System.Drawing.Size(41, 23);
            this.bOutputDir.TabIndex = 5;
            this.bOutputDir.Text = "......";
            this.bOutputDir.UseVisualStyleBackColor = true;
            this.bOutputDir.Click += new System.EventHandler(this.bOutputDir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bProsegui
            // 
            this.bProsegui.Enabled = false;
            this.bProsegui.Location = new System.Drawing.Point(250, 230);
            this.bProsegui.Name = "bProsegui";
            this.bProsegui.Size = new System.Drawing.Size(55, 28);
            this.bProsegui.TabIndex = 6;
            this.bProsegui.Tag = "";
            this.bProsegui.Text = "Read";
            this.bProsegui.UseVisualStyleBackColor = true;
            this.bProsegui.Click += new System.EventHandler(this.bProsegui_Click);
            // 
            // UUIDtotal
            // 
            this.UUIDtotal.Location = new System.Drawing.Point(99, 212);
            this.UUIDtotal.Name = "UUIDtotal";
            this.UUIDtotal.ReadOnly = true;
            this.UUIDtotal.Size = new System.Drawing.Size(81, 20);
            this.UUIDtotal.TabIndex = 7;
            this.UUIDtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UUIDfound
            // 
            this.UUIDfound.Location = new System.Drawing.Point(99, 235);
            this.UUIDfound.Name = "UUIDfound";
            this.UUIDfound.ReadOnly = true;
            this.UUIDfound.Size = new System.Drawing.Size(81, 20);
            this.UUIDfound.TabIndex = 8;
            this.UUIDfound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "No. of  UUID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Found";
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(503, 230);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(55, 28);
            this.bClose.TabIndex = 12;
            this.bClose.Tag = "Close window";
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bBVH
            // 
            this.bBVH.Enabled = false;
            this.bBVH.Location = new System.Drawing.Point(351, 230);
            this.bBVH.Name = "bBVH";
            this.bBVH.Size = new System.Drawing.Size(99, 28);
            this.bBVH.TabIndex = 13;
            this.bBVH.Text = "Write BVH Files";
            this.bBVH.UseVisualStyleBackColor = true;
            this.bBVH.Click += new System.EventHandler(this.bBVH_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(141, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(339, 18);
            this.labelTitle.TabIndex = 14;
            this.labelTitle.Text = "Generate BVH files from UUID animation List";
            // 
            // lfilescreated
            // 
            this.lfilescreated.AutoSize = true;
            this.lfilescreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfilescreated.Location = new System.Drawing.Point(247, 196);
            this.lfilescreated.MinimumSize = new System.Drawing.Size(280, 15);
            this.lfilescreated.Name = "lfilescreated";
            this.lfilescreated.Size = new System.Drawing.Size(280, 15);
            this.lfilescreated.TabIndex = 15;
            // 
            // checkByDate
            // 
            this.checkByDate.AutoSize = true;
            this.checkByDate.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.checkByDate.Checked = true;
            this.checkByDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkByDate.Location = new System.Drawing.Point(27, 92);
            this.checkByDate.Name = "checkByDate";
            this.checkByDate.Size = new System.Drawing.Size(118, 17);
            this.checkByDate.TabIndex = 17;
            this.checkByDate.Text = "Select by date/time";
            this.checkByDate.UseVisualStyleBackColor = true;
            this.checkByDate.CheckedChanged += new System.EventHandler(this.checkByDate_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "from";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "to";
            // 
            // textFrom
            // 
            this.textFrom.AcceptsTab = true;
            this.textFrom.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.textFrom.Location = new System.Drawing.Point(185, 89);
            this.textFrom.Name = "textFrom";
            this.textFrom.ReadOnly = true;
            this.textFrom.Size = new System.Drawing.Size(74, 20);
            this.textFrom.TabIndex = 20;
            this.textFrom.TabStop = false;
            this.textFrom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textFrom_MouseClick);
            // 
            // textTo
            // 
            this.textTo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textTo.Location = new System.Drawing.Point(385, 89);
            this.textTo.Name = "textTo";
            this.textTo.ReadOnly = true;
            this.textTo.Size = new System.Drawing.Size(74, 20);
            this.textTo.TabIndex = 21;
            this.textTo.TabStop = false;
            this.textTo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textTo_MouseClick);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(286, 111);
            this.monthCalendar1.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.monthCalendar1.MinDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 22;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // UpDownFromHour
            // 
            this.UpDownFromHour.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpDownFromHour.Cursor = System.Windows.Forms.Cursors.Default;
            this.UpDownFromHour.Location = new System.Drawing.Point(260, 89);
            this.UpDownFromHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.UpDownFromHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.UpDownFromHour.Name = "UpDownFromHour";
            this.UpDownFromHour.ReadOnly = true;
            this.UpDownFromHour.Size = new System.Drawing.Size(35, 20);
            this.UpDownFromHour.TabIndex = 23;
            this.UpDownFromHour.TabStop = false;
            this.UpDownFromHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDownFromHour.ValueChanged += new System.EventHandler(this.UpDownFromHour_ValueChanged);
            // 
            // UpDownFromMin
            // 
            this.UpDownFromMin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpDownFromMin.Location = new System.Drawing.Point(296, 89);
            this.UpDownFromMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.UpDownFromMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.UpDownFromMin.Name = "UpDownFromMin";
            this.UpDownFromMin.ReadOnly = true;
            this.UpDownFromMin.Size = new System.Drawing.Size(35, 20);
            this.UpDownFromMin.TabIndex = 24;
            this.UpDownFromMin.TabStop = false;
            this.UpDownFromMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDownFromMin.ValueChanged += new System.EventHandler(this.UpDownFromMin_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "hours";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "minutes";
            // 
            // UpDownToHour
            // 
            this.UpDownToHour.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpDownToHour.Location = new System.Drawing.Point(460, 89);
            this.UpDownToHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.UpDownToHour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.UpDownToHour.Name = "UpDownToHour";
            this.UpDownToHour.ReadOnly = true;
            this.UpDownToHour.Size = new System.Drawing.Size(35, 20);
            this.UpDownToHour.TabIndex = 28;
            this.UpDownToHour.TabStop = false;
            this.UpDownToHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDownToHour.ValueChanged += new System.EventHandler(this.UpDownToHour_ValueChanged);
            // 
            // UpDownToMin
            // 
            this.UpDownToMin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpDownToMin.Location = new System.Drawing.Point(496, 89);
            this.UpDownToMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.UpDownToMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.UpDownToMin.Name = "UpDownToMin";
            this.UpDownToMin.ReadOnly = true;
            this.UpDownToMin.Size = new System.Drawing.Size(35, 20);
            this.UpDownToMin.TabIndex = 29;
            this.UpDownToMin.TabStop = false;
            this.UpDownToMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDownToMin.ValueChanged += new System.EventHandler(this.UpDownToMin_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(493, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "minutes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(462, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "hours";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(405, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "date";
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(385, 111);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 33;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 293);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.UpDownToMin);
            this.Controls.Add(this.UpDownToHour);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.UpDownFromMin);
            this.Controls.Add(this.UpDownFromHour);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.textTo);
            this.Controls.Add(this.textFrom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkByDate);
            this.Controls.Add(this.lfilescreated);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.bBVH);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UUIDfound);
            this.Controls.Add(this.UUIDtotal);
            this.Controls.Add(this.bProsegui);
            this.Controls.Add(this.bOutputDir);
            this.Controls.Add(this.bCacheDB2);
            this.Controls.Add(this.OutputDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CacheDB2);
            this.Name = "Form1";
            this.Text = "Animation Files from cache";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpDownFromHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownFromMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownToHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownToMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CacheDB2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputDir;
        private System.Windows.Forms.Button bCacheDB2;
        private System.Windows.Forms.Button bOutputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bProsegui;
        private System.Windows.Forms.TextBox UUIDtotal;
        private System.Windows.Forms.TextBox UUIDfound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bBVH;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lfilescreated;
        private System.Windows.Forms.CheckBox checkByDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.TextBox textTo;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown UpDownFromHour;
        private System.Windows.Forms.NumericUpDown UpDownFromMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown UpDownToHour;
        private System.Windows.Forms.NumericUpDown UpDownToMin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
    }
}

