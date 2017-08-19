using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Inetspeedmeter
{
    public partial class ConnectionCheck : Form
    {
        public ConnectionCheck()
        {
            InitializeComponent();
        }

        private void ConBtn_Click(object sender, EventArgs e)
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection==true)
            {
                MessageBox.Show("connected");
                Form1 f = new Form1();
                f.Show();
                this.Hide();
               
            }
            else
                MessageBox.Show("Not connected");

        }
    }
}
