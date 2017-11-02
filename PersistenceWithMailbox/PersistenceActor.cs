using System;
using Akka.Persistence;

namespace PersistenceWithMailbox
{
    public class PersistenceActor : ReceivePersistentActor
    {
        public override string PersistenceId { get; } = "PersistenceActor";

        public PersistenceActor()
        {
            Command<string>(cmd =>
            {
                if (cmd == "error")
                {
                    // force the actor to restart
                    throw new Exception("Dummy. Force the actor to restart.");
                }

                Persist(cmd, _ =>
                {
                    Console.WriteLine($"Persisted: '{cmd}'.");
                });
            });


            Recover<string>(msg =>
            {
                Console.WriteLine($"RECOVERING Event: '{msg}'");
            });

        }
    }
}