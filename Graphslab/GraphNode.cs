using System.Collections.Generic;

namespace Graphslab
{
    public class GraphNode
    {
        private string id;  // Identifier for the graph node.
        private LinkedList<string> adjList;  // Adjacency list to hold IDs of connected nodes.
        public bool Visited { get; set; }  // Property to check if the node has been visited.

        // Constructor initializes the graph node with a unique identifier.
        public GraphNode(string id)
        {
            this.id = id;
            adjList = new LinkedList<string>();  // Initialize the adjacency list.
            Visited = false;  // Initially, the node is not visited.
        }

        public string ID
        {
            get { return id; }  // Getter for the node's identifier.
        }

        // Adds a directed edge to another node.
        public void AddEdge(GraphNode to)
        {
            adjList.AddLast(to.ID);  // Append the identifier of the destination node to the adjacency list.
        }

        // Retrieves the adjacency list of the node.
        public LinkedList<string> GetAdjList()
        {
            return adjList;  // Return the list of adjacent node identifiers.
        }
    }
}
