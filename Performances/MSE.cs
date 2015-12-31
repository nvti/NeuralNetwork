using System;
using System.Collections.Generic;

namespace NeuralNetwork.Performances
{
	class MSE : Performance
	{
		public override double Error(List<double> output, List<double> target)
		{
			double err = 0;
			this.Err = new List<double>();

			for(int i = 0; i < output.Count; i++)
			{
				this.Err.Add(target[i] - output[i]);
				err += Err[i] * Err[i];
			}

			return Math.Sqrt(err);
		}
	}
}
