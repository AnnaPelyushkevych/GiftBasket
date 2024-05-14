using System;

namespace CandyGiftBasket.Exceptions
{
	public class IncorrectUserInputException : Exception
	{
		public IncorrectUserInputException(string userInput) : base($"Incorrect {userInput}, please enter only digits")
		{

		}
	}
}
