using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumVertexCoverGUI
{
    public class SetFormatter
    {
        public static string ListToString(List<HashSet<int>> list, string header)
        {
            var output = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                output.AppendFormat("{0}{1}: ", header, i + 1);
                foreach (var j in list[i])
                {
                    output.AppendFormat("{0}, ", j);
                }
                output.Append("\r\n");
            }
            return output.ToString();
        }
    }
}
