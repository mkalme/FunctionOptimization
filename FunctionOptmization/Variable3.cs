namespace FunctionOptmization
{
    public readonly struct Variable3
    {
        public double X1 { get; init; }
        public double X2 { get; init; }
        public double X3 { get; init; }

        public Variable3(double x, double y, double z)
        {
            X1 = x;
            X2 = y;
            X3 = z;
        }

        public static Variable3 operator -(Variable3 a, Variable3 b)
        {
            return new Variable3(a.X1 - b.X1, a.X2 - b.X2, a.X3 - b.X3);
        }

        public static Variable3 operator *(Variable3 system, double n)
        {
            return new Variable3(system.X1 * n, system.X2 * n, system.X3 * n);
        }

        public double NormalizeSquare()
        {
            return X1 * X1 + X2 * X2 + X3 * X3;
        }

        public override string ToString()
        {
            return $"[X1 = {X1:F3}; X2 = {X2:F3}; X3 = {X3:F3}]".Replace(',', '.');
        }
    }
}
