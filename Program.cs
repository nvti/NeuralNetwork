
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeuralNetwork
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> num = new List<int> { 2, 3, 1};
			NeuralNetwork nn = new NeuralNetwork(num);

			List<List<double>> inputs = new List<List<double>>
			{
				new List<double> { 0, 0 },
				new List<double> { 0, 1 },
				new List<double> { 1, 0 },
				new List<double> { 1, 1 }
			};

			List<List<double>> outputs = new List<List<double>>
			{
				new List<double> { 0 },
				new List<double> { 0 },
				new List<double> { 0 },
				new List<double> { 1 }
			};

			nn.Learn(inputs, outputs);

			nn.CreateInput(new List<double> { 0, 0 });
			Console.WriteLine("Output: {0}", nn.GetOutput()[0]);

			nn.CreateInput(new List<double> { 0, 1 });
			Console.WriteLine("Output: {0}", nn.GetOutput()[0]);

			nn.CreateInput(new List<double> { 1, 0 });
			Console.WriteLine("Output: {0}", nn.GetOutput()[0]);

			nn.CreateInput(new List<double> { 1, 1 });
			Console.WriteLine("Output: {0}", nn.GetOutput()[0]);
			Console.ReadLine();
		}
	}
}