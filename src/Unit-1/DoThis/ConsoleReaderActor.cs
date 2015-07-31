using Akka.Actor;
using System;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for reading FROM the console.
    /// Also responsible for calling <see cref="ActorSystem.Shutdown"/>.
    /// </summary>
    internal class ConsoleReaderActor : UntypedActor
    {
        public const string ExitCommand = "exit";
        public const string StartCommand = "start";
        private IActorRef _validationActor;

        public ConsoleReaderActor(IActorRef validationActor)
        {
            _validationActor = validationActor;
        }

        protected override void OnReceive(object message)
        {
            if (message.Equals(StartCommand))
            {
                DoPrintInstructions();
            }

            GetAndValidateInput();
        }

        private void GetAndValidateInput()
        {
            var message = Console.ReadLine();
            if (!string.IsNullOrEmpty(message) && String.Equals(message, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                Context.System.Shutdown();
                return;
            }

            _validationActor.Tell(message);
        }

        private void DoPrintInstructions()
        {
            Console.WriteLine("Please provide the URI of a log file on disk.\n");
        }
    }
}
