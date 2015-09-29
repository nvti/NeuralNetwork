using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork
{
	public class Layer : List<Neuron>
	{
		#region Protected Properties
		
		#endregion

		#region Public Properties
		/// <summary>
		/// Pre Layer of this layer
		/// </summary>
		public string Id { get; set; }
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
		Layer(string Id)
		{
			this.Id = Id;
#if DEBUG_BUILD_NN
			Console.WriteLine("Layer ID : " + Id);
#endif
		}

		/// <summary>
		/// Create Hiden/Output Layer
		/// </summary>
		/// <param name="preLayer">Pre Layer</param>
		/// <param name="nn">Number of Neuron on this layer</param>
		public Layer(string Id, int nn, Layer preLayer, Random Rand) : this(Id)
		{
			for (int i = 0; i < nn; i++)
			{
				Neuron n = new Neuron(Id + "_" + i);
				foreach(Neuron preNeuron in preLayer)
				{
					Axon ax = new Axon(preNeuron.Id + "->" + n.Id, Rand, preNeuron, n);
#if DEBUG_BUILD_NN
					ax.Print();
#endif
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
				Neuron n = new Neuron(Id + "_" + i);
				this.Add(n);
			}
		}
		#endregion

		public void Reset()
		{
			foreach(Neuron n in this)
			{
				n.Reset();
			}
		}
	}
}
