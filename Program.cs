using System;
using System.Threading;

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

        // pozycja NPC
        static int npcX = 5;
        static int npcY = 5;

        // pozycja przedmiotu
        static int itemX = 15;
        static int itemY = 15;

        // czy gracz podnisol przedmiot
        static bool hasItem = false;


        static bool[,] obstacles = new bool[width, height];

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // ręczne dodanie przeszkód
            AddObstacles();

            while (true)
            {
                // render planszy
                DrawBoard();

                // input ruchu
                HandleInput();

                // ruch NPC
                MoveNPC();

                // sprawdź czy NPC jest blisko gracza
                CheckNPCProximity();

                // sprawdź czy gracz podniósł przedmiot
                CheckItemPickup();
            }
        }

        static void AddObstacles()
        {

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
                    else if (x == npcX && y == npcY)
                    {
                        Console.Write('@'); // NPC
                    }
                    else if (x == itemX && y == itemY && !hasItem)
                    {
                        Console.Write('*'); // przedmiot
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

            // wyświetl informacje o inwentarzu
            Console.SetCursorPosition(0, height);
            Console.Write("Inwentarz: ");
            if (hasItem)
            {
                Console.Write("Przedmiot");
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

        static void MoveNPC()
        {
            // npc ruch
            Random rnd = new Random();
            int direction = rnd.Next(0, 4);

            int newNPCX = npcX;
            int newNPCY = npcY;

            switch (direction)
            {
                case 0: // gora
                    if (npcY > 0 && !obstacles[npcX, npcY - 1]) newNPCY--;
                    break;
                case 1: // dol
                    if (npcY < height - 1 && !obstacles[npcX, npcY + 1]) newNPCY++;
                    break;
                case 2: // lewo
                    if (npcX > 0 && !obstacles[npcX - 1, npcY]) newNPCX--;
                    break;
                case 3: // prawo
                    if (npcX < width - 1 && !obstacles[npcX + 1, npcY]) newNPCX++;
                    break;
            }

            // aktualizacja pozycji nmpc
            npcX = newNPCX;
            npcY = newNPCY;
        }

        static void CheckNPCProximity()
        {
            // sprawdzanie czy NPC jest blisko
            if (Math.Abs(playerX - npcX) <= 1 && Math.Abs(playerY - npcY) <= 1)
            {
                // npc jest blisko
                Console.SetCursorPosition(Console.WindowWidth / 2 - 3, Console.WindowHeight / 2);
                Console.Write("NPC: Witaj!");

                // delay textu
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                }
            }
        }

        static void CheckItemPickup()
        {
            // sprawdzanie podnoszenia itemu
            if (playerX == itemX && playerY == itemY && !hasItem)
            {
                hasItem = true;
                // usuń przedmiot z planszy
                itemX = -1;
                itemY = -1;
            }
        }
    }
}
