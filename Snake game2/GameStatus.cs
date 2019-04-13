using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game2
{
    class GameStatus
    {
        private bool gameOver;
        private int score;
        public GameStatus()
        {
            gameOver = false;
        }

        public bool GameOver
        {
            get { return this.gameOver; }
            set { this.gameOver = value; }
        }

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

    }
}
