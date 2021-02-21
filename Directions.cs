   public enum Direction
    {
        Top, Left, Right, Bottom
    }
     public struct Pos
    {
        public  int X {get;  set; }
        public int Y { get; set; }

        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }
    public override string ToString()
    {
        return $"x:{X} - y:{Y}";
    }

        public void ToTop()
        {
            X--;
        }
        public void ToRight()
        {
            Y++;
        }
        public void ToBottom()
        {
            X++;
        }
        public void ToLeft()
        {
            Y--;
        }
    }