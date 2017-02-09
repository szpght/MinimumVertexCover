using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumVertexCover
{
    public interface IGraphLoader
    {
        List<Edge> Edges { get; }
        int VerticeCount { get; }
    }
}
