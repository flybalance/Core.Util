namespace Core.Util.Test
{
    using System;
    using Xunit;

    public class ExcelUtilTest
    {
        [Fact]
        public void ImportExcelTest()
        {
            //string filePath = @"D:/NewDeskTop/阿里巴巴Java开发手册终极版v1.3.0 - 副本.xls";
            //FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            //var result = ExcelUtil.ImportExcel(fileStream, 2);
            //Assert.True(null != result && result.Count > 0);

            var result = string.IsNullOrWhiteSpace("");

            Console.WriteLine(result);
        }
    }
}