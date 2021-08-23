namespace LangtonsAnt
{
    public class SimulationModel
    {
        public int XPos;
        public int YPos;
        public Direction Dir;
        public List<List<Color>> Playground = new List<List<Color>>();
        public enum Direction
        {
            down,
            up,
            left,
            right
        }
        public enum Color
        {
            black,
            white
        }

        public SimulationModel(int xPos, int yPos, int width, int height, bool randomize)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.Dir = Direction.left;
            this.InitializeGrid(randomize, width, height);
        }

        public void InitializeGrid(bool randomize, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                this.Playground.Add(new List<Color>());
                for (int y = 0; y < height; y++)
                {
                    var color = Color.white;
                    if (randomize)
                    {
                        color = Convert.ToBoolean(new Random().Next(2)) ? Color.white : Color.black;

                    }
                    this.Playground[x].Add(color);
                }
            }
        }
    }
}

