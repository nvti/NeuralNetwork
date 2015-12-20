using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks.Performances
{
	class MSE : Performance
	{
		public override double Error(List<double> output, List<double> target)
		{
			double err = 0;
			this.Err = new List<double>();

			for(int i = 0; i < output.Count; i++)
			{
				this.Err.Add(output[i] - target[i]);
				err += Err[i] * Err[i];
			}

			return err;
		}
	}
}
