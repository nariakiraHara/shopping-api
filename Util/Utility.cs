namespace Util
{
    public class Utility
    {
        public static string ReplaceMoneyFomat(string money)
        {
            return money.Replace("￥", "").Replace("\\", "").Replace(",", "").Replace("円", "");
        }
    }
}