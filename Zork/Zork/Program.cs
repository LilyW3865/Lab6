using System;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;

            while(command != Commands.QUIT)
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case "QUIT":
                        command = command.QUIT;
                        break;

                    case "LOOK":
                        command = command.LOOK;
                        break;

                    case "NORTH":
                        command = command.NORTH;
                        break;

                    case "SOUTH":
                        command = command.SOUTH;
                        break;

                    case "EAST":
                        command = command.EAST;
                        break;

                    case "WEST":
                        command = command.WEST;
                        break;

                    default:
                        command = command.UNKNOWN;
                        break;
                }

                Console.WriteLine(outputString);

            }
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

    }
}
