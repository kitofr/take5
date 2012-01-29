using System;
using System.Collections.Generic;
using System.Linq;

namespace Take5
{
	public static class Extensions
	{
		public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> action)
		{
			var items = source.ToArray();
			foreach (var item in items)
			{
				action(item);
			}
			return source;
		}
	}
}