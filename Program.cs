using System;

namespace ConsoleGame
{
    class Program
    {
        // plansza
        const int width = 40;
        const int height = 20;

        // pozycja gracza
        static int playerX = 20;
        static int playerY = 10;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                // render planszy
                DrawBoard();

                // input ruchu
                HandleInput();
            }
        }

        static void DrawBoard()
        {
            Console.Clear();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.Write('X'); // gracz
                    }
                    else
                    {
                        Console.Write('.'); // podloga
                    }
                }
                Console.WriteLine();
            }
        }

        static void HandleInput()
        {
            // readkey
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (playerY > 0) playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    if (playerY < height - 1) playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (playerX > 0) playerX--;
                    break;
                case ConsoleKey.RightArrow:
                    if (playerX < width - 1) playerX++;
                    break;
            }
        }
    }
}
