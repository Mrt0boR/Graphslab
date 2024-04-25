using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphslab
{
    public class GraphNode
    {
        private int id;

        private LinkedList<int> adjList; //list of IDs of the nodes that are adjacent to the current node



        //constructor of GraphNode which outines the properties of a graphnode object

        public GraphNode(int id)
        {
            this.id = id;

            //lists are used to represent the edges which are attached to the node.
            //as long as the id of the node is included in the list it means there
            //is at least one edge between these two nodes
            adjList = new LinkedList<int>();
        }

        //getters and setters for an ID
        public int ID
        {
            set { id = value; }
            get {  return id; }
        }

        //this adds edges to allow the connections between the node
        // this would be applied to a speficic node and use to tie it from node 1 to node 2.
        public void AddEdge(GraphNode to)
        {
            adjList.AddLast(to.ID);
        }

        //return the adj list of the node

        public LinkedList<int> GetAdjList()
        { 
            //return the adjacent list of the node (adjacent meaning close to / near something else)
            return adjList; 
        
        }

    }
}
