using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public interface IInputValue
	{
		double Value { get; set; }
		string Id { get; set; }
		string PrintInfo();
	}
}
