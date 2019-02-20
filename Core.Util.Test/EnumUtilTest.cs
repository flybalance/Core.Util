using System.ComponentModel;
using Xunit;

namespace Core.Util.Test
{
    public class EnumUtilTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            string description = Fruit.apple.GetDescription();

            string target = "苹果";

            Assert.Equal(target, description);
        }
    }

    public enum Fruit
    {
        [Description("香蕉")]
        banana = 1,

        [Description("橘子")]
        orange = 2,

        [Description("苹果")]
        apple = 3
    }
}