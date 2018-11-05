namespace Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// 文件操作帮助类
    /// </summary>
    public static class FileUtil
    {
        private static List<FileInfo> lst = new List<FileInfo>();

        /// <summary>
        /// 获得目录下所有文件或指定文件类型文件(包含所有子文件夹)
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="extName">扩展名可以多个 例如 *.mp3 *.wma *.rm</param>
        /// <returns><![CDATA[List<FileInfo>]]></returns>
        public static List<FileInfo> GetFile(string path, string extName)
        {
            try
            {
                // 文件夹列表
                string[] dir = Directory.GetDirectories(path);
                DirectoryInfo fdir = new DirectoryInfo(path);
                // 获取指定后缀的文件列表
                FileInfo[] file = fdir.GetFiles(extName);
                // 当前目录文件或文件夹不为空
                if (file.Length > 0)
                {
                    // 显示当前目录所有文件
                    lst.AddRange(file);
                }

                if (dir.Length > 0)
                {
                    foreach (string d in dir)
                    {
                        // 递归子目录
                        GetFile(d, extName);
                    }
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}