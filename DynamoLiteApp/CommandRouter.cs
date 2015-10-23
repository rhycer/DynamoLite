using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoLiteApp
{
    public class CommandRouter
    {
        public void ListParticipants()
        {
            Console.WriteLine("LIST command recieved.");
            
        }

        public void LaunchParticipants()
        {
            Console.WriteLine("LAUNCH command recieved.");
            var parts = Console.ReadLine();
            int? units = parts.IntFromString();
            if (!units.HasValue)
            {

            }
        }

        public void ReportStatus()
        {
            Console.WriteLine("REPORT command recieved.");
            var parts = Console.ReadLine();
        }


        public void InteractWith()
        {

        }


        private IObservable<Participant> _participants;




    }
}
