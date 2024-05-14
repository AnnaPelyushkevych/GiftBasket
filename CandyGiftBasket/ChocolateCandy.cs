using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyGiftBasket
{
	public enum ChocolateType
	{
		White,
		Milk,
		Dark
	}

	public class ChocolateCandy : Candy
	{
		public int PercentageOfCacao { get; set; }

		public ChocolateType Type { get; set; }

		public ChocolateCandy(string name, int price) : base(name, price) { }
	}
}
