namespace NeuralNetwork
{
	public interface IElement
	{
		string Id { get; set; }

		/// <summary>
		/// For debug
		/// </summary>
		/// <returns>Info</returns>
		string PrintInfo();
	}
}
