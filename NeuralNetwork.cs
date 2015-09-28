using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoNeuralNetwork.LearningAlgorithms;

namespace DemoNeuralNetwork
{
	public class NeuralNetwork : List<Layer>
	{
		#region Public properties
		public int N_Inputs
		{
			get
			{
				return this[0].Count;
			}
		}
		public int N_Outputs
		{
			get
			{
				return this[N_Layer - 1].Count;
			}
		}
		#endregion

		#region Protected Properties
		protected int N_Layer { set; get; }
		protected List<int> N_Neuron { get; set; }
		protected Random rand = new Random();
		protected LearningAlgorithm la;
		#endregion

		public NeuralNetwork(List<int> N_Neuron)
		{
			N_Layer = 3;
			la = new BackPropagationLearningAlgorithm(this);
			this.N_Neuron = N_Neuron;
			CreateNeuralNetwork();
		}

		public NeuralNetwork(List<int> N_Neuron, int N_Layer)
		{
			this.N_Layer = N_Layer;
			la = new BackPropagationLearningAlgorithm(this);
			this.N_Neuron = N_Neuron;
			CreateNeuralNetwork();
		}

		protected void CreateNeuralNetwork()
		{
			Layer l = new Layer("0", N_Neuron[0]);
			this.Add(l);
			for (int i = 1; i < N_Layer; i++)
			{
				Layer layer = new Layer(i + "", N_Neuron[i], this[i - 1], rand);
				this.Add(layer);
			}
		}

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

		public List<double> GetOutput()
		{
			List<double> output = new List<double>();
			Layer layer = this[N_Layer - 1];		// output layer
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

		public void Learn(List<List<double>> inputs, List<List<double>> expected_outputs)
		{
			la.Learn(inputs, expected_outputs);
		}
	}
}
