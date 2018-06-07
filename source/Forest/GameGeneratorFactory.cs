namespace Forest
{
    class GameGeneratorFactory : IGameGeneratorFactory
    {
        /// <summary>
        /// 引数に合ったIGameGeneratorを作る
        /// </summary>
        /// <param name="generateMode">現在指定されている組み合わせ方法</param>
        /// <returns>指定された組み合わせ方法のGenerator</returns>
        public IGameGenerator Create(int generateMode)
        {
            switch (generateMode)
            {
                case 0:
                    return new RandomGenerator();

                default: //デフォルトは完全ランダム
                    return new RandomGenerator();
            }
        }
    }
}
