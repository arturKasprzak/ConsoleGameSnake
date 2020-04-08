using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L17_1_Snake
{
    public class Snake
    {
        private static LinkedList<Point> bodySnake = new LinkedList<Point>();
        public static Direction whereTurn;    // Direction snake

        public static void CreateSnake()
        {
            for (int i = 1; i < 5; i++)
            {
                bodySnake.AddFirst(new Point(i, Board.minRow+6));
            }
            whereTurn = Direction.right;
            DrawSnake();
        }
       
        public static void DrawPoint(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write("*");
        }
        public static void DrawSnake()
        {
            foreach (Point point in bodySnake)
            {
                DrawPoint(point);
            }
        }
        public static void ClearPoint(Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(" ");
        }
        public static void CleanSnake()
        {
            foreach (Point point in bodySnake)
            {
                ClearPoint(point);   // Clear snake on the screen
            }
            bodySnake.Clear();         // Clear list
        }

        private static void SetMoveForHeadSnake(ref int inVertical, ref int inHorizontal)
        {
            if (whereTurn == Direction.right)
                inHorizontal = 1;
            else if (whereTurn == Direction.left)
                inHorizontal = -1;
            if (whereTurn == Direction.up)
                inVertical = -1;
            else if (whereTurn == Direction.down)
                inVertical = 1;
        }
        private static void MakeMove()
        {
            int makeInVertical = 0, makeInHorizontal = 0;
            ClearPoint(bodySnake.Last.Value);  // Delete end of snake
            bodySnake.RemoveLast();
            SetMoveForHeadSnake(ref makeInVertical, ref makeInHorizontal);
            Point point = new Point();
            point.Y = bodySnake.First.Value.Y + makeInVertical;
            point.X = bodySnake.First.Value.X + makeInHorizontal;

            bodySnake.AddFirst(point);   // Add head's snake
            DrawPoint(point);
        }
        public static bool MoveSnake()
        {
            bool moveOK = true;
            // Checking if traffic is possible
            if ((whereTurn == Direction.right &&
                bodySnake.First.Value.X >= Board.maxColumn - 2) ||
                (whereTurn == Direction.left &&
                bodySnake.First.Value.X <= Board.minColumn + 1) ||
                (whereTurn == Direction.up &&
                bodySnake.First.Value.Y <= Board.minRow + 1) ||
                (whereTurn == Direction.down &&
                bodySnake.First.Value.Y >= Board.maxRow - 1))
            {
                moveOK = false;    // It has exceeded the range of the game board
            }
            else
            {
                MakeMove();
            }
            return moveOK;
        }
        private static void SetMoveForTail(ref int inVertical, ref int inHorizontal)
        {
            SetMoveForHeadSnake(ref inVertical, ref inHorizontal);
            inHorizontal = inHorizontal * (-1);  // On the contrary than for the head
            inVertical = inVertical * (-1);      // On the contrary than for the head
        }
        public static void SnakeElongation()
        {
            int makeInVertical = 0, makeInHorizontal = 0;
            Point point = new Point();
            SetMoveForTail(ref makeInVertical, ref makeInHorizontal);
            point.Y = bodySnake.Last.Value.Y + makeInVertical;
            point.X = bodySnake.Last.Value.X + makeInHorizontal;
            bodySnake.AddLast(point);
            DrawPoint(point);
        }
        public static bool IsItHere(Point prizePoint)
        {
            bool result = false;
            foreach (Point snakePoint in bodySnake)
            {
                if (snakePoint.X == prizePoint.X && 
                    snakePoint.Y == prizePoint.Y)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        internal static bool DidSnakeEat()
        {
            // Will check if the head (First) is in collision with any of the other points of the snake
            bool result = false;
            bool ifFirstPoint = true;
            foreach (Point point in bodySnake)
            {
                if (!ifFirstPoint)
                {
                    if (bodySnake.First.Value.X == point.X &&
                        bodySnake.First.Value.Y == point.Y)
                    {
                        result = true;
                        break;
                    }
                }
                ifFirstPoint = false;
            }
            return result;
        }
    }
}

