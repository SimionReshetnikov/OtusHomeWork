using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork10new
{
    internal class ImageDownloader
    {

        public event Action? ImageStarted;
        public event Action? ImageCompleted;
        public void Download(string fileName, string remoteUri)
        {
            using (var myWebClient = new WebClient())
            {
                ImageStarted();
                myWebClient.DownloadFile(fileName, remoteUri);
                ImageCompleted();
            }
        }
    }
}
