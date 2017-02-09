using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumVertexCover
{
    public class BoolMultiplier
    {
        public List<HashSet<int>> MultiplyListOfSums(List<Edge> input)
        {
            var result = multiply(input);
            result = result
                .Distinct(HashSet<int>.CreateSetComparer())
                .OrderBy(x => x.Count)
                .ToList();
            simplify(result);
            return result;
        }

        private void simplify(List<HashSet<int>> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = result.Count - 1; j >= i; j--)
                {
                    if (i != j && result[i].IsSubsetOf(result[j]))
                        result.RemoveAt(j);
                }
            }
        }

        private List<HashSet<int>> multiply(List<Edge> input)
        {
            var result = new List<HashSet<int>>();

            foreach (var edge in input)
            {
                if (!result.Any())
                {
                    result.Add(new HashSet<int> { edge.VerticeA });
                    result.Add(new HashSet<int> { edge.VerticeB });
                    continue;
                }

                int count = result.Count;
                for (int i = 0; i < count; i++)
                {
                    var newProduct = new HashSet<int>(result[i]);
                    result[i].Add(edge.VerticeA);
                    newProduct.Add(edge.VerticeB);
                    result.Add(newProduct);
                }
            }

            return result;
        }
        
    }
}
