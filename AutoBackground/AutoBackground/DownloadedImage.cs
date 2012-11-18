using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutoBackground
{
    public class DownloadedImage
    {
        string localPath;
        public string LocalPath
        {
            get { return localPath; }
            set { localPath = value; }
        }
        string webURL;
        public string WebURL
        {
            get { return webURL; }
            set { webURL = value; }
        }

        public DownloadedImage(string localPath, string webURL)
        {
            this.localPath = localPath;
            this.webURL = webURL;
        }

        public string getSettingsString()
        {
            return "i " + webURL + " " + localPath;
        }

        public string FileName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(localPath);
            }
        }
    }
}
