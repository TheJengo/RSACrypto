using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSACrypto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Encrypt e1 = new Encrypt(Convert.ToInt32(txtP.Text), Convert.ToInt32(txtQ.Text), Convert.ToInt32(txtD.Text), Convert.ToInt32(txtWord.Text));
            lblResult.Text = e1.RSAOutput().ToString();
        }

        private void btnDecrpyt_Click(object sender, EventArgs e)
        {
            Decrypt d1 = new Decrypt(Convert.ToInt32(txtP.Text), Convert.ToInt32(txtQ.Text), Convert.ToInt32(txtD.Text), Convert.ToInt32(txtWord.Text));
            lblResult.Text = d1.RSAOutput().ToString();
        }
    }
}
