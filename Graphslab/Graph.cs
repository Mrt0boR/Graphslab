using System;
using System.Collections.Generic;

namespace Graphslab
{
    class Graph
    {
        private LinkedList<GraphNode> nodes;
        private int edgeCount;
        public Graph()
        {
            nodes = new LinkedList<GraphNode>();
            edgeCount = 0;
        }

        public void AddNode(string id)
        {
            nodes.AddLast(new GraphNode(id));
        }

        public GraphNode GetNodeByID(string id)
        {
            foreach (var node in nodes)
            {
                if (node.ID == id)
                {
                    return node;
                }
            }
            return null;
        }

        public void AddEdge(string from, string to)
        {
            GraphNode node1 = GetNodeByID(from);
            GraphNode node2 = GetNodeByID(to);
            if (node1 != null && node2 != null)
            {
                node1.AddEdge(node2);
            }
        }

        public int NodeCount()
        {
            return nodes.Count;
        }

        public int EdgeCount()
        {
            return edgeCount;
        }

        // BFS method revised to closely match the provided pseudocode.
        public void BreadthFirstSearch(string startId)
        {
            GraphNode startNode = GetNodeByID(startId);
            if (startNode == null)
            {
                Console.WriteLine("Start node not found.");
                return;
            }

            List<GraphNode> visited = new List<GraphNode>();  // List to store visited nodes.
            Queue<GraphNode> toVisit = new Queue<GraphNode>();  // Queue for nodes to visit.

            toVisit.Enqueue(startNode);  // Enqueue the start node.

            while (toVisit.Count > 0)  // While there are nodes left to visit,
            {
                GraphNode current = toVisit.Dequeue();  // Dequeue the next node.

                if (!visited.Contains(current))
                {
                    visited.Add(current);  // Add the current node to visited.
                    Console.WriteLine("Visited Node: " + current.ID);  // Output the ID of the visited node.

                    foreach (string adjId in current.GetAdjList())  // For each adjacent node ID,
                    {
                        GraphNode adjNode = GetNodeByID(adjId);
                        // Only enqueue if not visited and not already in the queue.
                        if (!visited.Contains(adjNode) && !toVisit.Contains(adjNode))
                        {
                            toVisit.Enqueue(adjNode);
                        }
                    }
                }
            }
        }

        public bool doubleTraversePossible(string startId, string endId)
        {

            GraphNode startNode = GetNodeByID(startId);
            GraphNode endNode = GetNodeByID(endId);
            if (startNode == null && endId == null)
            {
                Console.WriteLine("Start or end node not found.");
                return false;
            }

            List<GraphNode> visited = new List<GraphNode>();  // List to store visited nodes.
            Queue<GraphNode> toVisit = new Queue<GraphNode>();  // Queue for nodes to visit.

            toVisit.Enqueue(startNode);  // Enqueue the start node.

            while (toVisit.Count > 0)  // While there are nodes left to visit,
            {
                GraphNode current = toVisit.Dequeue();  // Dequeue the next node.

                if (current.ID == endId) //if the end node has been reached through the process of the while loop
                {
                    return true;
                }
                if (!visited.Contains(current))
                {
                    visited.Add(current);  // Add the current node to visited.
                    Console.WriteLine("Visited Node: " + current.ID);  // Output the ID of the visited node.

                    foreach (string adjId in current.GetAdjList())  // For each adjacent node ID,
                    {
                        GraphNode adjNode = GetNodeByID(adjId);
                        // Only enqueue if not visited and not already in the queue.
                        if (!visited.Contains(adjNode) && !toVisit.Contains(adjNode))
                        {
                            toVisit.Enqueue(adjNode);
                        }
                    }
                }
            }
            return false;
        }
    }
}
