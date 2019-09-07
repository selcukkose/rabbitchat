using System;
using RabbitChatConfig;
using BookSleeve;
using System.Globalization;

namespace RabbitChatData.Helpers
{
	public static class RedisHelper
	{
		#region Variables
		/// <summary>
		///	Redis connection.
		/// </summary>
		private static RedisConnection redisClient;
		#endregion

		#region Constructors
		static RedisHelper()
		{
			redisClient = new RedisConnection(
				ConfigHelper.RedisConnectionHost,
				password: ConfigHelper.RedisConnectioPassword,
				port: ConfigHelper.RedisConnectionPort,
				allowAdmin: true
			);
			redisClient.Open();
		}

		/// <summary>
		/// Append To Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		/// <param name="value">Yazılacak olan değer.</param>
		public static void Append(string key, byte[] value)
		{
			lock (redisClient)
			{
				redisClient.Strings.Append(0, key, value);
			}
		}

		/// <summary>
		/// Append To Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		/// <param name="value">Yazılacak olan değer.</param>
		public static void Append(string key, string value)
		{
			lock (redisClient)
			{
				redisClient.Strings.Append(0, key, value);
			}
		}

		/// <summary>
		/// Append Nunexist Value To Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		/// <param name="value">Yazılacak olan değer.</param>
		/// <param name="expire">Değişkenin ömrü.</param>
		public static bool Set<T>(string key, T value, TimeSpan expire)
		{
			lock (redisClient)
			{
				if (typeof(T) == typeof(byte[]))
					redisClient.Strings.Set(0, key, (byte[])(object)value, expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(string))
					redisClient.Strings.Set(0, key, (string)(object)value, expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(bool?) || typeof(T) == typeof(bool))
					redisClient.Strings.Set(0, key, ((bool?)(object)value).Value == true ? "1" : "0", expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(byte?) || typeof(T) == typeof(byte))
					redisClient.Strings.Set(0, key, ((byte?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(sbyte?) || typeof(T) == typeof(sbyte))
					redisClient.Strings.Set(0, key, ((sbyte?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(short?) || typeof(T) == typeof(short))
					redisClient.Strings.Set(0, key, ((short?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(ushort?) || typeof(T) == typeof(ushort))
					redisClient.Strings.Set(0, key, ((ushort?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(int?) || typeof(T) == typeof(int))
					redisClient.Strings.Set(0, key, ((int?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(uint?) || typeof(T) == typeof(uint))
					redisClient.Strings.Set(0, key, ((uint?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(long?) || typeof(T) == typeof(long))
					redisClient.Strings.Set(0, key, ((long?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(ulong?) || typeof(T) == typeof(ulong))
					redisClient.Strings.Set(0, key, ((ulong?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(float?) || typeof(T) == typeof(float))
					redisClient.Strings.Set(0, key, ((float?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(double?) || typeof(T) == typeof(double))
					redisClient.Strings.Set(0, key, ((double?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else if (typeof(T) == typeof(decimal?) || typeof(T) == typeof(decimal))
					redisClient.Strings.Set(0, key, ((decimal?)(object)value).Value.ToString(CultureInfo.InvariantCulture), expirySeconds: (long)expire.TotalSeconds).Wait();
				else
					throw new NotImplementedException();
			}

			return true;
		}

		/// <summary>
		/// Remove From Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		public static bool Remove(string key)
		{
			lock (redisClient)
			{
				return redisClient.Keys.Remove(0, key).Result;
			}
		}

		/// <summary>
		/// Get Value From Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		public static T Get<T>(string key)
		{
			object nullResult = null;
			lock (redisClient)
			{
				if (typeof(T) == typeof(byte[]))
				{
					var result = redisClient.Strings.Get(0, key).Result;
					if (result == null)
						return (T)nullResult;

					return (T)(object)result;
				}
				else
				{
					var result = redisClient.Strings.GetString(0, key).Result;
					if (result == null)
						return (T)nullResult;

					if (typeof(T) == typeof(string))
						return (T)(object)result;
					else if (typeof(T) == typeof(bool?) || typeof(T) == typeof(bool))
						return (T)(object)(result == "1");
					else if (typeof(T) == typeof(byte?) || typeof(T) == typeof(byte))
						return (T)(object)Convert.ToByte(result);
					else if (typeof(T) == typeof(sbyte?) || typeof(T) == typeof(sbyte))
						return (T)(object)Convert.ToSByte(result);
					else if (typeof(T) == typeof(short?) || typeof(T) == typeof(short))
						return (T)(object)Convert.ToInt16(result);
					else if (typeof(T) == typeof(ushort?) || typeof(T) == typeof(ushort))
						return (T)(object)Convert.ToUInt16(result);
					else if (typeof(T) == typeof(int?) || typeof(T) == typeof(int))
						return (T)(object)Convert.ToInt32(result);
					else if (typeof(T) == typeof(uint?) || typeof(T) == typeof(uint))
						return (T)(object)Convert.ToUInt32(result);
					else if (typeof(T) == typeof(long?) || typeof(T) == typeof(long))
						return (T)(object)Convert.ToInt64(result);
					else if (typeof(T) == typeof(ulong?) || typeof(T) == typeof(ulong))
						return (T)(object)Convert.ToUInt64(result);
					else if (typeof(T) == typeof(float?) || typeof(T) == typeof(float))
						return (T)(object)Convert.ToSingle(result);
					else if (typeof(T) == typeof(double?) || typeof(T) == typeof(double))
						return (T)(object)Convert.ToDouble(result);
					else if (typeof(T) == typeof(decimal?) || typeof(T) == typeof(decimal))
						return (T)(object)Convert.ToDecimal(result);
					else
						throw new NotImplementedException();
				}
			}
		}

		/// <summary>
		/// Check Value In Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		public static bool CheckExist<T>(string key)
		{
			var value = Get<T>(key);
			return value == null;
		}

		/// <summary>
		/// Increase Values In Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		/// <param name="amount">Yapılacak olan ekleme değeri.</param>
		public static long Increment(string key, uint amount)
		{
			lock (redisClient)
			{
				return redisClient.Strings.Increment(0, key, amount).Result;
			}
		}

		/// <summary>
		/// Decrease Values In Redis Database
		/// </summary>
		/// <param name="key">Değerin anahtar değeri.</param>
		/// <param name="amount">Yapılacak olan çıkarma değeri.</param>
		public static long Decrement(string key, uint amount)
		{
			lock (redisClient)
			{
				return redisClient.Strings.Decrement(0, key, amount).Result;
			}
		}
		#endregion
	}
}
