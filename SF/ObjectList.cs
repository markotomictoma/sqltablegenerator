using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF
{
    public class ObjectList
    {
        private static List<String> objsForCreate = new List<String>{ "Account", "Contact", "User", "AccountTeamMember"};
        public static bool ShouldBeCreated(SF.DescribeGlobalSObjectResult obj)
        {
            return objsForCreate.Contains(obj.name) || obj.custom || obj.customSetting;
        }
    }
}
