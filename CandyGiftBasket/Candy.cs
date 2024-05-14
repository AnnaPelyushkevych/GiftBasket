namespace CandyGiftBasket
{
	public interface ICandy
	{
		int Weight { get; set; }

		int Calories { get; set; }

		string Name { get; }

		int GetCandiesWeigth();
	}

	public abstract class Candy : ICandy
	{
		private string _name;

		private int _price;

		public int Weight { get; set; }

		public int Calories { get; set; }

		public int Quantity { get; set; }

		//public string Name => _name;

		public int Price => _price;

		public string Name => _name;

		public Candy(string name, int price) 
		{ 
			_name = name;

			_price = price;
		}

		public virtual int GetCandiesWeigth() 
		{
			return Weight * Quantity;
		}
	}
}
