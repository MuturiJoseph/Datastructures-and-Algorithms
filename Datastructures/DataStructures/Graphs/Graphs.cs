using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.Graphs
{
    public class Graph
    {
        public List<List<int>> graph;
        public int v;
        public Graph(int nodes)
        {
            v = nodes;
            graph = new List<List<int>>();
            for (int i = 0; i < v; i++)
                graph.Add(new List<int>());
        }

        public void AddEdge(int v,int u)
        {
            graph[v].Add(u);
            graph[u].Add(v);
        }
        public void PrintGraph()
        {
            for(int i = 0;i < v; i++)
            {
                Console.Write("Node i :" + i);
                foreach(int x in graph[i])
                    Console.Write(" -> " + x);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
