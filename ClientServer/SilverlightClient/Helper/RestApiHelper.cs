using System;
using System.Net;

namespace SilverlightClient.Helper
{
    public static class RestApiHelper
    {
        /// <summary>
        /// получает данные с сервера
        /// </summary>
        /// <param name="downloadDataCompleted"></param>
        /// <param name="url"></param>
        public static void GetData(DownloadStringCompletedEventHandler downloadDataCompleted, string url)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += downloadDataCompleted;
            client.Headers["Accept"] = "application/json";
            client.DownloadStringAsync(new Uri(url));
        }
    }
}
