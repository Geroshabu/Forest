using System;

namespace Forest
{
    public class GameGeneratorFactory : IGameGeneratorFactory
    {
        /// <summary>
        /// 引数に合ったIGameGeneratorを作る
        /// </summary>
        /// <param name="generateMode">現在指定されている組み合わせ方法</param>
        /// <returns>指定された組み合わせ方法のGenerator</returns>
        /// <exception cref="ArgumentException">引数のgenerateModeに不適切なものが入っていた場合</exception>
        public IGameGenerator Create(GenerateMode generateMode)
        {
            switch (generateMode)
            {
                case GenerateMode.Random:
                    return new RandomGenerator();
                case GenerateMode.RandomByGender:
                    return new RandomByGenderGenerator();
                case GenerateMode.RandomByLebel:
                    return new RandomByLevelGenerator();
                case GenerateMode.FewMatchPriority:
                    return new FewMatchPriorityGenerator();

                default:
                    throw new ArgumentException("generateModeに適切なものが入っていません");
            }
        }
    }
}
