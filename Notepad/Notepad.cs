using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    class Editor
    {
        private string m_fileName = "Новый файл";
        private string m_filePath = "";
        private string m_plaintext = "";

        private void UpdateFileName(string path)
        {
            string[] fileName = path.Split(new Char[] { '\\' });
            this.m_fileName = fileName[fileName.Length - 1];
        }

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
                this.m_filePath = value;
            }
        }

        public string getPlainText()
        {
            return this.m_plaintext;
        }

        public void setPlainText(string text)
        {
            this.m_plaintext = text;
        }

        public bool OpenFile(string path)
        {
            this.UpdateFileName(path);
            
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

                fileStream.Close();
                return true;
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("У Вас нет доступа к данному файлу.");

                return false;
            }
            catch (IOException e)
            {
                MessageBox.Show("Возникла ошибка во время открытия файла.");

                return false;
            }
        }

        public bool SaveFile()
        {
            try
            {
                if (this.m_filePath.Length == 0)
                {
                    throw new Exception("Путь до файла не задан.");
                }

                FileStream fileStream = new FileStream(m_filePath, FileMode.Create, FileAccess.Write);
                Byte[] text = new UTF8Encoding(true).GetBytes(this.m_plaintext);

                fileStream.Write(text, 0, text.Length);

                fileStream.Close();

                this.UpdateFileName(m_filePath);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }
    }
}