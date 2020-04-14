using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Models
{
    public static class VectorHelper
    {
        public static Vector Sum(IEnumerable<Vector> collection)
        {
            return new Vector(collection.Sum(o => o.X), collection.Sum(o => o.Y));
        }

        public static Vector Average(IEnumerable<Vector> collection)
        {
            return new Vector(collection.Average(o => o.X), collection.Average(o => o.Y));
        }
    }
}
