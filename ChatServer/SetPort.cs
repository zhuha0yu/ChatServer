using System;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class SetPort : Form
    {
        private Mainwindow Dad =null;
        public SetPort()
        {
            InitializeComponent();
        }
        public SetPort(Mainwindow Parents)
        {
            InitializeComponent();
            Dad = Parents;
        }

        private void SetPort_Load(object sender, EventArgs e)
        {
            this.Text = "设定端口号";
            textBox_port.Focus();
        }

        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Portnum = 0;
            try
            {
                Exception Numoutofrange=new Exception();
                
                Portnum = Convert.ToInt32(textBox_port.Text);
                if (Portnum < 0 || Portnum > 65535)
                    throw Numoutofrange;
                Dad.Setport(Portnum);
                this.Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("端口号无效！必须是0-65535整数");
                textBox_port.Text = "";
                textBox_port.Focus();
            }
        }
    }
}
