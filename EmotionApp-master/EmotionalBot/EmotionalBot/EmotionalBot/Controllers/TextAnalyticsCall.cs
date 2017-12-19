using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmotionalBot.Controllers
{
    public class TextAnalyticsCall
    {
    }

    public class BatchInput
    {
        internal List<DocumentInput> Documents;

        public List<DocumentInput> documents { get; set; }
    }
    public class DocumentInput
    {
        internal int Id;

        public double id { get; set; }
        public string Text { get; internal set; }
        public string text { get; set; }
    }

    // Classes to store the result from the sentiment analysis
    public class BatchResult
    {
        public List<DocumentResult> documents { get; set; }
    }
    public class DocumentResult
    {
        public double score { get; set; }
        public string id { get; set; }
        public int Score { get; internal set; }
    }
}