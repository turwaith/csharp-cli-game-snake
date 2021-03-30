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
            Board game = new Board(18,36);
            bool gameLost = false;
            int originalHeight = Console.WindowHeight;
            int originalWidth = Console.WindowWidth;
            ConsoleKeyInfo userDirection;

            
            game.Draw();
            snake.Draw();
            game.SetApple(snake.Parts);

            do
            {
                while (Console.KeyAvailable == false)
                {
                    snake.Change();
                    snake.Draw();
                    if(game.Collision(snake))                    
                    {
                        gameLost = true;
                        break;
                    }                                   
                    Thread.Sleep(100); // Loop until input is entered.
                }

                if(gameLost)
                    break;
                    
                userDirection = Console.ReadKey(true);

                switch (userDirection.Key)
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
            } while (userDirection.Key != ConsoleKey.Escape && !gameLost); // quit the game
            
            Console.Clear();
            if(gameLost)
            {
            Console.SetCursorPosition(7,3);
            Console.WriteLine($"Lost !!! You got {game.Score} points");
            Console.SetCursorPosition(7,5);
            Console.WriteLine("<press any key to exit>");
            }
            else
            {
                Console.SetCursorPosition(7,3);
                Console.WriteLine("Bye");
            }            
            Console.ReadKey(true);
            Console.SetWindowSize(originalWidth,originalHeight);
            Console.SetBufferSize(originalWidth, originalHeight);
            Console.Clear();        
        }        
    }
}

