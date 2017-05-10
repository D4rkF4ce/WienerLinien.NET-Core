using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiGHTECHNiX.WienerLinienAPI.RealtimeData
{
    public interface IParameter
    {
        string GetStringFromParameters(string url, string apiKey);
    }
}