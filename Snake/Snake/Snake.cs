using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        // position of the snake head
        private int x;
        public int X
        {
            get { return x; }
        }
        private int y;
        public int Y
        {
            get { return y; }
        }
        private readonly Game game;

        private List<BodyPart> bodyParts = new List<BodyPart>();
        public List<BodyPart> BodyParts
        {
            get { return bodyParts; }
        }

        private SnakeDirection currentDirection = SnakeDirection.Right;
        public SnakeDirection Direction
        {
            set
            {
                if (bodyParts.Count < 2)
                {
                    currentDirection = value;
                }
                else if (currentDirection != value)
                {
                    switch(value)
                    {
                        case SnakeDirection.Up:
                            if (currentDirection != SnakeDirection.Down)
                                currentDirection = SnakeDirection.Up;
                            break;
                        case SnakeDirection.Down:
                            if (currentDirection != SnakeDirection.Up)
                                currentDirection = SnakeDirection.Down;
                            break;
                        case SnakeDirection.Left:
                            if (currentDirection != SnakeDirection.Right)
                                currentDirection = SnakeDirection.Left;
                            break;
                        case SnakeDirection.Right:
                            if (currentDirection != SnakeDirection.Left)
                                currentDirection = SnakeDirection.Right;
                            break;
                    }
                }
            }
        }

        public Snake(int x, int y, Game game)
        {
            this.x = x;
            this.y = y;
            this.game = game;
        }

        public void UpdatePosition()
        {
            if (IsEatMouse())
            {
                bodyParts.Add(new BodyPart(X, Y));
                game.EatMouse();
            }
            else
            {
                if (bodyParts.Count != 0)
                {
                    bodyParts.Add(new BodyPart(X, Y));
                    bodyParts.RemoveAt(0);
                }
            }

            switch (currentDirection)
            {
                case SnakeDirection.Up:
                    x--;
                    break;
                case SnakeDirection.Down:
                    x++;
                    break;
                case SnakeDirection.Right:
                    y++;
                    break;
                case SnakeDirection.Left:
                    y--;
                    break;
            }

            if (IsOutBorders() || IsEatItself())
            {
                game.FinishGame();
            }
        }

        private bool IsOutBorders()
        {
            if (X == 1 || X == game.Width - 1 || Y == 1 || Y == game.Width - 1)
                return true;
            return false;
        }

        private bool IsEatItself()
        {
            foreach(BodyPart part in bodyParts)
            {
                if (x == part.x && y == part.y)
                    return true;
            }

            return false;
        }

        private bool IsEatMouse()
        {
            if (X == game.CurrentMouse.X && Y == game.CurrentMouse.Y)
                return true;

            return false;
        }

        public struct BodyPart
        {
            // position of snake's body part
            public int x;
            public int y;

            public BodyPart(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }
    }
}
