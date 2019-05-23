namespace Core.Util.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    /// <summary>
    /// Decimal数据类型扩展方法
    /// </summary>
    public class DecimalUtilTest
    {
        [Fact]
        public void InterceptToStringTest()
        {
            decimal dnum = 65.8303M;
            string result = dnum.InterceptToString(6);

            Assert.Equal("65.830300", result);
        }

        [Fact]
        public void InterceptToDecimalTest()
        {
            decimal dnum = 65.8303M;
            decimal result = dnum.InterceptToDecimal(6);

            Assert.True(dnum == result);
        }
    }
}
