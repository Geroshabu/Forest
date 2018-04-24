using System;
using Forest;
using Xunit;

namespace ForestTest
{
    public class GenderTest
    {
        /// <summary>
        /// ToStringメソッドのテスト
        /// </summary>
        [Theory(DisplayName = "ToString()のテスト")]
        [InlineData(0, "男")]
        [InlineData(1, "女")]
        [Trait("分類", "正常系")]
        public void ToStringTest(int genderNum, string expectedText)
        {
            Gender gender = new Gender { GenderNum = genderNum };
            Assert.Equal(expectedText, gender.ToString());
        }

        [Fact(DisplayName = "Equalsのテスト（等しいとき）")]
        public void EqualsGenderTest1()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 1 };

            Assert.True(gender1.Equals(gender2));
        }

        [Fact(DisplayName = "Equalsのテスト（異なるとき）")]
        public void EqualsGenderTest2()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 2 };

            Assert.False(gender1.Equals(gender2));
        }

        [Fact(DisplayName = "Equalsのテスト（nullのとき）")]
        public void EqualsGenderTest3()
        {
            var gender1 = new Gender { GenderNum = 1 };

            Assert.False(gender1.Equals(null));
        }

        [Fact(DisplayName = "Equalsのテスト（等しいとき）")]
        public void EqualsObjectTest1()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 1 };

            Assert.True(gender1.Equals((object)gender2));
        }

        [Fact(DisplayName = "Equalsのテスト（異なるとき）")]
        public void EqualsObjectTest2()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 2 };

            Assert.False(gender1.Equals((object)gender2));
        }

        [Fact(DisplayName = "Equalsのテスト（nullのとき）")]
        public void EqualsObjectTest3()
        {
            var gender1 = new Gender { GenderNum = 1 };

            Assert.False(gender1.Equals((object)null));
        }

        [Fact(DisplayName = "Equalsのテスト（異なる型のとき）")]
        public void EqualsObjectTest4()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var other1 = new Object();

            Assert.False(gender1.Equals(other1));
        }


        [Fact(DisplayName = "==のテスト（等しいとき）")]
        public void OperatorTest01()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 1 };

            Assert.True(gender1 == gender2);
        }

        [Fact(DisplayName = "==のテスト（異なるとき）")]
        public void OperatorTest02()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 2 };

            Assert.False(gender1 == gender2);
        }

        [Fact(DisplayName = "==のテスト（nullのとき）")]
        public void OperatorTest03()
        {
            var gender1 = new Gender { GenderNum = 1 };

            Assert.False(gender1 == null);
        }

        [Fact(DisplayName = "==のテスト（nullのとき）")]
        public void OperatorTest04()
        {
            var gender1 = new Gender { GenderNum = 1 };

            Assert.False(null == gender1);
        }

        [Fact(DisplayName = "==のテスト（nullのとき）")]
        public void OparatorTest05()
        {
            Assert.True((Gender)null == null);
        }

        [Fact(DisplayName = "!=のテスト（等しいとき）")]
        public void OperatorTest06()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 1 };

            Assert.False(gender1 != gender2);
        }

        [Fact(DisplayName = "!=のテスト（異なるとき）")]
        public void OperatorTest07()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = new Gender { GenderNum = 2 };

            Assert.True(gender1 != gender2);
        }

        [Fact(DisplayName = "!=のテスト（nullのとき）")]
        public void OperatorTest08()
        {
            var gender1 = new Gender { GenderNum = 1 };

            Assert.True(gender1 != null);
        }

        [Fact(DisplayName = "!=のテスト（nullのとき）")]
        public void OperatorTest09()
        {
            var gender1 = new Gender { GenderNum = 1 };

            Assert.True(null != gender1);
        }

        [Fact(DisplayName = "!=のテスト（nullのとき）")]
        public void OparatorTest10()
        {
            Assert.False((Gender)null != null);
        }

        [Fact(DisplayName = "GetHashCode()のテスト")]
        public void GetHashCodeTest()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var gender2 = gender1;

            Assert.True(gender1 == gender2);
        }

        [Fact(DisplayName = "CompareTo()のテスト（nullのとき）")]
        public void CompareToTest01()
        {
            var gender1 = new Gender { GenderNum = 1 };
            var expected = 1;
            var actual = gender1.CompareTo(null);
            Assert.Equal(expected,actual);
        }

        [Fact(DisplayName = "CompareTo()のテスト（異なるとき）")]
        public void CompareToTest02()
        {
            var gender1 = new Gender { GenderNum = 0 };
            var gender2 = new Gender { GenderNum = 1 };
            var expected = -1;
            var actual = gender1.CompareTo(gender2);
            Assert.Equal(expected, actual);
        }

    }
}
