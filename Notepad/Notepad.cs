namespace Notepad
{
    class Editor
    {
        private string m_fileName = "New file";
        private string m_filePath = "";

        public string FileName {
            get
            {
                return this.m_fileName;
            }

            set
            {
                this.FileName = value;
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
    }
}