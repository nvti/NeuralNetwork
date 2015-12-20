using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks.ActivationFunctions
{
	public enum ActivationFunc
	{
		SIDMOID
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
				default:
					return new SigmoidFunction();
			}
		}
	}
}
