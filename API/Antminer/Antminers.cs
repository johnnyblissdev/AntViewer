using System.Collections.Generic;

namespace AntViewer.API.Antminer
{
    public class Antminers
    {
        public List<Antminer> Antminer { get; set; }

        public Antminers()
        {
            Antminer = new List<Antminer>();
        }
    }
}
