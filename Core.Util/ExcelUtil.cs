namespace Core.Util
{
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.SS.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Excel工具类
    /// </summary>
    public static class ExcelUtil
    {
        /// <summary>
        /// 日期格式化字符串
        /// </summary>
        private const string DATE_FORMATTER_PATTERN = "yyyy-MM-dd";

        /// <summary>
        /// 通用导入Excel工具类
        /// </summary>
        /// <param name="stream">excel文件流</param>
        /// <param name="titleRownum">起始行索引(从标题开始)</param>
        /// <returns><![CDATA[List<Dictionary<"标题", "值">>]]></returns>
        public static List<Dictionary<string, object>> ImportExcel(Stream stream, int titleRownum = 1)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (titleRownum < 0)
            {
                return list;
            }

            IWorkbook workbook = null;
            ISheet sheet = null;

            try
            {
                workbook = WorkbookFactory.Create(stream);
                sheet = workbook.GetSheetAt(0);

                int sheetCount = sheet.LastRowNum;

                IRow row = null;
                Dictionary<string, int> titleMap = new Dictionary<string, int>();

                for (int rowIndex = titleRownum - 1; rowIndex <= sheetCount; rowIndex++)
                {
                    row = sheet.GetRow(rowIndex);
                    if (null == row || row.RowNum < titleRownum - 1)
                    {
                        continue;
                    }

                    // 解析标题行
                    if (row.RowNum == titleRownum - 1)
                    {
                        List<ICell> cellList = row.Cells;

                        ParsingExcelHeader(sheet, titleMap, cellList);

                        // 标题行解析完成跳出本次循环
                        continue;
                    }

                    //若整行都为空，则跳过该行
                    bool allRowIsNull = CheckAllRowIsNull(row);
                    if (allRowIsNull)
                    {
                        continue;
                    }

                    Dictionary<string, object> map = GetRowMap(titleMap, row);
                    list.Add(map);
                }
            }
            catch (Exception)
            {
                //TODO:记录日志
            }
            finally
            {
                if (null != workbook)
                {
                    workbook.Close();
                }

                stream.Dispose();
            }

            return list;
        }

        /// <summary>
        /// 获取当前行数据
        /// </summary>
        /// <param name="titleMap">excel标题行</param>
        /// <param name="row">row对象</param>
        /// <returns></returns>
        private static Dictionary<string, object> GetRowMap(Dictionary<string, int> titleMap, IRow row)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            foreach (string key in titleMap.Keys)
            {
                int index = titleMap[key];
                object contentCellValue = GetCellValue(row.GetCell(index));
                map.Add(key, null == contentCellValue ? "" : contentCellValue.ToString());
            }

            return map;
        }

        /// <summary>
        /// 检查所有行是否为null
        /// </summary>
        /// <param name="row">row对象</param>
        /// <returns></returns>
        private static bool CheckAllRowIsNull(IRow row)
        {
            bool allRowIsNull = true;
            List<ICell> validCellList = row.Cells;

            foreach (ICell cell in validCellList)
            {
                object cellValue = GetCellValue(cell);
                if (null != cellValue)
                {
                    allRowIsNull = false;
                    break;
                }
            }

            return allRowIsNull;
        }

        /// <summary>
        /// 解析excel标题行
        /// </summary>
        /// <param name="sheet">sheet对象</param>
        /// <param name="titleMap">标题行集合</param>
        /// <param name="cellList">单元格集合</param>
        private static void ParsingExcelHeader(ISheet sheet, Dictionary<string, int> titleMap, List<ICell> cellList)
        {
            int sheetMergeCount = sheet.NumMergedRegions;
            object cellValue = null;
            int index = 0;

            foreach (ICell cellItem in cellList)
            {
                if (sheetMergeCount > 0)
                {
                    for (int i = 0; i < sheetMergeCount; i++)
                    {
                        CellRangeAddress range = sheet.GetMergedRegion(i);
                        int firstColumn = range.FirstColumn;
                        int lastColumn = range.LastColumn;
                        int firstRow = range.FirstRow;
                        int lastRow = range.LastRow;

                        if (cellItem.RowIndex == firstRow
                            && cellItem.RowIndex == lastRow
                            && cellItem.ColumnIndex >= firstColumn
                            && cellItem.ColumnIndex >= lastColumn)
                        {
                            for (int j = firstColumn; j <= lastColumn; j++)
                            {
                                index = j;
                                cellValue = GetCellValue(sheet.GetRow(firstRow + 1).GetCell(j));
                                titleMap.Add(null == cellValue ? "" : cellValue.ToString(), index);
                            }
                        }
                    }
                }
                else
                {
                    cellValue = GetCellValue(cellItem);
                    titleMap.Add(null == cellValue ? "" : cellValue.ToString(), index);
                }

                index++;
            }
        }

        /// <summary>
        /// 获取单元格值
        /// </summary>
        /// <param name="cell">cell对象</param>
        /// <returns></returns>
        private static object GetCellValue(ICell cell)
        {
            if (cell == null || (cell.CellType == CellType.String
                    && string.IsNullOrWhiteSpace(cell.StringCellValue)))
            {
                return null;
            }

            CellType cellType = cell.CellType;

            switch (cellType)
            {
                case CellType.Blank:
                    return null;

                case CellType.Boolean:
                    return cell.BooleanCellValue;

                case CellType.Error:
                    return cell.ErrorCellValue;

                case CellType.Formula:
                    return cell.NumericCellValue;

                case CellType.Numeric:
                    // 区分日期格式类型
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                    {
                        DateTime date = cell.DateCellValue;
                        return date.ToString(DATE_FORMATTER_PATTERN);
                    }
                    else
                    {
                        cell.SetCellType(CellType.String);
                        return cell.StringCellValue;
                    }
                case CellType.String:
                    return cell.StringCellValue;

                default:
                    return null;
            }
        }
    }
}