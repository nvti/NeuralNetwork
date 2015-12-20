using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks.Performances
{
	public enum Perform
	{
		MSE
	}

	public abstract class Performance
	{
		public List<double> Err { get; set; }

		public abstract double Error(List<double> output, List<double> target);

		public static Performance Create(Perform per)
		{
			switch (per)
			{
				default:
					return new MSE();
			}
		}
	}
}
