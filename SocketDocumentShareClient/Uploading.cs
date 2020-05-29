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
using WindowsThread;

namespace SocketDocumentShareClient
{
    public partial class Uploading : Form
    {
        private string mPath;
        FileTransport ft;
        ClientSocketSend csSend = new ClientSocketSend();
        public Uploading(string name, string path)
        {
            InitializeComponent();
            mPath = path;
            MessageBox.Show(name);
            ft = new FileTransport(name, mPath);
            this.Text = string.Format("正在从{0}上传", mPath);
            Thread t = new Thread(new ParameterizedThreadStart(csSend.sendMessage));
            t.Start(ft);
            if (csSend.ConnectionFailed)
            {
                t.Abort();
                
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
