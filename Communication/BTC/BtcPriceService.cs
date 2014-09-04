using System;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;

namespace AntViewer.Communication.BTC
{
    public static class BtcPriceService
    {
        public static double GetBtcPrice()
        {
            var wc = new WebClient();
            var json = wc.DownloadString(new Uri(ConfigurationManager.AppSettings["Bitstamp.TickerApi.Url"] ?? "https://www.bitstamp.net/api/ticker/"));
            var ticker = JsonConvert.DeserializeAnonymousType(json, new {vwap = 0.00});

            return ticker != null ? ticker.vwap : 0.00;
        }
    }
}
