using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace AutoBackground
{
    public class SettingsManager
    {
        List<DownloadedImage> images = new List<DownloadedImage>();
        internal List<DownloadedImage> Images
        {
            get { return images; }
            set { images = value; }
        }
        List<string> categories = new List<string>();
        public List<string> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        string fileName = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "wpDownloaderSettings.txt");

         string defaultFolder = "";
         int lastNumber = 0;

         public int LastNumber
         {
             get { return lastNumber; }
             set { lastNumber = value; }
         }

         public void CheckOrCreateFile()
         {
             if (!File.Exists(fileName))
             {
                 var f = File.Create(fileName);
                 (f as FileStream).Close();
             }
         }

         public void LoadSettings()
         {
             CheckOrCreateFile();
             images.Clear();
             // Read settings
             string[] s = File.ReadAllLines(fileName);
             foreach (string fileString in s)
             {
                 string[] split = fileString.Split(' ');
                 switch (split[0])
                 {
                     case "i":
                         images.Add(new DownloadedImage(split[2], split[1]));
                         break;
                     case "d":
                         defaultFolder = split[1];
                         break;
                     case "n":
                         lastNumber = Convert.ToInt32(split[1]);
                         break;
                     default:
                         break;
                 }
             }

         }

        public string GetDefaultFolder()
        {
            return defaultFolder;
        }

        public void SetDefaultFolder(string newDefaultFolder)
        {
            CheckOrCreateFile();
            defaultFolder = newDefaultFolder;

            WriteSettingsFile();

            LoadSettings();
        }

        public void SetLastNumber(int newCounter)
        {
            CheckOrCreateFile();
            lastNumber = newCounter;
            WriteSettingsFile();
            LoadSettings();
        }

        public bool IsImageDownloaded(string ImageURL)
        {
            foreach(DownloadedImage d in images)
            {
                if(d.WebURL == ImageURL)
                    return true;
            }
            return false;
        }

        public void AddImageDownloaded(DownloadedImage image)
        {
            images.Add(image);
        }

        public void WriteSettingsFile()
        {
            string[] fileStrings = new string[images.Count + 2];
            fileStrings[0] = "d " + defaultFolder;
            fileStrings[1] = "n " + lastNumber;
            for (int i = 2; i < 2 + images.Count; i++)
                fileStrings[i] = images[i - 2].getSettingsString();
            File.Delete(fileName);
            File.WriteAllLines(fileName, fileStrings);
        }

        // Currently unused, renames image at path to new name. PictureBox passed to dispose of the image data, could just be done before calling function.
        public bool RenameImage(string localPath, string newName, PictureBox pb)
        {
            try
            {
                
                File.Copy(localPath, localPath.Substring(0, localPath.LastIndexOf("\\") + 1) + newName + Path.GetExtension(localPath));
                foreach (DownloadedImage di in images)
                {
                    if (di.LocalPath == localPath)
                        di.LocalPath = localPath.Substring(0, localPath.LastIndexOf("\\") + 1) + newName + Path.GetExtension(localPath);
                }
                pb.Image.Dispose();
                pb.Image = Image.FromFile(localPath.Substring(0, localPath.LastIndexOf("\\") + 1) + newName + Path.GetExtension(localPath));
                File.Delete(localPath);
                WriteSettingsFile();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
