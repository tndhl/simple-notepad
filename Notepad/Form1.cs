using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            statusFilename.Text = editor.FileName;
        }

        private void fileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                editor.FileName = openFileDialog.SafeFileName;

                if (editor.OpenFile(openFileDialog.FileName))
                {
                    textBox.Text = editor.getPlainText();
                    statusFilename.Text = editor.FileName;
                }
            }
        } 
    }
}
