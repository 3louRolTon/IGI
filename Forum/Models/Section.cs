using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Topic> Topics { get; set; }
    }
}
