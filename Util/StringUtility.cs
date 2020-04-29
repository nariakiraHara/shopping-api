using System;

namespace Util
{
    /// <summary>
    /// Stringの拡張クラス
    /// </summary>
    public static class StringUtility
    {
        public static int? ToInt(this string str)
        {
            int? ret = null;
            int result = 0;

            if(int.TryParse(str, out result))
                ret = result;

            return ret;
        }

        /// <summary>
		/// Parse成功したら数値で戻る；失敗したらnullで戻る
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static long? ToLong(this string str)
		{
			long? ret = null;
			long result = 0;

			if (Int64.TryParse(str, out result))
			{
				ret = result;
			}

			return ret;
		}

        /// <summary>
		/// 変換可能なタイプTに変換成功できたらTで戻る；失敗したらnullで戻る
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static T? ConvertTo<T>(this string str) where T : struct, IConvertible
		{
			T? ret = null;

			try
			{
				ret = (T)System.Convert.ChangeType(str, typeof(T));
			}
			catch { }

			return ret;
		}

		#region Null・空白チェック関連メソッド
		/// <summary>
		/// IsNullOrEmptyの略
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsNullOrEmpty(this string str)
		{
			return String.IsNullOrEmpty(str);
		}

		/// <summary>
		/// !IsNullOrEmptyの略
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool NotNullOrEmpty(this string str)
		{
			return !str.IsNullOrEmpty();
		}

		/// <summary>
		/// String.IsNullOrWhiteSpaceの略
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return String.IsNullOrWhiteSpace(str);
		}

		/// <summary>
		/// !String.IsNullOrWhiteSpaceの略
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool NotNullOrWhiteSpace(this string str)
		{
			return !str.IsNullOrWhiteSpace();
		}
		#endregion
    }
}