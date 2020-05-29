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
    public partial class RenameForm : Form
    {
        public string newname = "";
        public Form1 f;
        public RenameForm(Form1 form)
        {
            InitializeComponent();
            f = form;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            btnConfirm.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void setName(string str)
        {
            newname = textBox1.Text;
            f.filename = newname;
        }
    }
}
