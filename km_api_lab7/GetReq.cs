using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace km_api_lab7
{
    public class GetReq
    {
        HttpWebRequest _req;
        string _adr;
        public string Responce { get; set; }

        public GetReq(string address) {
            _adr = address;
        }

        public void Run() {
            _req = (HttpWebRequest)WebRequest.Create(_adr);
            _req.Method = "Get";

            try {
                HttpWebResponse response = (HttpWebResponse)_req.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) { Responce = new StreamReader(stream).ReadToEnd(); }
            }
            catch (Exception) { }
        }
    }
}
