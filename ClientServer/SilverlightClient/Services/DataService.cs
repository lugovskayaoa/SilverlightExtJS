using System;
using System.Collections.Generic;
using System.Net;
using ClientServer.Common;
using Newtonsoft.Json;
using SilverlightClient.Helper;

namespace SilverlightClient.Services
{
    public static class DataService
    {
        private const string HostName = "http://localhost:52605";

        /// <summary>
        /// запрашивает данные с сервера и вызывает переданный обработчик
        /// </summary>
        /// <typeparam name="T">тип данных для обработки</typeparam>
        /// <param name="downloadHandler">обработчик загруженных данных</param> 
        /// <param name="url">адрес для получения данных</param>
        private static void GetData<T>(Action<T> downloadHandler, string url)
        {
            RestApiHelper.GetData(delegate(object sender, DownloadStringCompletedEventArgs args)
            {
                var error = args.Error;

                if (error != null)
                {
                    throw new Exception(error.Message, error.InnerException);
                }

                var data = JsonConvert.DeserializeObject<T>(args.Result);

                downloadHandler(data);

            }, url);
        }

        public static void GetManufacturers(Action<List<Manufacturer>> manufacturersDownloadHandler)
        {
            GetData(manufacturersDownloadHandler, HostName + "/api/Data/GetManufacturers");
        }

        public static void GetModels(Action<List<Model>> modelsDownloadHandler, int id)
        {
            GetData(modelsDownloadHandler, HostName + "/api/Data/GetModels?id=" + id);
        }
    }
}
