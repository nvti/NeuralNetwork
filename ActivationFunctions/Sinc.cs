using System;

namespace NeuralNetwork.ActivationFunctions
{
	public class Sinc : ActivationFunction
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public override double Output(double x)
		{
			if (x == 0)
				return 1;
			else
				return Math.Sin(x) / x;
		}

		public override double OutputPrime(double x)
		{
			if (x == 0)
				return 0;
			else
				return Math.Cos(x) / x - Math.Sin(x) / (x * x);
		}
	}
}
