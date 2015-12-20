using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public abstract class Element<T> : List<T>
	{
		public string Id { get; set; }

		public Element(string Id)
		{
			this.Id = Id;
		}

		public Element()
		{

		}

		public abstract string PrintInfo();
		public abstract void Reset();
	}
}
