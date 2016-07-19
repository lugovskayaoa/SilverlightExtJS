using System.Collections.Generic;

namespace ClientServer.Common
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Model> ModelsList { get; set; } 
    }
}