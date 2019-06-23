public interface Armazenavel
{
    bool getEstacavel();
    uint getID();
    ushort getTipo();
    string getImagem();
    T getItem<T>();
}



