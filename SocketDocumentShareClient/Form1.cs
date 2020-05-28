using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDocumentShareClient
{
    public partial class Form1 : Form
    {
        private string path;
        public string filename = "";
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
        private delegate void DelRename(string str);
        DelRename delRename;
        private string rename()
        {
            string name = "";
            RenameForm form = new RenameForm();
            delRename += form.setName;
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
    }
}
