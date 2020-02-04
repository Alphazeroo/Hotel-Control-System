using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyonSistemi
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e) => Application.Exit();
        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            MainPage mainPage = new MainPage();
            login.EnterSys(Password.Text, Username.Text, DateTime.Now);
            string HoldInf= Password.Text + " " + Username.Text;
            if(login.LoginSt == HoldInf)
            {
                mainPage.Show();
                this.Hide();
            }
        }        
    }
}
