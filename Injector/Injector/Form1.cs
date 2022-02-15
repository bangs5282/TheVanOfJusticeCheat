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

namespace Injector
{
    public partial class Form1 : Form
    {
        string path = System.Windows.Forms.Application.StartupPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Inject
        {
            System.Diagnostics.ProcessStartInfo pri = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            pri.FileName = "cmd.exe";

            pri.CreateNoWindow = true;
            pri.UseShellExecute = false;

            pri.RedirectStandardInput = true;
            pri.RedirectStandardOutput = true;
            pri.RedirectStandardError = true;

            pro.StartInfo = pri;
            pro.Start();

            pro.StandardInput.Write(@"cd" + path + Environment.NewLine);
            pro.StandardInput.Write(@"smi.exe inject -p TheVanOfJustice -a VanOfJusticeCheatDll.dll -n Gamename_Hack -c Loader -m Init" + Environment.NewLine);
            pro.StandardInput.Close();

            string resultValue = pro.StandardOutput.ReadToEnd();

            pro.WaitForExit();
            pro.Close();

            MessageBox.Show("Injected!");
            this.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) // FindDll
        {
            bool isGameRunning = false;
            Process[] proccesses = Process.GetProcesses();

            foreach (Process p in proccesses)
            {
                if (p.ProcessName == "TheVanOfJustice")
                {
                    isGameRunning = true;
                }
            }

            if (!isGameRunning)
            {
                MessageBox.Show("게임이 실행되고있지 않습니다\n게임을 실행한뒤 실행해주세요");
            }

            bool SharpMonoInjector = false;
            bool VanOfJusticeCheatDll = false;
            bool smi = false;

            string[] files = Directory.GetFiles(@path, "*.dll");
            foreach (var file in files)
            {
                if (file.ToString() == path + "\\SharpMonoInjector.dll")
                {
                    SharpMonoInjector = true;
                }

                if (file.ToString() == path + "\\VanOfJusticeCheatDll.dll")
                {
                    VanOfJusticeCheatDll = true;
                }
            }

            files = Directory.GetFiles(@path, "*.exe");
            foreach (var file in files)
            {
                if (file.ToString() == path + "\\smi.exe")
                {
                    smi = true;
                }
            }

            if (!SharpMonoInjector)
            {
                MessageBox.Show("SharpMonoInjector.dll 파일을 찾을수 없습니다\n폴더에 파일이 있는지 확인해주세요");
            }
            if (!VanOfJusticeCheatDll)
            {
                MessageBox.Show("VanOfJusticeCheatDll.dll 파일을 찾을수 없습니다\n폴더에 파일이 있는지 확인해주세요");
            }
            if (!smi)
            {
                MessageBox.Show("smi.exe 파일을 찾을수 없습니다\n폴더에 파일이 있는지 확인해주세요");
            }

            if(SharpMonoInjector && VanOfJusticeCheatDll && smi && isGameRunning)
            {
                button2.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/bangs5282");
        }
    }
}
