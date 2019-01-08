using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreTable
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private bool run_cmd()       // path from within solution: ..\\..\\..\\ScoreSorter\\                 path below is from within Release folder
        {
            bool succes = false;
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c " + "dist\\scorecombiner.exe " + SavePathBox.Text + " " + LoadPathBox.Text + " " + LoadPathBox2.Text)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    ErrorBox.Visible = true;
                    ErrorBox.Text = (result);
                }
            }
            if(!(ErrorBox.Text == String.Empty)) succes = true;
            return succes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {//combine button
            checkBox1.Checked = false;
            checkBox1.Checked = run_cmd();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void LoadPathBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
