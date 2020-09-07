using System;

namespace Snake
{
    public class Game
    {
        private readonly char[,] gameArray;

        private readonly int width;
        public int Width
        { get { return width; } }

        private Random random = new Random();
        private Mouse currentMouse;
        public Mouse CurrentMouse
        {
            get { return currentMouse; }
        }

        private bool isAlive = true;
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        private int score = 0;

        public Game(int width)
        {
            this.width = width;
            gameArray = new char[width, width];

            GenerateMouse();
        }

        public void EatMouse()
        {
            score++;
            GenerateMouse();
        }

        public void FinishGame()
        {
            isAlive = false;
        }

        private void GenerateMouse()
        {
            currentMouse = new Mouse(random.Next(2, Width - 2), random.Next(2, Width - 2));
        }

        public void UpdateFrame(Snake snake)
        {

            ClearGameFrame();

            gameArray[CurrentMouse.X, currentMouse.Y] = 'E';

            // body parts
            for (int i = 0; i < snake.BodyParts.Count; i++)
            {
                gameArray[snake.BodyParts[i].x, snake.BodyParts[i].y] = '0';
            }

            // head
            gameArray[snake.X, snake.Y] = '3';

            Console.WriteLine("     Snake game!     ");

            PrintGameFrame();

            Console.WriteLine("Current score: " + score);
        }

        private void ClearGameFrame()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == width - 1 || j == 0 || j == width - 1)
                        gameArray[i, j] = '#';
                    else
                        gameArray[i, j] = ' ';
                }
            }
        }

        private void PrintGameFrame()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(gameArray[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
