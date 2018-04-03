using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Rmg.Windows.ShellControls.NativeMethods;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Rmg.Windows.ShellControls.DemoApp
{
    public partial class Form1 : Form
    {
        private string selectedItem;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var filePath = ((string[])e.Data.GetData(DataFormats.FileDrop)).First();

            this.shellPreviewControl1.DisplayedPath = filePath;

            this.selectedItem = filePath;
            this.btOpenDefault.Text = $"Open {Path.GetFileName(filePath)}";
            this.btOpenDefault.Enabled = this.btOpenWithOther.Enabled = true;
        }

        private void shellPreviewControl1_DisplayedPathChanged(object sender, EventArgs e)
        {
            label1.Visible = shellPreviewControl1.LastLoadException != null;
        }

        private void btOpenDefault_Click(object sender, EventArgs e)
        {
            var shellExecute = new ProcessStartInfo(selectedItem)
            {
                UseShellExecute = true,
                Verb = "Open"
            };
            Process.Start(shellExecute);
        }

        private void btOpenWithOther_Click(object sender, EventArgs e)
        {
            var handlers = AssociatedHandler.ForPath(selectedItem)
                .Select(at => new MenuItem(at.DisplayName, (_1, _2) => at.Invoke()))
                .ToArray();

            var cxm = new ContextMenu(handlers);
            cxm.Show(this, this.PointToClient(MousePosition));
        }
    }
}
