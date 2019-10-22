using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Section> Sections { get; set; }

        public IEnumerable<Topic> Topics { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
