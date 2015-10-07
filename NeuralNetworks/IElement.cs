using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public interface IElement
	{
		string Id { get; set; }

		void Reset();
	}
}
