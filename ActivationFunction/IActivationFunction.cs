using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.ActivationFunction
{
	public interface IActivationFunction
	{
		double Output(double x);
		double OutputPrime(double x);
	}
}
