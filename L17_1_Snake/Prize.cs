using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L17_1_Snake
{
    class Prize
    {
        public int Value { get; private set; }
        public Point position = new Point();

        public Prize()
        {
            Random generate = new Random();
            this.Value = generate.Next(0, 9);
            position.X = generate.Next(Board.minColumn + 1, Board.maxColumn - 2);
            position.Y = generate.Next(Board.minRow + 1, Board.maxRow - 1);
        }
        public void ShowPrize()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.SetCursorPosition(position.X, position.Y);
            if (this.Value == 0)  
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.Value);
            Console.ForegroundColor = color;
        }
        public void ClearPrize()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
        }
    }
}
