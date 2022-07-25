using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Models
{
    public class PageModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

    }
}
