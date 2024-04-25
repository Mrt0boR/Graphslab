using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphslab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Graph graph = new Graph();

            //node addition
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            //connect node 1 to node 2
            graph.AddEdge(1, 2);

            graph.AddEdge(2, 3);
            graph.AddEdge(3, 2);

            graph.GetNodeByID(1);

            Console.ReadKey();
            

        }
    }
}
