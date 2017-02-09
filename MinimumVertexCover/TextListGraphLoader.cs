using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MinimumVertexCover
{
    public class TextListGraphLoader : IGraphLoader
    {
        private string textList;
        public int VerticeCount { get; private set; }
        public List<Edge> Edges { get; private set; }

        public void LoadTextList(string textList)
        {
            this.textList = textList;
            try
            {
                generateListOfEdges();
                computeVerticeCount();
            }
            catch (Exception)
            {
                Edges.Clear();
            }
        }

        private void generateListOfEdges()
        {
            Edges = new List<Edge>();
            var regex = new Regex(@"^(\w+)[ \t]+(\d+)[-](\d+)[ \t](\d+)\s*$", RegexOptions.Multiline);

            var match = regex.Match(textList);
            while (match.Success)
            {
                var edge = edgeFromMatch(match);
                Edges.Add(edge);
                match = match.NextMatch();
            }
        }

        private Edge edgeFromMatch(Match match)
        {
            var groups = match.Groups;
            var name = groups[1].Value;
            var firstVertice = int.Parse(groups[2].Value);
            var secondVertice = int.Parse(groups[3].Value);
            var weight = int.Parse(groups[4].Value);
            return new Edge(name, firstVertice, secondVertice, weight);
        }

        private void computeVerticeCount()
        {
            VerticeCount = Edges
                .OrderByDescending(x => x.VerticeB)
                .First()
                .VerticeB;
        }
    }
}
