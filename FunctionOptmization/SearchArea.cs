namespace FunctionOptmization
{
    public readonly struct SearchArea
    {
        public Variable3 LowerLimit { get; init; }
        public Variable3 UpperLimit { get; init; }

        public void CapStep(ref Variable3 pos, ref Variable3 step) 
        {
            double x1Cap = Cap(pos.X1, LowerLimit.X1, UpperLimit.X1, step.X1) / step.X1;
            double x2Cap = Cap(pos.X2, LowerLimit.X2, UpperLimit.X2, step.X2) / step.X2;
            double x3Cap = Cap(pos.X3, LowerLimit.X3, UpperLimit.X3, step.X3) / step.X3;

            double k = Min(x1Cap, x2Cap, x3Cap);
            step = new Variable3(step.X1 * k, step.X2 * k, step.X3 * k);

            static double Cap(double x, double lowerLimit, double upperLimit, double step) 
            {
                if (x - step < lowerLimit) return x - lowerLimit;
                if (x - step > upperLimit) return x - upperLimit;
                return step;
            }

            static double Min(double a, double b, double c) 
            {
                if (a <= b && a <= c) return a;
                if (b <= a && b <= c) return b;
                return c;
            }
        }
    }
}
