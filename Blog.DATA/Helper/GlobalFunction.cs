using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DATA.Helper
{
	public class GlobalFunction
	{

		#region Türkçe Karakter Değiştirme
		public static string TextLinkReturning(string? text, int langID = 0)
		{
			string returnText = "";
			if (!string.IsNullOrEmpty(text))
			{
				returnText = text.ToLower().Trim();
				returnText = returnText.Replace(" ", "-");
				returnText = returnText.Replace("+ ", "-");
				returnText = returnText.Replace(" +", "-");
				returnText = returnText.Replace("+", "-");
				returnText = returnText.Replace("ç", "c");
				returnText = returnText.Replace("ğ", "g");
				returnText = returnText.Replace("ı", "i");
				returnText = returnText.Replace("ö", "o");
				returnText = returnText.Replace("ä", "a");
				returnText = returnText.Replace("ş", "s");
				returnText = returnText.Replace("ü", "u");
				returnText = returnText.Replace("$", "");
				returnText = returnText.Replace(":", "-");
				returnText = returnText.Replace("=", "-");
				returnText = returnText.Replace(";", "-");
				returnText = returnText.Replace("%", "");
				returnText = returnText.Replace("&", "-");
				returnText = returnText.Replace(".", "-");
				returnText = returnText.Replace("?", "");
				returnText = returnText.Replace("'", "");
				returnText = returnText.Replace(",", "-");
				returnText = returnText.Replace("'", "");
				returnText = returnText.Replace("^", "");
				returnText = returnText.Replace("--", "-");
				returnText = returnText.Replace("*", "");
				returnText = returnText.Replace("<", "");
				returnText = returnText.Replace(">", "");
				returnText = returnText.Replace("İ", "i");
				returnText = returnText.Replace("#", "");
				//returnText = returnText.Replace("/", "-");
				returnText = returnText.Replace(@"\", "-");
				returnText = returnText.Replace("ä", "a");
				returnText = returnText.Replace("é", "e");
				returnText = returnText.Replace("--", "-");
				returnText = returnText.Replace("\"", "");
				returnText = returnText.Replace(" ", "-");
				if (langID != 0)
					returnText = Translit1(returnText, langID);
				returnText = returnText.Replace("'", "");

			}
			return returnText;
		}
		#endregion

		#region Harf Convert
		//Rusça Convert
		public static string Translit1(string text, int langID)
		{
			if (langID == 1)
			{
				string[] lat_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "\"", "Y", "'", "E", "Yu", "Ya" };
				string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "\"", "y", "'", "e", "yu", "ya" };
				string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
				string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
				for (int i = 0; i <= 32; i++)
				{
					text = text.Replace(rus_up[i], lat_up[i]);
					text = text.Replace(rus_low[i], lat_low[i]);
				}
			}
			else if (langID == -1 || langID == -1 || langID == -1)
			{

			}
			else if (langID == -1 || langID == -1)
			{

			}
			else if (langID == -1 || langID == -1)
			{
				text = text.Replace("û", "u");
				text = text.Replace("à", "a");
				text = text.Replace("é", "e");
				text = text.Replace("À", "a");
			}
			return text;
		}
		#endregion

		#region Kullanıcı Adı Oluştur
		public static string UsernameApp(string? email)
		{
			string userName = "";
			if (!string.IsNullOrEmpty(email))
			{
				Random rnd = new Random();
				userName = email.Split('@').First() + rnd.Next(10000, 99999);
			}
			return userName;
		}
		#endregion


	}
}
