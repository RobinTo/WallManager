using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;


namespace AutoBackground
{
    public partial class Form1 : Form
    {
        WallpaperChanger wp = new WallpaperChanger();
        WebpageImageRetriever ir = new WebpageImageRetriever();
        SettingsManager sm = new SettingsManager();
        List<string> images;


        int counter = 0;
        int currentImage = 0;
        int timeSinceStart = 0;

        string subReddits = "wallpaper+wallpapers";

        public int CurrentImage
        {
            get { return currentImage; }
            set {
                if (sm.Images.Count > 0)
                {
                    if (value >= sm.Images.Count)
                        value -= sm.Images.Count;
                    else if (value < 0)
                        value += sm.Images.Count;
                    currentImage = value;
                }
            }
        }

        int oldHeight;
        int oldWidth;
        int pictureBoxHeight;
        int pictureBoxWidth;

        bool minimize = true;

        List<string> screens = new List<string>();
        int selectedScreen = 0;
        int[] screenIntImages = new int[Screen.AllScreens.Count()];
        Image[] screenImages = new Image[Screen.AllScreens.Count()];

        public Form1()
        {
            InitializeComponent();
            Text = "WallManager";
            ShowInTaskbar = true;
            sm.LoadSettings();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            openFileDialog1.InitialDirectory = sm.GetDefaultFolder();
            labelFolder.Text = sm.GetDefaultFolder();
            counter = sm.LastNumber;
            SizeChanged += new EventHandler(Form1_SizeChanged);
            oldHeight = Height;
            oldWidth = Width;
            pictureBoxHeight = pictureBox1.Height;
            pictureBoxWidth = pictureBox1.Width;

            FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            notifyIcon1.MouseClick += new MouseEventHandler(notifyIcon1_MouseClick);

            if(sm.Images.Count > 0)
                ChangeImage(0);

            for (int i = 0; i < Screen.AllScreens.Count(); i++)
                screens.Add(Screen.AllScreens[i].DeviceName);
            for (int i = 0; i < screenIntImages.Count(); i++)
                screenIntImages[i] = 0;
            if (sm.Images.Count() > 0)
            {
                for (int i = 0; i < screenImages.Count(); i++)
                    screenImages[i] = Image.FromFile(sm.Images[0].LocalPath);
            }
            comboBoxScreens.DataSource = screens;

            textBoxTimer.GotFocus += new EventHandler(textBoxTimer_GotFocus);

            pictureBox1.MouseClick += new MouseEventHandler(Form1_MouseClick);
            pictureBox1.MouseHover += new EventHandler(pictureBox1_MouseHover);
            pictureBox1.PreviewKeyDown += new PreviewKeyDownEventHandler(pictureBox1_PreviewKeyDown);

            KeyPreview = true;
            KeyUp += new KeyEventHandler(Form1_KeyUp);

            MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox1.Focus();
        }

