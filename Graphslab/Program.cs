using System;

namespace Graphslab
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling and creating the graph struc
            Graph theSocialNetwork = new Graph();
            
            //Node creation
            theSocialNetwork.AddNode("Dave");
            theSocialNetwork.AddNode("Anwar");
            theSocialNetwork.AddNode("Haniy");
            theSocialNetwork.AddNode("Rob");
            theSocialNetwork.AddNode("Peggy");
            theSocialNetwork.AddNode("Rabia");


            //Connecting the nodes with one way edges. I worked on each name individually untill all thier connections were exhausted working outside and then in.
            theSocialNetwork.AddEdge("Anwar", "Dave");
            
            theSocialNetwork.AddEdge("Anwar", "Rob");
            
            theSocialNetwork.AddEdge("Dave", "Peggy");

            theSocialNetwork.AddEdge("Peggy", "Rob");

            theSocialNetwork.AddEdge("Peggy", "Rabia");
            
            theSocialNetwork.AddEdge("Rabia", "Anwar");

            theSocialNetwork.AddEdge("Rob", "Haniy");


            //Breadth first search call
            Console.WriteLine("Starting BFS:");
            theSocialNetwork.BreadthFirstSearch("anwar");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Double Traversal #1" + "\n");

            //Return true double traversal - xID is a friend of a friend of yID
            theSocialNetwork.doubleTraversePossible("Anwar", "Peggy");
            Console.WriteLine();
            Console.WriteLine();


            //Return false double traversal -xID is not a friend of a friend of yID
            Console.WriteLine("Double Traversal 2" + "\n");
           
            theSocialNetwork.doubleTraversePossible("Haniy", "Dave");
            //readkey so the window stays open until a key is pressed
            Console.ReadKey();
        }
    }
}