using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks
{
	public class InputValue : IInputValue
	{
		public string Id { get; set; }
		double _value;
		public double Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public InputValue(string id)
		{
			this.Id = id;
		}
		public InputValue(double value)
		{
			_value = value;
		}

		public string PrintInfo()
		{
			string s = "";
			s += "\tInput value: " + _value + "\n";
			return s;
		}
	}
}
