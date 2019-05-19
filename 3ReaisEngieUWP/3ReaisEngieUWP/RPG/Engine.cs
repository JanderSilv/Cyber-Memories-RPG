#define LOG

using _3ReaisEngine.Core;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace _3ReaisEngine
{
    public static class Engine
    {

        public static void save<T>(T x, string path)
        {
            string output = JsonConvert.SerializeObject(x);
           
            File.WriteAllText(path, output);

            
        }
        public static T load<T>(string path)
        {
           
            string esse = File.ReadAllText(path);
            T deserializedGeneric = JsonConvert.DeserializeObject<T>(esse);

            return deserializedGeneric;
        }

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
