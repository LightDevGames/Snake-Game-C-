using System;

namespace Snake
{
    public class Program
    {
        public static void Main(String[] args)
        {
            ShowPreview();
            System.Threading.Thread.Sleep(3000);
            CreateGame();
        }

        private static void ShowPreview()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("      ПЗПИ-18-4");
            Console.WriteLine();
            Console.WriteLine("Bilenko Entertainment");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("Press W A S D to move");
            Console.WriteLine();
            Console.WriteLine("   Press I/O to");
            Console.WriteLine(" boost/slow the snake");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("All rights reserved.");
        }

        private static void CreateGame()
        {
            Game game = new Game(21);
            Snake snake = new Snake(10, 2, game);

            DateTime lastMeasuredTime = DateTime.Now;
            double desiredFrameTime = 1000.0 / 10;

            //Main game looop
            while (game.IsAlive)
            {
                while (Console.KeyAvailable)
                {
                    //Process input for each key
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            snake.Direction = SnakeDirection.Up;
                            break;
                        case ConsoleKey.S:
                            snake.Direction = SnakeDirection.Down;
                            break;
                        case ConsoleKey.D:
                            snake.Direction = SnakeDirection.Right;
                            break;
                        case ConsoleKey.A:
                            snake.Direction = SnakeDirection.Left;
                            break;

                        case ConsoleKey.I:
                            desiredFrameTime -= 10;
                            break;
                        case ConsoleKey.O:
                            desiredFrameTime += 10;
                            break;
                    }
                }
                if ((DateTime.Now - lastMeasuredTime).TotalMilliseconds >= desiredFrameTime)
                {
                    ClearCurrentConsoleLine();
                    
                    snake.UpdatePosition();
                    game.UpdateFrame(snake);


                    lastMeasuredTime = DateTime.Now;
                }
            }

            Console.WriteLine("GameOver!");
            Console.WriteLine("  Press r to restart.");
            Console.WriteLine(" Press any key to exit."); 
            if(Console.ReadLine().Equals("r"))
            {
                CreateGame();
            }
        }

        private static void ClearCurrentConsoleLine()
        {
            while (Console.CursorTop > 0)
                Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

    }
}