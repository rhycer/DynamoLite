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
                var input = Console.ReadLine();
                var commandParts = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var commandPart = commandParts[0];
                var commandParms = commandParts.Skip(1).ToArray();
                switch (input)
                {
                    case "LIST":
                        cr.ListParticipants();
                        break;
                    case "LAUNCH":
                        cr.LaunchParticipants();
                        break;
                    case "xXx":
                        Console.WriteLine("exit command recieved.  please press <enter> to continue;");
                        stayAlive = false;
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            Action shutDown = () => surfaceArea.Dispose();
            surfaceArea.Invoke(shutDown);
        }
    }
}
