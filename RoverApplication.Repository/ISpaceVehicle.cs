using RoverApplication.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoverApplication.Repository
{
    public interface ISpaceVehicle  //Base Class for Vehicle Types
    {


        public void Move(char[] commands);

        public string GetCoordinates();
    }
}
