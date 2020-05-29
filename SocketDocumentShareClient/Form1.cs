using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsThread;

namespace SocketDocumentShareClient
{
    public partial class Form1 : Form
    {
        private string path;
        public string filename = "";
        private string strFileChoose;
        ClientSocketReceive csrAsk;
        public Form1()
        {
            InitializeComponent();
            btnRename.Enabled = false;
            btnRename2.Enabled = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openUploadingForm();
        }

        private void openDocSelectForm()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                txtPath.Text = path;
                filename = Path.GetFileName(path);
                btnRename.Enabled = true;
            }
            
        }
        private void openUploadingForm()
        {
            Uploading uploadingForm = new Uploading(filename,path);
            uploadingForm.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            openDocSelectForm();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            filename = rename();
            if(filename != "default")
            {
                MessageBox.Show(filename);
            }
        }
        //private delegate void DelRename(string str);
        //DelRename delRename;
        private string rename()
        {
            string name = "";
            RenameForm form = new RenameForm(this);
            //delRename += form.setName;
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                name = form.newname;
            }
            
            if (name != "")
            {
                return name;
            }
            else
            {
                string n = Path.GetFileName(path);
                return n;
            }
            
        }

        private void btnSelectFromServer_Click(object sender, EventArgs e)
        {
            csrAsk = new ClientSocketReceive("192.168.1.105",182);
            Thread t = new Thread(new ThreadStart(csrAsk.sendRequest));//发送下载文件请求
            t.Start();
            t.Join();
            t.Abort();
            Thread twait = new Thread(new ThreadStart(csrAsk.getMessageFromServer));//回收文件列表
            twait.Start();
            twait.Join();
            string[] strFileList = new string[100];
            try
            {
                strFileList = SerializeNDeserialize.Deserialize(csrAsk.BtToReceiveList) as string[];
            }
            catch(Exception ex)
            {
                Console.WriteLine("获得文件列表错误{0}", ex);
            }
            //twait.Abort();

            ServerFiles f = new ServerFiles(this,strFileList);
            //f.Show();
            if(f.ShowDialog() == DialogResult.OK)
            {
                tbPathDownload.Text = f.strGetFileChosen;
                strFileChoose = f.strGetFileChosen;
                
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //csrAsk = new ClientSocketReceive("192.168.1.105", 182);
            Thread tSend = new Thread(new ParameterizedThreadStart(csrAsk.SendMessage));
            tSend.Start(strFileChoose);
            tSend.Join();
            Thread tDownload = new Thread(new ThreadStart(csrAsk.downloadFile));
            tDownload.Start();
            tDownload.Join();
        }
    }
}
