using System.Collections.Generic;

namespace NeuralNetwork.Lists
{
	public abstract class ListElement<T> : List<T>, IElement
	{
		#region Properties
		/// <summary>
		/// Id of element
		/// </summary>
		public string Id { get; set; }

		#endregion

		#region Construction
		public ListElement(string Id)
		{
			this.Id = Id;
		}

		public ListElement()
		{

		}

		#endregion

		#region Method
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string PrintInfo()
		{
			string s = MyInfo();
			foreach(var n in this)
			{
				s += ((IElement)n).PrintInfo();
			}
			return s;
		}

		protected abstract string MyInfo();
		#endregion
	}
}
