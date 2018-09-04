namespace Core.Util
{
    using System;

    /// <summary>
    /// 线程安全的单例工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonUtil<T> where T : new()
    {
        /// <summary>
        /// 延迟加载
        /// </summary>
        private static Lazy<T> _instance;

        private static readonly object sync = new object();

        private SingletonUtil()
        {
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new Lazy<T>();
                        }
                    }
                }
                return _instance.Value;
            }
        }
    }
}