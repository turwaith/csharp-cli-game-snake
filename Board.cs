using System;
using System.Collections.Generic;
class Board
{
    int rows;
    int cols;

    int windowX;
    int windowY;
    public Board(int rows, int cols)
    {
        this.rows = rows < Console.LargestWindowHeight ? rows : Console.LargestWindowHeight - 5;
        this.cols = cols < Console.LargestWindowWidth ? cols : Console.LargestWindowWidth -5;
        windowX = rows + 2;
        windowY = cols + 2;
    }

    public void SetApple(List<Pos> parts)
    {
        Random rand = new Random();
        int x = rand.Next(3, cols - 2), 
            y = rand.Next(3, rows - 2);;
        bool xDiff = true, yDiff = true;

        while(true)
        {
            
            for(int i = 0, size =parts.Count; i < size; i++)
            {
                if(x == parts[i].X)
                {
                    x = rand.Next(3,cols -2);
                    xDiff = false;
                }
                else{
                    xDiff = true;
                }
            }
            for(int i = 0, size = parts.Count; i < size; i++)
            {
                if(y == parts[i].Y)
                {
                    y = rand.Next(3,rows-2);
                    yDiff = false;
                }else
                {
                    yDiff = true;
                }
            }
            if(xDiff && yDiff)
            {
                break;
            }
        }
        Console.SetCursorPosition(x,y);
        Console.Write("a");

    }
    public void Draw()
    {
        Console.SetWindowSize(cols+3, rows+2);
        Console.SetBufferSize(cols +3, rows+2);
    
        for(int i = 0; i < rows; i++)
        {
            Console.SetCursorPosition(2,i+2);
            for(int j = 0; j  < cols; j++)
            {
                if(i == 0)
                    Console.Write("▄");
                else if(i == rows-1)
                    Console.Write("▀");
                else if(j == 0 || j == cols -1)
                    Console.Write("█");
                else                
                    Console.Write(" ");
                
            }
            Console.WriteLine();
        }
    }
}