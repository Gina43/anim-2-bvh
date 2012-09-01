namespace AninToBVH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wAnim = new System.Windows.Forms.TextBox();
            this.wBVH = new System.Windows.Forms.TextBox();
            this.wFileBVH = new System.Windows.Forms.TextBox();
            this.bAnim = new System.Windows.Forms.Button();
            this.bBVH = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pConverti = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelSuccess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File .anim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "BVH Dir";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "File BVH";
            // 
            // wAnim
            // 
            this.wAnim.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.wAnim.Location = new System.Drawing.Point(81, 64);
            this.wAnim.Name = "wAnim";
            this.wAnim.ReadOnly = true;
            this.wAnim.Size = new System.Drawing.Size(409, 20);
            this.wAnim.TabIndex = 3;
            // 
            // wBVH
            // 
            this.wBVH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.wBVH.Location = new System.Drawing.Point(81, 98);
            this.wBVH.Name = "wBVH";
            this.wBVH.ReadOnly = true;
            this.wBVH.Size = new System.Drawing.Size(408, 20);
            this.wBVH.TabIndex = 4;
            // 
            // wFileBVH
            // 
            this.wFileBVH.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.wFileBVH.Location = new System.Drawing.Point(81, 134);
            this.wFileBVH.Name = "wFileBVH";
            this.wFileBVH.Size = new System.Drawing.Size(405, 20);
            this.wFileBVH.TabIndex = 5;
            // 
            // bAnim
            // 
            this.bAnim.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bAnim.Location = new System.Drawing.Point(496, 62);
            this.bAnim.Name = "bAnim";
            this.bAnim.Size = new System.Drawing.Size(67, 23);
            this.bAnim.TabIndex = 6;
            this.bAnim.Text = "........";
            this.bAnim.UseVisualStyleBackColor = false;
            this.bAnim.Click += new System.EventHandler(this.bAnim_Click);
            // 
            // bBVH
            // 
            this.bBVH.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bBVH.Location = new System.Drawing.Point(496, 97);
            this.bBVH.Name = "bBVH";
            this.bBVH.Size = new System.Drawing.Size(67, 23);
            this.bBVH.TabIndex = 7;
            this.bBVH.Text = ".......";
            this.bBVH.UseVisualStyleBackColor = false;
            this.bBVH.Click += new System.EventHandler(this.bBVH_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pConverti
            // 
            this.pConverti.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pConverti.Enabled = false;
            this.pConverti.Location = new System.Drawing.Point(122, 201);
            this.pConverti.Name = "pConverti";
            this.pConverti.Size = new System.Drawing.Size(98, 35);
            this.pConverti.TabIndex = 8;
            this.pConverti.Text = "Start Conversion";
            this.pConverti.UseVisualStyleBackColor = false;
            this.pConverti.Click += new System.EventHandler(this.pConverti_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(362, 179);
            this.label4.MinimumSize = new System.Drawing.Size(188, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "1 - Select the file(s) .anim to convert";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(362, 201);
            this.label5.MinimumSize = new System.Drawing.Size(188, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "2 . Select the BVH\'s destination Folder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(362, 223);
            this.label6.MinimumSize = new System.Drawing.Size(188, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "3 - Edit the BVH file name (optional)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(362, 245);
            this.label7.MinimumSize = new System.Drawing.Size(188, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "4 - Push the Start Conversion button";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(326, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "....";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.Location = new System.Drawing.Point(326, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "....";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.Location = new System.Drawing.Point(326, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "....";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label11.Location = new System.Drawing.Point(326, 245);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "....";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(119, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(316, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "Converts the SL animation format (.anim) to BVH";
            // 
            // labelSuccess
            // 
            this.labelSuccess.AutoSize = true;
            this.labelSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuccess.Location = new System.Drawing.Point(30, 272);
            this.labelSuccess.MinimumSize = new System.Drawing.Size(520, 13);
            this.labelSuccess.Name = "labelSuccess";
            this.labelSuccess.Size = new System.Drawing.Size(520, 15);
            this.labelSuccess.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(592, 294);
            this.Controls.Add(this.labelSuccess);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pConverti);
            this.Controls.Add(this.bBVH);
            this.Controls.Add(this.bAnim);
            this.Controls.Add(this.wFileBVH);
            this.Controls.Add(this.wBVH);
            this.Controls.Add(this.wAnim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Anim to BVH v.1.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wAnim;
        private System.Windows.Forms.TextBox wBVH;
        private System.Windows.Forms.TextBox wFileBVH;
        private System.Windows.Forms.Button bAnim;
        private System.Windows.Forms.Button bBVH;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button pConverti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelSuccess;
    }
}

