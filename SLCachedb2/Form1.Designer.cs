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
            this.label6 = new System.Windows.Forms.Label();
            this.lfilescreated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CacheDB2
            // 
            this.CacheDB2.Location = new System.Drawing.Point(82, 49);
            this.CacheDB2.Name = "CacheDB2";
            this.CacheDB2.Size = new System.Drawing.Size(447, 20);
            this.CacheDB2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UUID List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Output Dir";
            // 
            // OutputDir
            // 
            this.OutputDir.Location = new System.Drawing.Point(82, 85);
            this.OutputDir.Name = "OutputDir";
            this.OutputDir.Size = new System.Drawing.Size(447, 20);
            this.OutputDir.TabIndex = 3;
            // 
            // bCacheDB2
            // 
            this.bCacheDB2.Location = new System.Drawing.Point(535, 47);
            this.bCacheDB2.Name = "bCacheDB2";
            this.bCacheDB2.Size = new System.Drawing.Size(41, 23);
            this.bCacheDB2.TabIndex = 4;
            this.bCacheDB2.Text = "......";
            this.bCacheDB2.UseVisualStyleBackColor = true;
            this.bCacheDB2.Click += new System.EventHandler(this.bCacheDB2_Click);
            // 
            // bOutputDir
            // 
            this.bOutputDir.Location = new System.Drawing.Point(535, 84);
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
            this.bProsegui.Location = new System.Drawing.Point(233, 155);
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
            this.UUIDtotal.Location = new System.Drawing.Point(82, 137);
            this.UUIDtotal.Name = "UUIDtotal";
            this.UUIDtotal.ReadOnly = true;
            this.UUIDtotal.Size = new System.Drawing.Size(81, 20);
            this.UUIDtotal.TabIndex = 7;
            this.UUIDtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UUIDfound
            // 
            this.UUIDfound.Location = new System.Drawing.Point(82, 163);
            this.UUIDfound.Name = "UUIDfound";
            this.UUIDfound.ReadOnly = true;
            this.UUIDfound.Size = new System.Drawing.Size(81, 20);
            this.UUIDfound.TabIndex = 8;
            this.UUIDfound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "No. UUID in List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Found";
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(486, 155);
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
            this.bBVH.Location = new System.Drawing.Point(334, 155);
            this.bBVH.Name = "bBVH";
            this.bBVH.Size = new System.Drawing.Size(99, 28);
            this.bBVH.TabIndex = 13;
            this.bBVH.Text = "Write BVH Files";
            this.bBVH.UseVisualStyleBackColor = true;
            this.bBVH.Click += new System.EventHandler(this.bBVH_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(141, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Generate BVH files from UUID animation List";
            // 
            // lfilescreated
            // 
            this.lfilescreated.AutoSize = true;
            this.lfilescreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfilescreated.Location = new System.Drawing.Point(230, 121);
            this.lfilescreated.MinimumSize = new System.Drawing.Size(280, 15);
            this.lfilescreated.Name = "lfilescreated";
            this.lfilescreated.Size = new System.Drawing.Size(280, 15);
            this.lfilescreated.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 211);
            this.Controls.Add(this.lfilescreated);
            this.Controls.Add(this.label6);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lfilescreated;
    }
}

