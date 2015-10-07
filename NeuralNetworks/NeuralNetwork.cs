using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoNeuralNetwork.NeuralNetworks.LearningAlgorithms;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public class NeuralNetwork : List<Layer>, IElement
	{
		#region Public properties

		public string Id { get; set; }

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
		#endregion

		#region Protected Properties
		/// <summary>
		/// Number of neuron on each layer
		/// </summary>
		protected List<int> N_Neuron { get; set; }
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
		public NeuralNetwork(List<int> N_Neuron, int N_Layer = 3)
		{
			la = new BackPropagationLearningAlgorithm(this);
			this.N_Neuron = N_Neuron;
			CreateNeuralNetwork(N_Layer);
		}
		/// <summary>
		/// Create Neural Network with fixed number layer and learning algorithm
		/// </summary>
		/// <param name="N_Neuron">List number of neuron on each layer</param>
		/// <param name="N_Layer">Number of layer</param>
		/// <param name="la">Learning algorithm</param>
		public NeuralNetwork(List<int> N_Neuron, int N_Layer, LearningAlgorithm la)
		{
			this.la = la;
			this.N_Neuron = N_Neuron;
			CreateNeuralNetwork(N_Layer);
		}
		#endregion


		/// <summary>
		/// Create layers of this neural network
		/// </summary>
		/// <param name="count">Number of layer</param>
		protected void CreateNeuralNetwork(int count)
		{
			Layer l = new Layer("0", N_Neuron[0]);
			this.Add(l);
			for (int i = 1; i < count; i++)
			{
				Layer layer = new Layer(i + "", N_Neuron[i], this[i - 1], rand);
				this.Add(layer);
			}
		}

		/// <summary>
		/// Make Input of Neural Network
		/// </summary>
		/// <param name="input">List of input</param>
		public void CreateInput(List<double> input)
		{
			Reset();
			Layer input_layer = this[0];        // Input layer
			if (input.Count < input_layer.Count)
			{
				Console.WriteLine("Not enough number of input.");
				throw new Exception("");
			}
			int index = 0;
			foreach(Neuron n in input_layer)
			{
				n.InputValue = input[index++];
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
		/// <param name="inputs">Input matrix</param>
		/// <param name="expected_outputs">Expected Output matrix</param>
		public void Learn(List<List<double>> inputs, List<List<double>> expected_outputs)
		{
			la.Learn(inputs, expected_outputs);
		}
	}
}
