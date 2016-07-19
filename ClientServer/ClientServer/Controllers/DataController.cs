using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using ClientServer.Common;

namespace ClientServer.Controllers
{
    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
        private readonly Reader _reader;

        public DataController()
        {
            _reader = new Reader(CurrentPath);
        }

        private string CurrentPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) + "\\" + "Data.json";
            }
        }

        [HttpGet]
        [Route("GetManufacturers")]
        public List<Manufacturer> GetManufacturers()
        {
            return _reader.Data.ManufacturersList;
        }

        [HttpGet]
        public List<Model> GetModels(int id)
        {
            var result = new List<Model>();
            
            var manufacturer = _reader.Data.ManufacturersList.FirstOrDefault(x => x.Id == id);

            return manufacturer == null ? result : manufacturer.ModelsList;
        }
    }
}