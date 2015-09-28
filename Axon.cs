using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork
{
	public class Axon
	{
		public double Weight { set; get; }
		public Neuron OutputNeuron { set; get; }
		public Neuron InputNeuron { set; get; }
		public string Id { get; set; }

		public Axon(string Id)
		{
			this.Id = Id;
		}
		public Axon(string Id, Random rand) : this(Id)
		{
			Weight = rand.NextDouble() * 2 - 1;		// [-1, 1]
		}

		public Axon(string Id, double w) : this(Id)
		{
			Weight = w;
		}

		public void Print()
		{
			Console.WriteLine("\t\tAxon ID : " + Id);
			Console.WriteLine("\t\t\tWeight : " + Weight);
		}
	}
}
