using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks.ActivationFunction
{
	/// <summary>
	/// Interface of every activation function
	/// </summary>
	public interface IActivationFunction
	{
		double Output(double x);
		double OutputPrime(double x);
	}
}
