using System;
using System.Collections.Generic;

namespace GETECO_Connect.Models
{
    
    public class Feeds
    {
        public List<FeedData> feeds { get; set; }
    }
    public class FeedData
    {
        public string id { get; set; }
        public string headline1 { get; set; }
        public string headline2 { get; set; }
        public string picture1 { get; set; }
        public string picture2 { get; set; }
        public string picture3 { get; set; }
        public string video { get; set; }
        public string serverVideo { get; set; }
        public string text { get; set; }
        public string rubrik { get; set; }
        public string timestamp { get; set; }


    }
}
