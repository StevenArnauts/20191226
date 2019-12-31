using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Utilities.Exceptions;

namespace Server.Utilities.Extensions {

	public static class EnumerableExtensions {

		/// <summary>
		/// Tries to get a unique item from the list.
		/// </summary>
		public static bool TryGet<T>(this IEnumerable<T> source, Predicate<T> condition, out T result) {
			try {
				result = Get(source, condition);
				return (true);
			} catch (QueryException) {
				result = default(T);
				return (false);
			}
		}

		/// <summary>
		/// Delete the items from the collection that satisfy the condition
		/// </summary>
		public static void Delete<T>(this ICollection<T> source, Predicate<T> condition) {
			List<T> candidates = source.Where(i => condition(i)).ToList();
			foreach(T candidate in candidates) {
				source.Remove(candidate);
			}
		}

		public static T Get<T>(this IEnumerable<T> source, Predicate<T> condition) {
			List<T> candidates = source.Where(i => condition(i)).ToList();
			if (!candidates.Any()) throw new ObjectNotFoundException("No instance of " + typeof(T).Name + " satisfied the criteria");
			if (candidates.Count > 1) throw new ObjectNotUniqueException("There were " + candidates.Count + " instances of " + typeof(T).Name + " that satisfied the criteria");
			return (candidates[0]);
		}

		public static string Print<TItem>(this IEnumerable<TItem> source, Func<TItem, string> formatter) {
			string result = string.Empty;
			foreach (TItem item in source) {
				result += formatter.Invoke(item);
			}
			return (result);
		}

		public static void ForEach<TItem>(this IEnumerable<TItem> source, Action<TItem> action) {
			foreach (TItem item in source) action(item);
		}

		public static string Print<TItem>(this IEnumerable<TItem> source, string separator) {
			StringBuilder bldr = new StringBuilder();
			IList<TItem> items = new List<TItem>(source);
			for (int i = 0; i < items.Count; i++) {
				bldr.Append(items[i]);
				if (i < items.Count - 1) bldr.Append(separator);
			}
			return bldr.ToString();
		}

		public static string Print<TItem>(this IEnumerable<TItem> source, Func<TItem, string> formatter, string separator) {
			StringBuilder bldr = new StringBuilder();
			IList<TItem> items = new List<TItem>(source);
			for (int i = 0; i < items.Count; i++) {
				bldr.Append(formatter(items[i]));
				if (i < items.Count - 1) bldr.Append(separator);
			}
			return bldr.ToString();
		}

	}

}
