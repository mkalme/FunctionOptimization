namespace FunctionOptmization
{
    public static class GradientDescent
    {
        public static Variable3 Optimize(GradientDescentArgs args, out int iterations) 
        {
            iterations = 0;
            if (args.GradientFunction == null) return args.Start;
            Variable3 result = args.Start;

            double prevSlope = 0;

            while (true) 
            {
                Variable3 slope = args.GradientFunction(result);
                Variable3 step = new(
                    slope.X1 < 0 ? -args.Step.X1 : args.Step.X1,
                    slope.X2 < 0 ? -args.Step.X2 : args.Step.X2,
                    slope.X3 < 0 ? -args.Step.X3 : args.Step.X3);

                result -= step;

                //Console.WriteLine(iterations + " " + result.X1 + " " + result.X2 + " " + result.X3);

                double currentSlope = slope.X1 + slope.X2 + slope.X3;
                if (!DoubleExtension.IsSameCardinality(currentSlope, prevSlope)) break;
                else prevSlope = currentSlope;
                if (++iterations >= args.MaxIterations ||
                    (slope * args.LearningRate).NormalizeSquare() < args.Precision * args.Precision) break;
            }

            return result;
        }
    }
}
