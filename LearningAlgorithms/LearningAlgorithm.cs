using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.LearningAlgorithms
{
	public abstract class LearningAlgorithm
	{
		protected NeuralNetwork nn;
		protected double _erorrTreshold = 0.0001;
		protected double _error = -1;
		protected int _maxIteration = 1000;

		public List<List<double>> Inputs { get; set; }
		public List<List<double>> Outputs { get; set; }

		public int MaxIteration
		{
			get { return _maxIteration; }
			set { _maxIteration = (value > 0) ? value : _maxIteration; }
		}
		public double ErrorTreshold
		{
			get { return _erorrTreshold; }
			set { _erorrTreshold = (value > 0) ? value : _erorrTreshold; }
		}
		public double Error
		{
			get { return _error; }
		}

		public LearningAlgorithm(NeuralNetwork nn)
		{
			this.nn = nn;
		}

		public virtual void Learn(List<List<double>> inputs, List<List<double>> expected_outputs)
		{
			if (inputs.Count < 1)
				throw new Exception("LearningAlgorithme : no input data");
			if (expected_outputs.Count < 1)
				throw new Exception("LearningAlgorithme : no output data");
			if (inputs.Count != expected_outputs.Count)
				throw new Exception("LearningAlgorithme : inputs and outputs size does not match");
			Inputs = inputs;
			Outputs = expected_outputs;
		}
	}
}
