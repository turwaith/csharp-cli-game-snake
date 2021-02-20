using System;
using System.Threading;
using System.Collections.Generic;
// using System.Timers;
namespace csharp_game_snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Console.SetWindowSize(150,20);
            //  Console.SetBufferSize(150,20);
            Console.Clear();
            Console.CursorVisible = false;
            Snake snake = new Snake();
            //Console.SetCursorPosition(snake.X, snake.Y);
            Console.CursorVisible = false;
            //Console.Write("O");
           for (int i = 0, size = snake.snake.Count; i < size; i++)
            {
                Console.SetCursorPosition(snake.snake[i].X, snake.snake[i].Y);
                Console.WriteLine("O");
            }

            ConsoleKeyInfo a;

            do
            {
                Console.CursorVisible = false;
                while (Console.KeyAvailable == false)
                {
                    snake.Change();
                    Thread.Sleep(333); // Loop until input is entered.
                }

                a = Console.ReadKey(true);

                switch (a.Key)
                {
                    case ConsoleKey.Z:
                        snake.Move = Direction.Top;
                        break;
                    case ConsoleKey.S:
                        snake.Move = Direction.Bottom;
                        break;
                    case ConsoleKey.Q:
                        snake.Move = Direction.Left;
                        break;
                    case ConsoleKey.D:
                        snake.Move = Direction.Right;
                        break;
                    default:
                        break;
                }

            } while (a.Key != ConsoleKey.X);
        }

        public enum Direction
        {
            Top, Left, Right, Bottom
        }
        public struct Pos
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Pos(int x, int y)
            {
                X = x;
                Y = y;
            }
            public void ChangeX(int x)
            {
                X = x;
            }
            public void ChangeY(int y)
            {
                Y = y;
            }
        }
        public class Snake
        {
            public List<Pos> snake = new List<Pos>();
            public Direction Move;

            public Snake()
            {
                Move = Direction.Right;
                snake.Add(new Pos(5, 5));
                snake.Add(new Pos(4, 5));
            }

            public void Go()
            {

            }

            public void Change()
            {
                Pos flag = snake[0];

                for (int i = 0, size = snake.Count; i < size; i++)
                {
                    if (i == 0)
                    {                        
                        switch (Move)
                        {
                            case Direction.Top:
                                Console.MoveBufferArea(snake[i].X, snake[i].Y, 1, 1, snake[i].X, snake[i].Y - 1);
                                snake[i].ChangeY(snake[i].Y-1);
                                break;
                            case Direction.Bottom:
                                Console.MoveBufferArea(snake[i].X, snake[i].Y, 1, 1, snake[i].X, snake[i].Y + 1);
                                snake[i].ChangeY(snake[i].Y+1);
                                break;
                            case Direction.Right:
                                Console.MoveBufferArea(snake[i].X, snake[i].Y, 1, 1, snake[i].X+1, snake[i].Y);
                                snake[i].ChangeY(snake[i].X+1);
                                break;
                            case Direction.Left:
                                Console.MoveBufferArea(snake[i].X, snake[i].Y, 1, 1, snake[i].X-1, snake[i].Y);
                                snake[i].ChangeY(snake[i].X-1);
                                break;
                        }
                    }
                    else
                    {
                        Console.MoveBufferArea(snake[i].X, snake[i].Y, 1, 1, flag.X, flag.Y);
                        flag = snake[i];
                        snake[i] = flag;
                    }
                }
            }

        }
    }
}

