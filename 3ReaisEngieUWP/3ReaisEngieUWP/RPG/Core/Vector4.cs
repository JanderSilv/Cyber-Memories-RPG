namespace _3ReaisEngine.Core
{
    public class Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }

        static Vector4 zero = new Vector4(0, 0, 0, 0);
        public static Vector4 Zero { get { return zero; } }


        public override string ToString()
        {
            return "[" + x + "," + y + "," + z + "," + w + "]";
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public static Vector4 operator -(Vector4 a, float b)
        {
            return new Vector4(a.x - b, a.y - b, a.z - b, a.w - b);
        }
        public static Vector4 operator -(Vector4 a)
        {
            return new Vector4(a.x * -1, a.y * -1, a.z * -1, a.w * -1);
        }
        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static Vector4 operator +(Vector4 a, float b)
        {
            return new Vector4(a.x + b, a.y + b, a.z + b, a.w + b);
        }
        public static Vector4 operator *(Vector4 a, float b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return (a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w);
        }
        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !(a == b);
        }
    }
}
