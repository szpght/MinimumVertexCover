using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumVertexCover
{
    public class Graph
    {
        public List<Edge> Edges { get; private set; }
        public int VerticesCount { get; private set; }

        public Graph(IGraphLoader loader)
        {
            Edges = loader.Edges;
            VerticesCount = loader.VerticeCount;
        }

        public List<HashSet<int>> GetMinVertexCover()
        {
            var multiplier = new BoolMultiplier();
            return multiplier.MultiplyListOfSums(Edges);
        }

        public List<HashSet<int>> GetMaxIndependentSets(List<HashSet<int>> minVertexCover)
        {
            var list = new List<HashSet<int>>();
            foreach (var set in minVertexCover)
            {
                var compSet = getComplementarySet(set);
                list.Add(compSet);
            }
            return list;
        }

        /*public string AsTextList()
        {
            var output = new StringBuilder();

            foreach(var edge in Edges)
            {

            }
        }*/

        private HashSet<int> getComplementarySet(HashSet<int> set)
        {
            var compSet = new HashSet<int>();
            for (int i = 1; i <= VerticesCount; i++)
                compSet.Add(i);
            compSet.RemoveWhere(x => set.Contains(x));
            return compSet;
        }
    }
}
