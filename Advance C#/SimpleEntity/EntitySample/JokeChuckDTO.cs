using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySample
{
    public class JokeChuckDTO
    {
        //         "categories": [],
        //  "created_at": "2020-01-05 13:42:25.352697",
        //  "icon_url": "https://api.chucknorris.io/img/avatar/chuck-norris.png",
        //  "id": "OERBrE0iT5a2uu5yTPtlmQ",
        //  "updated_at": "2020-01-05 13:42:25.352697",
        //  "url": "https://api.chucknorris.io/jokes/OERBrE0iT5a2uu5yTPtlmQ",
        //  "value": "Chuck Norris does not use a calendar, he decides which year it is."
        //}
        public string[] categories { get; set; }
        public string created_at { get; set; }
        public string icon_url { get; set; }
        public string id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }
}
