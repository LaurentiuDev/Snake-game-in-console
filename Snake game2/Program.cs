﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_game2
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10, 10);
            Snake snake = new Snake(board);
         
            while (!snake.IsGameOver())
            {
                char direction;

                direction = Console.ReadKey().KeyChar;

                snake.Direction( direction);
                
            }

            if (snake.IsGameOver())
            {
                Console.WriteLine();
                Console.WriteLine("GAME OVER !");
            }
        }
    }
}
