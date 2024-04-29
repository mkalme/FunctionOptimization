namespace FunctionOptmization
{
    internal class Program
    {
        private static readonly double A = 1, B = 5, C = -4, D = 5, L = 5, K = -4;
        private static readonly Func<Variable3, Variable3> GRADIENT = input =>
        {
            double x1 = 4 * A * input.X1.Cube() - 2 * input.X1 / (input.X1.Square() + input.X2.Square() + 1) + L - B * input.X2.Square();
            double x2 = 2 * input.X2 * C * input.X3.Square() - 2 * input.X1 * B * input.X2 - 2 * input.X2 / (input.X1.Square() + input.X2.Square() + 1) - K;
            double x3 = -3 * input.X3.Square() * D + 2 * input.X2.Square() * C * input.X3 + Math.Exp(input.X3);

            return new Variable3(x1, x2, x3);
        };

        static void Main()
        {
            Gradient(
                startingPoint: new Variable3(0, 0, 0),
                stepSize: 1e-3,
                precision: 1e-6,
                maxIterations: 10000);

            Gradient(
                startingPoint: new Variable3(0.2, 0.2, 0.2),
                stepSize: 1e-3,
                precision: 1e-6,
                maxIterations: 10000);

            Gradient(
                startingPoint: new Variable3(-0.4, -0.4, -0.4),
                stepSize: 1e-3,
                precision: 1e-6,
                maxIterations: 10000000);

            Console.ReadLine();
        }

        private static void Gradient(Variable3 startingPoint, double stepSize, double precision, int maxIterations) 
        {
            GradientDescentArgs args = new()
            {
                GradientFunction = GRADIENT,
                LearningRate = 1e-3,
                Precision = precision,
                MaxIterations = maxIterations,
                Start = startingPoint,
                Step = new Variable3(stepSize, stepSize, stepSize)
            };

            Variable3 result = GradientDescent.Optimize(args, out int iterations);
            Console.WriteLine("Gradient method for optimization:");
            Console.WriteLine($"Starting point: {startingPoint}; step size: {stepSize:F3}; precision: {precision:F3}; max iterations: {maxIterations}".Replace(',', '.'));
            Console.WriteLine($"Result: {result} exited at {iterations} iterations");
            Console.WriteLine("=============================================");
        }
    }
}