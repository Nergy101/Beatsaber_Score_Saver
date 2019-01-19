using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        string jsonstring = "";

        private void run_cmd(string sortType, string loadPath)       // path from within solution: ..\\..\\..\\ScoreSorter\\                 path below is from within Release folder
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c " + "dist\\scoresorter.exe " + sortType + " " + loadPath);
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

        private async Task load()
        {
            string inputSortType = ErrorBox.Text;
            string loadPath = LoadPathBox.Text;
            try
            {
                run_cmd(inputSortType, loadPath); // fills jsonstring
                //var input = File.ReadAllText("D:\\sorted_scores.json");
                var result = JsonConvert.DeserializeObject<List<PlayerEntry>>(jsonstring);

                List<int> scores = new List<int>();
                dataGridView1.DataSource = result;
                result.ForEach(pe => scores.Add(pe._score));
                scores.Sort();
                scores.Reverse();
                textBox1.Text = scores[0].ToString();
                textBox2.Text = scores[1].ToString();
                textBox3.Text = scores[2].ToString();
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
            await Task.Delay(180000);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void label1_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.Gray;
            label1.BackColor = Color.Green;
            ErrorBox.Text = "1";
            await load();
        }

        private async void label2_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Gray;
            label2.BackColor = Color.Green;
            ErrorBox.Text = "2";
            await load();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Form2 = new Form2();
            Form2.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form3 = new Form3();
            Form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Form4 = new Form4();
            Form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LoadPathBox.Text == @"C:\Users\YourPCNameHere\AppData\LocalLow\Hyperbolic Magnetism\Beat Saber\LocalLeaderboards.dat")
                LoadPathBox.Text = @"D:\LocalLeaderboards.dat";
            else { LoadPathBox.Text = @"C:\Users\YourPCNameHere\AppData\LocalLow\Hyperbolic Magnetism\Beat Saber\LocalLeaderboards.dat"; }


        }

        bool refresh = false;
        private async void button5_Click(object sender, EventArgs e)
        {
            refresh = (refresh == false) ? refresh = true : refresh = false;
            if (refresh)
            {
                button5.BackColor = Color.Green;
                while (refresh)
                {
                    await load();
                }
                button5.BackColor = Color.Red;
            }
        }
    }
}
