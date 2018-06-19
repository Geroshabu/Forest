namespace Forest
{
    /// <summary>
    /// GameGeneratorのFactoryのインターフェース
    /// </summary>
    public interface IGameGeneratorFactory
    {
        /// <summary>
        /// 引数に合ったIGameGeneratorを作る
        /// </summary>
        /// <param name="generateMode">現在指定されている組み合わせ方法</param>
        /// <returns>指定された組み合わせ方法のGenerator</returns>
        IGameGenerator Create(GenerateMode generateMode);
    }
}
