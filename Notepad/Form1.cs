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
                if (editor.OpenFile(openFileDialog.FileName))
                {
                    textBox.Text = editor.getPlainText();
                    statusFilename.Text = editor.FileName;
                }
            }
        }

        private void fileSave_Click(object sender, EventArgs e)
        {
            editor.setPlainText(textBox.Text);

            if (editor.FilePath.Length == 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.InitialDirectory = "C:\\";
                saveFileDialog.Filter = "All files (*.*)|(*.*)";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    editor.FilePath = saveFileDialog.FileName;

                    if (editor.SaveFile())
                    {
                        statusFilename.Text = editor.FileName;
                        MessageBox.Show("File was successfully saved.");
                    }
                }
            }
            else
            {
                if (editor.SaveFile())
                {
                    MessageBox.Show("File was successfully saved.");
                }
            }
        }

        private void fileSaveAs_Click(object sender, EventArgs e)
        {
            editor.setPlainText(textBox.Text);
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Filter = "All files (*.*)|(*.*)";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                editor.FilePath = saveFileDialog.FileName;

                if (editor.SaveFile())
                {
                    statusFilename.Text = editor.FileName;
                    MessageBox.Show("File was successfully saved.");
                }
            }
        }

        private void fileNew_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            editor.setPlainText("");
            editor.FilePath = "";
            editor.FileName = "New file";

            statusFilename.Text = editor.FileName;
        }

        private void fileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 
    }
}
