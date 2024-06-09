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

        // tablica
        static bool[,] obstacles = new bool[width, height];

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // ręczne dodanie przeszkod
            AddObstacles();

            while (true)
            {
                // render planszy
                DrawBoard();

                // input ruchu
                HandleInput();
            }
        }

        static void AddObstacles()
        {
            // reczne dodanie przeszkód

            obstacles[10, 5] = true;
            obstacles[15, 8] = true;
            obstacles[5, 15] = true;
            obstacles[30, 12] = true;
            obstacles[25, 18] = true;
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
                    else if (obstacles[x, y])
                    {
                        Console.Write('|'); // przeszkoda
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
                    if (playerY > 0 && !obstacles[playerX, playerY - 1]) playerY--;
                    break;
                case ConsoleKey.DownArrow:
                    if (playerY < height - 1 && !obstacles[playerX, playerY + 1]) playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (playerX > 0 && !obstacles[playerX - 1, playerY]) playerX--;
                    break;
                case ConsoleKey.RightArrow:
                    if (playerX < width - 1 && !obstacles[playerX + 1, playerY]) playerX++;
                    break;
            }
        }
    }
}
