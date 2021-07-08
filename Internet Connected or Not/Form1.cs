using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Internet_Connected_or_Not
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool pingStatus ()
        {
            bool pingStatus = false;
            string hostNameOrAddress = "Google.com";

            using (Ping p = new Ping())
            {
                string data = "aaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000;

                try
                {
                    PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                    pingStatus = (reply.Status == IPStatus.Success);
                }
                catch(Exception)
                {
                    pingStatus = false;
                }
                return pingStatus;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(pingStatus()==true)
            {
                pictBoxStatus.Image = Properties.Resources.wifi;
                lblStatus.Text = "Internet Connected";
                lblStatus.ForeColor = Color.FromArgb(33, 230, 197);
            }
            else
            {
                pictBoxStatus.Image = Properties.Resources.wifi_off;
                lblStatus.Text = "Internet Not Connected";
                lblStatus.ForeColor = Color.FromArgb(240, 89, 69);
            }
        }
    }
}
