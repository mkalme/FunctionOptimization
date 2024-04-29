namespace FunctionOptmization
{
    public readonly struct GradientDescentArgs
    {
        public Func<Variable3, Variable3>? GradientFunction { get; init; }
        public double LearningRate { get; init; }
        public double Precision { get; init; }
        public int MaxIterations { get; init; }
        public Variable3 Start { get; init; }
        public Variable3 Step { get; init; }

        public GradientDescentArgs(){}
    }
}
