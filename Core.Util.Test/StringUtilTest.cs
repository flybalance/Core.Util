namespace Core.Util.Test
{
    using Xunit;

    public class StringUtilTest
    {
        [Fact]
        public void IsOutOfAllowTest()
        {
            string testStr = "abc";

            bool result = testStr.IsOutOfLength(50);

            Assert.False(result);
        }

        [Fact]
        public void IsNumericTest()
        {
            bool result = "-59.0s8".IsNumeric();

            Assert.False(result);
        }
    }
}