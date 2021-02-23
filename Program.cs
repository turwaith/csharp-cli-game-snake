using System;
using System.Threading;
namespace csharp_game_parts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Snake snake = new Snake();
            Board game = new Board(30, 60);
            int originalHeight = Console.WindowHeight;
            int originalWidth = Console.WindowWidth;
            ConsoleKeyInfo a;

            game.Draw();
            snake.Draw();
            game.SetApple(snake.parts);

            do
            {
                while (Console.KeyAvailable == false)
                {
                    snake.Change();
                    Thread.Sleep(333); // Loop until input is entered.
                }

                a = Console.ReadKey(true);

                switch (a.Key)
                {
                    case ConsoleKey.Z:
                        if(snake.Move != Direction.Bottom)
                            snake.Move = Direction.Top;
                        break;
                    case ConsoleKey.S:
                        if(snake.Move != Direction.Top)
                            snake.Move = Direction.Bottom;
                        break;
                    case ConsoleKey.Q:
                        if(snake.Move != Direction.Right)
                            snake.Move = Direction.Left;    
                        break;
                    case ConsoleKey.D:
                        if(snake.Move != Direction.Left)
                            snake.Move = Direction.Right;
                        break;
                    default:
                        break;
                }
            } while (a.Key != ConsoleKey.Escape); // quit the game
            
            Console.SetWindowSize(originalWidth,originalHeight);
            Console.SetBufferSize(originalWidth, originalHeight);
            Console.Clear();        
        }        
    }
}

