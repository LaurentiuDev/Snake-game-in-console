using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game2
{
    class Snake
    {
        private int x;
        private int y;
        private Board board;
        private GameStatus gameStatus;
        private List<Tuple<int, int>> tail = new List<Tuple<int, int>>();

        public Snake(Board board)
        {
            this.board = board;
            this.x = 1;
            this.y = 1;
            tail.Add(new Tuple<int, int>(this.x, this.y));
            board.AddSnakeTail(this.x, this.y);
            //gameStatus = new GameStatus();
        }

        public bool GetGameStatus()
        {
            if(gameStatus.IsGameOver())
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

            int nextX, nextY, height, width;

            height = board.Height;
            width = board.Width;

            nextX = this.x + dx[direction];
            nextY = this.y + dy[direction];

            if(nextX < 0 || nextY < 0)
            {
                return;
            }

            if (board.IsObstacle(nextX, nextY))
            {
                gameStatus.GameOver(true);
            }

            Move(nextX, nextY);
           
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
            this.x = nextX;
            this.y = nextY;

            board.AddSnakeTail(nextX, nextY);

            tail.Add(new Tuple<int, int>(nextX, nextY));

            if(!board.IsPoint(tail.First().Item1, tail.First().Item2))
            {
                board.RemoveSnakeTail(tail.First().Item1, tail.First().Item2);

                tail.Remove(tail.First());
            }

            board.Draw();
            
        }

        public int GetX { get => x; set => x = value; }

        public int GetY { get => y; set => y = value; }
    }
}
