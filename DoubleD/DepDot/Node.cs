using System.Collections.Generic;

namespace DepDot
{
    public enum NodeType
    {
        SCHEDULE,
        PROJECT
    };

    public class Node
    {
        public string UniqueId { get; set; }

        public string Name { get; set; }

        public NodeType NodeType;

        public List<Dependency> Dependencies;

        public Node()
        {
            Dependencies = new List<Dependency>();
        }

        public void CreateDependency(Direction direction, int weight, string target)
        {
            Dependency d = new Dependency();
            d.Direction = direction;
            d.Weight = weight;
            d.Target = target;
            Dependencies.Add(d);
        }
    }
}
