using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageViewer.Models
{
    public class PageView
    {
        public PageView()
        {
            Blocks = new List<Block>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public List<Block> Blocks { get; set; }
    }
}
