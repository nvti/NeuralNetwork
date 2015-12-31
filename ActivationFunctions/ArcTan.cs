using System;

namespace NeuralNetwork.ActivationFunctions
{
	public class ArcTan : ActivationFunction
	{
		/// <summary>
		/// f(x) = arctan(x)
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f(x)</returns>
		public override double Output(double x)
		{
			return Math.Atan(x);
		}

		/// <summary>
		/// f'(x) = 1 / (1 + x^2)
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f'(x)</returns>
		public override double OutputPrime(double x)
		{
			return (double)1 / (1 + x * x);
		}
	}
}
