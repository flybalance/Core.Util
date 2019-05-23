namespace Core.Util.Test
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class DictionaryUtilTest
    {
        [Fact]
        public void AddRangeOverrideTest()
        {
            Dictionary<string, string> targetDic = new Dictionary<string, string>();
            targetDic.Add("1", "a");
            targetDic.Add("2", "aa");
            targetDic.Add("3", "aaa");

            Dictionary<string, string> testDic = new Dictionary<string, string>();
            testDic.Add("1", "bbb");

            targetDic.AddRangeOverride(testDic);

            Assert.Equal("bbb", targetDic["1"]);
        }
    }
}
