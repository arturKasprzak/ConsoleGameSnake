using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace L17_1_Snake
{
    static class Game
    {
        static bool gameContinues = true;
        static DateTime start = DateTime.Now;
        static Prize prize = new Prize();
        static int points = 0;

        public static void NewGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            gameContinues = true;
            points = 0;
            Board.DrawBoard();
            Snake.CreateSnake();
            prize.ShowPrize();
            Play();
        }

        private static void Play()
        {
            while (gameContinues)
            {
                LoadKey();
                if (!gameContinues) break;
                NewPrize();
                DidSnakeEat();
                if (!gameContinues) break;
                SnakeGo();
                if (!gameContinues) break;
                EatPrize();
                Thread.Sleep(100);         
            }
        }

        private static void DidSnakeEat()
        {
            if (Snake.DidSnakeEat())
            {
                GameOver();
            }
        }

        private static void EatPrize()
        {
            if (Snake.IsItHere(prize.position))
            {
                if (prize.Value == 0)   // punishment
                {
                    Snake.CleanSnake();
                    Snake.CreateSnake();
                    points = 0;
                }
                else                        // real proze
                {
                    points += prize.Value;
                    Snake.SnakeElongation();
                }
                Board.WritePoints(points);
                prize = new Prize();
                prize.ShowPrize();
            }
        }

        private static void NewPrize()
        {
            if (start <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
            {
                prize.ClearPrize();
                start = DateTime.Now;
                prize = new Prize();
                prize.ShowPrize();
            }
        }

        private static void SnakeGo()
        {
            if (!Snake.MoveSnake())
            {
                GameOver();
            }
        }

        private static void GameOver()
        {
            gameContinues = false;
            ConsoleColor color = Console.ForegroundColor;
            Console.SetCursorPosition(Board.minColumn+40, Board.minRow + 15);   
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Game over!!!");
            Console.ForegroundColor = color;
            Console.ReadKey();
            Snake.CleanSnake();
        }

        private static void LoadKey()
        {
            if (Console.KeyAvailable)   // stream input
            {
                ConsoleKeyInfo pushbutton = Console.ReadKey(true);   // read key
                
                // Push "left"
                if (pushbutton.Key == ConsoleKey.LeftArrow &&
                    Snake.whereTurn != Direction.right) 
                {
                    Snake.whereTurn = Direction.left;
                }
                // Push "right
                if (pushbutton.Key == ConsoleKey.RightArrow &&
                    Snake.whereTurn != Direction.left)
                {
                    Snake.whereTurn = Direction.right;
                }
                // Push "up"
                if (pushbutton.Key == ConsoleKey.UpArrow &&
                    Snake.whereTurn != Direction.down)
                {
                    Snake.whereTurn = Direction.up;
                }
                // Push "down"
                if (pushbutton.Key == ConsoleKey.DownArrow && 
                    Snake.whereTurn != Direction.up)
                {
                    Snake.whereTurn = Direction.down;
                }
                // Push "Escape - the end"
                if (pushbutton.Key == ConsoleKey.Escape)
                {
                    GameOver();
                }
                // clear up
                while (Console.KeyAvailable) { Console.ReadKey(true); }
            }
        }
    }
}
