using System.Collections.Generic;

namespace DBCommunication
{
    public static class TablesInfo
    {
        public static Dictionary<string,List<string>> smallDataTables = new Dictionary<string, List<string>>
        {
            {"userIdTable", new List<string>{"userId","Facebook","checked"}},
        };
    }
}