using System;
using System.Collections.Generic;
class Board
{
    int Rows {get; set;}
    int Cols {get; set;}
    Pos Apple = new Pos(0,0);
    public int Score = 0;
    public Board(int Rows, int Cols)
    {
        this.Rows = Rows < Console.LargestWindowHeight ? Rows+4 : Console.LargestWindowHeight - 5;
        this.Cols = Cols < Console.LargestWindowWidth ? Cols+4 : Console.LargestWindowWidth -5;
    }

    public void SetApple(List<Pos> parts)
    {
        Random rand = new Random();
        int x = rand.Next(3, Cols - 2), 
            y = rand.Next(3, Rows - 2);;
        bool xDiff = true, yDiff = true;

        while(xDiff && yDiff)
        {
            
            for(int i = 0, size =parts.Count; i < size; i++)
            {
                if(x == parts[i].X)                
                    x = rand.Next(3,Cols -2);              
                else                    
                    xDiff = false;                
            }
            for(int i = 0, size = parts.Count; i < size; i++)
            {
                if(y == parts[i].Y)                
                    y = rand.Next(3,Rows-2);
                else
                    yDiff = false;                
            }
        }
        Apple.X = x;
        Apple.Y = y; 
        Console.SetCursorPosition(x,y);
        Console.Write("@");

    }
    public void Draw()
    {
        Console.SetWindowSize(Cols+2, Rows+2);
        Console.SetBufferSize(Cols+2, Rows+2);
        // Console.SetCursorPosition(10,10);
        // Console.WriteLine("Snake");
        // Console.ReadKey(true);
        for(int i = 0; i < Rows; i++)
        {
            Console.SetCursorPosition(0,i);
            for(int j = 0; j  < Cols; j++)
            {
                if(i == 0)
                    Console.Write("▄");
                else if(i == Rows-1)
                    Console.Write("▀");
                else if(j == 0 || j == Cols -1)
                    Console.Write("█");
                else                
                    Console.Write(" ");
                
            }
            // Console.WriteLine();
             
        }
        Console.WriteLine("\nScore:");
    }
    public bool Collision(Snake snake)
    {
        if(snake.Parts[0].Equals(Apple))
        {
            Score++;
            SetApple(snake.Parts);
            Console.SetCursorPosition(7,Rows);
            Console.WriteLine(Score);
            snake.Parts.Add(new Pos(snake.Parts.Count-1, snake.Parts.Count));
            return false;
        }
        else if(snake.Parts[0].X.Equals(0) ||
                snake.Parts[0].Y.Equals(0) ||
                snake.Parts[0].X.Equals(Cols-1) ||
                snake.Parts[0].Y.Equals(Rows-1))        
            return true;
        else
            return false;
    }
}