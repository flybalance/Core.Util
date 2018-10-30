namespace Core.Util
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Http请求工具类
    /// </summary>
    public static class HttpUtil
    {
        /// <summary>
        /// HttpPost请求
        /// </summary>
        /// <param name="requestUrl">请求url</param>
        /// <param name="json">请求参数</param>
        /// <returns></returns>
        public static string HttpPostRequest(string requestUrl, string json)
        {
            // json格式请求数据
            string requestData = json;

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            myRequest.Timeout = 5000;
            // 请求类型
            myRequest.Method = "POST";
            // utf-8编码
            byte[] buf = Encoding.GetEncoding("UTF-8").GetBytes(requestData);
            myRequest.ContentLength = buf.Length;

            // 指定为json否则会出错
            myRequest.ContentType = "application/json;charset=UTF-8";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            HttpWebResponse myResponse = null;
            Stream newStream = null;
            StreamReader reader = null;
            string ReqResult = string.Empty;
            try
            {
                newStream = myRequest.GetRequestStream();
                newStream.Write(buf, 0, buf.Length);
                // 获得接口返回值
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                ReqResult = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                // 此处的异常请根据实际业务来处理
                throw ex;
            }
            finally
            {
                if (null != reader)
                {
                    reader.Dispose();
                }
                if (null != newStream)
                {
                    newStream.Dispose();
                }
                if (null != myResponse)
                {
                    myResponse.Dispose();
                }
            }

            return ReqResult;
        }

        /// <summary>
        /// HttpGet请求
        /// </summary>
        /// <param name="requestUrl">请求url</param>
        /// <param name="requestParamStr">请求参数</param>
        /// <returns></returns>
        public static string HttpGetRequest(string requestUrl, string requestParamStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl + (requestParamStr == "" ? "" : "?") + requestParamStr);
            request.Method = "GET";
            request.ContentType = "application/json;charset=UTF-8";

            HttpWebResponse myResponse = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            string retString = string.Empty;
            try
            {

                myResponse = (HttpWebResponse)request.GetResponse();
                myResponseStream = myResponse.GetResponseStream();
                myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
                retString = myStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (null != myStreamReader)
                {
                    myStreamReader.Dispose();
                }
                if (null != myResponseStream)
                {
                    myResponseStream.Dispose();
                }
                if (null != myResponse)
                {
                    myResponse.Dispose();
                }
            }

            return retString;
        }
    }
}
