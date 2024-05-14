using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CandyGiftBasket
{
	public enum LollipopType
	{
		Sour,
		Sweet
	}

	public enum LollipopTaste
	{
		Lime,
		Apple,
		Orange,
		Lemon,
		Strawberry
	}

	public class LolliPopCandy : Candy
	{
		public LollipopType Type { get; set; }

		public Color Color { get; set; }

		public LollipopTaste Taste { get; set; }

		public int ExtraLollipopsQuantity { get; set; }

		public LolliPopCandy(string name, int price) : base(name, price) { }

		public override int GetCandiesWeigth()
		{
			return base.GetCandiesWeigth() + ExtraLollipopsQuantity * Weight;
		}
	}
}
