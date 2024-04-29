namespace FunctionOptmization
{
    public static class DoubleExtension
    {
        public static bool IsSameCardinality(double a, double b) 
        {
            return a >= 0 && b >= 0 || a <= 0 && b <= 0;
        }

        public static double Square(this double x)
        {
            return x * x;
        }

        public static double Cube(this double x)
        {
            return x * x * x;
        }
    }
}
