namespace NeuralNetwork.Lists
{
	public class InputValue : IInputValue
	{
		#region Properties
		public string Id { get; set; }
		public double Value
		{
			get; set;
		}
		#endregion

		#region Construction
		public InputValue(string id)
		{
			this.Id = id;
		}
		public InputValue(double value)
		{
			Value = value;
		}
		#endregion

		#region Method
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string PrintInfo()
		{
			string s = "";
			s += "\tInput value: " + Value + "\n";
			return s;
		}
		#endregion
	}
}
