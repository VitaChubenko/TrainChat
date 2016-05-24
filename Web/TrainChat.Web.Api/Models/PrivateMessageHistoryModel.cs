using System.Collections.Generic;

namespace TrainChat.Web.Api.Models
{
    public class PrivateMessageHistoryModel
    {
        public string UserName1 { get; set; }
        public string UserName2 { get; set; }
        public List<MessageHistoryModel> PrivateMessages { get; set; }
    }
}