using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCognitiveService.Utilities
{
    public class Request
    {
        public string SubscriptionKey { get; set; }
        public string UriBase { get; set; }
        public string RequestParameters { get; set; }
        public string ImageFilePath { get; set; }
        public string ContentType { get; set; }
    }
}
