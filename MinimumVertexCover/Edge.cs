using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumVertexCover
{
    public class Edge
    {
        public int VerticeA { get; private set; }
        public int VerticeB { get; private set; }
        public string Name { get; private set; }
        public int Weight { get; private set; }

        public Edge(string name, int firstVertice, int secondVertice)
        {
            Name = name;
            if (firstVertice < secondVertice)
            {
                VerticeA = firstVertice;
                VerticeB = secondVertice;
            }
            else
            {
                VerticeA = secondVertice;
                VerticeB = firstVertice;
            }
        }

        public Edge(string name, int firstVertice, int secondVertice, int weight) :
            this(name, firstVertice, secondVertice)
        {
            Weight = weight;
        }

    }
}
