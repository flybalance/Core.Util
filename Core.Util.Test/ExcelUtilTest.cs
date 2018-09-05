using System.IO;
using Xunit;

namespace Core.Util.Test
{
    public class ExcelUtilTest
    {
        [Fact]
        public void ImportExcelTest()
        {
            string filePath = @"D:/NewDeskTop/阿里巴巴Java开发手册终极版v1.3.0 - 副本.xls";
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            var result = ExcelUtil.ImportExcel(fileStream, 2);
            Assert.True(null != result && result.Count > 0);

        }
    }
}
