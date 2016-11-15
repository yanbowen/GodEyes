using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{
    /// <summary>
    /// QQ上下线记录列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ProcessingQQLoginLogoutList<T>:ArrayList
    {
        private static ProcessingQQLoginLogoutList<T> instanceQQ;
        private static object _lock = new object();

        public static ProcessingQQLoginLogoutList<T> GetInstance()
        {
            if (instanceQQ == null)
            {
                GC.Collect(); //强制进行资源释放
                lock (_lock)
                {
                    if (instanceQQ == null)
                    {
                        instanceQQ = new ProcessingQQLoginLogoutList<T>();
                    }
                }
            }
            return instanceQQ;
        }
    }
}
