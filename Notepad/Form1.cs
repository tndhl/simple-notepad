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
            if (editor.FilePath.Length > 0)
            {
                if (MessageBox.Show("Сохранить открытый файл?", "Ранее открытый файл", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (editor.SaveFile())
                    {
                        MessageBox.Show("Файл успешно сохранен.");

                        textBox.Clear();
                        editor.setPlainText("");
                        editor.FilePath = "";
                        editor.FileName = "Новый файл";
                    }
                }
            }

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
                        MessageBox.Show("Файл успешно сохранен.");
                    }
                }
            }
            else
            {
                if (editor.SaveFile())
                {
                    MessageBox.Show("Файл успешно сохранен.");
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
                    MessageBox.Show("Файл успешно сохранен.");
                }
            }
        }

        private void fileNew_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            editor.setPlainText("");
            editor.FilePath = "";
            editor.FileName = "Новый файл";

            statusFilename.Text = editor.FileName;
        }

        private void fileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutBox_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        } 
    }
}
