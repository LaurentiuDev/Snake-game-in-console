using System;

namespace Snake_game2
{
    class RandomGenerator
    {
        private readonly Random random = new Random();

        public RandomGenerator()
        {

        }

        public int RandomNumbersOfItems(int height, int width)
        {
            return random.Next(1, height * width / 8);
        }

        public int RandomCoordonateX(int height)
        {
            return random.Next(2, height - 2);
        }

        public int RandomCoordonateY(int width)
        {
            return random.Next(1, width - 2);
        }
    }
}
