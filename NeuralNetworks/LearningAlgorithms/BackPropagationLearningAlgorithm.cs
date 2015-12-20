using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork.NeuralNetworks.LearningAlgorithms
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
		//double[] e;

		/// <summary>
		/// Get/set nuy param of Back Propagation Learning Algorithm
		/// </summary>
		public double Nuy
		{
			get { return _nuy; }
			set { _nuy = (value > 0) ? value : _nuy; }
		}

		public BackPropagationLearningAlgorithm() : base()
		{

		}
		public BackPropagationLearningAlgorithm(NeuralNetwork nn) : base(nn)
		{
		}

		/// <summary>
		/// To train the neuronal network on data.
		/// inputs[n] represents an input vector of the neural network and expected_outputs[n] the expected ouput for this vector.
		/// </summary>
		public override void Learn()
		{
			do
			{
				LearnStep();
			} while (Iter < MaxIteration && this.Error > ErrorThreshold);
		}

		/// <summary>
		/// 
		/// </summary>
		public override void LearnStep()
		{
			this.Error = 0;
			for (int i = 0; i < Inputs.Count; i++)
			{
				NN.CreateInput(Inputs[i]);

				double err = Per.Error(NN.Outputs, Outputs[i]);

				this.Error += err;

				ComputeDelta();
				setWeight();
			}

			Iter++;
		}

		/// <summary>
		/// Compute Delta param
		/// </summary>
		void ComputeDelta()
		{
			int l = NN.N_Layers - 1;

			// for output layer
			for(int i = 0; i < NN.N_Outputs; i++)
			{
				NN[l][i].Delta = NN[l][i].OutputPrime * Per.Err[i];
			}

			// for other layer
			for (l--; l >= 0; l--)
			{
				for (int j = 0; j < NN[l].N_Neurons; j++)
				{
					double sk = 0;
					for (int k = 0; k < NN[l + 1].N_Neurons; k++)
						sk += NN[l + 1][k].Delta * NN[l + 1][k][j].Weight;
					NN[l][j].Delta = NN[l][j].OutputPrime * sk;
				}
			}
		}

		/// <summary>
		/// Set new value of weight for every Axon
		/// </summary>
		void setWeight()
		{
			for (int i = 1; i < NN.N_Layers; i++)
			{
				Layer layer = NN[i];
				for(int j = 0; j < layer.N_Neurons; j++)
				{
					Neuron neuron = layer[j];
					foreach(Axon ax in neuron)
					{
						ax.Weight += _nuy * neuron.Delta * ax.InputNeuron.Value ;
					}
					neuron.InputValue += _nuy * neuron.Delta;
				}
			}
		}
	}
}