        void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            pictureBox1.Focus();
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down)
                ChangeImage(currentImage - 1);
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
                ChangeImage(currentImage + 1);
        }

        void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ChangeImage(currentImage + 1);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ChangeImage(currentImage - 1);
            }
        }

        // Change pictureBox image on mousescroll.
        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            ChangeImage(currentImage + (int)Math.Floor((double)(e.Delta / 120.0)));
        }

        // Clear the timer textbox when it gets focus.
        void textBoxTimer_GotFocus(object sender, EventArgs e)
        {
            textBoxTimer.Text = "";
        }

        // Show Menu when left click on NotifyIcon.
        void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(new System.Drawing.Point(MousePosition.X, MousePosition.Y));
        }

        // Minimizes if closing except on exit click from notifyIcon menu.
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sm.WriteSettingsFile();
            if (minimize)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // Resizes picturebox when form is resized.
        void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
            else
            {
                if (Height < 640)
                    Height = 640;
                if (Width < 970)
                    Width = 970;
                pictureBox1.Height += Height - oldHeight;
                pictureBox1.Width += Width - oldWidth;
                oldHeight = Height;
                oldWidth = Width;
                pictureBoxHeight = pictureBox1.Height;
                pictureBoxWidth = pictureBox1.Width;
                if (pictureBox1.Width < 825)
                    pictureBox1.Width = 825;
                if (pictureBox1.Height < 550)
                    pictureBox1.Height = 550;
            }
        }

        // Changes picturebox image, int is stored in CurrentImage.
        private void ChangeImage(int i)
        {
            CurrentImage = i; // Value is clamped in setter.
            if (sm.Images.Count > 0)
            {
                Image image = Image.FromFile(sm.Images[CurrentImage].LocalPath);
                if (image.Height < pictureBoxHeight)
                    pictureBox1.Height = image.Height;
                else
                    pictureBox1.Height = pictureBoxHeight;
                if (image.Width < pictureBoxWidth)
                    pictureBox1.Width = image.Width;
                else
                    pictureBox1.Width = pictureBoxWidth;

                if(pictureBox1.Image != null)
                    pictureBox1.Image.Dispose(); // Release old image.
                pictureBox1.Image = image;
                labelImageInfo.Text = image.Width + "x" + image.Height + "\n" + Path.GetFileName(sm.Images[CurrentImage].LocalPath);
                labelNumber.Text = CurrentImage + 1 + " of " + sm.Images.Count;
            }
        }

        // Generates a random Background for all available screens.
        public void GenerateRandomMultipleScreenBG()
        {
            Random r = new Random();
            Image[] images = new Image[Screen.AllScreens.Count()];
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                images[i] = Image.FromFile(sm.Images[r.Next(0, sm.Images.Count)].LocalPath);
            }
            ScreenManager screenManager = new ScreenManager();
            if (screenManager.GenerateMultipleScreenBG(images, sm.GetDefaultFolder() + "\\multiImage.jpg"))
                wp.SetWallpaper(sm.GetDefaultFolder() + "\\multiImage.jpg");
            else
                InfoLabel.Text = "Shit bro!";
        }

        // Sets the current wallpaper on all monitors.
        private void buttonSetWallpaper_Click(object sender, EventArgs e)
        {
            if (sm.Images.Count > 0)
            {
                screenIntImages[selectedScreen] = CurrentImage;
                screenImages[selectedScreen] = Image.FromFile(sm.Images[screenIntImages[selectedScreen]].LocalPath);

                ScreenManager screenManager = new ScreenManager();
                if (screenManager.GenerateMultipleScreenBG(screenImages, sm.GetDefaultFolder() + "\\multiImage.jpg"))
                    wp.SetWallpaper(sm.GetDefaultFolder() + "\\multiImage.jpg");
                else
                    InfoLabel.Text = "Shit bro!";
            }
            else
                InfoLabel.Text = "No images!";
        }

        // Button calls DownloadImages().
        private void buttonDownloadWallpapers_Click(object sender, EventArgs e)
        {
            DownloadInputBox testDialog = new DownloadInputBox();
            if (sm.GetDefaultFolder() == "")
            {
                InfoLabel.Text = "Select Folder!";
            }
            else
            {
                testDialog.Text = "Enter subreddit names. www.reddit.com/r/THISTEXT";
                string subReddits;
                testDialog.SetDefaultTextBoxText("wallpaper+wallpapers");
                List<string> subRedditSuggestions = new List<string>();
                subRedditSuggestions.Add("wallpaper+wallpapers");
                subRedditSuggestions.Add("MinimalWallpaper");
                subRedditSuggestions.Add("BigWallpapers");
                subRedditSuggestions.Add("wallpaper");
                subRedditSuggestions.Add("wallpapers");
                testDialog.SetComboBoxDataSource(subRedditSuggestions);
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK && !testDialog.Input.Contains(' '))
                {
                    subReddits = testDialog.Input;
                }
                else
                {
                    subReddits = "wallpaper+wallpapers";
                }

                DownloadImages(subReddits);
            }
        }

        public void SetInfoLabelText(string s)
        {
            InfoLabel.Text = s;
        }

        bool downloading = false;
        // Downloads and saves all new images.
        public void DownloadImages(string subReddits)
        {
            if (!downloading)
            {
                InfoLabel.Text = "Getting new images...";
                downloading = true;
                var process = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        List<string> posts;
                        if (subReddits.Contains("imgur"))
                            posts = ir.getImageURLsImgurAlbum(subReddits);
                        else
                            posts = ir.getImageURLs(subReddits); ;
                        images = new List<string>();
                        foreach (string s in posts)
                        {
                            if (!sm.IsImageDownloaded(s))
                            {
                                if ((s.Contains(".jpg") || s.Contains(".jpeg")))
                                {
                                    images.Add(s);
                                }
                                else if (s.Contains(".png"))
                                {
                                    images.Add(s);
                                }
                            }
                        }
                        int counter = 0;
                        InfoLabel.Invoke(new Action(delegate() { InfoLabel.Text = "Starting downloads..."; }));
                        foreach (string s in images)
                        {
                            if ((s.Contains(".jpg") || s.Contains(".jpeg")))
                            {
                                if (TryToDownload(s, ".jpg"))
                                    counter++;
                            }
                            else if (s.Contains(".png"))
                            {
                                if (TryToDownload(s, ".png"))
                                    counter++;
                            }
                            if (currentImage == 0 && counter > 0)
                                pictureBox1.Invoke(new Action(delegate() { pictureBox1.Image = Image.FromFile(sm.Images[0].LocalPath); }));

                            InfoLabel.Invoke(new Action(delegate() { InfoLabel.Text = "Completed\n" + counter + " of " + images.Count; }));
                        }
                    }
                    finally
                    {
                        sm.SetLastNumber(counter);
                        InfoLabel.Invoke(new Action(delegate() { InfoLabel.Text = "Done!"; }));
                        downloading = false;
                    }
                });
            }
        }

        public bool TryToDownload(string s, string extension)
        {
            int tries = 0;
            while (tries < 2)
            {
                if (!ir.DownloadFile(s, sm.GetDefaultFolder() + "\\" + counter + extension))
                    tries++;
                else
                {
                    sm.AddImageDownloaded(new DownloadedImage(sm.GetDefaultFolder() + "\\" + counter + extension, s));
                    counter++;
                    tries = 2;
                    return true;
                }
            }
            return false;
        }

        // Prompts a change of default folder.
        private void buttonChangeFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK && !folderBrowserDialog1.SelectedPath.Contains(' '))
            {
                sm.SetDefaultFolder(folderBrowserDialog1.SelectedPath);
                openFileDialog1.InitialDirectory = sm.GetDefaultFolder();
            }
            else if (folderBrowserDialog1.SelectedPath.Contains(' '))
            {
                InfoLabel.Text = "Sorry, no spaces\nin the path, please.";
            }
            labelFolder.Text = sm.GetDefaultFolder();
        }

        // On doubleClick on notifyIcon, shows the form.
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        // Timer1 times random wallpapers.
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBoxDownloadOnRandom.Checked)
                DownloadImages(subReddits);
            GenerateRandomMultipleScreenBG();
            timeSinceStart = 0;
        }

        // Changes timer1's tick interval when text is changed.
        private void textBoxTimer_TextChanged(object sender, EventArgs e)
        {
            int testInt;
            try
            {
                if (textBoxTimer.Text.Length > 0)
                    testInt = Convert.ToInt32(textBoxTimer.Text) * 60000;
            }
            catch
            {
                textBoxTimer.Text = "";
            }
        }

        // Starts and stops Timer1.
        private void buttonStartTimer_Click(object sender, EventArgs e)
        {
            if (sm.Images.Count > 0)
            {
                try
                {
                    timer1.Interval = Convert.ToInt32(textBoxTimer.Text) * 60000;
                }
                catch
                {
                    timer1.Interval = 60000;
                    textBoxTimer.Text = "1";
                }
                if (!timer1.Enabled)
                {
                    timer1.Start();
                    timeSinceStart = 0;
                    timer2.Start();
                    buttonStartTimer.Text = "Stop Timer";
                }
                else
                {
                    timer1.Stop();
                    timer2.Stop();
                    buttonStartTimer.Text = "Start Timer";
                }
            }
            else
                InfoLabel.Text = "No images!";
        }


        // Timer2 is used to show the label timing when next random wallpaper change will occur.
        private void timer2_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = "Time: " + ((timer1.Interval - timeSinceStart) /1000).ToString() + " sec";
            timeSinceStart += timer2.Interval;
        }

        // When exit is selected in the notifyIcon menu.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimize = false;
            Dispose();
            Close();
        }

        // When label is clicked, clear text.
        private void labelTimer_Click(object sender, EventArgs e)
        {
            this.Text = "";
        }

        // Button to generate random multiscreen background.
        private void buttonRandomMulti_Click(object sender, EventArgs e)
        {
            if(sm.Images.Count > 0)
                GenerateRandomMultipleScreenBG();
            else
                InfoLabel.Text = "No images!";
        }

        // Change which screen is shown.
        private void comboBoxScreens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sm.Images.Count() > 0)
            {
                selectedScreen = comboBoxScreens.SelectedIndex;
                screenImages[selectedScreen] = Image.FromFile(sm.Images[screenIntImages[selectedScreen]].LocalPath);
                ChangeImage(screenIntImages[selectedScreen]);
            }

            ProcessTabKey(true);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ConfirmBox cb = new ConfirmBox("Delete this image?");
            DialogResult dialogResult = cb.ShowDialog();
            if(dialogResult == DialogResult.Yes)
            {
                pictureBox1.Image.Dispose();
                File.Delete(sm.Images[currentImage].LocalPath);
                sm.Images.RemoveAt(currentImage);
                ChangeImage(currentImage);
                sm.WriteSettingsFile();
            }
        }

    }
}
