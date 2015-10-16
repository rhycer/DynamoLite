using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoLiteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var theTable = new SurfaceArea();
            theTable.Show();

            var stayAlive = true;
            do
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
                        Console.ReadLine();
                        stayAlive = false;
                        break;
                    default:
                        
                        break;
                }


            } while (stayAlive);

        }



    }
}
