#define LOG

using System.Diagnostics;

namespace _3ReaisEngine
{
    public static class Engine
    {
        public static void Debug(object obj)
        {
#if LOG
            System.Diagnostics.Debug.WriteLine(obj);
#endif
        }
    }

}
