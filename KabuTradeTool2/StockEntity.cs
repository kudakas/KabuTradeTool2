using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KabuTradeTool2
{
    class StockEntity
    {
        public string Code { get;set;}
        public string Name { get; set; }
        public string Market { get; set; }
        public string Category { get; set; }
        public string Opening { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Closing { get; set; }
        public string Volume { get; set; }
        public string Turnover { get; set; }
    }
}
