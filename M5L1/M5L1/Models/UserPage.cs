using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Models
{
    public class UserPage : PageModel
    {
        [JsonProperty("data")]
        public UserModel[] Data { get; set; }
    }
}
