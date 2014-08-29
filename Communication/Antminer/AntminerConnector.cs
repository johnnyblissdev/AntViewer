using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace AntViewer.Communication.Antminer
{
    public static class AntminerConnector
    {
        public static IDictionary<string, object> GetStats(IPAddress ip)
        {
            var client = new TcpClient();
            client.Connect(ip, 4028);

            using (var os = client.GetStream())
            {
                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new {command = "stats"}));
                os.Write(data, 0, data.Length);
                os.Flush();

                var buffer = new byte[1024];
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = os.Read(buffer, 0, buffer.Length)) > 0)
                        ms.Write(buffer, 0, read);

                    var msg = Encoding.ASCII.GetString(ms.ToArray());
                    if (string.IsNullOrEmpty(msg))
                        return new Dictionary<string, object>();

                    var ana = new { STATS = new List<IDictionary<string, object>>() };
                    var response = JsonConvert.DeserializeAnonymousType(msg.Substring(0, msg.Length - 2), ana);

                    return response.STATS[0];
                }
            }
        }

        public static IDictionary<string, object> GetSummary(IPAddress ip)
        {
            var client = new TcpClient();
            client.Connect(ip, 4028);

            using (var os = client.GetStream())
            {
                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new { command = "summary" }));
                os.Write(data, 0, data.Length);
                os.Flush();

                var buffer = new byte[1024];
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = os.Read(buffer, 0, buffer.Length)) > 0)
                        ms.Write(buffer, 0, read);

                    var msg = Encoding.ASCII.GetString(ms.ToArray());
                    if (string.IsNullOrEmpty(msg))
                        return new Dictionary<string, object>();

                    var ana = new { SUMMARY = new List<IDictionary<string, object>>() };
                    var response = JsonConvert.DeserializeAnonymousType(msg.Substring(0, msg.Length - 2), ana);

                    return response.SUMMARY[0];
                }
            }
        }

        public static List<IDictionary<string, object>> GetPools(IPAddress ip)
        {
            var client = new TcpClient();
            client.Connect(ip, 4028);

            using (var os = client.GetStream())
            {
                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new { command = "pools" }));
                os.Write(data, 0, data.Length);
                os.Flush();

                var buffer = new byte[1024];
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = os.Read(buffer, 0, buffer.Length)) > 0)
                        ms.Write(buffer, 0, read);

                    var msg = Encoding.ASCII.GetString(ms.ToArray());
                    if(string.IsNullOrEmpty(msg))
                        return new List<IDictionary<string, object>>();

                    var ana = new { POOLS = new List<IDictionary<string, object>>() };
                    var response = JsonConvert.DeserializeAnonymousType(msg.Substring(0, msg.Length - 2), ana);

                    return response.POOLS;
                }
            }
        }

        public static bool Exists(IPAddress ip)
        {
            var ping = new Ping();
            var reply = ping.Send(ip);

            if (reply == null) return false;

            if (!reply.Status.Equals(IPStatus.Success))
                return false;

            var client = new TcpClient();
            try
            {
                var result = client.BeginConnect(ip, 4028, null, null);

                if (!result.AsyncWaitHandle.WaitOne(new TimeSpan(0, 0, 0, 0, 300)))
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            using (var os = client.GetStream())
            {
                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new { command = "version" }));
                os.Write(data, 0, data.Length);
                os.Flush();

                var buffer = new byte[1024];
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = os.Read(buffer, 0, buffer.Length)) > 0)
                        ms.Write(buffer, 0, read);

                    var msg = Encoding.ASCII.GetString(ms.ToArray());
                    if (string.IsNullOrEmpty(msg))
                        return false;

                    var ana = new {STATUS = new List<IDictionary<string, object>>()};
                    var response = JsonConvert.DeserializeAnonymousType(msg.Substring(0, msg.Length - 2), ana);
                    return response.STATUS[0]["STATUS"].Equals("S");
                }
            }
        }

        public static void Restart(IPAddress ip)
        {
            var client = new TcpClient();
            client.Connect(ip, 4028);

            using (var os = client.GetStream())
            {
                var data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new { command = "restart" }));
                os.Write(data, 0, data.Length);
                os.Flush();

                var buffer = new byte[1024];
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = os.Read(buffer, 0, buffer.Length)) > 0)
                        ms.Write(buffer, 0, read);

                    var msg = Encoding.ASCII.GetString(ms.ToArray());
                    if(string.IsNullOrEmpty(msg))
                        throw new Exception("Unable to restart miner. No response.");

                    var ana = new {STATUS = new List<IDictionary<string, object>>()};
                    var response = JsonConvert.DeserializeAnonymousType(msg.Substring(0, msg.Length - 2), ana);
                    if(response.STATUS[0]["STATUS"].Equals("E"))
                        throw new Exception("Unable to restart miner, privledged access denied.");
                }
            }
        }
    }
}
