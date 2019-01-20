using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageViewer.Models
{
    public class Block
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
