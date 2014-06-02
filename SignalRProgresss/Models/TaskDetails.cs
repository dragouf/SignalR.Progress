using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRProgresss.ViewModels
{
    public class TaskDetails
    {
        [JsonProperty("taskId")]
        public string Id { get; set; }
        [JsonProperty("taskName")]
        public string Name { get; set; }
        [JsonProperty("taskPercent")]
        public int Percent { get; set; }
        [JsonProperty("barCss")]
        public string BarCss { get; set; }
        [JsonProperty("taskPage")]
        public string TaskPage { get; set; }
        [JsonIgnore]
        public CancellationTokenSource CancelToken { get; set; }
    }
}
