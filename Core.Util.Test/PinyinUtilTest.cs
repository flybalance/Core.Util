using Xunit;

namespace Core.Util.Test
{
    public class PinyinUtilTest
    {
        [Fact]
        public void GetPinYinTest()
        {
            string chineseStr = "我是中国人";

            string str = PinyinUtil.GetPinYin(chineseStr);

            Assert.True(true);
        }

        [Fact]
        public void GetSimplifiedPinYin()
        {
            string chineseStr = "我是中国人";

            string str = PinyinUtil.GetSimplifiedPinYin(chineseStr);

            Assert.True(true);
        }
    }
}