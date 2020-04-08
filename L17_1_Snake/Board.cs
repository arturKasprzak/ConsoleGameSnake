using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L17_1_Snake
{
    public static class Board
    {
        public static readonly int minRow = 0;
        public static readonly int minColumn = 0;
        public static readonly int maxRow = 25;
        public static readonly int maxColumn = 90;
        
        public static void DrawBoard()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            string space = String.Empty;
            Console.SetCursorPosition(minColumn, minRow);
            Console.Write(space.PadLeft(maxColumn));   // up edge
            Console.SetCursorPosition(minColumn, maxRow);
            Console.Write(space.PadLeft(maxColumn));   // down edge

            for (int i = 1; i < maxRow; i++)
            {
                Console.SetCursorPosition(minColumn, i);      // left edge
                Console.Write(" ");
                Console.SetCursorPosition(maxColumn-1, i);    // right edge
                Console.Write(" ");
            }
            WritePoints(0);
            Console.SetWindowPosition(0, 0);
        }

        public static void WritePoints(int points)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(minColumn+1, maxRow);   
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Result = {0}", points);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
