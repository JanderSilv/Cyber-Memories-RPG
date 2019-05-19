
namespace _3ReaisEngine.Core
{
    /*
     * Gambiarra que faz o sistema funcionar
     */

    public interface IComponente
    {
        int getRegister();
        void Init();
        void setEntidade(Entidade e);
    }
}
