namespace SocketDocumentShareClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tbPathDownload = new System.Windows.Forms.TextBox();
            this.btnSelectFromServer = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnRename2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(43, 39);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(394, 25);
            this.txtPath.TabIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(289, 84);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(148, 25);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(289, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(43, 84);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(108, 25);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择文件";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbPathDownload
            // 
            this.tbPathDownload.Location = new System.Drawing.Point(43, 127);
            this.tbPathDownload.Name = "tbPathDownload";
            this.tbPathDownload.Size = new System.Drawing.Size(394, 25);
            this.tbPathDownload.TabIndex = 0;
            // 
            // btnSelectFromServer
            // 
            this.btnSelectFromServer.Location = new System.Drawing.Point(43, 172);
            this.btnSelectFromServer.Name = "btnSelectFromServer";
            this.btnSelectFromServer.Size = new System.Drawing.Size(108, 25);
            this.btnSelectFromServer.TabIndex = 1;
            this.btnSelectFromServer.Text = "选择文件";
            this.btnSelectFromServer.UseVisualStyleBackColor = true;
            this.btnSelectFromServer.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(157, 84);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(126, 25);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "重命名";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnRename2
            // 
            this.btnRename2.Location = new System.Drawing.Point(157, 172);
            this.btnRename2.Name = "btnRename2";
            this.btnRename2.Size = new System.Drawing.Size(126, 25);
            this.btnRename2.TabIndex = 2;
            this.btnRename2.Text = "重命名";
            this.btnRename2.UseVisualStyleBackColor = true;
            this.btnRename2.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 269);
            this.Controls.Add(this.btnRename2);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectFromServer);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.tbPathDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPathDownload;
        private System.Windows.Forms.Button btnSelectFromServer;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnRename2;
    }
}

