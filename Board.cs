using System;
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

    public void Draw()
    {
        Console.SetWindowSize(cols+3, rows+2);
        Console.SetBufferSize(cols +3, rows+2);
    
        for(int i = 0; i < rows; i++)
        {
            Console.SetCursorPosition(2,i+2);
            for(int j = 0; j  < cols; j++)
            {
                
                if(i == 0 || i == rows-1 || j == 0 || j == cols -1)
                {
                    Console.Write("█");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}