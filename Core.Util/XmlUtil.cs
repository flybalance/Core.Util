namespace Core.Util
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// Xml工具类
    /// </summary>
    public static class XmlUtil
    {
        /// <summary>
        /// 保存xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="t"></param>
        public static void SaveXml<T>(string path, T t)
        {
            StreamWriter writer = new StreamWriter(path);

            new XmlSerializer(typeof(T)).Serialize(writer, t);

            writer.Close();
        }

        /// <summary>
        ///  将文件转换成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public static T LoadXml<T>(string file)
        {
            StreamReader reader = new StreamReader(file);

            object obj = new XmlSerializer(typeof(T)).Deserialize(reader);

            reader.Close();

            return (T)obj;
        }

        /// <summary>
        /// 将XML转换成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T FromXml<T>(string xml)
        {
            StringReader reader = new StringReader(xml);

            object obj = new XmlSerializer(typeof(T)).Deserialize(reader);

            reader.Close();

            return (T)obj;
        }

        /// <summary>
        /// 将实体对象转换为xml字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToXml<T>(T t)
        {
            StringBuilder builder = new StringBuilder();
            StringWriter writer = new StringWriter(builder);

            new XmlSerializer(typeof(T)).Serialize(writer, t);

            writer.Close();

            return builder.ToString();
        }

        /// <summary>
        /// 将xml转换为实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlPath">xml路径</param>
        /// <returns></returns>
        public static T LoadXmlFile<T>(string xmlPath) where T : class
        {
            if (!File.Exists(xmlPath))
            {
                return null;
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(xmlPath);
                return (T)(xmlSerializer.Deserialize(streamReader));
            }
            catch
            {
                return null;
            }
            finally
            {
                if (null != streamReader)
                {
                    streamReader.Close();
                }
            }
        }
    }
}