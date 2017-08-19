using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Inetspeedmeter
{
    public partial class Form1 : Form
    {
        private const double timerUpdate = 1000;
        double ByteRcv = 0;
        double ByteSent = 0;

      
        private NetworkInterface[] nicArr;

        private Timer timer;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            InitializeNetworkInterface();
            InitializeTimer();
        }


        private void InitializeNetworkInterface()
        {
        
            nicArr = NetworkInterface.GetAllNetworkInterfaces();

            for (int i = 0; i < nicArr.Length; i++)
                cmbInterface.Items.Add(nicArr[i].Name);

            cmbInterface.SelectedIndex = 0;
        }

     
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = (int)timerUpdate;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void UpdateNetworkInterface()
        {
         
            NetworkInterface nic = nicArr[cmbInterface.SelectedIndex];

            IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

            int bytesSentSpeed = (int)(interfaceStats.BytesSent -ByteSent) / 1024;
            int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - ByteRcv) / 1024;
            ByteRcv = interfaceStats.BytesReceived;
            ByteSent = interfaceStats.BytesSent;

            // Update the labels
          //  lblSpeed.Text = nic.Speed.ToString();
           // lblInterfaceType.Text = nic.NetworkInterfaceType.ToString();
          //  lblSpeed.Text = nic.Speed.ToString();
          //  lblBytesReceived.Text = interfaceStats.BytesReceived.ToString();
         //   lblBytesSent.Text = interfaceStats.BytesSent.ToString();
            lblupload.Text = bytesSentSpeed.ToString() + " KB/s";
            lbldown.Text = bytesReceivedSpeed.ToString() + " KB/s";

        }

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateNetworkInterface();
        }
        
        
    }
}
