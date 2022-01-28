using System.Collections.Generic;

namespace cad_series.Desenhos.interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Remove(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}