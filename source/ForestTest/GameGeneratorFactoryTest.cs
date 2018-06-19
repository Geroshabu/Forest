using Forest;
using System;
using Xunit;
namespace ForestTest
{
    public class GameGeneratorFactoryTest
    {
        IGameGeneratorFactory gameGeneratorFactory;

        public GameGeneratorFactoryTest()
        {
            gameGeneratorFactory = new GameGeneratorFactory();
        }

        [Theory(DisplayName = "適切なインスタンスが返っているかを確認するテスト")]
        [InlineData(GenerateMode.Random,typeof(RandomGenerator))]
        [InlineData(GenerateMode.RandomByGender, typeof(RandomByGenderGenerator))]
        [InlineData(GenerateMode.RandomByLebel, typeof(RandomByLevelGenerator))]
        [InlineData(GenerateMode.FewMatchPriority, typeof(FewMatchPriorityGenerator))]
        [Trait("分類", "正常系")]
        public void CreateTest(GenerateMode generateMode,Type expectedGeneratorType)
        {
            Type actualGenerator = gameGeneratorFactory.Create(generateMode).GetType();
            Assert.Equal(expectedGeneratorType, actualGenerator);
        }
    }
}
