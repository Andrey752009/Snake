using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        public struct PointDig
        {
            public int x;
            public int y;
        }
        struct Point
        {
            public int x;
            public int y;
            

        }
        public static PointDig pd;
        public static int dx, dy;
        public static int NewX, NewY;
        public static int Dig;
        public static int SnakeLength=3;
        static void Main(string[] args)
        {
            
            Console.SetBufferSize(80, 25);
            ConsoleKeyInfo cki;
            Console.WriteLine(Console.KeyAvailable);
            Point[] Snake = new Point[Console.BufferWidth * Console.BufferHeight];
           
            Console.Clear();
            InitSnake(Snake);
            PlaceNumber(Snake);
            Console.CursorVisible = false;
            bool flag = false;
            while (true)
            {
                while (Console.KeyAvailable == false)
                {
                    NewX = Snake[SnakeLength - 1].x + dx;
                    NewY = Snake[SnakeLength - 1].y + dy;

                    if (!IsSnake(NewX, NewY, Snake))
                    {
                        for (int i = 0; i < SnakeLength - 1; i++)
                            Snake[i] = Snake[i + 1];
                        Snake[SnakeLength - 1].x = NewX;
                        Snake[SnakeLength - 1].y = NewY;
                    }
                    else { flag = true; break; }

                    Thread.Sleep(150);
                    Console.Clear();
                    ShowSnake(Snake);
                    Console.SetCursorPosition(pd.x, pd.y);
                    Console.Write(Dig);
                    if (pd.x==NewX&&pd.y==NewY) 
                    {
                        SnakeLength = SnakeLength+Dig;
                        Snake[SnakeLength - 1].x = NewX;
                        Snake[SnakeLength - 1].y = NewY;
                        for (int i = 0; i < SnakeLength - 1; i++)
                            Snake[i] = Snake[i + 1];
                        PlaceNumber(Snake);
                    }
                }
                if (flag) break;
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.RightArrow: dx = 1; dy = 0; break;
                    case ConsoleKey.LeftArrow: dx = -1; dy = 0; break;
                    case ConsoleKey.UpArrow: dx = 0; dy = -1; break;
                    case ConsoleKey.DownArrow: dx = 0; dy = 1; break;
                }
            }
            Console.WriteLine("Конец игры");
            Console.ReadLine();
        }
        static void InitSnake(Point[] Snake)
        {
            dx = 1; dy = 0;
            for (int i = 0; i < SnakeLength; i++)
            {
                Snake[i].x = i; Snake[i].y = 0;
                Console.CursorLeft = Snake[i].x;
                Console.CursorTop = Snake[i].y;
                Console.Write("x");
            }
        }
        static void ShowSnake(Point [] Snake)
        {
            for (int i = 0; i < SnakeLength; i++)
            {
                Console.CursorLeft = Snake[i].x;
                Console.CursorTop = Snake[i].y;
                Console.Write("x");
            }

        }
        static void PlaceNumber(Point []Snake)
        {
            Random r=new Random();
            do
            {
                pd.y = r.Next(Console.BufferHeight);
                pd.x = r.Next(Console.BufferWidth);
            } while (IsSnake(pd.x,pd.y,Snake));
            Dig = r.Next(1, 10);
            Console.SetCursorPosition(pd.x, pd.y);
            Console.Write(Dig);
        }

        static bool IsSnake(int x, int y, Point[] Snake)
        {
      
            for (int i = 0; i < SnakeLength; i++)
            {
                if (Snake[i].x == x && Snake[i].y==y) return true;
            }
                return false;
        }
    }
}
