namespace Logger
{
    using Interfaces;
    using Enums;
    using System;
    using System.IO;

    public class FileAppender : IAppender
    {
        private string file;

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public string File
        {
            get { return this.file; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("File name can not be null or empty");
                }

                this.file = value;
            }
        }

        public ILayout Layout { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void AppendMessage(ReportLevel report, string message)
        {
            if ((int)report >= (int)ReportLevel)
            {
                this.Layout.Date = DateTime.Now;
                this.Layout.Report = report;
                this.Layout.Message = message;

                string result = this.Layout.FormatLog();
                FileStream fs = null;
                try
                {
                    fs = new FileStream(this.File, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    using (sw)
                    {
                        sw.Write(result + "\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                }
            }
        }
    }
}
