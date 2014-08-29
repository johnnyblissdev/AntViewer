using System;
using System.IO;
using System.Linq;
using AntViewer.API.Antminer;
using D.Common;

namespace AntViewer.DataService.Antminer
{
    public static class AntminerService
    {
        public static Antminers GetAntminers()
        {
            var antminers = new Antminers();
            using (var sr = new StreamReader("antminers.config"))
            {
                var xml = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(xml))
                    antminers = Utilities.Deserialize<Antminers>(xml);

                foreach (var a in antminers.Antminer.Where(a => a.Id.Equals(Guid.Empty)))
                    a.Id = Guid.NewGuid();
            }

            return antminers;
        }

        public static API.Antminer.Antminer GetAntminerById(Guid id)
        {
            var antminers = GetAntminers();
            return antminers.Antminer.SingleOrDefault(x => x.Id.Equals(id));
        }

        public static void SaveAntminers(Antminers antminers)
        {
            using (var sr = new StreamWriter("antminers.config"))
            {
                sr.Write(Utilities.Serialize(antminers));
            }
        }
    }
}
