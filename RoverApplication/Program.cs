using RoverApplication.Repository;
using System;

namespace RoverApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            TakeParameters();
          
        }

        static void TakeParameters() {

            try
            {
                Console.WriteLine("Enter plateau size: ");
                var size = Console.ReadLine();
                Plateu plateu = new Plateu(size);
                Console.WriteLine("Enter rover 1 position: ");
                var pos1 = Console.ReadLine();
                Console.WriteLine("Enter rover 1 commands: ");
                var com1 = Console.ReadLine();
                Rover rover1 = new Rover(plateu, pos1.ToUpper()); //Build Rover 1
                Console.WriteLine("Enter rover 2 position: ");
                var pos2 = Console.ReadLine();
                Console.WriteLine("Enter rover 2 commands: ");
                var com2 = Console.ReadLine();
                Rover rover2 = new Rover(plateu, pos2.ToUpper()); //Build Rover 2

                //Move Rovers
                rover1.Move(com1.ToUpper().ToCharArray());
                rover2.Move(com2.ToUpper().ToCharArray());

                //Print Rovers Positions
                Console.WriteLine("Rover 1 :" + rover1.GetCoordinates());
                Console.WriteLine("Rover 2 :" + rover2.GetCoordinates());

                Console.Read();
            }
            catch {
                Console.WriteLine("an error occurred.Press Y to start again /n");
                if (((ConsoleKeyInfo)Console.ReadKey()).Key == ConsoleKey.Y)
                {
                    TakeParameters();
                }
            }

        }
    }
}
