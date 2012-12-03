using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public class TestDataHelper
	{
		private static Random _random;
		public static Random Random
		{
			get
			{
				if (_random == null)
				{
					_random = new Random();
				}
				return _random;
			}
		}

		public static int RandomInt()
		{
			return TestDataHelper.Random.Next();
		}

		public static decimal RandomDecimal()
		{
			return Convert.ToDecimal(TestDataHelper.Random.NextDouble());
		}
	}
}
