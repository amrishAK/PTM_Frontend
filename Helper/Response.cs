using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM_Frontend.Helper
{
    public class GetTemplateTD
    {
        public string DateTimeStamp { get; set; }
        public Double Data { get; set; }
    }

    public class TrafficDensityRequest
    {
        public Double Density { get; set; }
        public string Label { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string SignalId { get; set; }
        public string SignalLocation { get; set; }
    }
}
