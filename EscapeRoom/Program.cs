
using System.Security.Cryptography;

namespace EscapeRoom
{
    internal class Program
    {
        public static int input;

        static void Main()
        {
            int keyX;
            int keyY;

            //Hier wird 10x10 der Buchstabe "W" erzeugt.
            char[,] Map = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 || i == 9 || j == 0 || j == 9)
                        Map[i, j] = 'W';
                    else
                    {
                        Map[i, j] = ' ';
                    }
                }
            }

            //Hier wird ein Player 'P' und ein Key 'K' zufällig innerhalb der Wände generiert.
            Random RNG = new Random();
            int playerX = RNG.Next(1, 9);
            int playerY = RNG.Next(1, 9);
            char m_key = 'K';
            char m_player = 'P';
            Map[playerX, playerY] = m_player;
            do
            {
                keyY = RNG.Next(1, 9);
                keyX = RNG.Next(1, 9);
                Map[keyX, keyY] = m_key;
            } while (Map[playerX, playerY] == Map[keyX, keyY]);

            // Hier wird eine Door 'D' an einer zufälligen Stelle entlang der Wände erzeugt, ausgenommen der Ecken.
            char m_door = 'D';
            int randomWall = RNG.Next(1, 5);
            switch (randomWall)
            {
                case 1:
                    Map[RNG.Next(1, 9), 0] = m_door;
                    break;

                case 2:
                    Map[9, RNG.Next(1, 9)] = m_door;
                    break;

                case 3:
                    Map[RNG.Next(1, 9), 9] = m_door;
                    break;

                case 4:
                    Map[0, RNG.Next(1, 9)] = m_door;
                    break;
            }

            // Hier wird das Array in die Konsole ausgegeben.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < 10; j++)
                {
                    Console.Write(Map[i, j]);
                }
            }
        }
    }
}

