using System;
using Xunit;
using Forest;

namespace ForestTest
{
    public class GenderTest
    {
        /// <summary>
        /// ToStringメソッドのテスト
        /// </summary>
        [Theory]
        [InlineData(0, "男")]
        [InlineData(1, "女")]
        public void ToStringTest(int genderNum, string expectedText)
        {
            Gender gender = new Gender { GenderNum = genderNum };
            Assert.Equal(expectedText, gender.ToString());
        }
    }
}
