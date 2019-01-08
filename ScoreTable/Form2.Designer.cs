namespace ScoreTable
{
    partial class Form2
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
            this.label3 = new System.Windows.Forms.Label();
            this.LoadPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadPathBox2 = new System.Windows.Forms.TextBox();
            this.ErrorBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SavePathBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Load path 1:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // LoadPathBox
            // 
            this.LoadPathBox.Location = new System.Drawing.Point(74, 11);
            this.LoadPathBox.Name = "LoadPathBox";
            this.LoadPathBox.Size = new System.Drawing.Size(350, 20);
            this.LoadPathBox.TabIndex = 15;
            this.LoadPathBox.Text = "D:\\LocalLeaderboards.dat";
            this.LoadPathBox.TextChanged += new System.EventHandler(this.LoadPathBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Load path 2:";
            // 
            // LoadPathBox2
            // 
            this.LoadPathBox2.Location = new System.Drawing.Point(74, 37);
            this.LoadPathBox2.Name = "LoadPathBox2";
            this.LoadPathBox2.Size = new System.Drawing.Size(350, 20);
            this.LoadPathBox2.TabIndex = 17;
            this.LoadPathBox2.Text = "D:\\LocalLeaderboards.dat";
            // 
            // ErrorBox
            // 
            this.ErrorBox.Location = new System.Drawing.Point(74, 129);
            this.ErrorBox.Name = "ErrorBox";
            this.ErrorBox.Size = new System.Drawing.Size(350, 96);
            this.ErrorBox.TabIndex = 19;
            this.ErrorBox.Text = "";
            this.ErrorBox.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Combine";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Save path:";
            // 
            // SavePathBox
            // 
            this.SavePathBox.Location = new System.Drawing.Point(74, 63);
            this.SavePathBox.Name = "SavePathBox";
            this.SavePathBox.Size = new System.Drawing.Size(350, 20);
            this.SavePathBox.TabIndex = 21;
            this.SavePathBox.Text = "D:\\combined_scores.json";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Succes:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(245, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SavePathBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ErrorBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadPathBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadPathBox);
            this.Name = "Form2";
            this.Text = "ScoreCombiner";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoadPathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LoadPathBox2;
        private System.Windows.Forms.RichTextBox ErrorBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SavePathBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}