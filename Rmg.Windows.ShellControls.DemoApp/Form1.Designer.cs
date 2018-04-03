
namespace Rmg.Windows.ShellControls.DemoApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOpenDefault = new System.Windows.Forms.Button();
            this.btOpenWithOther = new System.Windows.Forms.Button();
            this.wndPreview = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.shellPreviewControl1 = new Rmg.Windows.ShellControls.ShellPreviewControl();
            this.wndPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpenDefault
            // 
            this.btOpenDefault.Enabled = false;
            this.btOpenDefault.Location = new System.Drawing.Point(13, 13);
            this.btOpenDefault.Name = "btOpenDefault";
            this.btOpenDefault.Size = new System.Drawing.Size(170, 23);
            this.btOpenDefault.TabIndex = 0;
            this.btOpenDefault.Text = "Drop file here to preview";
            this.btOpenDefault.UseVisualStyleBackColor = true;
            this.btOpenDefault.Click += new System.EventHandler(this.btOpenDefault_Click);
            // 
            // btOpenWithOther
            // 
            this.btOpenWithOther.Enabled = false;
            this.btOpenWithOther.Location = new System.Drawing.Point(190, 12);
            this.btOpenWithOther.Name = "btOpenWithOther";
            this.btOpenWithOther.Size = new System.Drawing.Size(38, 23);
            this.btOpenWithOther.TabIndex = 1;
            this.btOpenWithOther.Text = "...";
            this.btOpenWithOther.UseVisualStyleBackColor = true;
            this.btOpenWithOther.Click += new System.EventHandler(this.btOpenWithOther_Click);
            // 
            // wndPreview
            // 
            this.wndPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wndPreview.Controls.Add(this.label1);
            this.wndPreview.Controls.Add(this.shellPreviewControl1);
            this.wndPreview.Location = new System.Drawing.Point(12, 42);
            this.wndPreview.Name = "wndPreview";
            this.wndPreview.Size = new System.Drawing.Size(260, 207);
            this.wndPreview.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 207);
            this.label1.TabIndex = 1;
            this.label1.Text = "No preview available.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // shellPreviewControl1
            // 
            this.shellPreviewControl1.DisplayedPath = null;
            this.shellPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellPreviewControl1.Location = new System.Drawing.Point(0, 0);
            this.shellPreviewControl1.Name = "shellPreviewControl1";
            this.shellPreviewControl1.Size = new System.Drawing.Size(260, 207);
            this.shellPreviewControl1.TabIndex = 0;
            this.shellPreviewControl1.Text = "shellPreviewControl1";
            this.shellPreviewControl1.DisplayedPathChanged += new System.EventHandler(this.shellPreviewControl1_DisplayedPathChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.wndPreview);
            this.Controls.Add(this.btOpenWithOther);
            this.Controls.Add(this.btOpenDefault);
            this.Name = "Form1";
            this.Text = "Drag/drop file to preview";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.wndPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOpenDefault;
        private System.Windows.Forms.Button btOpenWithOther;
        private System.Windows.Forms.Panel wndPreview;
        private ShellPreviewControl shellPreviewControl1;
        private System.Windows.Forms.Label label1;
    }
}

