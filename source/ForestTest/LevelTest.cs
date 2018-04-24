using System;
using Forest;
using Xunit;

namespace ForestTest
{

    public class LevelTest
    {
        [Theory(DisplayName = "ToString()のテスト")]
        [InlineData(0, "初級者")]
        [InlineData(1, "中級者")]
        [InlineData(2, "上級者")]
        public void ToStringTest(int levelNum, string expectedText)
        {
            Level level = new Level { LevelNum = levelNum };
            Assert.Equal(expectedText, level.ToString());
        }

        [Fact(DisplayName = "Equalsのテスト（等しいとき）")]
        public void EqualsLevelTest1()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.True(level1.Equals(level2));
        }

        [Fact(DisplayName = "Equalsのテスト（等しくないとき）")]
        public void EqualsLevelTest2()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.False(level1.Equals(level2));
        }

        [Fact(DisplayName = "Equalsのテスト（引数がnullのとき）")]
        public void EqualsLevelTest3()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(level1.Equals(null));
        }

        [Fact(DisplayName = "Equalsのテスト（等しいとき）")]
        public void EqualsObjectTest1()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.True(level1.Equals((object)level2));
        }

        [Fact(DisplayName = "Equalsのテスト（等しくないとき）")]
        public void EqualsObjectTest2()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.False(level1.Equals((object)level2));
        }

        [Fact(DisplayName = "Equalsのテスト（引数がnullのとき）")]
        public void EqualsObjectTest3()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(level1.Equals((object)null));
        }

        [Fact(DisplayName = "Equalsのテスト（引数が異なる型のとき）")]
        public void EqualsObjectTest4()
        {
            var level1 = new Level { LevelNum = 1 };
            var other1 = new Object();

            Assert.False(level1.Equals(other1));
        }

        [Fact(DisplayName = "==のテスト（等しいとき）")]
        public void OperatorTest01()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.True(level1 == level2);
        }

        [Fact(DisplayName = "==のテスト（異なるとき）")]
        public void OperatorTest02()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.False(level1 == level2);
        }

        [Fact(DisplayName = "==のテスト（nullとき）")]
        public void OperatorTest03()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(level1 == null);
        }

        [Fact(DisplayName = "==のテスト（nullのとき）")]
        public void OperatorTest04()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(null == level1);
        }

        [Fact(DisplayName = "==のテスト（両方ともnullのとき）")]
        public void OparatorTest05()
        {
            Assert.True((Level)null == null);
        }

        [Fact(DisplayName = "!=のテスト（等しいとき）")]
        public void OperatorTest06()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.False(level1 != level2);
        }

        [Fact(DisplayName = "!=のテスト（異なるとき）")]
        public void OperatorTest07()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.True(level1 != level2);
        }

        [Fact(DisplayName = "!=のテスト（nullのとき）")]
        public void OperatorTest08()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.True(level1 != null);
        }

        [Fact(DisplayName = "!=のテスト（nullのとき）")]
        public void OperatorTest09()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.True(null != level1);
        }

        [Fact(DisplayName = "!=のテスト（両方ともnullのとき）")]
        public void OparatorTest10()
        {
            Assert.False((Level)null != null);
        }

        [Fact(DisplayName = "GetHashCode()のテスト")]
        public void GetHashCodeTest()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = level1;

            Assert.True(level1 == level2);
        }

        [Fact(DisplayName = "CompareTo()のテスト（nullのとき）")]
        public void CompareToTest01()
        {
            var level1 = new Level { LevelNum = 1 };
            var expected = 1;
            var actual = level1.CompareTo(null);
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "CompareTo()のテスト（異なるとき）")]
        public void CompareToTest02()
        {
            var level1 = new Level { LevelNum = 0 };
            var level2 = new Level { LevelNum = 2 };
            var expected = -1;
            var actual = level1.CompareTo(level2);
            Assert.Equal(expected, actual);
        }


    }
}
