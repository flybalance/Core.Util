namespace Core.Util.Test
{
    using System;
    using Xunit;

    public class DateUtilTest
    {
        [Fact]
        public void ParseTest()
        {
            string dateStr = "2018-11-05";
            DateTime dt = DateUtil.Parse(dateStr);

            DateTime dateTime = new DateTime(2018, 11, 5);

            Assert.Equal(dt, dateTime);
        }

        [Fact]
        public void FormatterDateTest()
        {
            DateTime dateTime = new DateTime(2018, 11, 5);
            string dateStr = DateUtil.FormatterDate(dateTime);

            string datestr2 = "2018-11-05";

            Assert.Equal(datestr2, dateStr);
        }

        [Fact]
        public void ToMillisecondTest()
        {
            long dateLong = DateTime.Now.ToMillisecond();

            Assert.True(dateLong > 0);
        }
    }
}
