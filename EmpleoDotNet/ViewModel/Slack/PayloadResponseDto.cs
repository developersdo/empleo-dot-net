using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpleoDotNet.ViewModel.Slack
{
    public class PayloadResponseDto
    {
        public string type { get; set; }
        public IEnumerable<Action> actions { get; set; }
        public string callback_id { get; set; }
        public Team team { get; set; }
        public Channel channel { get; set; }
        public User user { get; set; }
        public string action_ts { get; set; }
        public string message_ts { get; set; }
        public string attachment_id { get; set; }
        public string token { get; set; }
        public PayloadRequestDto original_message { get; set; }
        public string response_url { get; set; }
        public string trigger_id { get; set; }
    }

    public class Action
    {
        public string name { get; set; }
        public string value { get; set; }
        public string type { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
        public string domain { get; set; }
    }

    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}