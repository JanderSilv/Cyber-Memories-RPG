#define LOG

using _3ReaisEngine.Core;
using System;
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
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (float)System.Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        }
        public static Vector2 DistanceVec(Vector2 a,Vector2 b)
        {
            return new Vector2(Math.Abs(a.x - b.x), Math.Abs(a.y - b.y));
        }
        public static void MoveTo(Entidade e,Vector2 v)
        {

        }
    }

}
