using System;
using System.Collections.Generic;
namespace CandyGiftBasket
{
	public class GiftBasket
	{

		public List<ICandy> Candies { get; set; }

		public GiftBasket() 
		{
			//add smth
		}

		public int GetFinalWeigth() 
		{
			var finalWeigth = 0;

			foreach (ICandy candy in Candies) 
			{
				//finalWeigth += c.Weight;
				finalWeigth += candy.GetCandiesWeigth();
			}

			return finalWeigth;
		}

		public void FillGiftBasket(List<ICandy> candies) 
		{
			Candies = candies;

		}

	}
}
