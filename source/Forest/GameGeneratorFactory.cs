namespace Forest
{
    class GameGeneratorFactory : IGameGeneratorFactory
    {
        public IGameGenerator Create(int generateMode)
        {
            switch (generateMode)
            {
                case 0:
                    return new RandomGenerator();

                default:
                    return new RandomGenerator();
            }
        }
    }
}
