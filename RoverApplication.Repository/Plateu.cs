using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApplication.Repository
{

    public class Plateu:IPlateu
    {

        public int lengthX{ get; set; }

        public int lengthY { get; set; }

        public Plateu(string sizeCommand)
        {
            try
            {
                var sizeArray = sizeCommand.Split(" ");
                lengthX =Convert.ToInt32(sizeArray[0]);
                lengthY = Convert.ToInt32(sizeArray[1]);
            }
            catch {
                
                Console.WriteLine("Wrong size command");
                throw new InvalidOperationException();
            }

            
        }
    }
}
