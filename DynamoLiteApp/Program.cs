using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var surfaceArea = new SurfaceArea();
            var surfaceAreaThread = new Thread(() => Application.Run(surfaceArea));
            surfaceAreaThread.Start();

            var stayAlive = true;
            while (stayAlive)
            {
                Console.WriteLine("<==== waiting for next command.");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "LIST":
                        Console.WriteLine("LIST command recieved.");
                        break;
                    case "xXx":
                        Console.WriteLine("exit command recieved.  please press <enter> to continue;");
                        stayAlive = false;
                        Console.ReadLine();
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
