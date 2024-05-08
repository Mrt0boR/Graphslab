using System;

namespace Graphslab
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph theSocialNetwork = new Graph();
            theSocialNetwork.AddNode("Dave");
            theSocialNetwork.AddNode("Anwar");
            theSocialNetwork.AddNode("Hani");
            theSocialNetwork.AddNode("Rob");
            theSocialNetwork.AddNode("Peggy");
            theSocialNetwork.AddNode("Rabia");

            theSocialNetwork.AddEdge("Dave", "Anwar");
            theSocialNetwork.AddEdge("Anwar", "Hani");
            theSocialNetwork.AddEdge("Hani", "Rob");
            theSocialNetwork.AddEdge("Hani", "Peggy");
            theSocialNetwork.AddEdge("Peggy", "Rabia");
            theSocialNetwork.AddEdge("Rob", "Rabia");

            Console.WriteLine("Starting BFS from Dave:");
            theSocialNetwork.BreadthFirstSearch("Dave");
        }
    }
}