using House_Data.Data;

namespace House_Data
{
    public static class Functions
    {
        /// <summary>
        /// 產生物件代碼
        /// </summary>
        /// <returns></returns>
        public static string getHouseSerial()
        {
            House_DataContext _context = new House_DataContext(new Microsoft.EntityFrameworkCore.DbContextOptions<House_DataContext>());
            string serial = "";
            do
            {
                serial = "YC" + getRandStr(8);
            } while (_context.House.Where(v=>v.Serial== serial).Any());
            return serial;
        }

        /// <summary>
        /// 取得隨機亂數資料
        /// </summary>
        /// <param name="len">字串長度</param>
        /// <param name="type">類型(預設num=數字)，en=英數字，custom=自訂</param>
        /// <param name="custom">字串自訂</param>
        /// <returns></returns>
        public static string getRandStr(int len, string type = "num", string custom = "")
        {
            string rndTxt = "", result = "";
            if (type == "num")
                rndTxt = "0123456789";
            else if (type == "custom")
            {
                if (string.IsNullOrEmpty(custom))
                    custom = "0123456789";
                rndTxt = custom;
            }
            else if (type == "en2")
            {
                rndTxt = "abcdefghjkmnpqrstuvwxyz23456789";
            }
            else
                rndTxt = "abcdefghijkmnpqrstuvwxyz0123456789";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < len; i++)
                result += rndTxt.Substring(rnd.Next(0, rndTxt.Length), 1);

            return result;
        }
    }

    public static class VariableExtension
    {
        /// <summary>
        /// 輸出金額文字
        /// </summary>
        /// <param name="number">要轉換的數字</param>
        /// <returns></returns>
        public static string ToMoneyString(this int number)
        {
            return string.Format("{0:N0}", number);
        }
    }
}
