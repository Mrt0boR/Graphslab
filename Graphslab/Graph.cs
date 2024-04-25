using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graphslab
{

    //this class represents the graph in its entirety, rather than an examination of the 
    //individual nodes
     class Graph
    {
        //list of graphnodes in the graph (represents all the nodes in the entire graph)

        private LinkedList<GraphNode> nodes;

        //constructor of a Graph --
        //the new list initialisation ensures that the list is empty
        //the constructed graph has no nodes
        public Graph()
        {
            nodes = new LinkedList<GraphNode>();   
        }


        //Adding a node to the graph

        public void AddNode(int id)
        {
            nodes.AddLast(new GraphNode(id));
        }

        public GraphNode GetNodeByID(int id)
        {
            foreach (GraphNode node in nodes)
            {
                if (id == node.ID)
                {
                    return node;
                }
                
               
                  
                
            }
            Console.WriteLine("Node not Found, please check Node ID");
            return null; 


        }


        //add an edge which can be directed from one node to another with an ID(n) to ID(n+1)

        public void AddEdge(int from , int to)
        {

            GraphNode node1 = GetNodeByID(from);
            GraphNode node2 = GetNodeByID(to);

            node1.AddEdge(node2);
        }

    }
    
}
