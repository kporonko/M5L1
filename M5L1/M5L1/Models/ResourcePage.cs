using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Models
{
    public class ResourcePage : PageModel
    {
        [JsonProperty("data")]
        public Resource[] Data { get; set; }

        [JsonProperty("support")]
        public Support Support { get; set; }
    }
}
