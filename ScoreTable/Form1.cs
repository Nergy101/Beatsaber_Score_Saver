using Newtonsoft.Json;
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
    public partial class Form1 : Form
    {
        public string tekst { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void run_cmd(string sortType)
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c " + "C:\\Python36-64\\python.exe ..\\..\\..\\ScoreSorter\\ScoreSorter\\ScoreSorter.py " + sortType);
            //cmd is full path to python.exe
            //start.Arguments = args;//args is path to .py file and any cmd line args
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    var a = (result);
                }
            }
        }



        private void load()
        {
            string inputSortType = sortTypeBox.Text;
            try
            {
                run_cmd(inputSortType);
                var input = File.ReadAllText("D:\\sorted_scores.json");
                var result = JsonConvert.DeserializeObject<List<PlayerEntry>>(input);

                dataGridView1.DataSource = result;
                button1.Text = "Load another";
            }
            catch (FileNotFoundException)
            {
                button1.Text = "Failed1";
            }
            catch (FileLoadException)
            {
                button1.Text = "Failed2";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.Gray;
            label1.BackColor = Color.Green;
            sortTypeBox.Text = "1";
            load();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Gray;
            label2.BackColor = Color.Green;
            sortTypeBox.Text = "";
            load();
        }
    }
}
