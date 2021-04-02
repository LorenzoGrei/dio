using System.Collections.Generic;

namespace Dio.Animes.Interfaces
{
    public interface IRepositorio<T>
    {     
    
        List<T> lista();
        T RetonrnaPorId(int id);
        void Insere(T entidade);
        void Exclui (int id);
        void Atualiza(int id, T entidade); 
        int ProximoId();        
       
    }
}