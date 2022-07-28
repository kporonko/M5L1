using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Models
{
    internal class ReqresSingleUser
    {
        [JsonProperty("data")]
        public UserModel Data { get; set; }

        [JsonProperty("support")]
        public Support Support { get; set; }
    }
}
