using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HiGHTECHNiX.WienerLinienAPI
{
    public class WienerLinienContext
    {
        public string ApiKey { get; }
        public HttpClient Client { get; }

        public WienerLinienContext(string apiKey)
        {
            ApiKey = apiKey;
            Client = new HttpClient();
        }

    }
}
