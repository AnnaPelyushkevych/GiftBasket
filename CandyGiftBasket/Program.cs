using CandyGiftBasket.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace CandyGiftBasket
{
	public class Program
	{
		static void Main(string[] args)
		{
			var giftBasket = new GiftBasket();
			giftBasket.FillGiftBasket(GetCandies());

			PrintGiftBasketContent(giftBasket.Candies, "Filled gift basket with candies");

			// TODO: Taks #2 sorting by criteria
			//SortCandiesByName(giftBasket);
			//OrderCandiesByDescendingTotalWeigth(giftBasket);

			// TODO: Task #3 Selecting by criteria
			//SearchByMaxCaloriesCriteria(giftBasket);

			// TODO: exception handling in #2 and #3
			SelectCandyByIndex(giftBasket);

			Console.ReadLine();
		}

		public static void SelectCandyByIndex(GiftBasket giftBasket)
		{
			Console.WriteLine("Please enter candy index that you like to choose");

			var userChoise = Console.ReadLine();

			try
			{
				var index = Convert.ToInt32(userChoise);
				var candy = giftBasket.Candies[index];

			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void PrintGiftBasketContent(List<ICandy> candies, string printMessage)
		{
			Console.WriteLine(printMessage);

			foreach (Candy candy in candies)
			{
				PrintCandyInfo(candy);
			}

			Console.WriteLine("************************************************************");
		}

		public static void PrintCandyInfo(Candy candy)
		{
			Console.WriteLine($"Candy name: {candy.Name}");
			Console.WriteLine($"Candy calories: {candy.Calories}");
			Console.WriteLine($"Candy quantity: {candy.Quantity}");
			Console.WriteLine($"Candy weight: {candy.Weight}");
			Console.WriteLine($"Candies total weight: {candy.GetCandiesWeigth()}");
			Console.WriteLine();
		}

		public static void SortCandiesByName(GiftBasket giftBasket)
		{
			Console.WriteLine("For sorting candy, please enter candy name:");

			var candyNameInput = Console.ReadLine();

			Regex regex = new Regex("^[a-zA-Z]+$");

			if (!regex.IsMatch(candyNameInput))
			{
				throw new InvalidCandyNameException(candyNameInput);
			}

			giftBasket.Candies.Sort((x, y) => x.Name.CompareTo(y.Name));

			PrintGiftBasketContent(giftBasket.Candies, "Sorted by name");
		}

		public static void OrderCandiesByDescendingTotalWeigth(GiftBasket giftBasket)
		{
			var result = giftBasket.Candies.OrderByDescending(x => x.GetCandiesWeigth()).ToList();

			PrintGiftBasketContent(result, "Ordered by  descending total weigth");
		}

		//public static void SearchByMaxCaloriesCriteria(GiftBasket giftBasket)
		//{
		//	Console.WriteLine("For selecting candy, please enter max calory:");

		//	var userInput = Console.ReadLine();

		//	if (!Regex.IsMatch(userInput, "^[0-9]*$"))
		//	{
		//		throw new IncorrectUserInputException(userInput);
		//	}

		//	int maxCalory = -1;

		//	try
		//	{
		//		maxCalory = Convert.ToInt32(userInput);
		//	}
		//	catch (FormatException ex)
		//	{
		//		Console.WriteLine($"Unexpected format exception");
		//	}

		//	var result = giftBasket.Candies.Where(x => x.Calories < maxCalory).OrderBy(x => x.Calories).ToList();

		//	if (result.Count == 0)
		//	{
		//		throw new NoCandyForSuchCriteriaException(maxCalory);
		//	}

		//	PrintGiftBasketContent(result, $"Filtered by max calories less than {maxCalory}");
		//}

		public static void SearchByMaxCaloriesCriteria(GiftBasket giftBasket)
		{
			List<ICandy> result = null;


			Console.WriteLine("For selecting candy, please enter max calory:");

			var userInput = Console.ReadLine();

			if (!Regex.IsMatch(userInput, "^[0-9]*$"))
			{
				throw new IncorrectUserInputException(userInput);
			}

			int maxCalory = -1;

			try
			{
				maxCalory = Convert.ToInt32(userInput);

				result = giftBasket.Candies.Where(x => x.Calories < maxCalory).OrderBy(x => x.Calories).ToList();

				if (result.Count == 0)
				{
					throw new NoCandyForSuchCriteriaException(maxCalory);
				}

				PrintGiftBasketContent(result, $"Filtered by max calories less than {maxCalory}");
			}
			catch (FormatException ex)
			{
				Console.WriteLine($"Unexpected format exception");
			}
			catch (NoCandyForSuchCriteriaException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (NullReferenceException ex)
			{
				Console.WriteLine("Resulted collection is null");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Big dick");
			}
		}

		public static List<ICandy> GetCandies()
		{
			var chocolateCandies = GetChocolateCandies();
			var lollipopCandies = GetLollipopCandies();

			chocolateCandies.AddRange(lollipopCandies);

			return chocolateCandies;
		}

		public static List<ICandy> GetChocolateCandies()
		{
			var candies = new List<ICandy>
			{
				new ChocolateCandy("Mars", 40)
				{
					Weight = 10,
					PercentageOfCacao = 80,
					Calories = 200,
					Type = ChocolateType.Dark,
					Quantity = 20
				},

				new ChocolateCandy("Nuts", 35)
				{
					Weight = 10,
					PercentageOfCacao = 50,
					Calories = 300,
					Type = ChocolateType.Milk,
					Quantity = 25
				},

				new ChocolateCandy("Lion", 30)
				{
					Weight = 10,
					PercentageOfCacao = 20,
					Calories = 100,
					Type = ChocolateType.White,
					Quantity = 30
				},
			};

			return candies;
		}

		public static List<ICandy> GetLollipopCandies()
		{
			var candies = new List<ICandy>
			{
				new LolliPopCandy("Chupa-Chups", 25)
				{
					Weight = 17,
					Color = Colors.Orange,
					Calories = 120,
					Type = LollipopType.Sour,
					Taste = LollipopTaste.Orange
				},

				new LolliPopCandy("Chupa-Chups", 25)
				{
					Weight = 17,
					Color = Colors.Orange,
					Calories = 120,
					Type = LollipopType.Sour,
					Taste = LollipopTaste.Orange,
					ExtraLollipopsQuantity = 25
				},

				new LolliPopCandy("Shok", 25)
				{
					Weight = 20,
					Color = Colors.Green,
					Calories = 130,
					Type = LollipopType.Sour,
					Taste = LollipopTaste.Lime,
					ExtraLollipopsQuantity = 5,
				},
			};

			return candies;
		}
	}
}
