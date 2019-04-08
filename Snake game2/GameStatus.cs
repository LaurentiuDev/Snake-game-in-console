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
        public GameStatus()
        {
            gameOver = false;
        }

        public void GameOver(bool die)
        {
            if (die)
            {
                this.gameOver = true;
            }

            this.gameOver = false;
        }

        public bool IsGameOver()
        {
            if(this.gameOver == true)
                return true;

            return false;
        }
    }
}
