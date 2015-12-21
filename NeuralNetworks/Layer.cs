using DemoNeuralNetwork.NeuralNetworks.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public class Layer : Element<IInputValue>
	{
		#region Protected Properties
		
		#endregion

		#region Public Properties

		/// <summary>
		/// Number of Neuron on this layer
		/// </summary>
		public int N_Neurons
		{
			get
			{
				return Count;
			}
		}
		#endregion

		#region Construction
		/// <summary>
		/// Create new Layer
		/// </summary>
		Layer(string Id) : base(Id)
		{
		}

		/// <summary>
		/// Create Hiden/Output Layer
		/// </summary>
		/// <param name="preLayer">Pre Layer</param>
		/// <param name="nn">Number of Neuron on this layer</param>
		public Layer(string Id, ActivationFunc ac, int nn, Layer preLayer, Random Rand) : this(Id)
		{
			for (int i = 0; i < nn; i++)
			{
				Neuron n = new Neuron(Id + "_" + i, Rand, ac);
				foreach (IInputValue preNeuron in preLayer)
				{
					Axon ax = new Axon(preNeuron.Id + "->" + n.Id, Rand, preNeuron, n);

					n.Add(ax);
				}
				this.Add(n);
			}
		}

		/// <summary>
		/// Create Input Layer
		/// </summary>
		/// <param name="n_input">Number of input neuron</param>
		public Layer(string Id, int n_input) : this(Id)
		{
			for(int i = 0; i < n_input; i++)
			{
				InputValue n = new InputValue(Id + "_" + i);
				this.Add(n);
			}
		}
		#endregion

		public override void Reset()
		{
			foreach(IInputValue n in this)
			{
				if(n is Neuron)
				{
					((Neuron)n).Reset(); ;
				}
			}
		}

		public override string PrintInfo()
		{
			string s = "";
			s += "========================\n";
			s += "ID: " + Id + "\n";
			s += "Number neuron: " + N_Neurons + "\n";

			foreach(IInputValue n in this)
			{
				s += n.PrintInfo();
			}

			return s;
		}
	}
}
