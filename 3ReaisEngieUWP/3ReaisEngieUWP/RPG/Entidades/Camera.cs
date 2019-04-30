
namespace _3ReaisEngine.Entidades
{
   public class Camera:Core.Entidade
    {
        public Core.Entidade Seek = null;
        public Core.Vector2 delta;
        public Core.Vector2 last;
        public Core.Vector2 drawOffset;

        public Camera()
        {
            drawOffset = new Core.Vector2(0, 0);
            delta = new Core.Vector2(0, 0);
            last = new Core.Vector2(0,0);
        }

        public void setSeek(Core.Entidade seek)
        {
            Seek = seek;
            last.x = seek.EntPos.x;
            last.y = Seek.EntPos.y;

        }

        public override void Update()
        {
            if (Seek != null)
            {
                delta.x = Seek.EntPos.x - last.x;
                delta.y = Seek.EntPos.y - last.y;
             
                drawOffset.x += delta.x;
                drawOffset.y += delta.y;
                last.x = Seek.EntPos.x;
                last.y = Seek.EntPos.y;
            }
           
        }
    }
}
