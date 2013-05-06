using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    class Editor
    {
        private string m_fileName = "New file";
        private string m_filePath = "";
        private string m_plaintext = "";
       
        public string FileName 
        {
            get
            {
                return this.m_fileName;
            }

            set
            {
                this.m_fileName = value;
            }
        }

        public string FilePath
        {
            get
            {
                return this.m_filePath;
            }

            set
            {
                this.FilePath = value;
            }
        }

        public string getPlainText()
        {
            return this.m_plaintext;
        }

        public bool OpenFile(string path)
        {
            try
            {
                this.m_filePath = path;

                FileStream fileStream = new FileStream(this.m_filePath, FileMode.Open, FileAccess.ReadWrite);
                byte[] b = new byte[1024];
                UTF8Encoding tmp = new UTF8Encoding(true);

                while (fileStream.Read(b, 0, b.Length) > 0)
                {
                    this.m_plaintext += tmp.GetString(b);
                }

                return true;
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("Sorry, but you have not access to this file.");

                return false;
            }
            catch (IOException e)
            {
                MessageBox.Show("Error while opening the file.");

                return false;
            }
        }
    }
}