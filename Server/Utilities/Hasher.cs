using System;
using System.Security.Cryptography;
using System.Text;

namespace Server.Utilities {

	public class Hasher {

		private const string NUMBERS = "0123456789";
		private const string LOWER_CASE = "abcdefghijklmnopqrstuvwxyz";
		private const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string SYMBOLS = "$-_.+!*'(),";

		public static readonly char[] Letters;
		public static readonly char[] LettersAndNumbers;
		public static readonly char[] Numbers;
		public static readonly char[] LowerCase;
		public static readonly char[] UpperCase;
		public static readonly char[] Symbols;
		public static readonly char[] All;


		static Hasher() {
			Numbers = NUMBERS.ToCharArray();
			LowerCase = LOWER_CASE.ToCharArray();
			UpperCase = UPPER_CASE.ToCharArray();
			Symbols = SYMBOLS.ToCharArray();
			Letters = (LOWER_CASE + UPPER_CASE).ToCharArray();
			LettersAndNumbers = (LOWER_CASE + UPPER_CASE + NUMBERS).ToCharArray();
			All = (LOWER_CASE + UPPER_CASE + NUMBERS + SYMBOLS).ToCharArray();
		}

		public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt) {
			HashAlgorithm algorithm = new SHA256Managed();
			byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];
			for (int i = 0; i < plainText.Length; i++) {
				plainTextWithSaltBytes[i] = plainText[i];
			}
			for (int i = 0; i < salt.Length; i++) {
				plainTextWithSaltBytes[plainText.Length + i] = salt[i];
			}
			return algorithm.ComputeHash(plainTextWithSaltBytes);
		}

		public static string GenerateSaltedHash(string plainText, string salt) {
			return (Convert.ToBase64String(GenerateSaltedHash(Encoding.UTF8.GetBytes(plainText), Encoding.UTF8.GetBytes(salt))));
		}

		public static string GenerateRandomString(int length) {
			StringBuilder builder = new StringBuilder();
			Random random = new Random(Environment.TickCount);
			for (int i = 0; i < length; i++) {
				int x = random.Next(0, 128);
				char c = (char)x;
				builder.Append(c);
			}
			return builder.ToString();
		}

		public static string GenerateRandomString(int length, char[] characters) {
			StringBuilder builder = new StringBuilder();
			Random random = GenerateRandom();
			for (int i = 0; i < length; i++) {
				int pos = random.Next(0, characters.Length);
				char c = characters[pos];
				builder.Append(c);
			}
			return builder.ToString();
		}

		public static byte[] GenerateRandomBytes(int length) {
			byte[] randomBytes = new byte[length];
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			rng.GetBytes(randomBytes);
			return randomBytes;
		}

		public static int GenerateRandomInteger() {
			byte[] random = GenerateRandomBytes(4);
			int seed = (random[0] & 0x7f) << 24 |
						random[1] << 16 |
						random[2] << 8 |
						random[3];
			return seed;
		}

		public static Random GenerateRandom() {
			return new Random(GenerateRandomInteger());
		}

		public static string GenerateShortSecret() {
			return GenerateRandomString(8, LettersAndNumbers);
		}

		public static string GenerateId() {
			long i = 1;
			foreach (byte b in Guid.NewGuid().ToByteArray()) {
				i *= b + 1;
			}
			return string.Format("{0:x}", i - DateTime.Now.Ticks);
		}

	}

}
