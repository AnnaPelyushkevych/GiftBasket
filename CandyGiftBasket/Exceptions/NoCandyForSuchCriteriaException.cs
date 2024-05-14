using System;

namespace CandyGiftBasket.Exceptions
{
	public class NoCandyForSuchCriteriaException : Exception
	{
		public NoCandyForSuchCriteriaException(int calories) : base($"No candy founded for such criteria : {calories} calories")
		{
			//Console.WriteLine("No candy founded for such criteria : {calories} calories");
		}
	}
}
