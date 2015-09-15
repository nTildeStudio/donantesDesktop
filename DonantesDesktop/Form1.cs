using Parse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonantesDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ParseClient.Initialize("", "");

            btPush.Click+=new EventHandler(sendPush);
        }

        async void sendPush(object sender, EventArgs e)
        {
            var push = new ParsePush();
            push.Query = from installation in ParseInstallation.Query
                         where installation.Get<String>("numeroDonante") == tbDestino.Text
                         select installation;
            push.Alert = tbMsg.Text;
            await push.SendAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
