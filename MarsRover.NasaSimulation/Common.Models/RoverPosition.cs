namespace MarsRoverNasaSimulation.Common.Models
{
    public class RoverPosition
    {
        public RoverPosition(int xCoor, int yCoor, Direction direction)
        {
            this.CurrentXIndex = xCoor;
            this.CurrentYIndex = yCoor;
            this.Direction = direction;
        }
        public int CurrentXIndex { get; set; }
        public int CurrentYIndex { get; set; }
        public Direction Direction { get; set; }

        /// <summary>
        /// Move forward according to direction increase or decrease current X | Y coordinate.
        /// </summary>
        public void MoveForward()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    CurrentYIndex++;
                    break;
                case Direction.E:
                    CurrentXIndex++;
                    break;
                case Direction.S:
                    CurrentYIndex--;
                    break;
                case Direction.W:
                    CurrentXIndex--;
                    break;
            }
        }
        /// <summary>
        /// Get current direction then decrease direction hashvalue then set new direction value
        /// </summary>
        public void TurnLeft()
        {
            this.Direction = (Direction)((this.Direction.GetHashCode() - 1 + 4) % 4);
        }

        /// <summary>
        /// get currenct direction the increase direction hashvalue then set new direction value
        /// </summary>
        public void TurnRight()
        {
            this.Direction = (Direction)((this.Direction.GetHashCode() + 1) % 4);
        }

        /// <summary>
        /// Override toString method 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Concat(CurrentXIndex, " ", CurrentYIndex, " ", Direction.ToString());
        }
    }
}
