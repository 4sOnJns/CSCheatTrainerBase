using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace csharphack
{
    public partial class Form1 : Form
    {

        Mem meme = new Mem();

        public static string RifleAmmo = "ac_client.exe+0x0017B0B8,140"; //rifle ammo
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int PID = meme.GetProcIdFromName("ac_client");
            if (PID > 0)
            {
                meme.OpenProcess(PID);
                Thread WA = new Thread(writeAmmo) { IsBackground = true };
                WA.Start();
            }
        }

        private void writeAmmo()
        {
            while (true)
            {
                if (checkBox2.Checked)
                {
                    meme.WriteMemory(RifleAmmo, "int", "9999");
                    Thread.Sleep(2);
                }
            }
        }

        
    }
}