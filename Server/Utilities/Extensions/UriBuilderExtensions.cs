﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace Server.Utilities.Extensions {

	public static class UriBuilderExtensions {

		/// <summary>
		/// Sets the specified query parameter key-value pair of the URI.
		/// If the key already exists, the value is overwritten.
		/// </summary>
		public static UriBuilder SetQueryParam(this UriBuilder uri, string key, string value) {
			NameValueCollection collection = uri.ParseQuery();
			collection.Set(key, value);
			string query = collection
				.AsKeyValuePairs()
				.Print(pair =>
					pair.Key == null
					? pair.Value
					: pair.Key + "=" + pair.Value, "&");
			uri.Query = query;
			return uri;
		}

		/// <summary>
		/// Gets the query string key-value pairs of the URI.
		/// Note that the one of the keys may be null ("?123") and
		/// that one of the keys may be an empty string ("?=123").
		/// </summary>
		public static IEnumerable<KeyValuePair<string, string>> GetQueryParams(this UriBuilder uri) {
			return uri.ParseQuery().AsKeyValuePairs();
		}

		/// <summary>
		/// Converts the legacy NameValueCollection into a strongly-typed KeyValuePair sequence.
		/// </summary>
		static IEnumerable<KeyValuePair<string, string>> AsKeyValuePairs(this NameValueCollection collection) {
			foreach (string key in collection.AllKeys) {
				yield return new KeyValuePair<string, string>(key, collection.Get(key));
			}
		}

		/// <summary>
		/// Parses the query string of the URI into a NameValueCollection.
		/// </summary>
		static NameValueCollection ParseQuery(this UriBuilder uri) {
			return HttpUtility.ParseQueryString(uri.Query);
		}

	}

}
