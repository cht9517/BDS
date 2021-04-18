using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConstV
    {
        private static readonly Lazy<ConstV> lazy =
          new Lazy<ConstV>(() => new ConstV());
        public static ConstV Instance { get { return lazy.Value; } }
        //private ConstV() { }

        public double BT_local { get; set; } = 0.491;
        public double BAD_local { get; set; } = 45.5;//当地磁倾角

        public int Tool_Addr = 0x0F;
    }
}
