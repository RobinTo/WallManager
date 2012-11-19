using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace AutoBackground
{
    class WebpageImageRetriever
    {
        string pageAddress = "http://www.reddit.com/r/";
        string redditSearchString = "<a class=\"title \" href=\"";
        string imgurSearchString = " <div class=\"item view album-view-image-link\">";
        List<int> progress = new List<int>();

        public bool DownloadFile(string remoteFilename, string localFilename)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(new Uri(remoteFilename), localFilename);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> getImageURLs(string subReddits)
        {
            List<string> images = new List<string>();

            string htmlSource = getHTML(pageAddress + subReddits);

            int position = 1;

            while (position > 0 && position < htmlSource.Length)
            {
                position = htmlSource.IndexOf(redditSearchString, position+1);
                if(position < htmlSource.Length)
                    images.Add(htmlSource.Substring(position + redditSearchString.Length, htmlSource.IndexOf("\"", position + redditSearchString.Length) -position - redditSearchString.Length));
            }

            return images;
        }

        public List<string> getImageURLsImgurAlbum(string album)
        {
            List<string> images = new List<string>();
            
            string htmlSource = getHTML(album + "/layout/blog");

            string test = "<div class=\"item view album-view-image-link\">\n            <a href=\"";
            int position = 1;

            while (position > 0 && position < htmlSource.Length)
            {
                position = htmlSource.IndexOf(test, position + 1);
                if (position < htmlSource.Length)
                    images.Add(htmlSource.Substring(position + test.Length, htmlSource.IndexOf("\"", position + test.Length) - position - test.Length));
            }

            return images;
        }

        public string getHTML(string _URL)
        {
            string _PageContent = null;

            try
            {
                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);

                _HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";

                _HttpWebRequest.Referer = "http://www.google.com/";

                _HttpWebRequest.Timeout = 10000;

                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();
                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();
                System.IO.StreamReader _StreamReader = new System.IO.StreamReader(_WebStream);
                _PageContent = _StreamReader.ReadToEnd();
                _StreamReader.Close();
                _WebStream.Close();
                _WebResponse.Close();
            }
            catch (Exception _Exception)
            {
                return "Exception caught in process: " + _Exception.ToString();
            }
            return _PageContent;
        }

    }
}
