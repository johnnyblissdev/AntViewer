using System;

namespace AntViewer.API
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
