using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AutoBackground
{
    class ScreenManager
    {

        public ScreenManager()
        {

        }

        public bool GenerateMultipleScreenBG(Image[] images, string imagePath)
        {
            int width = 0;
            foreach(Screen s in Screen.AllScreens)
                width += s.Bounds.Width;
            int height = 0;
            foreach(Screen s in Screen.AllScreens)
            {
                if(s.Bounds.Height > height)
                    height = s.Bounds.Height;
            }

            int screenCounter = 0;
            var bitmap = new Bitmap(width, height); 
            var canvas = Graphics.FromImage(bitmap);
            canvas.CompositingQuality = CompositingQuality.HighQuality;
            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            foreach (Image i in images)
            {
                canvas.DrawImage(i, Screen.AllScreens[screenCounter].Bounds.X, Screen.AllScreens[screenCounter].Bounds.Y, Screen.AllScreens[screenCounter].Bounds.Width, Screen.AllScreens[screenCounter].Bounds.Height);
                canvas.Save();
                try
                {
                    bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch { return false; }
                screenCounter++;
            }
            return true;
        }
    }
}
