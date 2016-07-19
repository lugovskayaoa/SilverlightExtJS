using System;
using System.IO;
using ClientServer.Common;
using Newtonsoft.Json;

namespace ClientServer
{
    /// <summary>
    /// Реализует чтение данных из файлов json.
    /// </summary>
    public class Reader
    {
        #region Fields

        public JsonDb Data;

        #endregion

        #region Constructors

        public Reader(string path)
        {
            Data = null;

            Load(path);
        }

        #endregion

        /// <summary>
        /// Загружает файл и парсит его в свойство Data.
        /// </summary>
        /// <param name="path">Путь к файлу конфигурации.</param>
        private void Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            if (!IsValidFileName(Path.GetFileName(path)))
                throw new Exception("Неверное расширение файла конфигурации");

            var file = File.ReadAllText(path);

            Data = JsonConvert.DeserializeObject<JsonDb>(file);
        }

        /// <summary>
        /// Проверяет расширение файла конфигурации.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        /// <returns></returns>
        private bool IsValidFileName(string fileName)
        {
            if (!fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                return false;
            return true;
        }
    }
}