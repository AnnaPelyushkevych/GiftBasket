using System;

namespace CandyGiftBasket.Exceptions
{
	public class InvalidCandyNameException : Exception
	{
		public InvalidCandyNameException(string candyNameInput) : base($"Invalid candy name {candyNameInput}, please enter only letters")
		{

		}
	}
}
