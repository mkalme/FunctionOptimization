//https://www.symbolab.com/solver/partial-derivative-calculator/%5Cfrac%7B%5Cpartial%7D%7B%5Cpartial%20x%7D%5Cleft(ax%5E%7B4%7D-bx%5Ccdot%20y%5E%7B2%7D%2Bcy%5E%7B2%7D%5Ccdot%20z%5E%7B2%7D-dz%5E%7B3%7D%2Blx-ky%2Be%5E%7Bz%7D-ln%5Cleft(x%5E%7B2%7D%2By%5E%7B2%7D%2B1%5Cright)%5Cright)?or=input
//https://www.symbolab.com/solver/gradient-calculator/gradient%201%5Ccdot%20x%5E%7B4%7D%20-%205%5Ccdot%20x%5Ccdot%20y%5E%7B2%7D%20-4%5Ccdot%20y%5E%7B2%7D%5Ccdot%20z%5E%7B2%7D%20-%205%5Ccdot%20z%5E%7B3%7D%20%2B%205%5Ccdot%20x%20%2B%204%5Ccdot%20y%20%2B%20exp%5Cleft(z%5Cright)%20-%20log%5Cleft(x%5E%7B2%7D%20%2B%20y%5E%7B2%7D%20%2B%201%5Cright)?or=input

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