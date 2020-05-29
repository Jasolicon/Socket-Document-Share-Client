using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDocumentShareClient
{
    public partial class ServerFiles : Form
    {
        string[] strFileList = new string[100];
        private string strFileChosen;
        public string strGetFileChosen
        {
            get { return strFileChosen; }
        }
        Form1 pForm;
        public ServerFiles(Form1 parent,string[] s)
        {
            InitializeComponent();
            strFileList = s;
            pForm = parent;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            strFileChosen = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ServerFiles_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = strFileList ;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            strFileChosen = listBox1.Items[listBox1.SelectedIndex] as string;
            Console.WriteLine(strFileChosen);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
