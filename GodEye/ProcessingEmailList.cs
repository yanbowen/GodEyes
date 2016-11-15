using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{
    /// <summary>
    /// 邮件内容列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ProcessingEmailList<T>:ArrayList
    {
        private static ProcessingEmailList<T> instanceEmail;
        private static object _lock = new object();

        private ProcessingEmailList()
        {

        }
        public static ProcessingEmailList<T> GetInstance()
        {
            if (instanceEmail == null)
            {
                GC.Collect();
                lock (_lock)
                {
                    if (instanceEmail == null)
                    {
                        instanceEmail = new ProcessingEmailList<T>();
                    }
                }
            }
            return instanceEmail;
        }
    }
}
