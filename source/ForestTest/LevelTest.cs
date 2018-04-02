using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using Forest;

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
    }
}
