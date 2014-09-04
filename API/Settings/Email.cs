namespace AntViewer.API.Settings
{
    public class Email
    {
        public string SmptServer { get; set; }
        public int SmptServerPort { get; set; }
        public bool UseSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ToAddress { get; set; }
        public string FromName { get; set; }
    }
}
