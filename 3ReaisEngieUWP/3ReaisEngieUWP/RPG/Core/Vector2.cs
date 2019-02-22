namespace _3ReaisEngine.RPG.Core
{
    /*
     * Representa uma posição no plano
     */

    public class Vector2
    {
        public float x, y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        static Vector2 zero = new Vector2(0, 0);
        public static Vector2 Zero { get { return zero; } }


        public override string ToString()
        {
            return "[" + x + "," + y + "]";
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator -(Vector2 a, float b)
        {
            return new Vector2(a.x - b, a.y - b);
        }
        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(a.x *-1, a.y *-1);
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator +(Vector2 a, float b)
        {
            return new Vector2(a.x + b, a.y + b);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static bool operator == (Vector2 a, Vector2 b)
        {
            return (a.x == b.x && a.y == b.y);
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !(a.x == b.x && a.y == b.y);
        }
    }
}
