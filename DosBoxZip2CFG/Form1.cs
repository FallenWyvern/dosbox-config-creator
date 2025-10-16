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
using System.IO;

namespace DosBoxZip2CFG
{
    public partial class Form1 : Form
    {
        string zipFile = "";
        string directoryDrop = "";
        bool isZip = false;
        bool isDir = false;

        public Form1()
        {
            InitializeComponent();
        }

        // All UI Events
        #region
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            ProcessDragAndDroppedFile(e);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartConfCreation();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (executableList.Text.Contains('/'))
            {
                string fullPath = executableList.Text.Substring(0, executableList.Text.LastIndexOf('/')) + "/";
                string filename = executableList.Text.Replace(fullPath, "");

                string fileNameNoExt = filename.Substring(0, filename.LastIndexOf('.'));
                if (fileNameNoExt.Length > 8)
                {
                    filename = filename.Substring(0, 6) + "~1" + filename.Replace(fileNameNoExt, "");
                }

                textBox1.Text = fullPath + filename;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isoList.Text.Contains('/'))
            {
                string fullPath = isoList.Text.Substring(0, isoList.Text.LastIndexOf('/')) + "/";
                string filename = isoList.Text.Replace(fullPath, "");

                string fileNameNoExt = filename.Substring(0, filename.LastIndexOf('.'));
                if (fileNameNoExt.Length > 8)
                {
                    filename = filename.Substring(0, 6) + "~1" + filename.Replace(fileNameNoExt, "");
                }

                textBox2.Text = fullPath + filename;
            }
        }

