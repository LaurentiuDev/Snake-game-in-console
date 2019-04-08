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
        private char[,] board;

        public Board(int height, int width)
        {
            this.height = height;
            this.width = width;
            board = new char[height,width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i == 0 || i == height - 1) && j > 0 && j < height - 1) {
                        board[i, j] = '-';
                    } else if ((j == 0 || j == height - 1) && i > 0 && i < height - 1)
                    {
                        board[i, j] = '|';
                    }else if(i > 0 && j > 0 && i < height - 1 && j < height -1)
                    {
                        board[i, j] = '.';
                    }
                   
                }
            }

        }

        public bool IsObstacle(int xPosition, int yPosition)
        {
            String obstacle = "|-#@";
            if(board[xPosition,yPosition].ToString().Contains(obstacle))
            {
                return true;
            }

            return false;
        }

        public bool IsPoint(int xPosition, int yPosition)
        {
            if(board[xPosition,yPosition] == '*')
            {
                return true;
            }

            return false;
        }

        public void AddSnakeTail(int xPosition, int yPosition)
        {
            board[xPosition, yPosition] = '@';
        }

        public void RemoveSnakeTail(int xPosition, int yPosition)
        {
            board[xPosition, yPosition] = '.';
        }

        public void AddFruit(int xPosition, int yPosition)
        {
            if(IsInvalidPosition(xPosition, yPosition))
            {
                return;
            }

            board[xPosition,yPosition] = '*';
        }

        public void AddObstacle(int xPosition, int yPosition)
        {
            if (IsInvalidPosition(xPosition, yPosition))
            {
                return;
            }

            board[xPosition, yPosition] = '#';
        }

        private bool IsInvalidPosition(int xPosition, int yPosition)
        {
            if (xPosition <= 0 || xPosition >= this.height || yPosition <= 0 || yPosition >= this.width || board[xPosition, yPosition] == '*')
            {
                return true;
            }

            return false;
        }

        public void Draw()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.Write('\n');
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

       

        
    }
}
