using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableGenerator
{
    public class ReservedWordsChecker
    {
        static List<String> reservedWords = new List<String> { "Case", "User" };
        public static String CheckTableName(String tableName)
        {
            if (reservedWords.Contains(tableName))
            {
                return $"[{tableName}]";
            }else
            {
                return tableName;
            }           
        }
    }
}
