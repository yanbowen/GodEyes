using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{   
    /// <summary>
    /// 员工行为单例列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ProcessingBehaveList<T> : ArrayList
    {
        private static ProcessingBehaveList<T> instanceBehave;
        private static object _lock = new object();

        private ProcessingBehaveList()
        {

        }

        public static ProcessingBehaveList<T> GetInstance()
        {
            if(instanceBehave == null)
            {
                GC.Collect();
                lock(_lock)
                {
                    if (instanceBehave == null)
                    {
                        instanceBehave = new ProcessingBehaveList<T>();
                    }
                }
            }
            return instanceBehave;
        }
    }
}