        private void dosboxMemsize_ValueChanged(object sender, EventArgs e)
        {
            memSizeScrollerText.Text = dosboxMemsize.Value + " MB";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void insert_Click(object sender, EventArgs e)
        {
            Savefile();
        }

        private void save_Click(object sender, EventArgs e)
        {
            Savefile();
        }
        #endregion

        // Processing and Output Code
        #region
        private void ProcessDragAndDroppedFile(DragEventArgs e)
        {
            var dropped = e.Data.GetData(DataFormats.FileDrop);
            var files = ((string[])dropped);
            isZip = false;
            isDir = false;
            
            zipFile = "";
            directoryDrop = "";

            FileAttributes attr = File.GetAttributes(files[0]);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                isDir = true;
            }

            if (files[0].ToLower().Contains("zip"))
            {
                isZip = true;
            }


            if (isZip || isDir)
            {
                filesList.Items.Clear();
                executableList.Items.Clear();
                isoList.Items.Clear();
                textBox1.Text = "";
                textBox2.Text = "";

                if (isZip)
                {
                    using (ZipArchive archive = ZipFile.OpenRead(files[0]))
                    {
                        zipFile = files[0];
                        Console.WriteLine("Loaded " + zipFile);

                        foreach (ZipArchiveEntry fileContents in archive.Entries)
                        {
                            filesList.Items.Add(fileContents.FullName);
                            if (fileContents.Name.ToLower().Contains("exe") || fileContents.Name.ToLower().Contains("bat") || fileContents.Name.ToLower().Contains("com"))
                            {
                                executableList.Items.Add(fileContents.FullName);
                            }
                            if (fileContents.Name.ToLower().Contains("iso") || fileContents.Name.ToLower().Contains("bin") || fileContents.Name.ToLower().Contains("cue") || fileContents.Name.ToLower().Contains("img"))
                            {
                                isoList.Items.Add(fileContents.FullName);
                            }
                        }
                    }
                }

                if (isDir)
                {
                    directoryDrop = files[0];
                    Console.WriteLine("Directory Loaded " + directoryDrop);

                    string[] allFiles = Directory.GetFiles(files[0], "*.*", SearchOption.AllDirectories);
                    foreach (string filex in allFiles)
                    {
                        string file = filex.Replace(files[0], "");

                        filesList.Items.Add(file);
                        if (file.ToLower().Contains("exe") || file.ToLower().Contains("bat") || file.ToLower().Contains("com"))
                        {
                            executableList.Items.Add(file);
                        }
                        if (file.ToLower().Contains("iso") || file.ToLower().Contains("bin") || file.ToLower().Contains("cue") || file.ToLower().Contains("img"))
                        {
                            isoList.Items.Add(file);
                        }
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void createBAT()
        {
            configFileOutput.Text += "@echo off" + Environment.NewLine;
            configFileOutput.Text += "mount " + driveMount.Text + " \"..\"" + Environment.NewLine;
            configFileOutput.Text += driveMount.Text + ":" + Environment.NewLine;

            if (isDir)
            {
                string exePath = directoryDrop + textBox1.Text;
                string exeFile = exePath.Split('\\')[exePath.Split('\\').Count() - 1];
                exePath = exePath.Replace(exeFile, "");

                string isoPath = directoryDrop + textBox2.Text;
                string isoFile = isoPath.Split('\\')[isoPath.Split('\\').Count() - 1];
                isoPath = isoPath.Replace(isoFile, "");

                string truncPath = exePath.Replace(directoryDrop, "");

                // configFileOutput.Text = "";
                // configFileOutput.Text += "DIR: " + directoryDrop + Environment.NewLine;
                // configFileOutput.Text += "TRC: " + truncPath + Environment.NewLine;
                // configFileOutput.Text += exePath.Replace(directoryDrop, "") + Environment.NewLine;
                // configFileOutput.Text += exePath + Environment.NewLine;
                // configFileOutput.Text += "EXE: " + exeFile + Environment.NewLine;
                // configFileOutput.Text += isoPath + Environment.NewLine;
                // configFileOutput.Text += "ISO : " + isoFile + Environment.NewLine;

                if (isoPath.Contains('\\'))
                {
                    int isoPathCount = 0;
                    foreach (string pathPart in isoPath.Replace(directoryDrop, "").Split('\\'))
                    {
                        if (pathPart.Trim().Length > 0)
                        {
                            configFileOutput.Text += "cd " + pathPart + Environment.NewLine;
                            isoPathCount++;
                        }
                    }

                    configFileOutput.Text += "imgmount " + isomountPath.Text + " " + isoFile + " -t iso -fs iso" + Environment.NewLine;                                        
                    while (isoPathCount > 0)
                    {
                        configFileOutput.Text += "cd.." + Environment.NewLine;
                        isoPathCount--;
                    }
                }

                if (exePath.Contains('\\'))
                {                    
                    foreach (string pathPart in exePath.Replace(directoryDrop, "").Split('\\'))
                    {
                        if (pathPart.Trim().Length > 0)
                        {
                            configFileOutput.Text += "cd " + pathPart + Environment.NewLine;                            
                        }
                    }

                    configFileOutput.Text += exeFile + Environment.NewLine;
                }
            }

            if (isZip)
            {
                if (textBox2.Text.Trim().Length > 3)
                {
                    string isoPath = textBox2.Text.Substring(0, textBox2.Text.LastIndexOf('/'));
                    string isoFile = textBox2.Text.Split('/')[textBox2.Text.Split('/').Count() - 1];

                    foreach (string pathPart in isoPath.Split('/'))
                    {
                        configFileOutput.Text += "cd " + pathPart + Environment.NewLine;
                    }

                    configFileOutput.Text += "imgmount " + isomountPath.Text + " " + isoFile + " -t iso -fs iso" + Environment.NewLine;
                    configFileOutput.Text += "cd/" + Environment.NewLine;
                }

                if (textBox1.Text.Trim().Length > 3)
                {
                    string exePath = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf('/'));
                    string exeFile = textBox1.Text.Split('/')[textBox1.Text.Split('/').Count() - 1];

                    foreach (string pathPart in exePath.Split('/'))
                    {
                        configFileOutput.Text += "cd " + pathPart + Environment.NewLine;
                    }

                    configFileOutput.Text += exeFile + Environment.NewLine;
                }
            }

        }

        private void StartConfCreation()
        {
            if (ConfigCreation.target == null) { ConfigCreation.target = this; }

            configFileOutput.Text = "";
            ConfigCreation.CreateConfig();

            if (filesList.Items.Count > 0)
            {
                ConfigCreation.CreateAutoExec();
            }

            foreach (string configLines in ConfigCreation.ConfigFile)
            {
                configFileOutput.Text += configLines + Environment.NewLine;
            }

            if (filesList.Items.Count > 0)
            {
                createBAT();
            }
        }

        private void Savefile()
        {
            string exePath = "./";
            string exeFile = "DOSBOX.exe";

            string sourceFilePath = "./" + exeFile.Split('.')[0] + ".conf";
            string entryNameInZip = exePath + "/" + exeFile.Split('.')[0] + ".conf";

            if (textBox1.Text.Contains('/')) 
            {
                exePath = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf('/'));
                exeFile = textBox1.Text.Split('/')[textBox1.Text.Split('/').Count() - 1];

                sourceFilePath = "./" + exeFile.Split('.')[0] + ".conf";
                entryNameInZip = exePath + "/" + exeFile.Split('.')[0] + ".conf";
            }
            
            System.IO.File.WriteAllText(sourceFilePath, configFileOutput.Text);

            if (isZip)
            {
                if (checkBox1.Checked)
                {
                    entryNameInZip = "dosbox.conf";                    
                }

                using (ZipArchive archive = ZipFile.Open(zipFile, ZipArchiveMode.Update))
                {
                    List<ZipArchiveEntry> deleteMe = new List<ZipArchiveEntry>();
                    foreach (var item in archive.Entries)
                    {                        
                        if (item.Name.ToLower().Contains(".conf"))
                        {
                            Console.WriteLine(item.Name);
                            deleteMe.Add(item);
                        }
                    }

                    while (deleteMe.Count > 0) {
                        Console.WriteLine("Removing from list: " + deleteMe[0].Name);
                        if (MessageBox.Show("Conf File Detected: Delete " + deleteMe[0].Name + "?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            deleteMe[0].Delete();
                        }
                        deleteMe.RemoveAt(0);                        
                    }

                    archive.CreateEntryFromFile(sourceFilePath, entryNameInZip, CompressionLevel.Optimal);                    
                }
            }

            if (isDir)
            {
                exePath = directoryDrop + textBox1.Text;
                exeFile = exePath.Split('.')[0] + ".conf";
                System.IO.File.WriteAllText(exeFile, configFileOutput.Text);
            }
        }
        #endregion
    }
}
