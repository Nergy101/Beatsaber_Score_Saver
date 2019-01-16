using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScoreTable
{
    public partial class Form4 : Form
    {
        public string tekst { get; set; }

        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        string jsonstring = "";

        private void run_cmd(string sortType, string loadPath)       // path from within solution: ..\\..\\..\\ScoreSorter\\                 path below is from within Release folder
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c " + "dist\\battlesorter.exe " + sortType + " " + loadPath);
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    jsonstring = (result);
                }
            }
        }



        private void load()
        {
            string inputSortType = ErrorBox.Text;
            string loadPath = LoadPathBox.Text;
            try
            {
                run_cmd(inputSortType, loadPath); // fills jsonstring
                //var input = File.ReadAllText("D:\\sorted_scores.json");
                var result = JsonConvert.DeserializeObject<List<PlayerEntry>>(jsonstring);

                dataGridView1.DataSource = result;
            }
            catch (FileNotFoundException)
            {
                ErrorBox.Visible = true;
                ErrorBox.Text = "FileNotFoundEx";
                //"Failed1";
            }
            catch (FileLoadException)
            {
                // "Failed2";

                ErrorBox.Visible = true;
                ErrorBox.Text = "FileLoadEx";
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
            ErrorBox.Text = "1";
            load();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            label1.BackColor = Color.Gray;
            label2.BackColor = Color.Green;
            ErrorBox.Text = "2";
            load();
        }
    }
}
