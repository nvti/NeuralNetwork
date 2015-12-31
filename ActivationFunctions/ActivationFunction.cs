namespace NeuralNetwork.ActivationFunctions
{
	public enum ActivationFunc
	{
		SIDMOID,
		TANH,
		ARCTAN,
		GAUSSIAN,
		SINC
	}

	/// <summary>
	/// Interface of every activation function
	/// </summary>
	public abstract class ActivationFunction
	{
		public abstract double Output(double x);
		public abstract double OutputPrime(double x);

		static public ActivationFunction Create(ActivationFunc ac)
		{
			switch (ac)
			{
				case ActivationFunc.ARCTAN:
					return new ArcTan();
				case ActivationFunc.GAUSSIAN:
					return new Gaussian();
				case ActivationFunc.TANH:
					return new TanhFunction();
				case ActivationFunc.SINC:
					return new Sinc();
				default:
					return new SigmoidFunction();
			}
		}
	}
}
