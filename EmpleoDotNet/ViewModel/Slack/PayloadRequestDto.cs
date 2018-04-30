using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.ViewModel.Slack
{
    public class PayloadRequestDto
    {
        public string text { get; set; }
        public bool replace_original { get; set; }
        public IEnumerable<Attachment> attachments { get; set; }
    }

    public class Attachment
    {
        public string fallback { get; set; }
        public string author_name { get; set; }
        public string title { get; set; }
        public string title_link { get; set; }
        public string text { get; set; }
        public string thumb_url { get; set; }
        public string callback_id { get; set; }
        public string color { get; set; }
        public string attachment_type { get; set; }
        public IEnumerable<AttachmentAction> actions { get; set; }
        public IEnumerable<AttachmentField> fields { get; set; }
    }

    public class AttachmentAction
    {
        public string name { get; set; }
        public string text { get; set; }
        public string style { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }

    public class AttachmentField
    {
        public string title { get; set; }
        public string value { get; set; }
        public bool @short { get; set; }
    }
}