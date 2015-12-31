using System.Collections.Generic;

namespace NeuralNetwork.Performances
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
