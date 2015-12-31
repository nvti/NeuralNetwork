using System;

namespace NeuralNetwork.ActivationFunctions
{
	public class Gaussian : ActivationFunction
	{
		/// <summary>
		/// f(x) = e^(-x^2)
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f(x)</returns>
		public override double Output(double x)
		{
			return Math.Exp(-x * x);
		}
		/// <summary>
		/// f'(x) = -2x*e^(-x^2)
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f'(x)</returns>
		public override double OutputPrime(double x)
		{
			return -2 * x * Output(x);
		}
	}
}
