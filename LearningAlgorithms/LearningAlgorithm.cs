using System.Collections.Generic;
using NeuralNetwork.Performances;
using NeuralNetwork.Lists;

namespace NeuralNetwork.LearningAlgorithms
{
	public enum LearningAlthm
	{
		BACKPROPAGATION
	};

	public abstract class LearningAlgorithm
	{
		#region Properties
		protected double _erorrThreshold = 0.001;
		protected int _maxIteration = 10000;

		public NNetwork NN
		{
			set; get;
		}
		public List<List<double>> Inputs { get; set; }
		public List<List<double>> Outputs { get; set; }

		public Performance Per { set; get; }
		public int Iter { get; set; }

		public int MaxIteration
		{
			get { return _maxIteration; }
			set { _maxIteration = (value > 0) ? value : _maxIteration; }
		}

		public double ErrorThreshold
		{
			get { return _erorrThreshold; }
			set { _erorrThreshold = (value > 0) ? value : _erorrThreshold; }
		}
		public double Error
		{
			set; get;
		}
		#endregion

		#region Construction
		public LearningAlgorithm()
		{
			Iter = 0;
			Error = 1;
		}

		public LearningAlgorithm(NNetwork nn)
		{
			Error = 1;
			this.NN = nn;
		}

		public LearningAlgorithm(NNetwork nn, Perform per) :this(nn)
		{
			Per = Performance.Create(per);
		}
		#endregion

		#region Method
		/// <summary>
		/// To train the neuronal network on data.
		/// inputs[n] represents an input vector of the neural network and expected_outputs[n] the expected ouput for this vector.
		/// </summary>
		public abstract void Learn();

		/// <summary>
		/// 
		/// </summary>
		public abstract void LearnStep();


		public static LearningAlgorithm Create(LearningAlthm la)
		{
			switch (la)
			{
				default:
					return new BackPropagationLearningAlgorithm();
			}
		}
		#endregion
	}
}
