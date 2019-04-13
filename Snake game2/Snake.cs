using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game2
{
    class Snake
    {
        private int X;
        private int Y;
        private readonly Board board;
        private readonly GameStatus gameStatus;
        private readonly List<Tuple<int, int>> tail = new List<Tuple<int, int>>();


        public Snake(Board board)
        {
            this.board = board;
            this.X = 1;
            this.Y = 1;
            tail.Add(new Tuple<int, int>(this.X, this.Y));
            board.AddSnakeTail(this.X, this.Y);
            gameStatus = new GameStatus();
        }

        public bool IsGameOver()
        {
            if(gameStatus.GameOver)
                return true;

            return false;
        }

        public void Direction(char directionInput)
        {
            int direction = GetDirection(directionInput);
            
            if(direction == 5)
            {
                return;
            }

            /**E V S  N**/
            //int[] dx = { 0, 0, 1, -1 };
            //int[] dy = { 1, -1, 0, 0 };

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            int nextX, nextY;

            nextX = this.X + dx[direction];
            nextY = this.Y + dy[direction];

            if (board.IsObstacle(nextX, nextY))
            {
                gameStatus.GameOver = true;
            }
            else
            {
                Move(nextX, nextY);
            }

        }

        

        public int GetDirection(char direction)
        {
            switch (direction)
            {
                case 'W':
                case 'w':
                    return 0;
                case 'D':
                case 'd':
                    return 1;
                    
                case 'S':
                case 's':
                    return 2;
                   
                case 'A':
                case 'a':
                    return 3;
                   
                default:
                    return 5;
                    
            }
        }

        public void Move(int nextX,int nextY)
        {
            this.X = nextX;
            this.Y = nextY;

            tail.Add(new Tuple<int, int>(nextX, nextY));

            if(!board.IsPoint(nextX, nextY))
            {
                board.RemoveSnakeTail(tail.First().Item1, tail.First().Item2);

                tail.Remove(tail.First());
            } 

            board.AddSnakeTail(nextX, nextY);

            board.Draw();
            
        }

    }
}
