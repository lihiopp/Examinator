
namespace TestMaker
{
    partial class GenerateScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateScreen));
            this.cancelb = new System.Windows.Forms.Button();
            this.okb = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveExamb = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveKeyb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelb
            // 
            this.cancelb.Location = new System.Drawing.Point(373, 195);
            this.cancelb.Name = "cancelb";
            this.cancelb.Size = new System.Drawing.Size(75, 29);
            this.cancelb.TabIndex = 17;
            this.cancelb.Text = "Cancel";
            this.cancelb.UseVisualStyleBackColor = true;
            this.cancelb.Click += new System.EventHandler(this.cancelb_Click);
            // 
            // okb
            // 
            this.okb.Location = new System.Drawing.Point(257, 195);
            this.okb.Name = "okb";
            this.okb.Size = new System.Drawing.Size(75, 29);
            this.okb.TabIndex = 16;
            this.okb.Text = "OK";
            this.okb.UseVisualStyleBackColor = true;
            this.okb.Click += new System.EventHandler(this.okb_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(465, 26);
            this.textBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exam Filename:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 128);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(465, 26);
            this.textBox3.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Q number:";
            // 
            // saveExamb
            // 
            this.saveExamb.Location = new System.Drawing.Point(626, 30);
            this.saveExamb.Name = "saveExamb";
            this.saveExamb.Size = new System.Drawing.Size(71, 32);
            this.saveExamb.TabIndex = 18;
            this.saveExamb.Text = "...";
            this.saveExamb.UseVisualStyleBackColor = true;
            this.saveExamb.Click += new System.EventHandler(this.saveExamb_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Key Filename:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 79);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(465, 26);
            this.textBox2.TabIndex = 11;
            // 
            // saveKeyb
            // 
            this.saveKeyb.Location = new System.Drawing.Point(626, 76);
            this.saveKeyb.Name = "saveKeyb";
            this.saveKeyb.Size = new System.Drawing.Size(71, 32);
            this.saveKeyb.TabIndex = 18;
            this.saveKeyb.Text = "...";
            this.saveKeyb.UseVisualStyleBackColor = true;
            this.saveKeyb.Click += new System.EventHandler(this.saveKeyb_Click);
            // 
            // GenerateScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(729, 263);
            this.Controls.Add(this.saveKeyb);
            this.Controls.Add(this.saveExamb);
            this.Controls.Add(this.cancelb);
            this.Controls.Add(this.okb);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerateScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Q&A Generate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelb;
        private System.Windows.Forms.Button okb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveExamb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button saveKeyb;
    }
}