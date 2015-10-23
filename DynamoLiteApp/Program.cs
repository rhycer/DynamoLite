using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamoLiteApp
{
    class Program
    {
        private Program() { }


        static void Main(string[] args)
        {
            new Program().StartAndLoop();
        }

        private void StartAndLoop() {
            var cr = new CommandRouter();
            var surfaceArea = new TheaterOfOperations(ref cr);
            var surfaceAreaThread = new Thread(() => Application.Run(surfaceArea));
            surfaceAreaThread.Start();

            var stayAlive = true;
            while (stayAlive)
            {
                Console.WriteLine("<==== waiting for next command.");
                foreach (RouterCommand rCommand in Enum.GetValues(typeof(RouterCommand)))
                {
                    Console.WriteLine(string.Format("{0}.  {1}", (int)rCommand, rCommand.ToString()));
                }


                var input = Console.ReadLine();
                switch ((RouterCommand)(System.Convert.ToInt32(input)))
                {
                    case RouterCommand.EXIT:
                        Console.WriteLine("Exit command received.  Please press <enter> to continue.");
                        stayAlive = false;
                        Console.ReadLine();
                        break;
                    case RouterCommand.LAUNCH:
                        cr.LaunchParticipants();
                        break;
                    case RouterCommand.LIST:
                        cr.ListParticipants();
                        break;
                    case RouterCommand.REPORT:
                        cr.ReportStatus();
                        break;
                    default:
                        break;
                }
            }
            Action shutDown = () => surfaceArea.Dispose();
            surfaceArea.Invoke(shutDown);
        }
    }
}
