using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{
    class ProcessingAllDataList<T>:ArrayList
    {
        private static ProcessingAllDataList<T> instanceAllData;
        private static object _lock = new object();

        public static ProcessingAllDataList<T> GetInstance()
        {
            if (instanceAllData == null)
            {
                GC.Collect(); //强制进行资源释放
                lock (_lock)
                {
                    if (instanceAllData == null)
                    {
                        instanceAllData = new ProcessingAllDataList<T>();
                    }
                }
            }
            return instanceAllData;
        }
    }
}
