
namespace _3ReaisEngine.Entidades
{
   public class Camera:Core.Entidade
    {
        public Core.Entidade Seek = null;
        public Core.Vector2 delta;
        public Core.Vector2 last;
        
        public Camera()
        {
            delta = new Core.Vector2(0, 0);
            last = new Core.Vector2();
        }

        public void setSeek(Core.Entidade seek)
        {
            Seek = seek;
            last.x = seek.EntPos.x;
            last.y = seek.EntPos.y;
        }
        public override void Update()
        {
           
            delta.x = 0;
            delta.y = 0;

        }
    }
}
