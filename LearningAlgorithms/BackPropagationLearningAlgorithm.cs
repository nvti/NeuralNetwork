using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.LearningAlgorithms
{
	public class BackPropagationLearningAlgorithm : LearningAlgorithm
	{
		/// <summary>
		/// Nuy param of Back Propagation Learning Algorithm
		/// </summary>
		protected double _nuy = 0.5;

		/// <summary>
		/// List of error
		/// </summary>
		double[] e;

		/// <summary>
		/// Get/set nuy param of Back Propagation Learning Algorithm
		/// </summary>
		public double Nuy
		{
			get { return _nuy; }
			set { _nuy = (value > 0) ? value : _nuy; }
		}

		public BackPropagationLearningAlgorithm(NeuralNetwork nn) : base(nn)
		{
		}

		/// <summary>
		/// To train the neuronal network on data.
		/// inputs[n] represents an input vector of the neural network and expected_outputs[n] the expected ouput for this vector.
		/// </summary>
		/// <param name="inputs">Input matrix</param>
		/// <param name="expected_outputs">Expected Output matrix</param>
		public override void Learn(List<List<double>> inputs, List<List<double>> expected_outputs)
		{
			base.Learn(inputs, expected_outputs);

			int iter = 0;
			do
			{
				_error = 0;
				e = new double[nn.N_Outputs];
				for(int i = 0; i < inputs.Count; i++)
				{
					double err = 0;
					nn.CreateInput(inputs[i]);
					List<double> nout = nn.Outputs;
					for(int j = 0; j < nn.N_Outputs; j++)
					{
						e[j] = Outputs[i][j] - nout[j];
						err += e[j] * e[j];
					}
					err /= 2;
					_error += err;

					ComputeDelta();
					setWeight();
				}

				iter++;
			} while (iter < MaxIteration && this.Error > ErrorTreshold);
		}

		/// <summary>
		/// Compute Delta param
		/// </summary>
		void ComputeDelta()
		{
			int l = nn.N_Layers - 1;

			// for output layer
			for(int i = 0; i < nn.N_Outputs; i++)
			{
				nn[l][i].Delta = nn[l][i].OutputPrime * e[i];
			}

			// for other layer
			for (l--; l >= 0; l--)
			{
				for (int j = 0; j < nn[l].N_Neurons; j++)
				{
					double sk = 0;
					for (int k = 0; k < nn[l + 1].N_Neurons; k++)
						sk += nn[l + 1][k].Delta * nn[l + 1][k][j].Weight;
					nn[l][j].Delta = nn[l][j].OutputPrime * sk;
				}
			}
		}

		/// <summary>
		/// Set new value of weight for every Axon
		/// </summary>
		void setWeight()
		{
			for (int i = 1; i < nn.N_Layers; i++)
			{
				Layer layer = nn[i];
				for(int j = 0; j < layer.N_Neurons; j++)
				{
					Neuron neuron = layer[j];
					foreach(Axon ax in neuron)
					{
						ax.Weight += _nuy * neuron.Delta * ax.InputNeuron.Value;
					}
				}
			}
		}
	}
}
