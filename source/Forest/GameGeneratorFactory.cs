using static Forest.MainWindow;

namespace Forest
{
    class GameGeneratorFactory : IGameGeneratorFactory
    {
        /// <summary>
        /// 引数に合ったIGameGeneratorを作る
        /// </summary>
        /// <param name="generateMode">現在指定されている組み合わせ方法</param>
        /// <returns>指定された組み合わせ方法のGenerator</returns>
        public IGameGenerator Create(GenerateMode generateMode)
        {
            switch (generateMode)
            {
                case GenerateMode.random:
                    return new RandomGenerator();
                case GenerateMode.randomByGender:
                    return new RandomByGenderGenerator();
                case GenerateMode.randomByLebel:
                //    return new RandomByLevelGenerator();
                case GenerateMode.fewMatchPriority:
                //    return new RandomGenerator();

                default: //デフォルトは完全ランダム
                    return new RandomGenerator();
            }
        }
    }
}
