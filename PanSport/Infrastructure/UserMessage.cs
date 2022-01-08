using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanSport.Infrastructure
{
    public class UserMessage
    {
        public UserMessage()
        {
            Seconds = 999;
            Message = "Write message here!";
            Classes = "info";
        }

        public UserMessage(int seconds, string message, string classes)
        {
            Seconds = seconds;
            Message = message;
            Classes = classes;
        }
        public int Seconds { get; set; }
        public string Message { get; set; }
        public string Classes { get; set; }
    }
}
