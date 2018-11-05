using Xunit;

namespace Core.Util.Test
{
    public class StringUtilTest
    {
        [Fact]
        public void IsOutOfAllowTest()
        {
            string testStr = "abc";

            bool result = testStr.IsOutOfAllow(50);

            Assert.False(result);
        }
    }
}
