using System;
using System.Collections.Generic;
using NeuralNetwork.LearningAlgorithms;
using NeuralNetwork.ActivationFunctions;

namespace NeuralNetwork.Lists
{
	public class NNetwork : ListElement<Layer>
	{
		#region Public properties

		/// <summary>
		/// Get number of Input
		/// </summary>
		public int N_Inputs
		{
			get
			{
				return this[0].Count;
			}
		}
		/// <summary>
		/// Get number of Output
		/// </summary>
		public int N_Outputs
		{
			get
			{
				return this[N_Layers - 1].Count;
			}
		}
		/// <summary>
		/// Get number of Layer
		/// </summary>
		public int N_Layers
		{
			get
			{
				return Count;
			}
		}
		/// <summary>
		/// Set Learning Algorithm of Neural Network
		/// </summary>
		public LearningAlgorithm La
		{
			set
			{
				la = value;
			}
			get
			{
				return la;
			}
		}
		/// <summary>
		/// Get list of output
		/// </summary>
		public List<double> Outputs
		{
			get
			{
				return GetOutput();
			}
		}

		public List<double> InputLayer
		{
			set
			{
				if(value.Count == N_Inputs)
				{
					for(int i = 0; i < N_Inputs; i++)
					{
						this[0][i].Value = value[i];
					}
				}
				Reset();
			}
		}
		#endregion

		#region Protected Properties
		/// <summary>
		/// Number of neuron on each layer
		/// </summary>
		protected List<int> N_Neuron { get; set; }
		/// <summary>
		/// 
		/// </summary>
		//public InputLayer _inputlayer;
		/// <summary>
		/// For random weight of Axon
		/// </summary>
		protected Random rand = new Random();
		/// <summary>
		/// Learning Algorithm of Neural Network
		/// </summary>
		protected LearningAlgorithm la;
		#endregion

		#region Construction
		/// <summary>
		/// Create Neural Network
		/// </summary>
		/// <param name="N_Neuron">List number of neuron on each layer</param>
		/// <param name="N_Layer">Number of layer</param>
		public NNetwork(List<int> N_Neuron, int N_Layer = 3)
		{
			la = new BackPropagationLearningAlgorithm(this);
			this.N_Neuron = N_Neuron;
			CreateNeuralNetwork(N_Layer, ActivationFunc.SIDMOID);
		}
		/// <summary>
		/// Create Neural Network with fixed number layer and learning algorithm
		/// </summary>
		/// <param name="N_Neuron">List number of neuron on each layer</param>
		/// <param name="N_Layer">Number of layer</param>
		/// <param name="la">Learning algorithm</param>
		public NNetwork(List<int> N_Neuron, int N_Layer, LearningAlgorithm la, ActivationFunc ac)
		{
			this.la = la;
			this.la.NN = this;
			this.N_Neuron = N_Neuron;
			CreateNeuralNetwork(N_Layer, ac);
		}
		#endregion

		#region Method
		/// <summary>
		/// Create layers of this neural network
		/// </summary>
		/// <param name="count">Number of layer</param>
		protected void CreateNeuralNetwork(int count, ActivationFunc ac)
		{
			Layer l = new Layer("0", N_Neuron[0]);
			this.Add(l);

			for (int i = 1; i < count; i++)
			{
				Layer layer = new Layer(i + "", ac, N_Neuron[i], this[i - 1], rand);
				this.Add(layer);
			}
		}

		/// <summary>
		/// Get list of output
		/// </summary>
		/// <returns>List of output</returns>
		List<double> GetOutput()
		{
			List<double> output = new List<double>();
			Layer layer = this[N_Layers - 1];		// output layer
			foreach(Neuron n in layer)
			{
				output.Add(n.Value);
			}

			return output;
		}

		/// <summary>
		/// Reset
		/// </summary>
		public void Reset()
		{
			foreach(var l in this)
			{
				l.Reset();
			}
		}
		/// <summary>
		/// To train the neuronal network on data.
		/// inputs[n] represents an input vector of the neural network and expected_outputs[n] the expected ouput for this vector.
		/// </summary>
		public void Learn()
		{
			la.Learn();
		}

		/// <summary>
		/// Display info
		/// </summary>
		/// <returns>Info</returns>
		protected override string MyInfo()
		{
			string s = "";
			s += "Number input: " + N_Inputs + "\n";
			s += "Number output: " + N_Outputs + "\n";
			s += "Number layer: " + N_Layers + "\n";

			return s;
		}
		#endregion
	}
}
