using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Message
    {
        public int ID { get; set; }

        public string Text { get; set; }
        public User User { get; set; }

        public DateTime Time { get; set; }
    }
}
