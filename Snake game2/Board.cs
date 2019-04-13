using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game2
{
    class Board
    {
        private int height;
        private int width;
        private readonly char[,] board;
        private readonly GameStatus gameStatus = new GameStatus();
        private RandomGenerator random = new RandomGenerator();

        public Board(int height, int width)
        {
            board = new char[height, width];
            InitializeBoard(height,width);
        }

        private void InitializeBoard(int height, int width)
        {
            this.height = height;
            this.width = width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == 0 || i == height - 1) && j > 0 && j < height - 1)
                    {
                        board[i, j] = '-';
                    }
                    else if ((j == 0 || j == height - 1) && i > 0 && i < height - 1)
                    {
                        board[i, j] = '|';
                    }
                    else if (i > 0 && j > 0 && i < height - 1 && j < height - 1)
                    {
                        board[i, j] = '.';
                    }

                }
            }

            board[1, 1] = '@';

            RandomFruitsPosition();
            RandomObstaclePosition();
            Draw();
        }

        public bool IsObstacle(int xPosition, int yPosition)
        {
            String obstacle = "|-#@";

            if(obstacle.Contains(board[xPosition,yPosition]))
            {
                return true;
            }

            return false;
        }

        public bool IsPoint(int xPosition, int yPosition)
        {
            if(board[xPosition,yPosition] == '*')
            {
                IncrementScore();
                return true;
            }

            return false;
        }

        private void IncrementScore()
        {
            gameStatus.Score++;
        }

        public void AddSnakeTail(int xPosition, int yPosition) => board[xPosition, yPosition] = '@';

        public void RemoveSnakeTail(int xPosition, int yPosition) => board[xPosition, yPosition] = '.';

        private void AddItemToBoard(int xPosition, int yPosition, char item)
        {
            board[xPosition, yPosition] = item;
        }

        private void AddItem(String item)
        {
            if(!item.Equals("Fruit") && !item.Equals("Obstacle"))
            {
                throw new ArgumentException("Your argument is invalid");
            }

            int xPosition, yPosition, numbersOfItems;

            numbersOfItems = random.RandomNumbersOfItems(this.height, this.width);

            while (numbersOfItems > 0)
            {
                xPosition = random.RandomCoordonateX(this.height);
                yPosition = random.RandomCoordonateY(this.width);

                if (item.Equals("Fruit"))
                {
                    AddFruit(xPosition, yPosition);
                }

                if (item.Equals("Obstacle"))
                {
                    AddObstacle(xPosition, yPosition);
                }

                numbersOfItems--;
            }
        }

        private void RandomFruitsPosition()
        {
            AddItem("Fruit");
        }

        private void RandomObstaclePosition()
        {
            AddItem("Obstacle");
        }

        private void AddFruit(int xPosition, int yPosition) => AddItemToBoard(xPosition, yPosition, '*');

        private void AddObstacle(int xPosition, int yPosition) => AddItemToBoard(xPosition, yPosition, '#');

        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.Write('\n');
            }

            Console.WriteLine($"Your score is : {gameStatus.Score}");
        }
    }
}
