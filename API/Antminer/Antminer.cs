using System;

namespace AntViewer.API.Antminer
{
    public class Antminer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string SshUsername { get; set; }
        public string SshPassword { get; set; }
    }
}
