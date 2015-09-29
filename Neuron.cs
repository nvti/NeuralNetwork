using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoNeuralNetwork.ActivationFunction;

namespace DemoNeuralNetwork
{
	/// <summary>
	/// 
	/// </summary>
	public class Neuron : List<Axon>
	{
		#region Public Properties
		public double InputValue { get; set; }
		public double Target { get; set; }
		public string Id { get; set; }
		public bool IsInputChanged { get; set; }
		public double Value
		{
			get
			{
				return _value = IsInputChanged ? CalculateOutput() : _value;
			}
		}

		public double OutputPrime
		{
			get
			{
				return this.af.OutputPrime(ws);
			}
		}

		public int N_Input
		{
			get
			{
				return Count;
			}
		}
		/// <summary>
		/// Delta param. Usefull for Back Propagation Learning Algorithm 
		/// </summary>
		public double Delta { get; set; }
		#endregion

		#region Protected Properties
		/// <summary>
		/// Activation Function
		/// </summary>
		protected IActivationFunction af = null;
		protected double _value;
		/// <summary>
		/// Sum of input
		/// </summary>
		protected double ws = 0;		
		#endregion

		#region Construction
		public Neuron(string Id)
		{
			IsInputChanged = true;
			this.Id = Id;
#if DEBUG_
			Console.WriteLine("\tNeuron ID : " + Id);
#endif
			InputValue = 0;
			af = new SigmoidFunction();
		}

		public Neuron(string Id, IActivationFunction af)
		{
			IsInputChanged = true;
			this.Id = Id;
#if DEBUG_
			Console.WriteLine("\tNeuron ID : " + Id);
#endif
			InputValue = 0;
			this.af = af;
		}
		#endregion

		public void Reset()
		{
			IsInputChanged = true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		double CalculateOutput()
		{
			double result;
			if(this.Count == 0)
			{
				result = ws = InputValue;
			}
			else
			{
				ws = this.Sum(a => a.Weight * a.InputNeuron.Value);
				result = af.Output(ws);
			}
            
#if DEBUG_
			Console.WriteLine("Neuron ID : " + Id);
			Console.WriteLine("\tSum of inputs: {0}", ws);
			Console.WriteLine("\tValue: {0}", result);
#endif
			IsInputChanged = false;
			return result;
		}
	}
}
