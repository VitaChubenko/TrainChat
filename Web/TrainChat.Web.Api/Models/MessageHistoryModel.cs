using System;
namespace TrainChat.Web.Api.Models
{
    public class MessageHistoryModel
    {
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime MessageDateTime { get; set; }
    }
}