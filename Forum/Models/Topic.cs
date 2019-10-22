using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic
    {
        public int ID { get; set; }

        public string TopicName { get; set; }
        public string TopicText { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }

        public virtual List<Message> Messages { get; set; }
    }
}
