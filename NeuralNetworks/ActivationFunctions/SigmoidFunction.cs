using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks.ActivationFunctions
{
	/// <summary>
	/// 
	/// </summary>
	public class SigmoidFunction : ActivationFunction
	{
		/// <summary>
		/// Beta param of Sigmoid Function
		/// </summary>
		double beta = 1;
		public double Beta
		{
			get
			{
				return beta;
			}
			set
			{
				beta = value > 0 ? value : 1;
			}
		}
		/// <summary>
		/// f(x) = 1 / (1 + e^(-beta*x))  beta > 0
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f(x)</returns>
		public override double Output(double x)
		{
			return 1 / (1 + Math.Exp(-beta * x));
		}
		/// <summary>
		/// f'(x) = beta * f(x) * (1 - f(x))
		/// </summary>
		/// <param name="x">x</param>
		/// <returns>f'(x)</returns>
		public override double OutputPrime(double x)
		{
			double y = Output(x);
			return beta * y * (1 - y);
		}
	}
}
