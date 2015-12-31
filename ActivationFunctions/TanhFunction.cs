using System;

namespace NeuralNetwork.ActivationFunctions
{
	public class TanhFunction : ActivationFunction
	{
		/// <summary>
		/// f(x) = tanh(x)
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f(x)</returns>
		public override double Output(double x)
		{
			return Math.Tanh(x);
		}

		/// <summary>
		/// f'(x) = 1 - f(x)^2
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f'(x)</returns>
		public override double OutputPrime(double x)
		{
			double o = Output(x);
			return (double)(1 - o * o);
		}
	}
}
