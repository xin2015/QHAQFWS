using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Basic.Calculators
{
    public class NormalizationCalculator
    {
        protected double SourceMax { get; set; }
        protected double SourceMin { get; set; }
        protected double TargetMax { get; set; }
        protected double TargetMin { get; set; }
        protected double Factor { get; set; }

        public NormalizationCalculator(double sourceMax, double sourceMin, double targetMax, double targetMin)
        {
            SourceMax = sourceMax;
            SourceMin = sourceMin;
            TargetMax = targetMax;
            TargetMin = targetMin;
            Factor = sourceMax == sourceMin ? 1 : (targetMax - targetMin) / (sourceMax - sourceMin);
        }

        public double[] Normalize(double[] source)
        {
            double[] target = new double[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = (source[i] - SourceMin) * Factor + TargetMin;
            }
            return target;
        }

        public double[] NonNormalize(double[] target)
        {
            double[] source = new double[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                source[i] = (target[i] - TargetMin) / Factor + SourceMin;
            }
            return source;
        }
    }
}
