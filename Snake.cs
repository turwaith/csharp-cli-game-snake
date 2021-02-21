using System;
using System.Collections.Generic;
public class Snake
{
    public List<Pos> parts = new List<Pos>();
    public Direction Move;

    public Snake()
    {
        Move = Direction.Right;
        parts.Add(new Pos(5, 5));
        parts.Add(new Pos(4, 5));
        parts.Add(new Pos(3, 5));
    }

    public void Draw()
    {
        for (int i = 0, size = parts.Count; i < size; i++)
        {
            Console.SetCursorPosition(parts[i].X, parts[i].Y);
            Console.WriteLine("O");
        }
    }

    public void Change()
    {
        Pos flag = parts[0];

        for (int i = 0, size = parts.Count; i < size; i++)
        {
            if (i == 0)
            {
                switch (Move)
                {
                    case Direction.Top:
                        Console.MoveBufferArea(parts[i].X, parts[i].Y, 1, 1, parts[i].X, parts[i].Y - 1);
                        parts[i] = new Pos( parts[i].X, parts[i].Y - 1);
                        break;
                    case Direction.Bottom:
                        Console.MoveBufferArea(parts[i].X, parts[i].Y, 1, 1, parts[i].X, parts[i].Y + 1);
                        parts[i] = new Pos(  parts[i].X, parts[i].Y + 1);
                        break;
                    case Direction.Right:
                        Console.MoveBufferArea(parts[i].X, parts[i].Y, 1, 1, parts[i].X + 1, parts[i].Y);
                        parts[i] = new Pos( parts[i].X + 1, parts[i].Y);
                        break;
                    case Direction.Left:
                        Console.MoveBufferArea(parts[i].X, parts[i].Y, 1, 1, parts[i].X - 1, parts[i].Y);
                        parts[i] = new Pos(  parts[i].X - 1, parts[i].Y);
                        break;
                }
            }
            else
            {
                Console.MoveBufferArea(parts[i].X, parts[i].Y, 1, 1, flag.X, flag.Y);
                Pos temp = parts[i];
                parts[i] = flag;
                flag = temp;

            }
        }
    }
}
