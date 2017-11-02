using Akka.Actor;
using Akka.Configuration;
using Akka.Dispatch;

namespace PersistenceWithMailbox
{
    public class PersistenceActorMailBox : UnboundedPriorityMailbox
    {
        public PersistenceActorMailBox(Settings settings, Config config) : base(settings, config)
        {
        }

        protected override int PriorityGenerator(object message)
        {
            return 0;
        }
    }
}