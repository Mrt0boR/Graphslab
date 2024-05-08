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
            id = id.ToLower();
            foreach (var node in nodes)
            {
                if (node.ID.ToLower() == id)
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

        
        public void BreadthFirstSearch(string startId)
        {
            /* This ensures the startId is found even if the method is called and the name isnt exactly as stored 
             * e.g Node is Anwar - method calls startId as "anwar" or even "aNwAr"
             */
            startId = startId.ToLower(); 

            //find the start node id and assign to a graphnode object
            GraphNode startNode = GetNodeByID(startId);
            if (startNode == null)
            {
                Console.WriteLine("Start node not found.");
                return;
            }

            //List to store proccessed nodes once they have been Dequeued and their ID added to the list
            List<GraphNode> proccessedList = new List<GraphNode>();  

            //Queue tp store nodes awaiting processing, once proccessed they are dequeued and added to the proccessed list
            Queue<GraphNode> proccessingQueue = new Queue<GraphNode>();  

            proccessingQueue.Enqueue(startNode);  // Enqueue the start node immedietly into the proccessing queue to it isnt skipped.

            while (proccessingQueue.Count > 0)  // While there are nodes left to proccess in the queue,
            {
                GraphNode current = proccessingQueue.Dequeue();  // Dequeue the next node and asign it to a graphnode obj called current

                if (!proccessedList.Contains(current))
                {
                    proccessedList.Add(current);  // if the current and recently dequeued node is not already in the proccessed list, add it.
                    

                    foreach (string adjId in current.GetAdjList())  // find the Ids of all the nodes adjacent to current once it has been addded successfully.
                    {
                        //once an ajdcent node found from the list of adjacent nodes, find its Id.
                        GraphNode adjNode = GetNodeByID(adjId);

                        // if the adjNode with adjId is not contained within the processed list then add it to the proccessing queue, then repeat the loop until the queue count is 0
                        // this check ensures the while loop does not go on forever, as eventually an adjacent node will be found which is already in the proccessed list, breaking the queue.
                        if (!proccessedList.Contains(adjNode))
                        {
                            proccessingQueue.Enqueue(adjNode);
                        }
                    }
                }
            }
            
            //iterate through the list, printing all the nodes that have been added.
            // < rather than <= because there will be a 0 index so a processed list of 10 members should have 9 iterations as 0 is an index.
            for (int i = 0; i < proccessedList.Count; i++)
            {
                Console.WriteLine(proccessedList[i].ID);
            }
        }

        //This is essentially an edited bredth first search method.
        //Bool as double traversal is either true or false, yes or no, this specifies this as a result of the method.
        public bool doubleTraversePossible(string startId, string endId)
        {

            GraphNode startNode = GetNodeByID(startId);
            GraphNode endNode = GetNodeByID(endId);
            
            if (startNode == null && endId == null)
            {
                Console.WriteLine("Start or end node not found.");
                return false;
            }

            List<GraphNode> proccessedList = new List<GraphNode>();  // List to store visited nodes.
            Queue<GraphNode> nodeProccessingQueue = new Queue<GraphNode>();  // Queue for nodes to visit.

            nodeProccessingQueue.Enqueue(startNode);  // Enqueue the start node.

            while (nodeProccessingQueue.Count > 0)  // While there are nodes left to visit,
            {
                GraphNode current = nodeProccessingQueue.Dequeue();  // Dequeue the next node.

                if (current.ID == endId) //if the end node has been reached through the process of the while loop
                {
                    Console.WriteLine("double Traversal possible between " + startId + " and " + endId);
                    Console.WriteLine(endId + " is a friend of a friend of " + startId);
                    return true;
                    
                }
                if (!proccessedList.Contains(current))
                {
                    proccessedList.Add(current);  // Add the current node to visited.
                      



                    // Loop through each adjacent node ID of the current node that has just been added to the proccessedList.
                    foreach (string adjId in current.GetAdjList())  
                    {

                       //Use the GraphNodeObject and assign it to the id of the ajacent node attached to the current node just added to the processedList
                        GraphNode adjNode = GetNodeByID(adjId);


                        // if the adjNode is NOT in the vistedList then it still needs to be processed, so it is enqueued
                        // if the node ajecent to the current and recently processed node IS IN the processedList then this is skipped and the final return is called
                        if (!proccessedList.Contains(adjNode))
                        {
                            nodeProccessingQueue.Enqueue(adjNode);
                        }

                    }
                }
            }

            //no connection between separate nodes despite both start and end IDs being valid string entries
            Console.WriteLine("double Traversal not possible between " + startId + " and " + endId);
            Console.WriteLine(startId + " is not friend of " + endId);
            return false;
        }
    }
}
