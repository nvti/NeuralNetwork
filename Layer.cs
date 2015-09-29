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
		public Layer PreLayer { set; get; }
		public string Id { get; set; }
		#endregion

		public Layer(string Id)
		{
			this.Id = Id;
#if DEBUG_
			Console.WriteLine("Layer ID : " + Id);
#endif
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pre"></param>
		/// <param name="nn"></param>
		public Layer(string Id, int nn, Layer pre, Random Rand) : this(Id)
		{
			PreLayer = pre;
			for (int i = 0; i < nn; i++)
			{
				Neuron n = new Neuron(Id + "_" + i);
				foreach(Neuron pren in PreLayer)
				{
					Axon ax = new Axon(pren.Id + "->" + n.Id, Rand);
					ax.InputNeuron = pren;
					ax.OutputNeuron = n;
#if DEBUG_
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

		public void Reset()
		{
			foreach(Neuron n in this)
			{
				n.Reset();
			}
		}
	}
}
