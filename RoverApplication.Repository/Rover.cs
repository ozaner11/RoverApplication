using RoverApplication.Repository.Enums;
using System;

namespace RoverApplication.Repository
{
    public class Rover :ISpaceVehicle  //Rover inherited from SpaceVehicle
    {
        private int _x { get; set; }

        private int _y { get; set; }

        private DirectionEnum _direction { get; set; }

        private IPlateu _plateu { get; set; }

        public Rover(IPlateu plateu, string startPosition)
        {
            var coordinates = startPosition.Split(" ");
            _x = Convert.ToInt32(coordinates[0]);
            _y = Convert.ToInt32(coordinates[1]);
            Enum.TryParse(coordinates[2], out DirectionEnum direction);
            _direction = direction;
            _plateu = plateu;
        }
        public string GetCoordinates() {

            return String.Format("{0} {1} {2}"
                , _x, _y, _direction.ToString());
        
        }
        public void Move(char[] commands) //Rover Movement according to commands
        {
            foreach (char command in commands)
            {
                int tempx = _x;
                int tempy = _y;
                var indDir = (int)_direction;
                if (command == (char)MovementEnum.L)
                {

                    if (indDir - 1 < (int)DirectionEnum.W)   //Movement according to compass
                    {
                        _direction = DirectionEnum.S;
                    }
                    else
                    {
                        indDir--;
                        _direction = (DirectionEnum)indDir;
                    }

                }
                else if (command == (char)MovementEnum.R)
                {
                    if (indDir + 1 > (int)DirectionEnum.S)
                    {
                        _direction = DirectionEnum.W;
                    }
                    else
                    {
                        indDir++;
                        _direction = (DirectionEnum)indDir;
                    }

                }
                else if (command == (char)MovementEnum.M)   //Movement and changing grid position
                {
                    switch (_direction)                
                    {
                        case DirectionEnum.W:
                            _x--;
                            break;

                        case DirectionEnum.N:
                           _y++;
                            break;
                        case DirectionEnum.E:
                            _x++;
                            break;

                        case DirectionEnum.S:
                            _y--;
                            break;

                        default:
                            Console.WriteLine("Wrong Command");
                            throw  new InvalidOperationException();
                            
                    }

                }
                CheckBounds(tempx, tempy); // Controls if rover is in the bounds

            }

        }
        private void CheckBounds(int beforeX,int beforeY) {

            //Restore previous situation if there is bound limit
            if (_x < 0 || _x > _plateu.lengthX)
            {
                _x = beforeX;
            }
            if (_y < 0 || _y > _plateu.lengthY)
            {
                _y = beforeY;
            }

        }
    }
}
