using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DICoffT0
    {
        public float[] bias { get; set; } = new float[6];
        public float[] scale { get; set; } = new float[6];
        public float[] posA { get; set; } = new float[9];
        public float[] posM { get; set; } = new float[9];
    }
}
