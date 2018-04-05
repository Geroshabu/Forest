using System;
using Forest;
using Xunit;

namespace ForestTest
{

    public class LevelTest
    {
        [Theory]
        [InlineData(0, "初級者")]
        [InlineData(1, "中級者")]
        [InlineData(2, "上級者")]
        public void ToStringTest(int levelNum, string expectedText)
        {
            Level level = new Level { LevelNum = levelNum };
            Assert.Equal(expectedText, level.ToString());
        }


        [Fact]
        public void EqualsLevelTest1()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.True(level1.Equals(level2));
        }

        [Fact]
        public void EqualsLevelTest2()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.False(level1.Equals(level2));
        }

        [Fact]
        public void EqualsLevelTest3()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(level1.Equals(null));
        }

        [Fact]
        public void EqualsObjectTest1()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.True(level1.Equals((object)level2));
        }

        [Fact]
        public void EqualsObjectTest2()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.False(level1.Equals((object)level2));
        }

        [Fact]
        public void EqualsObjectTest3()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(level1.Equals((object)null));
        }

        [Fact]
        public void EqualsObjectTest4()
        {
            var level1 = new Level { LevelNum = 1 };
            var other1 = new Object();

            Assert.False(level1.Equals(other1));
        }


        [Fact]
        public void OperatorTest01()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.True(level1 == level2);
        }

        [Fact]
        public void OperatorTest02()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.False(level1 == level2);
        }

        [Fact]
        public void OperatorTest03()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(level1 == null);
        }

        [Fact]
        public void OperatorTest04()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.False(null == level1);
        }

        [Fact]
        public void OparatorTest05()
        {
            Assert.True((Level)null == null);
        }


        [Fact]
        public void OperatorTest06()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 1 };

            Assert.False(level1 != level2);
        }

        [Fact]
        public void OperatorTest07()
        {
            var level1 = new Level { LevelNum = 1 };
            var level2 = new Level { LevelNum = 2 };

            Assert.True(level1 != level2);
        }

        [Fact]
        public void OperatorTest08()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.True(level1 != null);
        }

        [Fact]
        public void OperatorTest09()
        {
            var level1 = new Level { LevelNum = 1 };

            Assert.True(null != level1);
        }

        [Fact]
        public void OparatorTest10()
        {
            Assert.False((Level)null != null);
        }


    }
}
