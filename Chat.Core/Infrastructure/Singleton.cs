using System;

namespace Chat.Core.Infrastructure
{
    public abstract class Singleton<T> where T : class
    {
        #region Static Fields and Constants

        private static Lazy<T> _instance;
        private static readonly object Lock = new object();

        #endregion

        #region Properties

        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance.Value ?? (_instance = Activator.CreateInstance<Lazy<T>>()).Value;
                }
            }
        }

        #endregion
    }
}