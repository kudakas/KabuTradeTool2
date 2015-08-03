using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KabuTradeTool2
{
    class StocksRepository
    {
        public string[] GetCSVData()
        {
            var client = new WebClient();
            byte[] buffer = client.DownloadData("http://k-db.com/?p=all&download=csv");
            string str = Encoding.Default.GetString(buffer);
            return str.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
