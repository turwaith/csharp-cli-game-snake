using System;
using System.Collections.Generic;
public class Snake
{
    public List<Pos> Parts = new List<Pos>();
    public Direction Move;

    public Snake()
    {
        Move = Direction.Right;
        Parts.Add(new Pos(5, 5));
        Parts.Add(new Pos(4, 5));
        Parts.Add(new Pos(3, 5));
    }

    public void Draw()
    {
        for (int i = 0, size = Parts.Count; i < size; i++)
        {
            Console.SetCursorPosition(Parts[i].X, Parts[i].Y);
            Console.WriteLine("O");
        }
    }

    public void Change()
    {
        Pos flag = Parts[0];

        for (int i = 0, size = Parts.Count; i < size; i++)
        {
            if (i == 0)
            {
                switch (Move)
                {
                    case Direction.Top:
                        Console.MoveBufferArea(Parts[i].X, Parts[i].Y, 1, 1, Parts[i].X, Parts[i].Y - 1);
                        Parts[i] = new Pos( Parts[i].X, Parts[i].Y - 1);
                        break;
                    case Direction.Bottom:
                        Console.MoveBufferArea(Parts[i].X, Parts[i].Y, 1, 1, Parts[i].X, Parts[i].Y + 1);
                        Parts[i] = new Pos(  Parts[i].X, Parts[i].Y + 1);
                        break;
                    case Direction.Right:
                        Console.MoveBufferArea(Parts[i].X, Parts[i].Y, 1, 1, Parts[i].X + 1, Parts[i].Y);
                        Parts[i] = new Pos( Parts[i].X + 1, Parts[i].Y);
                        break;
                    case Direction.Left:
                        Console.MoveBufferArea(Parts[i].X, Parts[i].Y, 1, 1, Parts[i].X - 1, Parts[i].Y);
                        Parts[i] = new Pos(  Parts[i].X - 1, Parts[i].Y);
                        break;
                }
            }
            else
            {
                Console.MoveBufferArea(Parts[i].X, Parts[i].Y, 1, 1, flag.X, flag.Y);
                Pos temp = Parts[i];
                Parts[i] = flag;
                flag = temp;

            }
        }
    }
}
