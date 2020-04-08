using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L17_1_Snake
{
    static class Menu
    {
        public static void StartMenu()
        {
            Console.Title = "Game Snake";
            Console.SetWindowSize(Board.maxColumn, Board.maxRow + 3);
            Console.SetBufferSize(Board.maxColumn, Board.maxRow + 5);
            
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(Board.minColumn+25, Board.minRow+5);
                Console.Write(">>> G a m e    S n a k e <<<");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(Board.minColumn + 35, Board.minRow + 8);
                Console.Write("S - Start game");
                Console.SetCursorPosition(Board.minColumn + 35, Board.minRow + 11);
                Console.Write("E - Exit");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo pushbutton = Console.ReadKey();
                switch (pushbutton.Key)
                {
                    case ConsoleKey.S:
                        Console.Clear();
                        Game.NewGame();
                        break;
                    case ConsoleKey.Escape:
                    case ConsoleKey.E:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
