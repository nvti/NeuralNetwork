using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetwork.ActivationFunctions;

namespace NeuralNetwork.Lists
{
	/// <summary>
	/// Neuron class
	/// </summary>
	public class Neuron : ListElement<Axon>, IInputValue
	{
		#region Public Properties
		public bool IsInputChanged { get; set; }
		/// <summary>
		/// Get Output of Neuron
		/// </summary>
		public double Value
		{
			get
			{
				return _value = IsInputChanged ? Calculate() : _value;
			}
			set
			{

			}
		}

		/// <summary>
		/// 
		/// </summary>
		public double OutputPrime
		{
			get
			{
				return this.af.OutputPrime(ws);
			}
		}
		/// <summary>
		/// Get Number of Input
		/// </summary>
		public int N_Inputs
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
		protected ActivationFunction af = null;
		protected double _value;
		/// <summary>
		/// Sum of input
		/// </summary>
		protected double ws = 0;		
		#endregion

		#region Construction
		/// <summary>
		/// Create new Neuron with fixed Activation Function
		/// </summary>
		/// <param name="af">Activation function</param>
		public Neuron(string Id, Random Rand, ActivationFunc af = ActivationFunc.SIDMOID)
		{
			IsInputChanged = true;
			this.Id = Id;

			this.af = ActivationFunction.Create(af);

			this.Add(new Axon("Bias", Rand, new InputValue(1), this));
		}
		#endregion

		#region Method
		/// <summary>
		/// Reset
		/// </summary>
		public void Reset()
		{
			IsInputChanged = true;
		}

		/// <summary>
		/// Calaulate Output of Neuron
		/// </summary>
		/// <returns>Output of Neuron</returns>
		double Calculate()
		{
			double result;

			ws = this.Sum(a => a.Weight * a.InputNeuron.Value);
			if (af == null) result = ws;
			else result = af.Output(ws);

			IsInputChanged = false;
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override string MyInfo()
		{
			string s = "";
			s += "\tID: " + Id + "\n";
			s += "\tValue: " + Value + '\n';

			return s;
		}
		#endregion
	}
}
