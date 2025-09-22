using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace DosBoxZip2CFG
{
    public partial class Form1 : Form
    {
        string zipFile = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            var dropped = e.Data.GetData(DataFormats.FileDrop);
            var files = ((string[])dropped);

            foreach (var file in files)
            {
                if (file.ToLower().Contains("zip"))
                {
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                    using (ZipArchive archive = ZipFile.OpenRead(file))
                    {
                        zipFile = file;
                        Console.WriteLine("Loaded " + zipFile);

                        foreach (ZipArchiveEntry fileContents in archive.Entries)
                        {
                            listBox1.Items.Add(fileContents.FullName);
                            if (fileContents.Name.ToLower().Contains("exe") || fileContents.Name.ToLower().Contains("bat") || fileContents.Name.ToLower().Contains("com"))
                            {
                                listBox2.Items.Add(fileContents.FullName);
                            }
                            if (fileContents.Name.ToLower().Contains("iso") || fileContents.Name.ToLower().Contains("bin") || fileContents.Name.ToLower().Contains("cue") || fileContents.Name.ToLower().Contains("img") )
                            {
                                listBox3.Items.Add(fileContents.FullName);
                            }
                        }
                    }
                }
            }

            e.Effect = DragDropEffects.None;           
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void createBAT()
        {            
            richTextBox1.Text += "@echo off" + Environment.NewLine;
            richTextBox1.Text += "mount c \"..\"" + Environment.NewLine;

            if (textBox2.Text.Trim().Length > 3)
            {
                string isoPath = textBox2.Text.Substring(0, textBox2.Text.LastIndexOf('/'));
                string isoFile = textBox2.Text.Split('/')[textBox2.Text.Split('/').Count() - 1];

                foreach (string pathPart in isoPath.Split('/'))
                {
                    richTextBox1.Text += "cd " + pathPart + Environment.NewLine;
                }

                richTextBox1.Text += "imgmount d " + isoFile + " -t iso -fs iso" + Environment.NewLine;
                richTextBox1.Text += "cd/" + Environment.NewLine;
            }

            string exePath = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf('/'));
            string exeFile = textBox1.Text.Split('/')[textBox1.Text.Split('/').Count() - 1];

            foreach (string pathPart in exePath.Split('/'))
            {
                richTextBox1.Text += "cd " + pathPart + Environment.NewLine;
            }

            richTextBox1.Text += exeFile + Environment.NewLine;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ConfigCreation.target == null) { ConfigCreation.target = this; }

            richTextBox1.Text = "";
            ConfigCreation.CreateConfig();

            if (listBox1.Items.Count > 0)
            {
                ConfigCreation.CreateAutoExec();
            }

            foreach (string configLines in ConfigCreation.ConfigFile)
            {
                richTextBox1.Text += configLines + Environment.NewLine;
            }

            if (listBox1.Items.Count > 0)
            {                
                createBAT();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox2.Text;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox3.Text;
        }

        private void dosboxMemsize_Scroll(object sender, EventArgs e)
        {

        }

        private void dosboxMemsize_ValueChanged(object sender, EventArgs e)
        {
            memSizeScrollerText.Text = dosboxMemsize.Value + " MB";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
