using System;
using Akka.Actor;

namespace PersistenceWithMailbox
{
    internal class Program
    {
        private static void Main()
        {
            var system = ActorSystem.Create("PersistenceWithMailbox");

            var actor = system.ActorOf(Props.Create<PersistenceActor>());

            // replace with the following to reproduce the issue.
            //var actor = system.ActorOf(Props.Create<PersistenceActor>().WithMailbox("PersistenceActorMailBox"));

            actor.Tell("A");
            actor.Tell("B");
            actor.Tell("C");

            Console.WriteLine("Press Enter to simulate an exception.");
            Console.ReadLine();
            actor.Tell("error");

            Console.ReadLine();
        }
    }
}
