using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainChat.Web.Api.Models
{
    public class MessageHistoryModel
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
        public string Message { get; set; }
    }
}